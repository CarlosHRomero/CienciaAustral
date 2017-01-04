using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciencia
{
    public partial class dlgBorrarBase : Form
    {
        public const string path = @"C:\Sistemas\Ciencia\";

        private List<string> _listaArchivos = null;

        public List<string> ListaArchivos { get { return _listaArchivos; } }

        public dlgBorrarBase()
        {
            InitializeComponent();
            listView1.View = View.Details;
            lblPath.Text = path;
        }

        private void dlgBorrarBase_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                di.Create();
            }
            FileInfo[] fi = di.GetFiles("*.mdb");
            listView1.BeginUpdate();

            listView1.SmallImageList = new ImageList();
            listView1.SmallImageList.ImageSize = new Size(16, 16);
            listView1.SmallImageList.TransparentColor = Color.Black;
            foreach (FileInfo f in fi)
            {
                ListViewItem item = new ListViewItem(" " + f.Name, 1);
                item.SubItems.Add(f.LastWriteTime.ToShortDateString());


                if (!listView1.SmallImageList.Images.ContainsKey(f.Extension))
                {
                    Icon ic = Icon.ExtractAssociatedIcon(f.FullName);
                    //Icon ic = FileEx
                    listView1.SmallImageList.Images.Add(f.Extension, ic);

                }
                item.ImageKey = f.Extension;
                this.listView1.Items.Add(item);
            }
            listView1.EndUpdate();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se borraran los archivos seleccionados.\n La oeración es irreversible. EstaSeguro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }
            if (listView1.SelectedItems.Count > 0)
            {
                _listaArchivos = new List<string>();
                foreach(ListViewItem item in listView1.SelectedItems)
                {
                    _listaArchivos.Add(item.SubItems[0].Text.Trim());
                }
            }
            DialogResult= DialogResult.OK;
        }

    }
}
