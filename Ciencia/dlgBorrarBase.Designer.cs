namespace Ciencia
{
    partial class dlgBorrarBase
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
            this.btmCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btmCancel
            // 
            this.btmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btmCancel.Location = new System.Drawing.Point(390, 236);
            this.btmCancel.Name = "btmCancel";
            this.btmCancel.Size = new System.Drawing.Size(70, 25);
            this.btmCancel.TabIndex = 11;
            this.btmCancel.Text = "Cancelar";
            this.btmCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(309, 236);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 25);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Borrar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nombre,
            this.Fecha});
            this.listView1.Location = new System.Drawing.Point(5, 68);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(454, 152);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Nombre
            // 
            this.Nombre.Text = "Nombre";
            this.Nombre.Width = 200;
            // 
            // Fecha
            // 
            this.Fecha.Text = "Fecha de modificación";
            this.Fecha.Width = 80;
            // 
            // lblPath
            // 
            this.lblPath.BackColor = System.Drawing.SystemColors.Window;
            this.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPath.Location = new System.Drawing.Point(5, 38);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(454, 22);
            this.lblPath.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(53, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Seleccione los archivos que desea borrar";
            // 
            // dlgBorrarBase
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btmCancel;
            this.ClientSize = new System.Drawing.Size(465, 271);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btmCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lblPath);
            this.Name = "dlgBorrarBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dlgBorrarBase";
            this.Load += new System.EventHandler(this.dlgBorrarBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btmCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Nombre;
        private System.Windows.Forms.ColumnHeader Fecha;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label label1;
    }
}