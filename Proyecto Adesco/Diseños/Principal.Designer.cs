namespace Proyecto_Adesco
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panelbarralateral = new System.Windows.Forms.Panel();
            this.Beneficiarios = new System.Windows.Forms.Button();
            this.Pendientes = new System.Windows.Forms.Button();
            this.Reporte = new System.Windows.Forms.Button();
            this.Recibo = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelhijo = new System.Windows.Forms.Panel();
            this.rjButton1 = new Proyecto_Adesco.RJButton();
            this.rjButton3 = new Proyecto_Adesco.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panelbarralateral.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Inter Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Inter Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(137, 443);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = ".";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(65, 13);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(164, 73);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 29;
            this.pictureBox5.TabStop = false;
            // 
            // panelbarralateral
            // 
            this.panelbarralateral.AutoScroll = true;
            this.panelbarralateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelbarralateral.Controls.Add(this.rjButton1);
            this.panelbarralateral.Controls.Add(this.Beneficiarios);
            this.panelbarralateral.Controls.Add(this.label2);
            this.panelbarralateral.Controls.Add(this.label1);
            this.panelbarralateral.Controls.Add(this.Pendientes);
            this.panelbarralateral.Controls.Add(this.rjButton3);
            this.panelbarralateral.Controls.Add(this.Reporte);
            this.panelbarralateral.Controls.Add(this.Recibo);
            this.panelbarralateral.Controls.Add(this.panelLogo);
            this.panelbarralateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelbarralateral.Location = new System.Drawing.Point(0, 0);
            this.panelbarralateral.Name = "panelbarralateral";
            this.panelbarralateral.Size = new System.Drawing.Size(310, 597);
            this.panelbarralateral.TabIndex = 30;
            // 
            // Beneficiarios
            // 
            this.Beneficiarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.Beneficiarios.FlatAppearance.BorderSize = 0;
            this.Beneficiarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Beneficiarios.ForeColor = System.Drawing.SystemColors.Control;
            this.Beneficiarios.Location = new System.Drawing.Point(0, 265);
            this.Beneficiarios.Name = "Beneficiarios";
            this.Beneficiarios.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Beneficiarios.Size = new System.Drawing.Size(310, 55);
            this.Beneficiarios.TabIndex = 4;
            this.Beneficiarios.Text = "Beneficiarios";
            this.Beneficiarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Beneficiarios.UseVisualStyleBackColor = true;
            this.Beneficiarios.Click += new System.EventHandler(this.Beneficiarios_Click);
            // 
            // Pendientes
            // 
            this.Pendientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pendientes.FlatAppearance.BorderSize = 0;
            this.Pendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pendientes.ForeColor = System.Drawing.SystemColors.Control;
            this.Pendientes.Location = new System.Drawing.Point(0, 210);
            this.Pendientes.Name = "Pendientes";
            this.Pendientes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Pendientes.Size = new System.Drawing.Size(310, 55);
            this.Pendientes.TabIndex = 3;
            this.Pendientes.Text = "Pendientes";
            this.Pendientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Pendientes.UseVisualStyleBackColor = true;
            this.Pendientes.Click += new System.EventHandler(this.Pendientes_Click);
            // 
            // Reporte
            // 
            this.Reporte.Dock = System.Windows.Forms.DockStyle.Top;
            this.Reporte.FlatAppearance.BorderSize = 0;
            this.Reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reporte.ForeColor = System.Drawing.SystemColors.Control;
            this.Reporte.Location = new System.Drawing.Point(0, 155);
            this.Reporte.Name = "Reporte";
            this.Reporte.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Reporte.Size = new System.Drawing.Size(310, 55);
            this.Reporte.TabIndex = 2;
            this.Reporte.Text = "Reporte";
            this.Reporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Reporte.UseVisualStyleBackColor = true;
            this.Reporte.Click += new System.EventHandler(this.Reporte_Click);
            // 
            // Recibo
            // 
            this.Recibo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Recibo.FlatAppearance.BorderSize = 0;
            this.Recibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Recibo.ForeColor = System.Drawing.SystemColors.Control;
            this.Recibo.Location = new System.Drawing.Point(0, 100);
            this.Recibo.Name = "Recibo";
            this.Recibo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Recibo.Size = new System.Drawing.Size(310, 55);
            this.Recibo.TabIndex = 1;
            this.Recibo.Text = "Nuevo Recibo";
            this.Recibo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Recibo.UseVisualStyleBackColor = true;
            this.Recibo.Click += new System.EventHandler(this.Recibo_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox5);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(310, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // panelhijo
            // 
            this.panelhijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelhijo.Location = new System.Drawing.Point(310, 0);
            this.panelhijo.Name = "panelhijo";
            this.panelhijo.Size = new System.Drawing.Size(960, 597);
            this.panelhijo.TabIndex = 31;
            // 
            // rjButton1
            // 
            this.rjButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rjButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.rjButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 0;
            this.rjButton1.BorderRadius1 = 0;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.BorderSize1 = 0;
            this.rjButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Inter Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(13, 506);
            this.rjButton1.Margin = new System.Windows.Forms.Padding(4);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(192, 38);
            this.rjButton1.TabIndex = 25;
            this.rjButton1.Text = "Cerrar sesion";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click_2);
            // 
            // rjButton3
            // 
            this.rjButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rjButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.rjButton3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.rjButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton3.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.rjButton3.BorderRadius = 0;
            this.rjButton3.BorderRadius1 = 0;
            this.rjButton3.BorderSize = 0;
            this.rjButton3.BorderSize1 = 0;
            this.rjButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton3.FlatAppearance.BorderSize = 0;
            this.rjButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton3.Font = new System.Drawing.Font("Inter Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton3.ForeColor = System.Drawing.Color.White;
            this.rjButton3.Location = new System.Drawing.Point(4, 380);
            this.rjButton3.Margin = new System.Windows.Forms.Padding(4);
            this.rjButton3.Name = "rjButton3";
            this.rjButton3.Size = new System.Drawing.Size(192, 38);
            this.rjButton3.TabIndex = 27;
            this.rjButton3.Text = "Registrarse";
            this.rjButton3.TextColor = System.Drawing.Color.White;
            this.rjButton3.UseVisualStyleBackColor = false;
            this.rjButton3.Click += new System.EventHandler(this.rjButton3_Click_1);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1270, 597);
            this.Controls.Add(this.panelhijo);
            this.Controls.Add(this.panelbarralateral);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Principal_FormClosed);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.SizeChanged += new System.EventHandler(this.Principal_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panelbarralateral.ResumeLayout(false);
            this.panelbarralateral.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private RJButton rjButton1;
        private RJButton rjButton3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panelbarralateral;
        private System.Windows.Forms.Button Beneficiarios;
        private System.Windows.Forms.Button Pendientes;
        private System.Windows.Forms.Button Reporte;
        private System.Windows.Forms.Button Recibo;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelhijo;
    }
}