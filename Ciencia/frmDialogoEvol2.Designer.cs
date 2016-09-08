namespace Ciencia
{
    partial class frmDialogoEvol2
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPromedio = new System.Windows.Forms.CheckBox();
            this.chkMaximo = new System.Windows.Forms.CheckBox();
            this.chkminimo = new System.Windows.Forms.CheckBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione el valor que desea guardar";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPromedio);
            this.groupBox1.Controls.Add(this.chkMaximo);
            this.groupBox1.Controls.Add(this.chkminimo);
            this.groupBox1.Location = new System.Drawing.Point(9, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 108);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // chkPromedio
            // 
            this.chkPromedio.AutoSize = true;
            this.chkPromedio.ForeColor = System.Drawing.Color.Maroon;
            this.chkPromedio.Location = new System.Drawing.Point(12, 81);
            this.chkPromedio.Name = "chkPromedio";
            this.chkPromedio.Size = new System.Drawing.Size(96, 17);
            this.chkPromedio.TabIndex = 2;
            this.chkPromedio.Text = "Valor promedio";
            this.chkPromedio.UseVisualStyleBackColor = true;
            // 
            // chkMaximo
            // 
            this.chkMaximo.AutoSize = true;
            this.chkMaximo.ForeColor = System.Drawing.Color.Maroon;
            this.chkMaximo.Location = new System.Drawing.Point(12, 48);
            this.chkMaximo.Name = "chkMaximo";
            this.chkMaximo.Size = new System.Drawing.Size(88, 17);
            this.chkMaximo.TabIndex = 1;
            this.chkMaximo.Text = "Valor máximo";
            this.chkMaximo.UseVisualStyleBackColor = true;
            // 
            // chkminimo
            // 
            this.chkminimo.AutoSize = true;
            this.chkminimo.ForeColor = System.Drawing.Color.Maroon;
            this.chkminimo.Location = new System.Drawing.Point(12, 15);
            this.chkminimo.Name = "chkminimo";
            this.chkminimo.Size = new System.Drawing.Size(87, 17);
            this.chkminimo.TabIndex = 0;
            this.chkminimo.Text = "Valor mínimo";
            this.chkminimo.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(145, 87);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(96, 27);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(145, 51);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(96, 27);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmDialogoEvol2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 149);
            this.ControlBox = false;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDialogoEvol2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ciencia -frmDialogoEvol2";
            this.Load += new System.EventHandler(this.frmDialogoEvol2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPromedio;
        private System.Windows.Forms.CheckBox chkMaximo;
        private System.Windows.Forms.CheckBox chkminimo;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
    }
}