namespace Ciencia
{
    partial class frmComplemento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComplemento));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblModulo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSel = new DrawFlat.FlatComboBox();
            this.cboTabla = new DrawFlat.FlatComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TablaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Campo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filtro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValoresACero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tabla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquivId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerValor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.btnBorrarTodos = new System.Windows.Forms.ToolStripButton();
            this.btnBorrarLinea = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.lblModulo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 43);
            this.panel1.TabIndex = 1;
            // 
            // lblModulo
            // 
            this.lblModulo.BackColor = System.Drawing.SystemColors.Window;
            this.lblModulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModulo.Location = new System.Drawing.Point(0, 20);
            this.lblModulo.Margin = new System.Windows.Forms.Padding(0);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(200, 20);
            this.lblModulo.TabIndex = 25;
            this.lblModulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(0, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 19);
            this.label3.TabIndex = 24;
            this.label3.Text = "Modulo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(203, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(439, 34);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione campos que desea pasar a estadística (para crear tabla))";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cboSel);
            this.panel2.Controls.Add(this.cboTabla);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.Maroon;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 40);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(483, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 37);
            this.label2.TabIndex = 12;
            this.label2.Text = "Doble clik para ver lista de valores";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSel
            // 
            this.cboSel.Filtro = false;
            this.cboSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSel.ForeColor = System.Drawing.Color.Navy;
            this.cboSel.FormattingEnabled = true;
            this.cboSel.Location = new System.Drawing.Point(331, 18);
            this.cboSel.Name = "cboSel";
            this.cboSel.ReadOnly = false;
            this.cboSel.ReadOnlyBackColor = System.Drawing.SystemColors.Control;
            this.cboSel.ReadOnlyFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSel.ReadOnlyForeColor = System.Drawing.SystemColors.ControlText;
            this.cboSel.Size = new System.Drawing.Size(152, 21);
            this.cboSel.TabIndex = 11;
            this.cboSel.SelectedIndexChanged += new System.EventHandler(this.cboSel_SelectedIndexChanged);
            // 
            // cboTabla
            // 
            this.cboTabla.Filtro = false;
            this.cboTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTabla.ForeColor = System.Drawing.Color.Navy;
            this.cboTabla.FormattingEnabled = true;
            this.cboTabla.Location = new System.Drawing.Point(0, 18);
            this.cboTabla.Name = "cboTabla";
            this.cboTabla.ReadOnly = false;
            this.cboTabla.ReadOnlyBackColor = System.Drawing.SystemColors.Control;
            this.cboTabla.ReadOnlyFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTabla.ReadOnlyForeColor = System.Drawing.SystemColors.ControlText;
            this.cboTabla.Size = new System.Drawing.Size(331, 21);
            this.cboTabla.TabIndex = 10;
            this.cboTabla.SelectedIndexChanged += new System.EventHandler(this.cboTabla_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(331, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "Selección";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(331, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tabla";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeight = 34;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TablaId,
            this.Campo,
            this.Sel,
            this.Tipo,
            this.Valor,
            this.Filtro,
            this.ValoresACero,
            this.Tabla,
            this.EquivId,
            this.VerValor});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 26;
            this.dataGridView1.Size = new System.Drawing.Size(769, 390);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
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
            this.Campo.Width = 320;
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
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightCyan;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle4;
            this.Valor.Frozen = true;
            this.Valor.HeaderText = "Valores a Cero";
            this.Valor.Name = "Valor";
            this.Valor.Width = 200;
            // 
            // Filtro
            // 
            this.Filtro.Frozen = true;
            this.Filtro.HeaderText = "Filtro";
            this.Filtro.Name = "Filtro";
            this.Filtro.Visible = false;
            // 
            // ValoresACero
            // 
            this.ValoresACero.Frozen = true;
            this.ValoresACero.HeaderText = "ValoresACero";
            this.ValoresACero.Name = "ValoresACero";
            this.ValoresACero.Visible = false;
            this.ValoresACero.Width = 200;
            // 
            // Tabla
            // 
            this.Tabla.Frozen = true;
            this.Tabla.HeaderText = "Tabla";
            this.Tabla.Name = "Tabla";
            this.Tabla.Visible = false;
            // 
            // EquivId
            // 
            this.EquivId.Frozen = true;
            this.EquivId.HeaderText = "EquivId";
            this.EquivId.Name = "EquivId";
            this.EquivId.Visible = false;
            // 
            // VerValor
            // 
            this.VerValor.Frozen = true;
            this.VerValor.HeaderText = "Ver Valores";
            this.VerValor.Name = "VerValor";
            this.VerValor.ReadOnly = true;
            this.VerValor.Width = 60;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(441, 487);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(87, 23);
            this.btnProcesar.TabIndex = 7;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArchivo.Location = new System.Drawing.Point(85, 488);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(238, 20);
            this.txtArchivo.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(6, 488);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 20);
            this.label11.TabIndex = 13;
            this.label11.Text = "Base de datos";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(342, 487);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(87, 23);
            this.btnRegresar.TabIndex = 16;
            this.btnRegresar.Text = "<< Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Enabled = false;
            this.btnExportar.Location = new System.Drawing.Point(538, 487);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(89, 23);
            this.btnExportar.TabIndex = 15;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar,
            this.btnBorrarTodos,
            this.btnBorrarLinea,
            this.btnSalir});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(623, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(137, 39);
            this.toolStrip1.TabIndex = 26;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSize = false;
            this.btnAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(24, 24);
            this.btnAgregar.Text = "toolStripButton1";
            this.btnAgregar.ToolTipText = "Agregar Elemento";
            this.btnAgregar.Visible = false;
            // 
            // btnBorrarTodos
            // 
            this.btnBorrarTodos.AutoSize = false;
            this.btnBorrarTodos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBorrarTodos.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrarTodos.Image")));
            this.btnBorrarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBorrarTodos.Name = "btnBorrarTodos";
            this.btnBorrarTodos.Size = new System.Drawing.Size(24, 24);
            this.btnBorrarTodos.Text = "btnBorrarTodos";
            this.btnBorrarTodos.ToolTipText = "Borrar Todos";
            this.btnBorrarTodos.Visible = false;
            // 
            // btnBorrarLinea
            // 
            this.btnBorrarLinea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBorrarLinea.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrarLinea.Image")));
            this.btnBorrarLinea.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBorrarLinea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBorrarLinea.Name = "btnBorrarLinea";
            this.btnBorrarLinea.Size = new System.Drawing.Size(28, 36);
            this.btnBorrarLinea.Text = "toolStripButton1";
            this.btnBorrarLinea.Visible = false;
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
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmComplemento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 517);
            this.ControlBox = false;
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.txtArchivo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmComplemento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmComplemento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmComplemento_FormClosing);
            this.Load += new System.EventHandler(this.frmComplemento_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DrawFlat.FlatComboBox cboSel;
        private DrawFlat.FlatComboBox cboTabla;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.DataGridViewTextBoxColumn TablaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filtro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValoresACero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquivId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VerValor;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.ToolStripButton btnBorrarTodos;
        private System.Windows.Forms.ToolStripButton btnBorrarLinea;
        private System.Windows.Forms.ToolStripButton btnSalir;
    }
}