using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Ciencia.BLL;
using Ciencia.OBJ;
using Ciencia.Properties;
using Common;
using DrawFlat;
using Generales;


namespace Ciencia
{
    public partial class frmSelector : Form
    {
        //private string conorg = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=\\\\AMERICA\\America\\Antonio\\Cardio\\Ciencia\\Car_Ciencia_Local.mdb"; // "\\\\AMERICA\\America\\Antonio\\Cardio\\Ciencia\\Car_Ciencia_Local.accdb" ;
        private string arorg = "C:\\Sistemas\\Ciencia\\Ciencia_Local.mdb";

        private string Titulo = "ICBA - Cardiología - Ciencia - frmSelector ";
        string _localConStr;
        SelectorBuss selB = new SelectorBuss();
        private int _moduloId;
        private string _nombreArchivo;
       // private Boolean _flag;
        public string EstablecerCadenaDeConexion(string nombreArchivo)
        {
            _localConStr = "Provider=Microsoft.ACE.OLEDB.12.0; " +
                            "Data Source= " + nombreArchivo;
            _nombreArchivo = nombreArchivo;
            selB.constr = _localConStr;
            return _localConStr;
        }
        public frmSelector()
        {
            flag = false;
            InitializeComponent();
            Text = Titulo;
            ProgressBar1.Minimum = 0;
            ProgressBar1.Maximum = 100;
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            //cb.CopiandoTabla += OnCopiandoTabla; 
        }

        void OnCopiandoTabla(object sender, EventArgs e)
        {
            try
            {
                stLabel.Text = "CopiandoTabla";
            }
            catch( Exception ex)
            {
                Mensajes.msgError(ex);
            }
        }
        private void CargarDesplegables()
        {
            ListasDesplegables obj = new ListasDesplegables();
            cboTabla.ValueMember = "TablaId";
            cboTabla.DisplayMember = "NombreTabla";
           
            //cboModulo.DataSource = Enum.GetValues(typeof(Modulo));
            cboModulo.ValueMember = "ModuloId";
            cboModulo.DisplayMember = "Nombre";

            cboModulo.DataSource = obj.ListaModulo();
            cboOperador.DataSource = obj.ListaOperador();
            cboAnd.DataSource = obj.ListaAnd();
            cboModulo.SelectedIndex = -1;
        }
        //private CienciaB cb = new CienciaB();
        private int cantAnt;
        private BackgroundWorker bw = new BackgroundWorker();
        private void frmSelector_Load(object sender, EventArgs e)
        {
            Formularios.fMenu.Hide();
            CargarDesplegables();
            InicializarControles();
            flag = true;
            CargarInfSelector();
            CargarGrid();
            
            //lblDesde.Text = cb.ObtenerFechaDesde().ToShortDateString();
            //lblHasta.Text = cb.ObtenerFechaHasta().ToShortDateString();
            lblUsuario.Text = Ambiente.Usuario.User_Nombre;
            lblSelMed.Text = Where;
            txtArchivo.Text = _nombreArchivo;
        }

        private void CargarGrid()
        {
            List<clsSelector> lista = selB.ListaSeleccion();
            dataGridView1.Rows.Clear();
            if (lista == null)
                return;
            foreach (clsSelector selec in lista)
            {
                ActualizarFiltro();
                Where += selec.ConsultaMedica;
                int cont = selB.ContarRegistros(_moduloId, Where);
                dataGridView1.Rows.Add("", selec.ConsultaMedica, cont, cantAnt);
                //dataGridView1.Rows.Add("", selec.ConsultaMedica, "", "");
                cantAnt = cont;
            }
        }
        private void CargarInfSelector()
        {
            SelecInf inf = selB.ObtenerSelectInf();
            if (inf != null)
            {
                cboModulo.SelectedValue = inf.moduloId;
                _moduloId = inf.moduloId;
                cboModulo.Enabled = false;
            }
            else
            {
                //MessageBox.Show("La base de datos no tiene el formato correcto", "Selector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (bw.IsBusy == true)
            //{
            //    Mensajes.msgProcesoEnCurso();
            //    return;
            //}
            if (cboTabla.SelectedIndex == -1)
            {
                cboCampo.DataSource = null;
                return;
            }
            ListasDesplegables obj = new ListasDesplegables();
            int val;
            if (cboTabla.SelectedValue == null)
            {
                cboCampo.DataSource = null;
                return;
            }
            if (int.TryParse(cboTabla.SelectedValue.ToString(), out val))
            {
                cboCampo.DataSource = obj.ListaCampos(val, _moduloId);
                cboCampo.DisplayMember = "CampoEquivalente";
                cboCampo.ValueMember = "EquivId";
                
            }
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bw.IsBusy == true)
            {
                Mensajes.msgProcesoEnCurso();
                return;
            }

            String Tabla = selB.ObtenerTablaEquivalente(cboTabla.Text.Trim());
            
            String Campo = cboCampo.Text.Trim();
            if (!(cboCampo.ValueMember == "EquivId"))
                return;
            int equivId = Convert.ToInt32(cboCampo.SelectedValue);
                
            if (string.IsNullOrEmpty(cboCampo.DisplayMember))
                return;
            ListasDesplegables obj = new ListasDesplegables();
            if ( string.IsNullOrEmpty(Campo))
                return;
            
            cboDato.DataSource = obj.ListaDatos(_moduloId, Campo,Where, equivId);
            
            if (Campo.Substring(Campo.Length - 2) == "_F")
            {
                txtDato.Visible = true;
                cboDato.Visible = false;
            }
            else
            {
                txtDato.Visible = false;
                cboDato.Visible = true;
            }
        }

