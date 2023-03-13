namespace Proyecto_Adesco
{
    partial class Reporte
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
            this.picRegresar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picRegresar)).BeginInit();
            this.SuspendLayout();
            // 
            // picRegresar
            // 
            this.picRegresar.Image = global::Proyecto_Adesco.Properties.Resources.regresar1;
            this.picRegresar.Location = new System.Drawing.Point(9, 10);
            this.picRegresar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picRegresar.Name = "picRegresar";
            this.picRegresar.Size = new System.Drawing.Size(30, 28);
            this.picRegresar.TabIndex = 16;
            this.picRegresar.TabStop = false;
            this.picRegresar.Click += new System.EventHandler(this.picRegresar_Click);
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.picRegresar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Reporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Reporte_FormClosed);
            this.Load += new System.EventHandler(this.Reporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picRegresar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picRegresar;
    }
}