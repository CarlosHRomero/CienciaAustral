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


namespace Ciencia
{
    public partial class frmComplemento : Form
    {
        private string _constr;

        public String ConStr
        {
            get
            {
                return _constr;
            }
            set
            {
                _constr = value;
            }

        }

        public string  EstablecerCadenaDeConexion(string nombreArchivo)
        {
            
            ConStr = "Provider=Microsoft.ACE.OLEDB.12.0; " +
                            "Data Source= " + nombreArchivo;
            return ConStr;
        }
        private string Titulo = "HUA - Ciencia - frmComplemento ";
        //public string Where { get; set; }
        int _moduloId { get; set; }
        string _where { get; set; }

        public string nombreArchivo { get; set; }
        public frmComplemento()
        {
            InitializeComponent();
            Text = Titulo;

        }

        void InicializarDesplegables()
        {
            ListasDesplegables obj = new ListasDesplegables();
            //cboTabla.DataSource = obj.ListaTablaLocal(_localConStr, false);
            //cboTabla.DataSource = obj.ListaTablaLocal(ConStr, false);
            cboTabla.DataSource = obj.ListaTabla(_moduloId, false, true);

            cboTabla.ValueMember = "TablaId";
            cboTabla.DisplayMember = "NombreTabla";

            cboSel.DataSource = obj.ListaNoSi();
            cboSel.DataSource = obj.ListaNoSi();
            cboSel.DataSource = obj.ListaNoSi();

            cboTabla.SelectedIndex = -1;

            cboSolapa.DataSource = obj.ListaSolapa(_moduloId);
        }

        //List<CienciaEquiv> _lista;
        private void frmComplemento_Load(object sender, EventArgs e)
        {
            InicializarDesplegables();
            txtArchivo.Text = nombreArchivo;
            //InicializarDataGridView();
            //ComplementoBuss cb = new ComplementoBuss();
            //_lista = cb.ListaCampos(moduloId);
            
            CargarGrid();
            //LocalSelectInfManager infMan = new LocalSelectInfManager(constr);
            //string where = infMan.ObtenerInfSeleccion().where;

        }

        public Boolean CargarInfSelector()
        {
            try
            {
                SelectorBuss selB = new SelectorBuss();
                selB.constr = _constr;
                SelecInf inf = selB.ObtenerSelectInf();
                if (inf == null)
                {
                    Mensajes.msgFormatoNoValido("CargarInfSelector");
                    return false;
                }
                if (inf != null)
                {
                    _moduloId = inf.moduloId;
                    _where = inf.where;
                }
                moduloBuss mb = new moduloBuss();
                if (_moduloId != 0)
                    lblModulo.Text = mb.ObtenerDatosModulo(_moduloId).Nombre;
                return true;
            }
            catch(Exception ex)
            {
                Mensajes.msgError(ex);
                return false;
            }
        }



        void InicializarDataGridView()
        {
            try
            {
                //LocalCarEqB eqB = new LocalCarEqB();
                //dataGridView1.AutoGenerateColumns = false;
                //_lista = eqB.ListaTodosCampos(_localConStr);
                //dataGridView1.DataSource = _lista;
                DataGridViewColumn dataGridViewColumn = dataGridView1.Columns["TablaId"];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.DataPropertyName = "TablaId";
                var gridViewColumn = dataGridView1.Columns["Campo"];
                if (gridViewColumn != null)
                    gridViewColumn.DataPropertyName = "CampoEquivalente";
                var viewColumn = dataGridView1.Columns["Sel"];
                if (viewColumn != null) viewColumn.DataPropertyName = "Seleccion";
                var column = dataGridView1.Columns["Tipo"];
                if (column != null)
                    column.DataPropertyName = "TipoDeDato";
                var o = dataGridView1.Columns["Sel"];
                if (o != null) o.DataPropertyName = "Seleccion";
                var dataGridViewColumn1 = dataGridView1.Columns["Filtro"];
                if (dataGridViewColumn1 != null)
                    dataGridViewColumn1.DataPropertyName = "Filtro";
                var gridViewColumn1 = dataGridView1.Columns["EquivId"];
                if (gridViewColumn1 != null)
                    gridViewColumn1.DataPropertyName = "EquivId";
            }
            catch (Exception ex)
            {
                Mensajes.msgError(ex);
                throw;
            }
        }


