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
    public partial class frmDialogoEvol1 : Form
    {
        public frmDialogoEvol1()
        {
            InitializeComponent();
        }
        public string funcion { get; set; }

        private void frmDialogoEvol1_Load(object sender, EventArgs e)
        {

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (rdbPrimera.Checked)
                funcion = "Primera";
            else if (rdbUltima.Checked)
                funcion = "Ultima";
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
