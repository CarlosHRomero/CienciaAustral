﻿using Ciencia;
using Ciencia.BLL;
using Common;
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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProceso_Click(object sender, EventArgs e)
        {
            AbrirProceso();
        }

        private void btnSelector_Click(object sender, EventArgs e)
        {
            AbrirSelector();
            
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
            Ambiente.ver = typeof(Program).Assembly.GetName().Version;
            this.lblHoy.Text = DateTime.Now.ToString();
            btnUsuario.Text = Ambiente.Usuario.User_Nombre;
            lblMaquina.Text = Ambiente.Maquina;
            lblVersion.Text = Ambiente.ver.ToString();
        }

        private void frmMenu_Shown(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void AbrirProceso()
        {
            Formularios.fProceso.MdiParent = this.MdiParent;
            Formularios.fProceso.Show();
            Hide();
        }
        public void AbrirSelector()
        {
                        //OpenFileDialog ofd = new OpenFileDialog();
            Ciencia.dlgAbrirBase ofd = new Ciencia.dlgAbrirBase();
            
            //ofd.DefaultExt = "mdb";
            //ofd.Filter = "Access (*.mdb) | *.mdb";
            ofd.Text = "Seleccione la base de datos";
            //ofd.CheckFileExists = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                string nombreArchivo = ofd.FileName;
                if (!nombreArchivo.Contains(".mdb"))
                {
                    nombreArchivo = string.Format("{0}.mdb", nombreArchivo);
                }
                if (!System.IO.File.Exists(nombreArchivo))
                {
                    nombreArchivo = nombreArchivo.Substring(0, nombreArchivo.Length - 4);
                    nombreArchivo = string.Format("{0}_{1}_{2}_{3}.mdb", nombreArchivo, DateTime.Today.Day.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Year.ToString());
                    if (!Formularios.fSelector.CopiarBaseDeDatos(nombreArchivo))
                    {
                        MessageBox.Show("No se pudo copiar base de datos", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Base de datos creada con exito", "Selector", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                Formularios.fSelector.MdiParent = this.MdiParent;
                string constr = Formularios.fSelector.EstablecerCadenaDeConexion(nombreArchivo);
                SelectorBuss sB = new SelectorBuss();
                sB.constr = constr;
                if (!sB.VerificarBaseDeDatos())
                {
                    MessageBox.Show("La base de datos no tiene el formato correcto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSelector.PerformClick();
                    return;
                }
                Formularios.fSelector.Show();
                Hide();
            }
        }
        public void AbrirComplemento()
        {
            Ciencia.dlgAbrirBase ofd = new Ciencia.dlgAbrirBase();

            //ofd.DefaultExt = "mdb";
            //ofd.Filter = "Access (*.mdb) | *.mdb";
            ofd.Text = "Seleccione la base de datos";
            //ofd.CheckFileExists = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                Formularios.fComplemento.MdiParent = this.MdiParent;
                string constr = Formularios.fComplemento.EstablecerCadenaDeConexion(ofd.FileName);
                SelectorBuss sB = new SelectorBuss();
                sB.constr = constr;
                if (!sB.VerificarBaseDeDatos())
                {
                    MessageBox.Show("La base de datos no tiene el formato correcto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSelector.PerformClick();
                    return;
                }
                if (!Formularios.fComplemento.CargarInfSelector())
                {                    
                    return;
                }
                Formularios.fComplemento.Show();
                Hide();
                //Dispose();
            }
        }
        public void AbrirEvolucion()
        {
            Ciencia.dlgAbrirBase ofd = new Ciencia.dlgAbrirBase();

            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.DefaultExt = "mdb";
            //ofd.Filter = "Access (*.mdb) | *.mdb";
            ofd.Text = "Seleccione la base de datos";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Formularios.fEvolucion.MdiParent = this.MdiParent;
                

                SelectorBuss sB = new SelectorBuss();
                sB.constr = Formularios.fEvolucion.EstablecerCadenaDeConexion(ofd.FileName); ;
                if (!sB.VerificarBaseDeDatos())
                {
                    MessageBox.Show("La base de datos no tiene el formato correcto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSelector.PerformClick();
                    return;
                }


                Formularios.fEvolucion.Show();
            }

        }

        private void btnComplemento_Click(object sender, EventArgs e)
        {
            AbrirComplemento();
        }

        private void btnEvolucion_Click(object sender, EventArgs e)
        {
            AbrirEvolucion();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }
    }
}