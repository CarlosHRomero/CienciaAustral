using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ciencia.BLL;
using Ciencia.OBJ;
using Ciencia.Properties;
using Common;
using Common.OBJ;

namespace Ciencia
{
    public partial class frmProceso : Form
    {
        private readonly BackgroundWorker _bw= new BackgroundWorker();
        private int _maximumProgressBar;

        public frmProceso()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            _bw.WorkerReportsProgress = true;
            _bw.WorkerSupportsCancellation = true;
            _bw.DoWork += bw_DoWork;
            _bw.ProgressChanged += bw_ProgressChanged;
            _bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        private void CargarDesplegables()
        {
            ListasDesplegables obj = new ListasDesplegables();
            cboModulo.DataSource = obj.ListaModulo();
            cboModulo.ValueMember = "ModuloId";
            cboModulo.DisplayMember = "Nombre";
        }

        String Titulo = "ICBA - Ciencia - frmProceso";
        DateTime _t;
        int _moduloId;

        private void btnProceso_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bw.IsBusy != true)
                {
                    lblProcesando.Text = "Proceso inicializado";
                    _t = DateTime.Now;
                    progressBar1.Visible = true;
                    _moduloId = Convert.ToInt32(cboModulo.SelectedValue);
                    _bw.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
                BackgroundWorker worker = sender as BackgroundWorker;
                ConversorCiencia conv = new ConversorCiencia(_moduloId);
                bool res = conv.ConvertirTablas(worker);
                if(!res)
                {
                    e.Result = "error";
                    if (worker != null) worker.CancelAsync();
                    return;
                }
                res = conv.ConvertirTablasEvolucion(worker);
                if (!res)
                {
                    e.Result = "error";
                    if (worker != null) worker.CancelAsync();
                    return;
                }
                res = conv.ConvertirTablasMultiples(worker);
                if (!res)
                {
                    e.Result = "error";
                    if (worker != null) worker.CancelAsync();
                    return;
                }
            if (worker != null)
            {
                worker.ReportProgress(0, "Proceso Terminado");
                if (worker.CancellationPending)
                    e.Cancel = true;
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Value = e.ProgressPercentage;
                var list = e.UserState as List<string>;
            
                if (list != null)
                {
                    int i = 0;
                    foreach (var mensaje in list)
                    {
                        if (i == 0)
                            lblTablas.Text = mensaje;
                        else if(i == 1)
                            lblProcesando.Text = mensaje;
                        else
                        {
                            _maximumProgressBar = Convert.ToInt32(mensaje);
                            progressBar1.Maximum = _maximumProgressBar;
                            timer1.Tick += new EventHandler(timer1_Tick);
                            timer1.Interval = 1;
                            timer1.Enabled = true;
                            timer1.Start();     
                        }
                        ++i;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != _maximumProgressBar)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Stop();
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    MessageBox.Show("Proceso Cancelado");
                    progressBar1.Value = 0;
                    lblEstado.Text = "Cancelado";
                }
                if (e.Result != null)
                {
                    if (e.Result.ToString() == "error")
                    {
                        lblTablas.Text = string.Empty;
                        lblProcesando.Text = string.Empty;
                        lblEstado.Text = string.Empty;
                        MessageBox.Show("Ha ocurrido un error");
                    }
                }
                else if (e.Error != null)
                {
                    lblTablas.Text = string.Empty;
                    lblProcesando.Text = string.Empty;
                    lblEstado.Text = string.Empty;
                    MessageBox.Show("Ha ocurrido un error");
                }
                else
                {
                    progressBar1.Value = progressBar1.Maximum;
                    TimeSpan dt = DateTime.Now - _t;
                    lblProcesando.Text = "Tiempo total:  " + dt.ToString(@"hh\:mm\:ss");
                    Ciencia_Car_Procesos obj = new Ciencia_Car_Procesos {Proc_F = DateTime.Today};
                    Ciencia.BLL.CienciaB cb = new Ciencia.BLL.CienciaB();
                    obj.SelD_F = cb.ObtenerFechaDesde();
                    obj.SelH_F = cb.ObtenerFechaHasta();
                    obj.ProcId = 1;
                    obj.UsrId = Ambiente.Usuario.User_Id;
                    _procB.Modificar(obj);
                    CargarGrid();
                    MessageBox.Show(Resources.Form1_btnProceso_Click_ProcesoTerminado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDesplegables();
            Text = Titulo;
            CargarGrid();
        }

        private readonly ProcesosB _procB = new ProcesosB();

        void CargarGrid()
        {
            List<Ciencia_Car_Procesos> lista = _procB.ObtenerProcesos();
            DataGridView1.Rows.Clear();
            foreach (var proc in lista)
            {
                if (proc.Proc_F != null)
                    if (proc.SelD_F != null)
                        if (proc.SelH_F != null)
                            DataGridView1.Rows.Add(((DateTime)proc.Proc_F).ToShortDateString(), proc.UsrId, ((DateTime)proc.SelD_F).ToShortDateString(), ((DateTime)proc.SelH_F).ToShortDateString(), proc.Motivo);
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                Close();
            }
        }

        private void btnCncel_Click(object sender, EventArgs e)
        {
            if (!_bw.IsBusy)
                return;
            if (
                MessageBox.Show(
                    "Para poder seguir usando ciencia debe terminar el proceso\n Está seguro que quiere cancelar?",
                    "Ciencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (_bw.WorkerSupportsCancellation)
            {
                _bw.CancelAsync();
            }
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (!_bw.IsBusy)
                Close();
        }

        private void frmProceso_FormClosing(object sender, FormClosingEventArgs e)
        {
            Formularios.fMenu.Show();
        }
    }
}
