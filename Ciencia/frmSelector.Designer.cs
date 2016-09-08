namespace Ciencia
{
    partial class frmSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelector));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.btnBorrarTodos = new System.Windows.Forms.ToolStripButton();
            this.btnBorrarLinea = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.lblSelMed = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboAnd = new DrawFlat.FlatComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboDato = new DrawFlat.FlatComboBox();
            this.cboOperador = new DrawFlat.FlatComboBox();
            this.cboCampo = new DrawFlat.FlatComboBox();
            this.cboTabla = new DrawFlat.FlatComboBox();
            this.icbaTextBox1 = new icbaTextBox.icbaTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalReg = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDato = new System.Windows.Forms.MaskedTextBox();
            this.cboModulo = new DrawFlat.FlatComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.stLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.lblSelMed);
            this.panel1.Controls.Add(this.lblHasta);
            this.panel1.Controls.Add(this.lblDesde);
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 54);
            this.panel1.TabIndex = 0;
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
            this.toolStrip1.Location = new System.Drawing.Point(495, 4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(137, 39);
            this.toolStrip1.TabIndex = 4;
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
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
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
            this.btnBorrarTodos.Click += new System.EventHandler(this.btnBorrarTodos_Click);
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
            this.btnBorrarLinea.Click += new System.EventHandler(this.btnBorrarLinea_Click);
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
            // lblSelMed
            // 
            this.lblSelMed.BackColor = System.Drawing.SystemColors.Window;
            this.lblSelMed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelMed.ForeColor = System.Drawing.Color.Navy;
            this.lblSelMed.Location = new System.Drawing.Point(156, 2);
            this.lblSelMed.Margin = new System.Windows.Forms.Padding(0);
            this.lblSelMed.Name = "lblSelMed";
            this.lblSelMed.Size = new System.Drawing.Size(339, 50);
            this.lblSelMed.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.BackColor = System.Drawing.SystemColors.Window;
            this.lblHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHasta.ForeColor = System.Drawing.Color.Navy;
            this.lblHasta.Location = new System.Drawing.Point(79, 27);
            this.lblHasta.Margin = new System.Windows.Forms.Padding(0);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(77, 25);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDesde
            // 
            this.lblDesde.BackColor = System.Drawing.SystemColors.Window;
            this.lblDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDesde.ForeColor = System.Drawing.Color.Navy;
            this.lblDesde.Location = new System.Drawing.Point(2, 27);
            this.lblDesde.Margin = new System.Windows.Forms.Padding(0);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(77, 25);
            this.lblDesde.TabIndex = 1;
            this.lblDesde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.lblUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUsuario.ForeColor = System.Drawing.Color.Navy;
            this.lblUsuario.Location = new System.Drawing.Point(2, 2);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(154, 26);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboAnd);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.cboDato);
            this.panel2.Controls.Add(this.cboOperador);
            this.panel2.Controls.Add(this.cboCampo);
            this.panel2.Controls.Add(this.cboTabla);
            this.panel2.Controls.Add(this.icbaTextBox1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lblTotalReg);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtDato);
            this.panel2.Controls.Add(this.cboModulo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.Maroon;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 61);
            this.panel2.TabIndex = 2;
            // 
            // cboAnd
            // 
            this.cboAnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnd.Filtro = false;
            this.cboAnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAnd.ForeColor = System.Drawing.Color.Navy;
            this.cboAnd.FormattingEnabled = true;
            this.cboAnd.Location = new System.Drawing.Point(25, 37);
            this.cboAnd.Name = "cboAnd";
            this.cboAnd.ReadOnly = false;
            this.cboAnd.ReadOnlyBackColor = System.Drawing.SystemColors.Control;
            this.cboAnd.ReadOnlyFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAnd.ReadOnlyForeColor = System.Drawing.SystemColors.ControlText;
            this.cboAnd.Size = new System.Drawing.Size(55, 21);
            this.cboAnd.TabIndex = 17;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Location = new System.Drawing.Point(564, 19);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 19);
            this.label20.TabIndex = 14;
            this.label20.Text = ")";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboDato
            // 
            this.cboDato.Filtro = false;
            this.cboDato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDato.ForeColor = System.Drawing.Color.Navy;
            this.cboDato.FormattingEnabled = true;
            this.cboDato.Location = new System.Drawing.Point(425, 37);
            this.cboDato.Name = "cboDato";
            this.cboDato.ReadOnly = false;
            this.cboDato.ReadOnlyBackColor = System.Drawing.SystemColors.Control;
            this.cboDato.ReadOnlyFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDato.ReadOnlyForeColor = System.Drawing.SystemColors.ControlText;
            this.cboDato.Size = new System.Drawing.Size(165, 21);
            this.cboDato.TabIndex = 13;
            // 
            // cboOperador
            // 
            this.cboOperador.Filtro = false;
            this.cboOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboOperador.ForeColor = System.Drawing.Color.Navy;
            this.cboOperador.FormattingEnabled = true;
            this.cboOperador.Location = new System.Drawing.Point(347, 37);
            this.cboOperador.Name = "cboOperador";
            this.cboOperador.ReadOnly = false;
            this.cboOperador.ReadOnlyBackColor = System.Drawing.SystemColors.Control;
            this.cboOperador.ReadOnlyFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOperador.ReadOnlyForeColor = System.Drawing.SystemColors.ControlText;
            this.cboOperador.Size = new System.Drawing.Size(81, 21);
            this.cboOperador.TabIndex = 12;
            // 
            // cboCampo
            // 
            this.cboCampo.Filtro = false;
            this.cboCampo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCampo.ForeColor = System.Drawing.Color.Navy;
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(188, 37);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.ReadOnly = false;
            this.cboCampo.ReadOnlyBackColor = System.Drawing.SystemColors.Control;
            this.cboCampo.ReadOnlyFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCampo.ReadOnlyForeColor = System.Drawing.SystemColors.ControlText;
            this.cboCampo.Size = new System.Drawing.Size(160, 21);
            this.cboCampo.TabIndex = 11;
            this.cboCampo.SelectedIndexChanged += new System.EventHandler(this.cboCampo_SelectedIndexChanged);
            // 
            // cboTabla
            // 
            this.cboTabla.Filtro = false;
            this.cboTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTabla.ForeColor = System.Drawing.Color.Navy;
            this.cboTabla.FormattingEnabled = true;
            this.cboTabla.Location = new System.Drawing.Point(79, 37);
            this.cboTabla.Name = "cboTabla";
            this.cboTabla.ReadOnly = false;
            this.cboTabla.ReadOnlyBackColor = System.Drawing.SystemColors.Control;
            this.cboTabla.ReadOnlyFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTabla.ReadOnlyForeColor = System.Drawing.SystemColors.ControlText;
            this.cboTabla.Size = new System.Drawing.Size(110, 21);
            this.cboTabla.TabIndex = 10;
            this.cboTabla.SelectedIndexChanged += new System.EventHandler(this.cboTabla_SelectedIndexChanged);
            // 
            // icbaTextBox1
            // 
            this.icbaTextBox1.ForeColor = System.Drawing.Color.Navy;
            this.icbaTextBox1.Location = new System.Drawing.Point(0, 37);
            this.icbaTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.icbaTextBox1.Name = "icbaTextBox1";
            this.icbaTextBox1.Size = new System.Drawing.Size(26, 20);
            this.icbaTextBox1.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(426, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 19);
            this.label10.TabIndex = 7;
            this.label10.Text = "Dato";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalReg
            // 
            this.lblTotalReg.BackColor = System.Drawing.SystemColors.Window;
            this.lblTotalReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalReg.Location = new System.Drawing.Point(485, 19);
            this.lblTotalReg.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalReg.Name = "lblTotalReg";
            this.lblTotalReg.Size = new System.Drawing.Size(80, 19);
            this.lblTotalReg.TabIndex = 6;
            this.lblTotalReg.Text = "label9";
            this.lblTotalReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(347, 19);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 19);
            this.label8.TabIndex = 4;
            this.label8.Text = "Operador";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(188, 19);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "Campo";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(79, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tabla";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(25, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "AND/OR";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(0, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "(";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDato
            // 
            this.txtDato.ForeColor = System.Drawing.Color.Navy;
            this.txtDato.Location = new System.Drawing.Point(426, 37);
            this.txtDato.Mask = "00/00/0000";
            this.txtDato.Name = "txtDato";
            this.txtDato.Size = new System.Drawing.Size(139, 20);
            this.txtDato.TabIndex = 16;
            this.txtDato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDato.ValidatingType = typeof(System.DateTime);
            // 
            // cboModulo
            // 
            this.cboModulo.Filtro = false;
            this.cboModulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboModulo.ForeColor = System.Drawing.Color.Navy;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(109, 0);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.ReadOnly = false;
            this.cboModulo.ReadOnlyBackColor = System.Drawing.SystemColors.Control;
            this.cboModulo.ReadOnlyFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModulo.ReadOnlyForeColor = System.Drawing.SystemColors.ControlText;
            this.cboModulo.Size = new System.Drawing.Size(160, 21);
            this.cboModulo.TabIndex = 19;
            this.cboModulo.SelectedIndexChanged += new System.EventHandler(this.cboModulo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Modulo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
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
            this.Nro,
            this.Seleccion,
            this.Cant,
            this.Total});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 26;
            this.dataGridView1.Size = new System.Drawing.Size(632, 318);
            this.dataGridView1.TabIndex = 3;
            // 
            // Nro
            // 
            this.Nro.HeaderText = "Nro";
            this.Nro.Name = "Nro";
            this.Nro.Width = 30;
            // 
            // Seleccion
            // 
            this.Seleccion.HeaderText = "Selección Médica";
            this.Seleccion.Name = "Seleccion";
            this.Seleccion.Width = 350;
            // 
            // Cant
            // 
            this.Cant.FillWeight = 90F;
            this.Cant.HeaderText = "Cant. (Sel.)";
            this.Cant.Name = "Cant";
            this.Cant.Width = 80;
            // 
            // Total
            // 
            this.Total.HeaderText = "(Total)";
            this.Total.Name = "Total";
            this.Total.Width = 80;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Controls.Add(this.txtArchivo);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.ForeColor = System.Drawing.Color.Maroon;
            this.panel3.Location = new System.Drawing.Point(0, 469);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(635, 40);
            this.panel3.TabIndex = 15;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(450, 7);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(115, 26);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Siguiente >>";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArchivo.Location = new System.Drawing.Point(95, 10);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(333, 20);
            this.txtArchivo.TabIndex = 12;
            this.txtArchivo.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(3, 10);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "Base de datos";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar1,
            this.stLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 509);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(635, 22);
            this.statusStrip1.TabIndex = 16;
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
            // frmSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 531);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmSelector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSelector_FormClosing);
            this.Load += new System.EventHandler(this.frmSelector_Load);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.ToolStripButton btnBorrarTodos;
        private System.Windows.Forms.Label lblSelMed;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label20;
        private DrawFlat.FlatComboBox cboDato;
        private DrawFlat.FlatComboBox cboOperador;
        private DrawFlat.FlatComboBox cboTabla;
        private icbaTextBox.icbaTextBox icbaTextBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalReg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtDato;
        private DrawFlat.FlatComboBox cboAnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.ToolStripButton btnBorrarLinea;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel stLabel;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private DrawFlat.FlatComboBox cboModulo;
        private System.Windows.Forms.Label label1;
        private DrawFlat.FlatComboBox cboCampo;
    }
}