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
using Ciencia.OBJ;

namespace Ciencia
{
    public partial class frmSeguimientoAnualHemo : Form
    {
        string _where;
        string _nombreArchivo;
        public frmSeguimientoAnualHemo()
        {
            InitializeComponent();
        }
        public string EstablecerCadenaDeConexion(string nombreArchivo)
        {
            _localConStr = "Provider=Microsoft.ACE.OLEDB.12.0; " +
                            "Data Source= " + nombreArchivo;
            txtArchivo.Text = nombreArchivo;
            _nombreArchivo = nombreArchivo;
            return _localConStr;
        }
        private void CargarInfSelector()
        {
                SelectorBuss selB = new SelectorBuss();
                selB.constr = _localConStr;
                SelecInf inf = selB.ObtenerSelectInf();
                if (inf != null)
                {
                    if (inf.moduloId != 5)
                        throw new Exception("LA base de datos no corresponde a Hemodinamia");
                    _where = inf.where;
                    lblSelMed.Text = _where;
                }
           

        }
        private void frmSeguimientoAnualHemo_Load(object sender, EventArgs e)
        {
            try
            {
                CargarInfSelector();
            }
            catch (Exception ex)
            {
                Generales.Mensajes.msgError(ex);
                Hide();
            }
        }

        string _localConStr;

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DateTime ti = DateTime.Now;
                var sahb = new SeguimientoAnualHemoBuss();
                sahb.ProcesarSeguimiento(_where, _nombreArchivo);
                string ts = (DateTime.Now - ti).TotalSeconds.ToString("N2");
                Cursor.Current = Cursors.Default;
                Close();
            }
            catch(Exception ex )
            {
                Generales.Mensajes.msgError(ex);
                Cursor.Current = Cursors.Default;
            }
//            MessageBox.Show("Listo " + ts);
        }
    }
}
