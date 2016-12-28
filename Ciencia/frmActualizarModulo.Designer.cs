namespace Ciencia
{
    partial class frmActualizarModulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActualizarModulo));
            this.cboModulo = new DrawFlat.FlatComboBox();
            this.cboTabla = new DrawFlat.FlatComboBox();
            this.label147 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this._btnValidar = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this._btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboModulo
            // 
            this.cboModulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboModulo.DisplayMember = "TipoCir";
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.Filtro = true;
            this.cboModulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(26, 38);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.ReadOnly = false;
            this.cboModulo.ReadOnlyBackColor = System.Drawing.SystemColors.Control;
            this.cboModulo.ReadOnlyFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModulo.ReadOnlyForeColor = System.Drawing.SystemColors.ControlText;
            this.cboModulo.Size = new System.Drawing.Size(190, 21);
            this.cboModulo.TabIndex = 5;
            this.cboModulo.SelectedIndexChanged += new System.EventHandler(this.cboModulo_SelectedIndexChanged);
            // 
            // cboTabla
            // 
            this.cboTabla.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboTabla.DisplayMember = "TipoCir";
            this.cboTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTabla.Filtro = true;
            this.cboTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboTabla.FormattingEnabled = true;
            this.cboTabla.Location = new System.Drawing.Point(222, 38);
            this.cboTabla.Name = "cboTabla";
            this.cboTabla.ReadOnly = false;
            this.cboTabla.ReadOnlyBackColor = System.Drawing.SystemColors.Control;
            this.cboTabla.ReadOnlyFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTabla.ReadOnlyForeColor = System.Drawing.SystemColors.ControlText;
            this.cboTabla.Size = new System.Drawing.Size(190, 21);
            this.cboTabla.TabIndex = 6;
            this.cboTabla.SelectedIndexChanged += new System.EventHandler(this.cboTabla_SelectedIndexChanged);
            // 
            // label147
            // 
            this.label147.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label147.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label147.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label147.ForeColor = System.Drawing.Color.Maroon;
            this.label147.Location = new System.Drawing.Point(26, 15);
            this.label147.Margin = new System.Windows.Forms.Padding(0);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(190, 20);
            this.label147.TabIndex = 48;
            this.label147.Tag = "TORSIDA";
            this.label147.Text = "    Modulo :";
            this.label147.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(222, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 20);
            this.label1.TabIndex = 49;
            this.label1.Tag = "TORSIDA";
            this.label1.Text = "    Tabla :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(26, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(918, 433);
            this.tabControl1.TabIndex = 50;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(910, 407);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Campos Cargados";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DataGridView1
            // 
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(5, 7);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(900, 393);
            this.DataGridView1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(910, 407);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Campos No Cargados";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(5, 7);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(900, 393);
            this.dataGridView2.TabIndex = 3;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnValidar,
            this._btnCancelar,
            this._btnGuardar});
            this.toolStrip2.Location = new System.Drawing.Point(724, 507);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(118, 31);
            this.toolStrip2.TabIndex = 51;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // _btnValidar
            // 
            this._btnValidar.AutoSize = false;
            this._btnValidar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnValidar.Enabled = false;
            this._btnValidar.Image = ((System.Drawing.Image)(resources.GetObject("_btnValidar.Image")));
            this._btnValidar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._btnValidar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnValidar.Name = "_btnValidar";
            this._btnValidar.Size = new System.Drawing.Size(28, 28);
            this._btnValidar.Text = "toolStripButton9";
            this._btnValidar.ToolTipText = "Validar";
            // 
            // _btnCancelar
            // 
            this._btnCancelar.AutoSize = false;
            this._btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnCancelar.Enabled = false;
            this._btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("_btnCancelar.Image")));
            this._btnCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(28, 28);
            this._btnCancelar.Text = "toolStripButton10";
            this._btnCancelar.ToolTipText = "Cancelar";
            this._btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // _btnGuardar
            // 
            this._btnGuardar.AutoSize = false;
            this._btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnGuardar.Enabled = false;
            this._btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("_btnGuardar.Image")));
            this._btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(28, 28);
            this._btnGuardar.Text = "toolStripButton11";
            this._btnGuardar.ToolTipText = "Guardar";
            // 
            // frmActualizarModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 547);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label147);
            this.Controls.Add(this.cboTabla);
            this.Controls.Add(this.cboModulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmActualizarModulo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmActualizarModulo";
            this.Load += new System.EventHandler(this.frmActualizarModulo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DrawFlat.FlatComboBox cboModulo;
        internal DrawFlat.FlatComboBox cboTabla;
        internal System.Windows.Forms.Label label147;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton _btnValidar;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
        private System.Windows.Forms.ToolStripButton _btnGuardar;
    }
}