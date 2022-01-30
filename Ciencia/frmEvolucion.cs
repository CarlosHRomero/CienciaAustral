using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ciencia.BLL;
using Ciencia.OBJ;
using Generales;
using Ciencia.Properties;

namespace Ciencia
{
    public partial class frmEvolucion : Form
    {
        protected String _localConStr;
        private string Titulo = "HUA - Ciencia - frmEvolucion ";
        private int _moduloId;
        private string _where;
        public string EstablecerCadenaDeConexion(string nombreArchivo)
        {
            _localConStr = "Provider=Microsoft.ACE.OLEDB.12.0; " +
                            "Data Source= " + nombreArchivo;
            txtArchivo.Text = nombreArchivo;
            return _localConStr;
        }
        public frmEvolucion()
        {
            InitializeComponent();
            Text = Titulo;
            ProgressBar1.Minimum = 0;
            ProgressBar1.Maximum = 100;
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        private void CargarInfSelector()
        {
            SelectorBuss selB = new SelectorBuss();
            selB.constr = _localConStr;
            SelecInf inf = selB.ObtenerSelectInf();
            if (inf != null)
            {
                _moduloId = inf.moduloId;
                _where = inf.where;
            }
            moduloBuss mb = new moduloBuss();
            var mod = mb.ObtenerDatosModulo(_moduloId);
            if (mod != null)
                lblModulo.Text = mod.Nombre;

        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.ProgressBar1.Value = e.ProgressPercentage;
            if (e.UserState != null)
                stLabel.Text = e.UserState.ToString();
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Cursor.Current = Cursors.Default;
            //Enabled = true;
            if ((e.Cancelled == true))
            {
                MessageBox.Show("Proceso Cancelado");
            }

            else if (!(e.Error == null))
            {
                MessageBox.Show("Error: " + e.Error, "Ciencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                ProgressBar1.Value = ProgressBar1.Maximum;
                MessageBox.Show(Resources.Form1_btnProceso_Click_ProcesoTerminado, "Ciencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnExportar.Enabled = true;
            }
        }
        void InicializarDesplegables()
        {

            ListasDesplegables obj = new ListasDesplegables();
            cboTabla.DataSource = obj.ListaTabla(_moduloId, true, true);
            cboTabla.ValueMember = "TablaId";
            cboTabla.DisplayMember = "NombreTabla";
            cboSolapa.DataSource = obj.ListaSolapaEvol(_moduloId);
            //cboSolapa.DisplayMember = "Solapa";
            cboTabla.SelectedIndex = -1;

        }

        private void frmEvolucion_Load(object sender, EventArgs e)
        {
            try
            {
                CargarInfSelector();
                InicializarDataGridView();
                InicializarDesplegables();

                CargarGrid();
                Formularios.fMenu.Hide();
            }
            catch (Exception ex)
            {
                Mensajes.msgError("Load", ex);
            }
        }

        void InicializarDataGridView()
        {
            int w = dataGridView1.RowHeadersWidth;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Visible)
                    w += column.Width;
            }
            dataGridView1.Width = w + 20;
            Width = dataGridView1.Width + 20;
        }

        private void cboTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LocalEquivB eqB = new LocalEquivB(_localConStr);
            //List<CienciaCarEquiv> lista;
            int val;
            if (cboTabla.SelectedValue == null || cboTabla.SelectedIndex == 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }
                return;
            }
            if (int.TryParse(cboTabla.SelectedValue.ToString(), out val))
            {
                if (val == 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Visible = true;
                    }
                }
                //////////////////////////


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(row.Cells["TablaId"].Value) == val)
                        row.Visible = true;
                    else
                    {
                        row.Visible = false;
                    }
                }
            }

        }

        protected virtual void CargarGrid()
        {
            EvolucionBuss evol = new EvolucionBuss();
            var lista = evol.ListaCampos(_moduloId, _localConStr);

            if (lista == null)
                return;
            TablaEquivBuss eqB = new TablaEquivBuss();
            List<SelTablaEvol> selTe = null;
            foreach (var obj in lista)
            {
                string tabla = eqB.TablaPorCodigo(obj.TablaId, true);
                if (!string.IsNullOrEmpty(obj.TipoDeDato))
                {
                    if (obj.Seleccion)
                    {
                        selTe = evol.ObtenerSeleccionEvolucion(obj.EquivId, _localConStr);
                    }
                    else
                    {
                        selTe = null;
                    }

                    dataGridView1.Rows.Add(obj.TablaId, obj.CampoEquivalente, obj.Seleccion, obj.TipoDeDato, obj.ValoresACero, obj.Filtro, tabla, obj.EquivId, obj.Solapa, selTe);
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bw.IsBusy == true)
            {
                Mensajes.msgProcesoEnCurso();
                return;
            }
            if (e.ColumnIndex == 4)
            {
                CargarFuncion(e.RowIndex);
            }
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void CargarFuncion(int indiceDeFila)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[indiceDeFila];
                string TipoDeDato = row.Cells["Tipo"].Value.ToString().Trim();
                if (TipoDeDato == "Numero")
                {

                    frmDialogoEvol2 f = new frmDialogoEvol2();
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        row.Cells["Valor"].Value = null;
                        if (f.ListaFuncion.Count > 0)
                        {

                            foreach (string item in f.ListaFuncion)
                                row.Cells["Valor"].Value += item + ", ";
                            string s = row.Cells["Valor"].Value.ToString();
                            row.Cells["Valor"].Value = s.Substring(0, s.Length - 2);
                            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[1];
                            row.Cells["Sel"].Value = true;
                        }
                        dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[1];
                    }
                    else
                    {
                        row.Cells["Sel"].Value = false;
                    }

                }
                if (TipoDeDato == "NoSi")
                {
                    frmDialogoEvol1 f = new frmDialogoEvol1();
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        row.Cells["Valor"].Value = f.funcion;
                        row.Cells["Sel"].Value = true;
                        dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[1];
                    }
                    else
                    {
                        row.Cells["Sel"].Value = false;
                    }

                }
                if (TipoDeDato == "Tabla")
                {
                    EvolucionBuss eB = new EvolucionBuss();
                    frmDialogoEvol3 f = new frmDialogoEvol3();
                    f.Tabla = eB.JoinEvolucion(_moduloId, _localConStr);
                    f.Campo = row.Cells["Campo"].Value.ToString();
                    f.Filtro = row.Cells["Filtro"].Value.ToString();
                    f.moduloId = _moduloId;
                    f.TipoDeDato = TipoDeDato;
                    f.constr = _localConStr;
                    f.where = _where;
                    if (row.Cells["selEvol"].Value != null)
                    {
                        f.ListaSel = (List<SelTablaEvol>)row.Cells["selEvol"].Value;
                    }
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        if (f.ListaSel != null && f.ListaSel.Count > 0)
                        {
                            row.Cells["Sel"].Value = true;
                            row.Cells["Valor"].Value = "Tabla";
                            row.Cells["selEvol"].Value = f.ListaSel;
                        }
                        else
                        {
                            row.Cells["Sel"].Value = false;
                            row.Cells["Valor"].Value = null;
                            row.Cells["selEvol"].Value = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.msgError("cargar funcion", ex);

            }
        }
        protected BackgroundWorker bw = new BackgroundWorker();
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy == true)
            {
                Mensajes.msgProcesoEnCurso();
                return;
            }
            try
            {
                bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Mensajes.msgError(ex);
                throw;
            }

        }

        protected virtual List<clsCampo> LeerGrid()
        {
            List<clsCampo> campos = new List<clsCampo>();
            int c, i = 0;
            c = dataGridView1.Rows.Count;
            clsCampo campo;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Valor"].Value == null)
                {
                    continue;
                }
                if (Convert.ToBoolean(row.Cells["Sel"].Value) == true && !String.IsNullOrEmpty(row.Cells["Valor"].Value.ToString()))
                {

                    campo = new clsCampo();
                    campo.EquivId = Convert.ToInt32(row.Cells["EquivId"].Value);
                    campo.nombre = row.Cells["Campo"].Value.ToString().Trim();
                    campo.tabla = row.Cells["Tabla"].Value.ToString().Trim() + "_Sel";
                    campo.tablaId = Convert.ToInt32(row.Cells["TablaID"].Value);

                    if (row.Cells["selEvol"].Value == null)
                    {
                        AgregarEquvalencias(ref campo, row.Cells["Valor"].Value.ToString().Trim());
                    }
                    else if (row.Cells["selEvol"].Value.GetType() == typeof(List<SelTablaEvol>))
                    {
                        campo.selTe = (List<SelTablaEvol>)row.Cells["selEvol"].Value;
                        campo.Func = row.Cells["Valor"].Value.ToString().Trim();
                    }
                    else
                    {
                        throw new Exception("celda sel evol tiene dato no valido");
                    }
                    campos.Add(campo);
                }
                i++;
                bw.ReportProgress(10 * i / c + 1);
            }
            return campos;

        }

        protected virtual void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            
            clsCampo campo = new clsCampo();

            var campos = LeerGrid();

            EvolucionBuss evol = new EvolucionBuss();

            evol.ActualizarCamposEvolucion(campos, _localConStr);
            if (evol.ConstruirEvolucion(campos, _localConStr, _moduloId, bw))
            {

                MessageBox.Show("Se creo la tabla evolución con éxito", "Ciencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor.Current = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Error al crear la tabla", "Evolución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }

        }
        void AgregarEquvalencias(ref clsCampo campo, string equiv)
        {
            List<string> listFunc = new List<string>();

            //char[] charSeparators = new char[] { ',' };
            //valores = equival.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            if (equiv == "Máximo")
            {
                campo.Func = "MAX";
            }
            else if (equiv == "Mínimo")
            {
                campo.Func = "MIN";
            }
            else if (equiv == "Promedio")
            {
                campo.Func = "AVG";
            }
            else if (equiv == "Primera")
            {
                campo.Func = "Primera";
            }
            else if (equiv == "Ultima")
            {
                campo.Func = "Ultima";
            }
            else
                campo.Func = equiv;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == false)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = "";
                }
            }
        }

        private void cboSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSolapa.Text != "Si")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Sel"].Value))
                        row.Visible = true;
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == false)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = "";
                }
                else
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    string TipoDeDato = row.Cells["Tipo"].Value.ToString().Trim();
                    if (TipoDeDato == "NoSi")
                    {
                        if (row.Cells["Valor"].Value == null)
                            row.Cells["Valor"].Value = "Primera";
                    }
                    if (TipoDeDato.ToLower() == "numero")
                    {
                        if (row.Cells["Valor"].Value == null)
                            row.Cells["Valor"].Value = "Máximo";
                    }

                }
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);

        }

        private void cboTabla_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboTabla.SelectedValue == null || cboTabla.SelectedIndex == 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }
                return;
            }
            int val;
            if (int.TryParse(cboTabla.SelectedValue.ToString(), out val))
            {
                if (val == 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Visible = true;
                    }
                }
                ListasDesplegables obj = new ListasDesplegables();
                cboSolapa.DataSource = obj.ListaSolapaEvol(_moduloId);
                //cboSolapa.DisplayMember = "Solapa";
                //cboTabla.SelectedIndex = -1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(row.Cells["TablaId"].Value) == val)
                        row.Visible = true;
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void cboSolapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboSolapa.SelectedValue == null || cboSolapa.SelectedIndex == 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Visible = true;
                    }
                    return;
                }
                string sol = cboSolapa.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(sol))
                {
                    if (sol == "*")
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            row.Visible = true;
                        }
                    }
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Solapa"].Value == null)
                        {
                            row.Visible = false;
                            continue;
                        }

                        if (row.Cells["Solapa"].Value.ToString() == sol)
                            row.Visible = true;
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.msgError("cboSolapa_SelectedIndexChanged", ex);
            }

        }

        private void frmEvolucion_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (bw.IsBusy == true)
            {
                Mensajes.msgProcesoEnCurso();
                e.Cancel = true;
                return;
            }
            Formularios.fMenu.Show();
            // bw.CancelAsync();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            EvolucionBuss evol = new EvolucionBuss();

            if (!evol.ExportarAExcel(_moduloId, _localConStr))
            {
                MessageBox.Show("Fallo al exportar a Excel");
            }


        }
    }
}
