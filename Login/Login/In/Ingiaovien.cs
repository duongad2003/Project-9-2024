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
    public partial class Ingiaovien : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        string _magv;
        public Ingiaovien(string magv)
        {
            InitializeComponent();
            _magv = magv;
        }

        private void Ingiaovien_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            // Fetch data from the database
            DataTable dt = GetTeacherData();
            ReportDataSource rds = new ReportDataSource("dtGiaoVien", dt);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtGiaoVien", dt));

            this.reportViewer1.RefreshReport();
        }

        private DataTable GetTeacherData()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM [dbo].[giaovien]";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@magv", _magv);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
