namespace Ciencia
{
    partial class frmProceso
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProceso));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblEstado = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnProceso = new System.Windows.Forms.ToolStripButton();
            this.btnCncel = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboModulo = new DrawFlat.FlatComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.lblTablas = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Proc_F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proc_ini_F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proc_fin_F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPromedio = new System.Windows.Forms.Label();
            this.lblProc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(397, 287);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(337, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(704, 297);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 13);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Proc_F,
            this.Usuario,
            this.Modulo,
            this.Maquina,
            this.Proc_ini_F,
            this.Proc_fin_F,
            this.Tiempo});
            this.DataGridView1.EnableHeadersVisualStyles = false;
            this.DataGridView1.Location = new System.Drawing.Point(1, 90);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(807, 149);
            this.DataGridView1.TabIndex = 26;
            this.DataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "Ultimo Proceso";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProceso,
            this.btnCncel,
            this.btnSalir});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(635, 9);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(124, 39);
            this.toolStrip1.TabIndex = 28;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnProceso
            // 
            this.btnProceso.AutoSize = false;
            this.btnProceso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnProceso.Image = global::Ciencia.Properties.Resources.Siguiente;
            this.btnProceso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProceso.Name = "btnProceso";
            this.btnProceso.Size = new System.Drawing.Size(24, 24);
            this.btnProceso.Text = "toolStripButton1";
            this.btnProceso.ToolTipText = "Procesar";
            this.btnProceso.Click += new System.EventHandler(this.btnProceso_Click);
            // 
            // btnCncel
            // 
            this.btnCncel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCncel.Image = ((System.Drawing.Image)(resources.GetObject("btnCncel.Image")));
            this.btnCncel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCncel.Name = "btnCncel";
            this.btnCncel.Size = new System.Drawing.Size(23, 36);
            this.btnCncel.Text = "toolStripButton1";
            this.btnCncel.ToolTipText = "Cancelar";
            this.btnCncel.Click += new System.EventHandler(this.btnCncel_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(34, 36);
            this.btnSalir.Text = "toolStripButton1";
            this.btnSalir.ToolTipText = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboModulo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(1, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 42);
            this.panel1.TabIndex = 29;
            // 
            // cboModulo
            // 
            this.cboModulo.Filtro = false;
            this.cboModulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboModulo.ForeColor = System.Drawing.Color.Navy;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(0, 18);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.ReadOnly = false;
            this.cboModulo.ReadOnlyBackColor = System.Drawing.SystemColors.Control;
            this.cboModulo.ReadOnlyFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModulo.ReadOnlyForeColor = System.Drawing.SystemColors.ControlText;
            this.cboModulo.Size = new System.Drawing.Size(166, 21);
            this.cboModulo.TabIndex = 12;
            this.cboModulo.SelectedIndexChanged += new System.EventHandler(this.cboModulo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Módulo";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.Location = new System.Drawing.Point(395, 315);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 13);
            this.lblProcesando.TabIndex = 30;
            this.lblProcesando.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTablas
            // 
            this.lblTablas.AutoSize = true;
            this.lblTablas.Location = new System.Drawing.Point(395, 264);
            this.lblTablas.Name = "lblTablas";
            this.lblTablas.Size = new System.Drawing.Size(0, 13);
            this.lblTablas.TabIndex = 31;
            this.lblTablas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Proc_F
            // 
            this.Proc_F.HeaderText = "F. Proc";
            this.Proc_F.Name = "Proc_F";
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            // 
            // Modulo
            // 
            this.Modulo.HeaderText = "Modulo";
            this.Modulo.Name = "Modulo";
            // 
            // Maquina
            // 
            this.Maquina.HeaderText = "Maquina";
            this.Maquina.Name = "Maquina";
            // 
            // Proc_ini_F
            // 
            this.Proc_ini_F.HeaderText = "Inicio Hora. Proc";
            this.Proc_ini_F.Name = "Proc_ini_F";
            this.Proc_ini_F.Width = 120;
            // 
            // Proc_fin_F
            // 
            this.Proc_fin_F.HeaderText = "Fin Hora. Proc";
            this.Proc_fin_F.Name = "Proc_fin_F";
            this.Proc_fin_F.Width = 120;
            // 
            // Tiempo
            // 
            this.Tiempo.HeaderText = "Tiempo";
            this.Tiempo.Name = "Tiempo";
            // 
            // lblPromedio
            // 
            this.lblPromedio.AutoSize = true;
            this.lblPromedio.Location = new System.Drawing.Point(53, 297);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(0, 13);
            this.lblPromedio.TabIndex = 32;
            this.lblPromedio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProc
            // 
            this.lblProc.AutoSize = true;
            this.lblProc.Location = new System.Drawing.Point(53, 264);
            this.lblProc.Name = "lblProc";
            this.lblProc.Size = new System.Drawing.Size(0, 13);
            this.lblProc.TabIndex = 33;
            this.lblProc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 343);
            this.ControlBox = false;
            this.Controls.Add(this.lblProc);
            this.Controls.Add(this.lblPromedio);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.lblTablas);
            this.Controls.Add(this.lblProcesando);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmProceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProceso_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblEstado;
        internal System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnProceso;
        private System.Windows.Forms.ToolStripButton btnCncel;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private DrawFlat.FlatComboBox cboModulo;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.Label lblTablas;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proc_F;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Maquina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proc_ini_F;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proc_fin_F;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiempo;
        private System.Windows.Forms.Label lblPromedio;
        private System.Windows.Forms.Label lblProc;
    }
}