        private void CargarGrid()
        {
            try
            {
                dataGridView1.Rows.Clear();
                ComplementoBuss cB = new ComplementoBuss();
                TablaEquivBuss teB = new TablaEquivBuss();
                List<CienciaEquiv> lista = cB.ListaCampos(_moduloId, _constr);

                if (lista == null)
                    return;


                foreach (var obj in lista)
                {
                    string tabla = teB.TablaPorCodigo(obj.TablaId, false);
                    if (!string.IsNullOrEmpty(obj.TipoDeDato))
                        dataGridView1.Rows.Add(obj.TablaId, obj.CampoEquivalente,obj.Solapa, obj.Seleccion, obj.TipoDeDato, obj.ValoresACero, obj.Filtro, obj.ValoresACeroStr, tabla, obj.EquivId, obj.VerValor);
                }
            }
            catch(Exception ex)
            {
                Mensajes.msgError(ex);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                frmUniverso f = new frmUniverso();
                //LocalCarEqB eqB = new LocalCarEqB();

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                //moduloBuss modB = new moduloBuss();
                //string tablasAgregadas = modB.ObtnerTablasAgregadas(_moduloId);

                //f.Tablas = tablasAgregadas;
                //f.Campo = row.Cells["Campo"].Value.ToString().Trim();
                f.EquivId = Convert.ToInt32(row.Cells["EquivId"].Value);
                f.TipoDeDato = row.Cells["Tipo"].Value.ToString().Trim();
                if (row.Cells["Filtro"].Value != null)
                {
                    if (row.Cells["Filtro"].Value.ToString().Length > 0)
                        f.Filtro = string.Format("{0}", row.Cells["Filtro"].Value.ToString().Trim());
                }
                if (row.Cells["ValoresACero"].Value != null)
                    if (row.Cells["ValoresACero"].Value.ToString().Length > 0)
                        f.ValoresACero = string.Format("{0}", row.Cells["ValoresACero"].Value.ToString().Trim());
                f.VerValor = Convert.ToBoolean(row.Cells["VerValor"].Value);
                f.where = _where;
                f.constr = ConStr;
                f.moduloId = _moduloId;
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK)
                {
                    if (f.TipoDeDato.ToLower().Trim() == "tabla")
                    {
                        row.Cells["Valor"].Value = f.ValoresACero;
                        row.Cells["ValoresACero"].Value = f.ValoresACero;
                        row.Cells["VerValor"].Value = f.VerValor;
                    }
                    row.Cells["Sel"].Value = true;
                    if (dataGridView1.CurrentRow != null)
                        dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[1];
                }
            }
        }

        ComplementoBuss cb = new ComplementoBuss();
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<clsCampo> campos = new List<clsCampo>();
                clsCampo campo = new clsCampo();
                //campo.tabla = "Ciencia_car_ingr_sel";
                //campo.nombre = "Ingr_pac_id";
                //campos.Add(campo);
                //campo = new clsCampo
                //{
                //    tabla = "Ciencia_car_ingr_sel",
                //    nombre = "Ingr_id"
                //};
                //campos.Add(campo);
                //campo = new clsCampo();
                //campo.tabla = "Ciencia_car_Ant_sel";
                //campo.nombre = "Ant_id";
                //campos.Add(campo);
                //campo = new clsCampo();
                //campo.tabla = "Ciencia_car_AntC_sel";
                //campo.nombre = "Antc_id";
                //campos.Add(campo);
                //LocalEquivB eqB = new LocalEquivB(_constr);
                

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    CienciaEquiv obj = new CienciaEquiv();
                    obj.EquivId = Convert.ToInt32(row.Cells["EquivId"].Value);
                    obj.CampoEquivalente = row.Cells["Campo"].Value.ToString();
                    obj.Seleccion = Convert.ToBoolean(row.Cells["Sel"].Value);
                    if (row.Cells["Valor"].Value != null)
                        obj.ValoresACero = row.Cells["Valor"].Value.ToString();
                    //eqB.ActualizarSelecciónCampo(obj);

