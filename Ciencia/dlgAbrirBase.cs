using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciencia
{
    public partial class dlgAbrirBase : Form
    {
        string path = @"C:\Sistemas\Ciencia\";
        public string FileName { get; set; }
        public dlgAbrirBase()
        {
            InitializeComponent();
            listView1.View = View.Details;
            //listView1.ci
            //listView1.Columns.Add("Nombre", -2, HorizontalAlignment.Left);
            //listView1.Columns.Add("Fecha de modificación", -2, HorizontalAlignment.Left);
            lblPath.Text = path;
        }

        private void dlgAbrirBase_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            DirectoryInfo di = new DirectoryInfo(path);
            if(!di.Exists)
            {
                di.Create();
            }
            FileInfo[] fi = di.GetFiles("*.mdb");
            listView1.BeginUpdate();
           
            listView1.SmallImageList = new ImageList();
            listView1.SmallImageList.ImageSize = new Size(16, 16);
            listView1.SmallImageList.TransparentColor = Color.Black;
            foreach(FileInfo f in fi )
            {
                ListViewItem item = new ListViewItem(" "+f.Name, 1);
                item.SubItems.Add(f.LastWriteTime.ToShortDateString());
                
                
                if(!listView1.SmallImageList.Images.ContainsKey(f.Extension))
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
            if (!string.IsNullOrEmpty(txtfileName.Text.Trim()))
            {
                FileName = path.Trim() + txtfileName.Text.Trim();
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                txtfileName.Text= listView1.SelectedItems[0].SubItems[0].Text;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            btnOk.PerformClick();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
