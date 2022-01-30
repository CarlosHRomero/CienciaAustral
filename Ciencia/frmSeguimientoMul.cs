using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ciencia.BLL;
using Ciencia.OBJ;

namespace Ciencia
{
    public partial class frmSeguimientoMul : Ciencia.frmEvolucion
    {
        public frmSeguimientoMul()
        {
            InitializeComponent();
            Text = "Seguimiento Multiple";
            dataGridView1.Columns["valor"].Visible = false;
        }

        private void frmSeguimientoMul_Load(object sender, EventArgs e)
        {
        }

        protected virtual List<clsCampo> LeerGrid()
        {
            List<clsCampo> campos = new List<clsCampo>();
            int c, i = 0;
            c = dataGridView1.Rows.Count;
            clsCampo campo;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Sel"].Value) == true )
                {

                    campo = new clsCampo();
                    campo.EquivId = Convert.ToInt32(row.Cells["EquivId"].Value);
                    campo.nombre = row.Cells["Campo"].Value.ToString().Trim();
                    campo.tablaId = Convert.ToInt32(row.Cells["TablaID"].Value);
                    campos.Add(campo);
                }
                i++;
                bw.ReportProgress(10 * i / c + 1);
            }
            return campos;
        }
        protected override void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var campos = LeerGrid();
            var segB = new SeguimientoMultBuss(_localConStr);
            segB.ActualizarCamposSgmto(campos);
            segB.ConstruirSgmto(bw);
        }

        protected override void CargarGrid()
        {
            var segB = new SeguimientoMultBuss(_localConStr);
            var lista = segB.ListaCampos();
            foreach(var obj in lista)
            {
                dataGridView1.Rows.Add(obj.TablaId, obj.CampoEquivalente, obj.Seleccion, obj.TipoDeDato, obj.ValoresACero, obj.Filtro, "",obj.EquivId, obj.Solapa, "");
            }
            return;
        }

        private void frmSeguimientoMul_Load_1(object sender, EventArgs e)
        {

        }
    }
}
