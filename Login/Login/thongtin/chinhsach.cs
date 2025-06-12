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
    public partial class chinhsach : Form
    {
        public chinhsach()
        {
            InitializeComponent();
           
        }

        SqlConnection sqlcon = new SqlConnection();

        public void ketnoi()
        {

            //string ketnoi = @"Data Source=DESKTOP-B6129AP\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True;";

            string ketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            sqlcon = new SqlConnection(ketnoi);
            sqlcon.Open();

        }

        private void LoadData()
        {
            try
            {
                string sql = "SELECT macs AS [Mã chính sách], tencs AS [Tên chính sách], chedo AS [Chế độ] FROM [chinhsach]";
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

        private void chinhsach_Load(object sender, EventArgs e)
        {
            ketnoi();
            LoadData();
        }

        private void btn_in_Click(object sender, EventArgs e)
        {
            InChinhSach f = new InChinhSach();
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
                    txtMacs.Text = row.Cells["Mã chính sách"].Value.ToString();
                    txtTencs.Text = row.Cells["Tên chính sách"].Value.ToString();
                    txtcd.Text = row.Cells["Chế độ"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }
    }
}
