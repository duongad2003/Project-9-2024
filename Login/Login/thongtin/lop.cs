using Login.In;
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

namespace Login.thongtin
{
    public partial class lop : Form
    {
        public lop()
        {
            InitializeComponent();
        }

        SqlConnection sqlcon = new SqlConnection();

        public void ketnoi()
        {

            string ketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            sqlcon = new SqlConnection(ketnoi);
            sqlcon.Open();

        }
        private void LoadData()
        {
            try
            {
                string sql = "SELECT malop AS [Mã lớp], tenlop AS [Tên lớp], makhoa AS [Mã khoa] FROM [lop]";
                DataSet ds = new DataSet();
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                sqlda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlcon != null && sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
        }

        private void lop_Load(object sender, EventArgs e)
        {
            ketnoi();
            LoadData();
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            InLop f = new InLop();  
            f.ShowDialog();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtMalp.Text = row.Cells["Mã lớp"].Value.ToString();
                    txtTenl.Text = row.Cells["Tên lớp"].Value.ToString();
                    txtMak.Text = row.Cells["Mã khoa"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }
    }
}