                    //dataGridView1.Rows.fi
                    if (Convert.ToBoolean(row.Cells["Sel"].Value) == true)
                    {
                        campo = new clsCampo();
                        campo.EquivId = Convert.ToInt32(row.Cells["EquivId"].Value);
                        campo.nombre = row.Cells["Campo"].Value.ToString().Trim();
                        campo.tabla = row.Cells["Tabla"].Value.ToString().Trim();
                        campo.tablaId = Convert.ToInt32(row.Cells["TablaId"].Value);
                        if (row.Cells["Valor"] != null && row.Cells["ValoresACero"].Value != null)
                        {
                            string s = row.Cells["ValoresACero"].Value.ToString().Trim();
                            if (!string.IsNullOrEmpty(s) && !string.IsNullOrEmpty(row.Cells["Valor"].Value.ToString()))
                                campo.ListaValores = Cadenas.DividirCadena(s, ",");
                            campo.verValor= Convert.ToBoolean(row.Cells["VerValor"].Value);
                        }
                        campos.Add(campo);
                    }

                }
                {
                    if(campos.Count < 1)
                    {
                        Mensajes.msgErrorDebeSeleccionarCampo("btnProcesar_Click");
                        return;
                    }

                }

                cb.ActualizarCamposSeleccion(campos, _constr);
                
                if (cb.CrearTablaCiencia(ConStr, campos, _moduloId, nombreArchivo))
                {

                    MessageBox.Show("Se exportaron los datos correctamente", "Ciencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // btnExportar.Enabled = true;
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Error al exportar datos", "Ciencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Mensajes.msgError(ex);
                //throw;
            }

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSel.Text != "Si")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }
            }
            else
            {
                cboTabla.SelectedIndex = -1;
                cboSolapa.SelectedIndex = -1;
                cboSolapa.Enabled = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //if (cb.ExportarAExcel(ConStr) == false)
            //    MessageBox.Show("Error Exportando a Excel", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Cursor.Current = Cursors.Default;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmSelector f = new frmSelector();
            f.MdiParent = this.MdiParent;
            f.EstablecerCadenaDeConexion(nombreArchivo);
            Close();
            f.Show();
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmComplemento_FormClosing(object sender, FormClosingEventArgs e)
        {
            Formularios.fMenu.Show();
        }
        private void cboTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LocalCarEqB eqB = new LocalCarEqB();
            ////List<CienciaCarEquiv> lista;
            int val;
            if (cboSolapa.DataSource == null)
                return;
            cboSel.SelectedIndex = 0;
            if (cboTabla.SelectedValue == null || cboTabla.Text == "*")
            {
                if (cboSolapa.DataSource != null)
                {
                    cboSolapa.SelectedIndex = -1;
                    cboSolapa.Enabled = false;
                    FiltrarGrid(-1, "*");
                    return;
                }
            }
            if (int.TryParse(cboTabla.SelectedValue.ToString(), out val))
            {
                if (val == 0)
                {
                    cboSolapa.SelectedIndex = 0;
                    cboSolapa.Enabled = false;
                    FiltrarGrid(-1, "*");
                    return;
                }
                var obj = new ListasDesplegables();
                cboSolapa.DataSource = obj.ListaSolapaPorTabla(_moduloId, val);
                cboSolapa.Enabled = true;
                FiltrarGrid(val, "*");
            }
        }

        private void FiltrarGrid(int tablaId, string solapa)
        {
            if (tablaId == -1 && solapa == "*")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }
                return;
            }
            if (solapa == "*")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(row.Cells["TablaId"].Value) == tablaId)
                        row.Visible = true;
                    else
                    {
                        row.Visible = false;
                    }
                }
                return;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Solapa"].Value == null)
                {
                    row.Visible = false;
                    continue;
                }

                if (Convert.ToInt32(row.Cells["TablaId"].Value) == tablaId && row.Cells["Solapa"].Value.ToString() == solapa)
                    row.Visible = true;
                else
                {
                    row.Visible = false;
                }
            }
            return;

        }

        private void cboSolapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int val;
                if (cboTabla.SelectedValue == null)
                    return;
                if (int.TryParse(cboTabla.SelectedValue.ToString(), out val))
                {
                    if (val == 0)
                    {
                        cboSolapa.SelectedIndex = 0;
                        cboSolapa.Enabled = false;
                        FiltrarGrid(-1, "*");
                        return;
                    }
                }
                if (cboSolapa.SelectedValue == null || cboSolapa.SelectedIndex == 0)
                {
                    FiltrarGrid(val, "*");
                    return;
                }
                string sol = cboSolapa.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(sol))
                {
                    FiltrarGrid(val, sol);
                }
            }
            catch (Exception ex)
            {
                Mensajes.msgError("cboSolapa_SelectedIndexChanged", ex);
            }

        }
    }
}
