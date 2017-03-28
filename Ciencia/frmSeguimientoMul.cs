using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

        protected override void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new Exception();
        }
    }
}
