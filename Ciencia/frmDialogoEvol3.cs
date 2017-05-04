using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ciencia.OBJ;
using Ciencia.BLL;

namespace Ciencia
{
    public partial class frmDialogoEvol3 : Form
    {
        public List<SelTablaEvol> ListaSel { get; set; }

        public string Tabla { get; set; }
        public string Campo { get; set; }
        public string TipoDeDato { get; set; }
        public string Filtro { get; set; }
        public string constr { get; set; }

        public string resultado { get; set; }
        public string ValoresACero { get; set; }
        public int moduloId { get; set; }
        public string where { get; set; }
        public frmDialogoEvol3()
        {
            InitializeComponent();
        }

        private void frmDialogoEvol3_Load(object sender, EventArgs e)
        {
            if (ListaSel == null)
                ListaSel = new List<SelTablaEvol>();
            else
            {
                ActualizarGrid2();
                tabControl1.SelectedTab = tabControl1.TabPages[1];
            }

            NumDePacB nb = new NumDePacB();
            CargarGrid(nb.CalcularNumDePac(Tabla, where, Campo, Filtro.Trim(), TipoDeDato, constr, moduloId));
        }

        private void CargarGrid(List<NumDePac> lista)
        {
            foreach (NumDePac obj in lista)
            {
                if (TipoDeDato == "Tabla")
                {
                    dataGridView1.Rows.Add(obj.Equivalencia, obj.Valor,  false, obj.Cant, obj.Ord);
                    dataGridView1.Sort(dataGridView1.Columns["Orden"], ListSortDirection.Ascending);
                }
                else
                {
                    dataGridView1.Rows.Add(obj.Equivalencia, "", false, obj.Cant);
                }
            }
        }

        private void flatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SelTablaEvol selT = new SelTablaEvol();
            selT.listaVal = new List<string>();
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Seleccion"].Value))
                    selT.listaVal.Add(row.Cells["Equivalencia"].Value.ToString());
            }
            if (rbtPrimera.Checked)
                selT.pri_ult = OrdenSel.Primera;
            else
                selT.pri_ult = OrdenSel.Ultima;

            ListaSel.Add(selT);
            ActualizarGrid2();
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["Seleccion"].Value = false;
            }
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[1];
        }

        void ActualizarGrid2()
        {
            dataGridView2.Rows.Clear();
            foreach(SelTablaEvol sel in ListaSel )
            {
                string s = sel.listaVal.Aggregate((res,x) => res+", "+ x);
                dataGridView2.Rows.Add(s, sel.pri_ult);
            }
        }

        
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if(ListaSel.Count == 0)
            {
                if(MessageBox.Show("No selecciono ningún campo. Desea Salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void btnQuitarFila_Click(object sender, EventArgs e)
        {
            if (ListaSel.Count > 0)
            {
                ListaSel.RemoveAt(ListaSel.Count - 1);
                ActualizarGrid2();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
