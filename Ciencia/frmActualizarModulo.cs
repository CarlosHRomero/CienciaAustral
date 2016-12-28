using Ciencia.BLL;
using Ciencia.OBJ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Generales;

namespace Ciencia
{
    public partial class frmActualizarModulo : Form
    {
        private String Titulo = "ICBA - Ciencia - frmActualizarModulo";

        public frmActualizarModulo()
        {
            InitializeComponent();
        }

        private void frmActualizarModulo_Load(object sender, EventArgs e)
        {
            InicializarGrid();
            CargarDesplegables();
            Text = Titulo;
            DataGridView1.CellValueChanged += DataGridView1_CellValueChanged; 
        }

        private void CargarDesplegables()
        {
            ListasDesplegables obj = new ListasDesplegables();
            cboModulo.DataSource = obj.ListaModulo();
            cboModulo.ValueMember = "ModuloId";
            cboModulo.DisplayMember = "Nombre";
            cboTabla.DataSource = obj.ListaTabla(1);
            cboTabla.ValueMember = "TablaId";
            cboTabla.DisplayMember = "NombreTabla";
        }

        DataGridViewComboBoxColumn tipoDato;

        public void InicializarGrid()
        {
            ListasDesplegables obj = new ListasDesplegables();
           
            tipoDato = new DataGridViewComboBoxColumn
            {
                HeaderText = "Tipo De Dato",
                Name = "TipoDeDato",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                FlatStyle = FlatStyle.Flat,
                DataSource = Enum.GetValues(typeof(TipoDeDatos)),
                ValueType = typeof(TipoDeDatos),
                Width = 80
            };
            this.DataGridView1.Columns.Add("CampoOriginal", "Campo Original");
            this.DataGridView1.Columns.Add("CampoEquivalente", "Campo Equivalente");
            DataGridView1.Columns.Add(tipoDato);
            this.DataGridView1.Columns.Add("TipodeDatoSql", "Tipo de Dato Sql Server");
            this.DataGridView1.Columns.Add("Solapa", "Solapa");
            this.DataGridView1.Columns.Add("Orden", "Orden");
            this.DataGridView1.Columns[0].Width = 160;
            this.DataGridView1.Columns[0].ReadOnly = true;
            this.DataGridView1.Columns[1].Width = 160;
            this.DataGridView1.Columns[2].Width = 100;
            this.DataGridView1.Columns[3].Width = 160;
            this.DataGridView1.Columns[4].Width = 140;
            this.DataGridView1.Columns[5].Width = 100;

            this.dataGridView2.Columns.Add("CampoOriginal", "Campo Original");
            this.dataGridView2.Columns.Add("CampoEquivalente", "Campo Equivalente");
            this.dataGridView2.Columns.Add("TipodeDato", "Tipo de Dato");
            this.dataGridView2.Columns.Add("TipodeDatoSql", "Tipo de Dato Sql Server");
            this.dataGridView2.Columns.Add("Solapa", "Solapa");
            this.dataGridView2.Columns.Add("Orden", "Orden");
            this.dataGridView2.Columns[0].Width = 160;
            this.dataGridView2.Columns[1].Width = 160;
            this.dataGridView2.Columns[2].Width = 100;
            this.dataGridView2.Columns[3].Width = 160;
            this.dataGridView2.Columns[4].Width = 140;
            this.dataGridView2.Columns[5].Width = 100;
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListasDesplegables obj = new ListasDesplegables();
            if (cboModulo.SelectedValue is int)
            {
                cboTabla.DataSource = obj.ListaTabla(Convert.ToInt32(cboModulo.SelectedValue));
                cboTabla.ValueMember = "TablaId";
                cboTabla.DisplayMember = "NombreTabla";
            }
        }

        private void cboTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        public void CargarGrid()
        {
            CienciaEquivBuss cienciaEquivB = new CienciaEquivBuss();
            if (cboTabla.SelectedValue is int)
            {
               var cienciaEquiv = cienciaEquivB.ListaCampos(Convert.ToInt32(cboTabla.SelectedValue));
               DataGridView1.Rows.Clear();
               int i = 0;
               foreach (CienciaEquiv obj in cienciaEquiv.OrderBy(x => x.orden))
               {
                   DataGridView1.Rows.Add(obj.CampoOriginal, obj.CampoEquivalente, null, obj.TipoDatoSqlServer, obj.Solapa, obj.orden);
                   this.DataGridView1.Rows[i].Cells[2].Value = (TipoDeDatos)Enum.Parse(typeof(TipoDeDatos), obj.TipoDeDato);
                   i++;
               }

            }
        }

        private void tpValidar_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _btnValidar.Enabled = true;
            _btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
