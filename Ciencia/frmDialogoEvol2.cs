using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciencia
{
    public partial class frmDialogoEvol2 : Form
    {
        public List<string> ListaFuncion { get; set; }
        public frmDialogoEvol2()
        {
            InitializeComponent();
            ListaFuncion = new List<string>();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (this.chkMaximo.Checked)
                ListaFuncion.Add("Máximo");
            if (this.chkminimo.Checked)
                ListaFuncion.Add("Mínimo");
            if (this.chkPromedio.Checked)
                ListaFuncion.Add("Promedio");
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDialogoEvol2_Load(object sender, EventArgs e)
        {

        }
    }
}
