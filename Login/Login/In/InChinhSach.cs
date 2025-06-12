using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.In
{
    public partial class InChinhSach : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public InChinhSach()
        {
            InitializeComponent();
        }

        private void InChinhSach_Load(object sender, EventArgs e)
        {
            LoadReport();
            this.reportViewer1.RefreshReport();
        }


        private void LoadReport()
        {
            // Fetch data from the database
            DataTable dt = getKhoaData();
            ReportDataSource rds = new ReportDataSource("dtChinhSach", dt);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtChinhSach", dt));

            this.reportViewer1.RefreshReport();
        }

        private DataTable getKhoaData()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM [dbo].[chinhsach]";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
