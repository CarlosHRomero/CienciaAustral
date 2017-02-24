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
using Common.BLL;
using System.Linq;

namespace Ciencia
{
    public partial class frmProceso : Form
    {
        private readonly BackgroundWorker _bw= new BackgroundWorker();
        private readonly ProcesosB _procB = new ProcesosB();
        private int _maximumProgressBar;
        private String Titulo = "ICBA - Ciencia - frmProceso";
        private DateTime _t;
        private int _moduloId;
        private Ciencia_Procesos _proc;
        private UsuarioBuss _usuarioB;
        private List<Ciencia_Modulo> _modulos;
        private moduloBuss _moduloB;

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
            _proc = new Ciencia_Procesos();
            _usuarioB = new UsuarioBuss();
            _moduloB = new moduloBuss();
        }

        private void CargarDesplegables()
        {
            ListasDesplegables obj = new ListasDesplegables();
            _modulos = obj.ListaModulo();
            cboModulo.DataSource = obj.ListaModulo();
            cboModulo.ValueMember = "ModuloId";
            cboModulo.DisplayMember = "Nombre";
        }

        private void btnProceso_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bw.IsBusy != true)
                {
                    _t = DateTime.Now;
                    List<Ciencia_Procesos> lista = _procB.ObtenerProcesos().Where(x => x.ModuloId == Convert.ToInt32(cboModulo.SelectedValue)).ToList();
                    List<TimeSpan> listTiempoProc = new List<TimeSpan>();
                    TimeSpan tiempoProc;
                    foreach(Ciencia_Procesos proc in lista)
                    {
                        if (proc.User_LogOn != null)
                        {
                            tiempoProc = proc.Proc_fin_F.Value.Subtract(proc.Proc_ini_F.Value);
                            listTiempoProc.Add(tiempoProc);
                        }
                    }
                    if (lista.Count>0) 
                        lblPromedio.Text = "Tiempo estimado de finalización del proceso " + TimeSpan.FromTicks((long)listTiempoProc.Average(timeSpan => timeSpan.Ticks)).ToString(@"hh\:mm\:ss");
                    lblProcesando.Text = "Proceso inicializado";
                    progressBar1.Visible = true;
                    _moduloId = Convert.ToInt32(cboModulo.SelectedValue);
                    lblProc.Text = "Procesando el modulo " + _moduloB.ObtenerDatosModulo(_moduloId).Nombre;
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
                _proc.Proc_ini_F = DateTime.Now;
                _proc.User_LogOn = Ambiente.Usuario.User_LogOn;
                _proc.Proc_Maq_T = Ambiente.Maquina;
                _proc.ModuloId = _moduloId;
                BackgroundWorker worker = sender as BackgroundWorker;
                ConversorCiencia conv = new ConversorCiencia(_moduloId);
                bool res = conv.ConvertirTablas(worker);
                //if (_bw.WorkerSupportsCancellation)
                //{
                //    return;
                //}
                if (!res)
                {
                    e.Result = "error";
                    if (worker != null) worker.CancelAsync();
                    return;
                }
                res = conv.ConvertirTablasEvolucion(worker);
                //if (_bw.WorkerSupportsCancellation)
                //{
                //    return;
                //}
                if (!res)
                {
                    e.Result = "error";
                    if (worker != null) worker.CancelAsync();
                    return;
                }
                res = conv.ConvertirTablasMultiples(worker);
                //if (_bw.WorkerSupportsCancellation)
                //{
                //    return;
                //}
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
                    Ciencia.BLL.CienciaB cb = new Ciencia.BLL.CienciaB();
                    _proc.Proc_fin_F = DateTime.Now;
                    _procB.Insertar(_proc);
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
        }

        void CargarGrid()
        {
            clsUsuario usuario;
            TimeSpan tiempoProc;
            List<Ciencia_Procesos> lista = _procB.ObtenerProcesos();
            DataGridView1.Rows.Clear();
            if (!(cboModulo.SelectedValue is Ciencia_Modulo))
                foreach (var proc in lista.Where(x => x.ModuloId == Convert.ToInt32(cboModulo.SelectedValue)).OrderByDescending(x => x.Proc_ini_F))
                {
                    usuario = _usuarioB.ObtenerUsuario(proc.User_LogOn);
                    if (usuario != null)
                    {
                        tiempoProc = proc.Proc_fin_F.Value.Subtract(proc.Proc_ini_F.Value);
                        DataGridView1.Rows.Add(proc.Proc_fin_F.Value.ToShortDateString(), usuario.User_Nombre, _modulos.FirstOrDefault(x => x.ModuloId == proc.ModuloId).Nombre, proc.Proc_Maq_T, proc.Proc_ini_F.Value.ToLongTimeString(), proc.Proc_fin_F.Value.ToLongTimeString(), tiempoProc.ToString(@"hh\:mm\:ss"));
                    }
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

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
