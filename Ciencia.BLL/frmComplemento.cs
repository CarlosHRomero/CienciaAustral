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
using Common.Interface;

namespace Ciencia
{
    public partial class frmComplemento : Form
    {
        private String _localConStr;
        private string Titulo = "ICBA - Cardiología - Ciencia - frmComplemento ";
        public void EstablecerCadenaDeConexion(string nombreArchivo)
        {
            _localConStr = "Provider=Microsoft.ACE.OLEDB.12.0; " +
                            "Data Source= " + nombreArchivo;
        }
        public frmComplemento()
        {
            InitializeComponent();
            Text = Titulo;
 
            
        }

        void InicializarDesplegables()
        {
            ListasDesplegables obj = new ListasDesplegables();
            cboTabla.DataSource = obj.ListaTablaLocal(_localConStr, false);
            cboTabla.ValueMember = "TablaId";
            cboTabla.DisplayMember = "NombreTabla";
            cboSel.DataSource = obj.ListaNoSi();
            cboTabla.SelectedIndex = -1;
        }

        List<CienciaEquiv> _lista;
        private void frmComplemento_Load(object sender, EventArgs e)
        {
            InicializarDesplegables();
            //InicializarDataGridView();
            LocalCarEqB eqB = new LocalCarEqB();
            _lista = eqB.ListaTodosCampos(_localConStr);
            CargarGrid(_lista);
        }

        void InicializarDataGridView()
        {
            try
            {
                LocalCarEqB eqB = new LocalCarEqB();
                dataGridView1.AutoGenerateColumns = false;
                _lista = eqB.ListaTodosCampos(_localConStr);
                dataGridView1.DataSource = _lista;
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

        private void cboTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocalCarEqB eqB = new LocalCarEqB();
            //List<CienciaCarEquiv> lista;
            int val;
            if (cboTabla.SelectedValue == null || cboTabla.SelectedIndex==0)
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

        private void CargarGrid(List<CienciaEquiv> lista)
        {
            
            //dataGridView1.Rows.Clear();
            if (lista == null)
                return;
            LocalCarEqB eqB = new LocalCarEqB();
            foreach (var obj in lista)
            {
                string tabla = eqB.TablaPorCodigo(obj.TablaId, _localConStr);
                if (!string.IsNullOrEmpty(obj.TipoDeDato))
                    dataGridView1.Rows.Add(obj.TablaId, obj.CampoEquivalente, obj.Seleccion, obj.TipoDeDato, obj.ValoresACero, obj.Filtro, tabla, obj.EquivId);
            }
             

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                frmUniverso f = new frmUniverso();
                LocalCarEqB eqB = new LocalCarEqB();

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                f.Tabla = row.Cells["Tabla"].Value.ToString().Trim() + "_Sel";
                f.Campo = row.Cells["Campo"].Value.ToString().Trim();
                f.TipoDeDato = row.Cells["Tipo"].Value.ToString().Trim();
                f.Filtro = row.Cells["Filtro"].Value.ToString().Trim();
                f.constr = _localConStr;
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK)
                {
                    row.Cells["Valor"].Value = f.resultado;
                    row.Cells["Sel"].Value = true;
                    if (dataGridView1.CurrentRow != null) 
                        dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[1];
                }
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<clsCampo> campos = new List<clsCampo>();
                clsCampo campo = new clsCampo();
                campo.tabla = "Ciencia_car_ingr_sel";
                campo.nombre = "Ingr_pac_id";
                campos.Add(campo);
                campo = new clsCampo
                {
                    tabla = "Ciencia_car_ingr_sel",
                    nombre = "Ingr_id"
                };
                campos.Add(campo);
                campo = new clsCampo();
                campo.tabla = "Ciencia_car_Ant_sel";
                campo.nombre = "Ant_id";
                campos.Add(campo);
                campo = new clsCampo();
                campo.tabla = "Ciencia_car_AntC_sel";
                campo.nombre = "Antc_id";
                campos.Add(campo);
                LocalCarEqB eqB = new LocalCarEqB();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    CienciaEquiv obj = new CienciaEquiv();
                    obj.EquivId = Convert.ToInt32(row.Cells["EquivId"].Value);
                    obj.CampoEquivalente = row.Cells["Campo"].Value.ToString();
                    obj.Seleccion = Convert.ToBoolean(row.Cells["Sel"].Value);
                    if (row.Cells["Valor"].Value != null)
                        obj.ValoresACero = row.Cells["Valor"].Value.ToString();
                    eqB.ActualizarSelecciónCampo(obj, _localConStr);

                    //dataGridView1.Rows.fi
                    if (Convert.ToBoolean(row.Cells["Sel"].Value) == true)
                    {
                        campo = new clsCampo();
                        campo.nombre = row.Cells["Campo"].Value.ToString().Trim();
                        campo.tabla = row.Cells["Tabla"].Value.ToString().Trim() + "_Sel";
                        if (row.Cells["Valor"].Value != null)
                        {
                            if (!String.IsNullOrEmpty(row.Cells["Valor"].Value.ToString()))
                            {
                                AgregarEquvalencias(ref campo, row.Cells["Valor"].Value.ToString().Trim(),
                                    row.Cells["Filtro"].Value.ToString().Trim());
                            }
                        }
                        campos.Add(campo);
                    }

                }
                TablaCienciaB tcb = new TablaCienciaB();
                if (tcb.CrearTablaCiencia(_localConStr, campos))
                {

                    MessageBox.Show("Se creo la tabla ciencia con éxito", "Ciencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Error al crear la tabla", "Ciencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Mensajes.msgError(ex);
                //throw;
            }

        }

        void AgregarEquvalencias(ref clsCampo campo, string equival, string filtro)
        {
            List<IEquivalencia> lista = new List<IEquivalencia>();
            string[] valores;
            char[] charSeparators = new char[] { ',' };
            valores = equival.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            LocalCarEqB lcqB = new LocalCarEqB();
            foreach (var val in valores)
            {
                IEquivalencia obj = new Equivalencia();
                obj.valor = Convert.ToInt32(val);
                obj.Texto = lcqB.EquivPoCodigo(obj.valor, filtro, _localConStr);
                obj.Equivalelente = "0";
                lista.Add(obj);
            }
            campo.listaEq = lista;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSel.Text != "Si" )
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
                    if(Convert.ToBoolean(row.Cells["Sel"].Value))
                        row.Visible = true;
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }
    }
}
