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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reporte));
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Proyecto_Adesco.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnGenerarRP = new Proyecto_Adesco.RJButton();
            this.btnBuscar = new Proyecto_Adesco.RJButton();
            this.cbxDato = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpAño = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataSet1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_Adesco.reporte.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(9, 60);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1093, 563);
            this.reportViewer1.TabIndex = 83;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // btnGenerarRP
            // 
            this.btnGenerarRP.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGenerarRP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnGenerarRP.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnGenerarRP.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnGenerarRP.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.btnGenerarRP.BorderRadius = 15;
            this.btnGenerarRP.BorderRadius1 = 15;
            this.btnGenerarRP.BorderSize = 0;
            this.btnGenerarRP.BorderSize1 = 0;
            this.btnGenerarRP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarRP.FlatAppearance.BorderSize = 0;
            this.btnGenerarRP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarRP.Font = new System.Drawing.Font("Inter", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarRP.ForeColor = System.Drawing.Color.White;
            this.btnGenerarRP.Location = new System.Drawing.Point(481, 636);
            this.btnGenerarRP.Name = "btnGenerarRP";
            this.btnGenerarRP.Size = new System.Drawing.Size(150, 39);
            this.btnGenerarRP.TabIndex = 86;
            this.btnGenerarRP.Text = "Generar Reporte";
            this.btnGenerarRP.TextColor = System.Drawing.Color.White;
            this.btnGenerarRP.UseVisualStyleBackColor = false;
            this.btnGenerarRP.Click += new System.EventHandler(this.btnGenerarRP_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnBuscar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnBuscar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnBuscar.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.btnBuscar.BorderRadius = 12;
            this.btnBuscar.BorderRadius1 = 12;
            this.btnBuscar.BorderSize = 0;
            this.btnBuscar.BorderSize1 = 0;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Inter", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(608, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 24);
            this.btnBuscar.TabIndex = 85;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextColor = System.Drawing.Color.White;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // cbxDato
            // 
            this.cbxDato.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxDato.FormattingEnabled = true;
            this.cbxDato.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cbxDato.Location = new System.Drawing.Point(394, 31);
            this.cbxDato.Margin = new System.Windows.Forms.Padding(2);
            this.cbxDato.Name = "cbxDato";
            this.cbxDato.Size = new System.Drawing.Size(135, 21);
            this.cbxDato.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(392, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 17);
            this.label1.TabIndex = 87;
            this.label1.Text = "Filtrar Busqueda por meses";
            // 
            // dtpAño
            // 
            this.dtpAño.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpAño.CustomFormat = "yyyy";
            this.dtpAño.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAño.Location = new System.Drawing.Point(533, 31);
            this.dtpAño.Margin = new System.Windows.Forms.Padding(2);
            this.dtpAño.Name = "dtpAño";
            this.dtpAño.ShowUpDown = true;
            this.dtpAño.Size = new System.Drawing.Size(70, 20);
            this.dtpAño.TabIndex = 126;
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1111, 684);
            this.Controls.Add(this.dtpAño);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerarRP);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbxDato);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Reporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Reporte_FormClosed);
            this.Load += new System.EventHandler(this.Reporte_Load);
            this.Resize += new System.EventHandler(this.Reporte_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private RJButton btnGenerarRP;
        private RJButton btnBuscar;
        private System.Windows.Forms.ComboBox cbxDato;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.DateTimePicker dtpAño;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}