using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Adesco
{
    public partial class ReciboVS : Form
    {
        private DataTable _dtUltimaFila;
        public ReciboVS(DataTable dtUltimaFila)
        {
            InitializeComponent();
            _dtUltimaFila = dtUltimaFila;
        }

        
        private void ReciboVS_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _dtUltimaFila));
            this.reportViewer1.RefreshReport();
        }
 
       


        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        private void ReciboVS_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {
          
           
        }
    }
}
