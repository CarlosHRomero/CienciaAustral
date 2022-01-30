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

using  Ciencia.OBJ;

namespace Ciencia
{
    public partial class frmUniverso : Form
    {
        public string Tablas { get; set; }
        public string where { get; set; }
        public string Format { get; set; }
        //public string Campo { get; set; }
        public int EquivId { get; set; }
        public string TipoDeDato { get; set; }
        public string Filtro { get; set; }
        public string constr { get; set; }

        public string resultado { get; set; }
        public string ValoresACero { get; set; }
        public int moduloId { get; set; }
        public bool VerValor { get; set; }


        private string Titulo = "HUA - Ciencia - frmUniverso ";
        
        public frmUniverso()
        {
            //VerValor = false;
            
            InitializeComponent();
            chkVerValor.Checked = VerValor;
            chkConvACero.Checked = !VerValor;
            Text = Titulo;
        }

        private void frmUniverso_Load(object sender, EventArgs e)
        {
            NumDePacB nb= new NumDePacB();
            if (TipoDeDato.ToLower().Trim() == "tabla")
            {
                dataGridView1.ReadOnly = false;
                chkVerValor.Enabled = true;
                chkConvACero.Enabled = true;
            }
            chkVerValor.Checked = VerValor;
            chkConvACero.Checked = !VerValor;
            moduloBuss modB = new moduloBuss();
            Tablas = modB.ObtnerTablasAgregadas(moduloId);
            ComplementoBuss cb = new ComplementoBuss();
            CienciaEquiv equiv= cb.ObtenerDatosCampo(EquivId);
            if (equiv.CampoEquivalente.ToLower() == "ingr_subdiag_d")
            {
                Filtro = cb.filtroSubDiag();
            }    

            CargarGrid(nb.CalcularNumDePac(Tablas, where, equiv.CampoEquivalente, Filtro, TipoDeDato, constr, moduloId));
        }

        private void CargarGrid(List<NumDePac> lista)
        {
            List<string> valACero = null;
            if (!string.IsNullOrEmpty(ValoresACero))
            {
                valACero = ValoresACero.Split(',').ToList();
            }

            foreach (NumDePac obj in lista)
            {
                if (TipoDeDato == "Tabla")
                {
                    if (valACero != null)
                    {
                        if (valACero.Where(x => x.Trim() == obj.Equivalencia).Count() > 0)
                        {
                            dataGridView1.Rows.Add(obj.Equivalencia, obj.Valor, true, obj.Cant, obj.Ord);
                           
                        }
                        else
                            dataGridView1.Rows.Add(obj.Equivalencia, obj.Valor, false, obj.Cant, obj.Ord);
                    }
                    else
                        dataGridView1.Rows.Add(obj.Equivalencia, obj.Valor, false, obj.Cant, obj.Ord);
                }
                else
                {
                    dataGridView1.Rows.Add(obj.Equivalencia, "", false, obj.Cant);
                }
            }
            dataGridView1.Sort(dataGridView1.Columns["Orden"], ListSortDirection.Ascending);
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (TipoDeDato == "NoSi")
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
            resultado = "";
            ValoresACero= "";
            if(dataGridView1.CurrentRow != null)
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0];
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["No"].Value)) 
                {
                    resultado = resultado + row.Cells["Valor"].Value.ToString() + ", ";
                    ValoresACero += row.Cells["Equivalencia"].Value.ToString() + ", ";
                }
            }
            VerValor = chkVerValor.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkVerValor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVerValor.Checked == true)
                chkConvACero.Checked = false;
            else
                chkConvACero.Checked = true;

        }

        private void chkConvACero_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConvACero.Checked == true)
                chkVerValor.Checked = false;
            else
                chkVerValor.Checked = true;
        }

       
    }
}
