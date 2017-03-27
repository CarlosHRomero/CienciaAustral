namespace Ciencia
{
    partial class frmEvolucion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.stLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboTabla = new DrawFlat.FlatComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSolapa = new DrawFlat.FlatComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblModulo = new System.Windows.Forms.Label();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.TablaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Campo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Filtro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tabla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquivId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Solapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelEvol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TablaId,
            this.Campo,
            this.Sel,
            this.Tipo,
            this.Valor,
            this.Filtro,
            this.Tabla,
            this.EquivId,
            this.Solapa,
            this.SelEvol});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 26;
            this.dataGridView1.Size = new System.Drawing.Size(781, 398);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(461, 499);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(89, 23);
            this.btnProcesar.TabIndex = 7;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar1,
            this.stLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 532);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(793, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // stLabel
            // 
            this.stLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stLabel.Name = "stLabel";
            this.stLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(668, 34);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione campos que desea pasar a estadística (para crear tabla))";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 43);
            this.panel1.TabIndex = 1;
            // 
            // cboTabla
            // 
            this.cboTabla.Filtro = false;
            this.cboTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTabla.ForeColor = System.Drawing.Color.Navy;
            this.cboTabla.FormattingEnabled = true;
            this.cboTabla.Location = new System.Drawing.Point(202, 64);
            this.cboTabla.Name = "cboTabla";
            this.cboTabla.ReadOnly = false;
            this.cboTabla.ReadOnlyBackColor = System.Drawing.SystemColors.Control;
            this.cboTabla.ReadOnlyFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTabla.ReadOnlyForeColor = System.Drawing.SystemColors.ControlText;
            this.cboTabla.Size = new System.Drawing.Size(200, 21);
            this.cboTabla.TabIndex = 20;
            this.cboTabla.SelectedIndexChanged += new System.EventHandler(this.cboTabla_SelectedIndexChanged_1);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(401, 46);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 19);
            this.label7.TabIndex = 19;
            this.label7.Text = "Solapa";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(202, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = "Tabla";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSolapa
            // 
            this.cboSolapa.Filtro = false;
            this.cboSolapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSolapa.ForeColor = System.Drawing.Color.Navy;
            this.cboSolapa.FormattingEnabled = true;
            this.cboSolapa.Location = new System.Drawing.Point(401, 64);
            this.cboSolapa.Name = "cboSolapa";
            this.cboSolapa.ReadOnly = false;
            this.cboSolapa.ReadOnlyBackColor = System.Drawing.SystemColors.Control;
            this.cboSolapa.ReadOnlyFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSolapa.ReadOnlyForeColor = System.Drawing.SystemColors.ControlText;
            this.cboSolapa.Size = new System.Drawing.Size(200, 21);
            this.cboSolapa.TabIndex = 21;
            this.cboSolapa.SelectedIndexChanged += new System.EventHandler(this.cboSolapa_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Modulo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblModulo
            // 
            this.lblModulo.BackColor = System.Drawing.SystemColors.Window;
            this.lblModulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModulo.Location = new System.Drawing.Point(3, 64);
            this.lblModulo.Margin = new System.Windows.Forms.Padding(0);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(200, 20);
            this.lblModulo.TabIndex = 23;
            this.lblModulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtArchivo
            // 
            this.txtArchivo.BackColor = System.Drawing.SystemColors.Window;
            this.txtArchivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArchivo.Location = new System.Drawing.Point(107, 502);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(333, 20);
            this.txtArchivo.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(15, 502);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "Base de datos";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExportar
            // 
            this.btnExportar.Enabled = false;
            this.btnExportar.Location = new System.Drawing.Point(582, 499);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(89, 23);
            this.btnExportar.TabIndex = 26;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // TablaId
            // 
            this.TablaId.Frozen = true;
            this.TablaId.HeaderText = "TablaId";
            this.TablaId.Name = "TablaId";
            this.TablaId.Visible = false;
            // 
            // Campo
            // 
            this.Campo.Frozen = true;
            this.Campo.HeaderText = "Campo Ciencia";
            this.Campo.Name = "Campo";
            this.Campo.Width = 290;
            // 
            // Sel
            // 
            this.Sel.FillWeight = 50F;
            this.Sel.Frozen = true;
            this.Sel.HeaderText = "Sel.";
            this.Sel.Name = "Sel";
            this.Sel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Sel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Sel.Width = 60;
            // 
            // Tipo
            // 
            this.Tipo.Frozen = true;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Width = 80;
            // 
            // Valor
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.Valor.Frozen = true;
            this.Valor.HeaderText = "Valor Requerido";
            this.Valor.Name = "Valor";
            this.Valor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Filtro
            // 
            this.Filtro.Frozen = true;
            this.Filtro.HeaderText = "Filtro";
            this.Filtro.Name = "Filtro";
            this.Filtro.Visible = false;
            // 
            // Tabla
            // 
            this.Tabla.Frozen = true;
            this.Tabla.HeaderText = "Tabla";
            this.Tabla.Name = "Tabla";
            // 
            // EquivId
            // 
            this.EquivId.Frozen = true;
            this.EquivId.HeaderText = "EquivId";
            this.EquivId.Name = "EquivId";
            this.EquivId.Visible = false;
            // 
            // Solapa
            // 
            this.Solapa.Frozen = true;
            this.Solapa.HeaderText = "Solapa";
            this.Solapa.Name = "Solapa";
            // 
            // SelEvol
            // 
            this.SelEvol.Frozen = true;
            this.SelEvol.HeaderText = "SelEvol";
            this.SelEvol.Name = "SelEvol";
            this.SelEvol.Visible = false;
            // 
            // frmEvolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 554);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.txtArchivo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblModulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboSolapa);
            this.Controls.Add(this.cboTabla);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "frmEvolucion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmEvolucion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEvolucion_FormClosing);
            this.Load += new System.EventHandler(this.frmEvolucion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel stLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private DrawFlat.FlatComboBox cboTabla;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private DrawFlat.FlatComboBox cboSolapa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridViewTextBoxColumn TablaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewLinkColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filtro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquivId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Solapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelEvol;
    }
}