namespace Ciencia
{
    partial class frmSeguimientoAnualHemo
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
            this.lblSelMed = new System.Windows.Forms.Label();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSelMed
            // 
            this.lblSelMed.BackColor = System.Drawing.SystemColors.Window;
            this.lblSelMed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelMed.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelMed.ForeColor = System.Drawing.Color.Navy;
            this.lblSelMed.Location = new System.Drawing.Point(0, 24);
            this.lblSelMed.Margin = new System.Windows.Forms.Padding(0);
            this.lblSelMed.Name = "lblSelMed";
            this.lblSelMed.Size = new System.Drawing.Size(462, 50);
            this.lblSelMed.TabIndex = 4;
            // 
            // txtArchivo
            // 
            this.txtArchivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArchivo.Location = new System.Drawing.Point(80, 93);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(268, 20);
            this.txtArchivo.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(0, 93);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "Base de datos";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(370, 92);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(87, 23);
            this.btnProcesar.TabIndex = 15;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Selección:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSeguimientoAnualHemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 128);
            this.Controls.Add(this.txtArchivo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.lblSelMed);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSeguimientoAnualHemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSeguimientoAnualHemo";
            this.Load += new System.EventHandler(this.frmSeguimientoAnualHemo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelMed;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Label label1;
    }
}