        private string Where;

        private List<string> TablasEquivalentes = new List<string>();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy == true)
                return;

            //Ciencia_Car_Filtro filtro = new Ciencia_Car_Filtro();

            try
            {
                if (cboTabla.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe Seleccionar tabla", "Ciencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if(cboCampo.SelectedIndex==-1)
                {
                    MessageBox.Show("Debe Seleccionar campo", "Ciencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                    if(cboOperador.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe Seleccionar operador", "Ciencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (cboDato.SelectedIndex == -1 && String.IsNullOrEmpty(txtDato.Text))
                    {
                        MessageBox.Show("Debe Seleccionar/escribir dato ", "Ciencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    

                if (dataGridView1.RowCount > 0 && String.IsNullOrEmpty(cboAnd.Text))
                {
                    cboAnd.Text = "AND";
                }
                String crit;
                String Campo = cboCampo.Text.Trim();
                string tabla = cboTabla.Text.Trim();
                //TablaEquivBuss tablaB = new TablaEquivBuss();
                var tablaEquiv = selB.ObtenerTablaEquivalente(tabla);
                if(TablasEquivalentes.FindIndex(x=> x==tablaEquiv)== -1)
                {
                    TablasEquivalentes.Add(tablaEquiv);
                }

                string Operador = cboOperador.Text;
                string valor;
                if (Campo.Substring(Campo.Length - 2) == "_F")
                {
                    valor = txtDato.Text;
                    DateTime fecha;
                    if (!DateTime.TryParse(valor, out fecha))
                    {
                        MessageBox.Show("fecha no válida", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else
                    valor = cboDato.Text;
                crit = selB.ConstruirCriterio(cboAnd.Text, tabla, Campo, Operador, valor);
                ActualizarFiltro();
                Where += crit;
                int cont = selB.ContarRegistros(_moduloId, Where);
                dataGridView1.Rows.Add("", crit, cont, cantAnt);
                lblSelMed.Text = crit;
                cantAnt = cont;
                lblSelMed.Text = Where;
                InicializarControles();
                cboModulo.Enabled = false;
            }
            catch (Exception ex)
            {
                Mensajes.msgError(ex);
            }
        }

        

        void ActualizarFiltro()
        {
            Where = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Where = Where + row.Cells["Seleccion"].Value.ToString();
            }
            lblSelMed.Text = Where;
        }

        void InicializarControles()
        {
            cboTabla.SelectedIndex = -1;
            cboCampo.SelectedIndex = -1;
            cboOperador.SelectedIndex = -1;
            cboDato.SelectedIndex = -1;
            txtDato.Text = null;
        }

        private void btnBorrarTodos_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy == true)
                return;

            cantAnt = selB.ContarRegistros(_moduloId);
            cboAnd.SelectedIndex = -1;
            dataGridView1.Rows.Clear();
            Where = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy == true)
            {
                Mensajes.msgProcesoEnCurso();
                return;
            }
            if(string.IsNullOrEmpty(Where))
            {
                MessageBox.Show("Debe seleccionar al menos un filtro", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                
                Cursor.Current = Cursors.WaitCursor;
            bw.RunWorkerAsync();

            //f.vista = view;
            //try
            //{
            
            //    List<clsSelector> lista = new List<clsSelector>();
            //    foreach(DataGridViewRow row in dataGridView1.Rows )
            //    {
            //        clsSelector obj = new clsSelector();
            //        obj.ConsultaMedica = row.Cells["Seleccion"].Value.ToString();
            //        lista.Add(obj);
            //    }

            //    selB.GuardarSelector(lista);
            //    SelecInf inf = new SelecInf();
            //    inf.moduloId = _moduloId;
            //    inf.where = Where;
            //    selB.GuardarSelecInf(inf);
            //    Thread.Sleep(1000);
            //    selB.CopiarTablas();
            //    //string view =selB.CrearVista(_moduloId, Where);
            //    frmComplemento f = new frmComplemento();
            //    f.MdiParent = this.MdiParent;
            //    f.ConStr = _localConStr;
            //    //f.moduloId = _moduloId;
            //    f.nombreArchivo = _nombreArchivo;
            //    //f.vista = view;
            //    f.Show();
            //    Close();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Mensajes.msgError(ex);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.ProgressBar1.Value = e.ProgressPercentage;
            if(e.UserState!= null)
                stLabel.Text = e.UserState.ToString();
        }

        private Boolean flag;
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {

                Cursor.Current = Cursors.WaitCursor;
                List<clsSelector> lista = new List<clsSelector>();
                foreach(DataGridViewRow row in dataGridView1.Rows )
                {
                    clsSelector obj = new clsSelector();
                    obj.ConsultaMedica = row.Cells["Seleccion"].Value.ToString();
                    lista.Add(obj);
                }
                bw.ReportProgress(15);
                selB.GuardarSelector(lista);
                bw.ReportProgress(40);
                SelecInf inf = new SelecInf();
                inf.moduloId = _moduloId;
                inf.where = Where;
                selB.GuardarSelecInf(inf);
                Thread.Sleep(1000);
                bw.ReportProgress(90);
                //selB.CopiarTablas();
                //string view =selB.CrearVista(_moduloId, Where);
            
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
                MessageBox.Show("Error: "+ e.Error, "Ciencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                Formularios.fComplemento.nombreArchivo = _nombreArchivo;
                Formularios.fComplemento.MdiParent = this.MdiParent;
                Formularios.fComplemento.ConStr = _localConStr;
                if (!Formularios.fComplemento.CargarInfSelector())
                {

                    return;
                }

                Hide();
                ProgressBar1.Value = 10;
                Formularios.fComplemento.Show();
                Close();
                //f. = _moduloId;
                
              
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnBorrarLinea_Click(object sender, EventArgs e)
        {
        //    if (bw.IsBusy == true)
        //        return;

            if (dataGridView1.RowCount > 0)
            {
                int index = dataGridView1.RowCount - 1;                
                dataGridView1.Rows.Remove(dataGridView1.Rows[index]);
                if(index > 0)
                    cantAnt = Convert.ToInt32(dataGridView1.Rows[index - 1].Cells["Cant"].Value);
                else
                {
                    cantAnt = selB.ContarRegistros(_moduloId);
                    cboAnd.SelectedIndex = -1;
                }
                ActualizarFiltro();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //if (bw.IsBusy == true)
            //    return;
            Close();
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (bw.IsBusy == true)
            //{
            //    Mensajes.msgProcesoEnCurso();
            //    return;
            //}
            if (flag == false)
                return;
            int moduloId;
            ListasDesplegables obj = new ListasDesplegables();
            if (cboModulo.SelectedValue == null)
            {
                cboTabla.DataSource = null;
                return;
            }
            if (int.TryParse(cboModulo.SelectedValue.ToString(), out moduloId))
            {
                flag = false;
                _moduloId = moduloId;
                var lista = obj.ListaTabla(moduloId, false, false);
                cboTabla.DataSource = lista;
                cboTabla.ValueMember = "TablaId";
                cboTabla.DisplayMember = "NombreTabla";
                //cboCampo.DisplayMember = "CampoEquivalente";
                //cboCampo.ValueMember = "CampoEquivalente";

                cantAnt = selB.ContarRegistros(moduloId);
                lblTotalReg.Text = cantAnt.ToString();
                InicializarControles();
                flag = true;
            }
            
        }

        public Boolean CopiarBaseDeDatos(string nombreArchivo)
        {
            return selB.CopiarBaseDeDatos(arorg, nombreArchivo);

        }

        private void frmSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            Formularios.fMenu.Show();
        }
    }
}
