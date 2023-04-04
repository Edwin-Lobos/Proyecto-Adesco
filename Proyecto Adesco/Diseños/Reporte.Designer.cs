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
            this.picRegresar = new System.Windows.Forms.PictureBox();
            this.cbxDato = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numreciboDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poligonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncasaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auxReciboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBuscar = new Proyecto_Adesco.RJButton();
            this.rjButton1 = new Proyecto_Adesco.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.picRegresar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auxReciboBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // picRegresar
            // 
            this.picRegresar.Image = global::Proyecto_Adesco.Properties.Resources.regresar1;
            this.picRegresar.Location = new System.Drawing.Point(12, 12);
            this.picRegresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picRegresar.Name = "picRegresar";
            this.picRegresar.Size = new System.Drawing.Size(40, 34);
            this.picRegresar.TabIndex = 16;
            this.picRegresar.TabStop = false;
            this.picRegresar.Click += new System.EventHandler(this.picRegresar_Click);
            // 
            // cbxDato
            // 
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
            this.cbxDato.Location = new System.Drawing.Point(417, 71);
            this.cbxDato.Name = "cbxDato";
            this.cbxDato.Size = new System.Drawing.Size(179, 24);
            this.cbxDato.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numreciboDataGridViewTextBoxColumn,
            this.mesesDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.otroDataGridViewTextBoxColumn,
            this.nombresDataGridViewTextBoxColumn,
            this.apellidosDataGridViewTextBoxColumn,
            this.sendaDataGridViewTextBoxColumn,
            this.poligonoDataGridViewTextBoxColumn,
            this.ncasaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.auxReciboBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(35, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1081, 440);
            this.dataGridView1.TabIndex = 18;
            // 
            // numreciboDataGridViewTextBoxColumn
            // 
            this.numreciboDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numreciboDataGridViewTextBoxColumn.DataPropertyName = "Num_recibo";
            this.numreciboDataGridViewTextBoxColumn.HeaderText = "N° Recibo";
            this.numreciboDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numreciboDataGridViewTextBoxColumn.Name = "numreciboDataGridViewTextBoxColumn";
            // 
            // mesesDataGridViewTextBoxColumn
            // 
            this.mesesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mesesDataGridViewTextBoxColumn.DataPropertyName = "Mes_es";
            this.mesesDataGridViewTextBoxColumn.HeaderText = "Mes(es)";
            this.mesesDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mesesDataGridViewTextBoxColumn.Name = "mesesDataGridViewTextBoxColumn";
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            // 
            // otroDataGridViewTextBoxColumn
            // 
            this.otroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.otroDataGridViewTextBoxColumn.DataPropertyName = "Otro";
            this.otroDataGridViewTextBoxColumn.HeaderText = "Otro (cargo)";
            this.otroDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.otroDataGridViewTextBoxColumn.Name = "otroDataGridViewTextBoxColumn";
            // 
            // nombresDataGridViewTextBoxColumn
            // 
            this.nombresDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombresDataGridViewTextBoxColumn.DataPropertyName = "Nombres";
            this.nombresDataGridViewTextBoxColumn.HeaderText = "Nombres";
            this.nombresDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nombresDataGridViewTextBoxColumn.Name = "nombresDataGridViewTextBoxColumn";
            // 
            // apellidosDataGridViewTextBoxColumn
            // 
            this.apellidosDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.apellidosDataGridViewTextBoxColumn.DataPropertyName = "Apellidos";
            this.apellidosDataGridViewTextBoxColumn.HeaderText = "Apellidos";
            this.apellidosDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.apellidosDataGridViewTextBoxColumn.Name = "apellidosDataGridViewTextBoxColumn";
            // 
            // sendaDataGridViewTextBoxColumn
            // 
            this.sendaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sendaDataGridViewTextBoxColumn.DataPropertyName = "Senda";
            this.sendaDataGridViewTextBoxColumn.HeaderText = "Senda";
            this.sendaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sendaDataGridViewTextBoxColumn.Name = "sendaDataGridViewTextBoxColumn";
            // 
            // poligonoDataGridViewTextBoxColumn
            // 
            this.poligonoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.poligonoDataGridViewTextBoxColumn.DataPropertyName = "Poligono";
            this.poligonoDataGridViewTextBoxColumn.HeaderText = "Poligono";
            this.poligonoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.poligonoDataGridViewTextBoxColumn.Name = "poligonoDataGridViewTextBoxColumn";
            // 
            // ncasaDataGridViewTextBoxColumn
            // 
            this.ncasaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ncasaDataGridViewTextBoxColumn.DataPropertyName = "N_casa";
            this.ncasaDataGridViewTextBoxColumn.HeaderText = "N° Casa";
            this.ncasaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ncasaDataGridViewTextBoxColumn.Name = "ncasaDataGridViewTextBoxColumn";
            // 
            // auxReciboBindingSource
            // 
            this.auxReciboBindingSource.DataSource = typeof(Proyecto_Adesco.Clases.AuxRecibo);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnBuscar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnBuscar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnBuscar.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.btnBuscar.BorderRadius = 18;
            this.btnBuscar.BorderRadius1 = 18;
            this.btnBuscar.BorderSize = 0;
            this.btnBuscar.BorderSize1 = 0;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(603, 65);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(125, 33);
            this.btnBuscar.TabIndex = 81;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextColor = System.Drawing.Color.White;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // rjButton1
            // 
            this.rjButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rjButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.rjButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderColor1 = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 18;
            this.rjButton1.BorderRadius1 = 18;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.BorderSize1 = 0;
            this.rjButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(472, 552);
            this.rjButton1.Margin = new System.Windows.Forms.Padding(4);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(256, 36);
            this.rjButton1.TabIndex = 82;
            this.rjButton1.Text = "Generar Reporte";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 614);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbxDato);
            this.Controls.Add(this.picRegresar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Reporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Reporte_FormClosed);
            this.Load += new System.EventHandler(this.Reporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picRegresar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auxReciboBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picRegresar;
        private System.Windows.Forms.ComboBox cbxDato;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource auxReciboBindingSource;
        private RJButton btnBuscar;
        private RJButton rjButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numreciboDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn poligonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncasaDataGridViewTextBoxColumn;
    }
}