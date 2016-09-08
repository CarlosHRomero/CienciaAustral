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

namespace Ciencia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 2500;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            MapeadorIngresos map = new MapeadorIngresos();
            progressBar1.Visible = true;
            map.MapearIngresos2(progressBar1);
            //progressBar1.Visible = false;
            MapeadorAnt map2 = new MapeadorAnt();
            map2.MapearAntecedentes2(progressBar1);
            MapeadorAntC map3 = new MapeadorAntC();
            map3.MapearAntecedentesC2(progressBar1);

            TimeSpan dt = DateTime.Now - t;
            label1.Text = "Tardo " + dt.ToString();
            label1.Visible = true;

            MessageBox.Show("ProcesoTerminado");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            MapeadorAntC map = new MapeadorAntC();
            progressBar1.Visible = true;
            map.MapearAntecedentesC2(progressBar1);
            progressBar1.Visible = false;
            TimeSpan dt = DateTime.Now - t;
            label1.Text = "Tardo " + dt.ToString();
            label1.Visible = true;
            MessageBox.Show("ProcesoTerminado");

        }
    }
}
