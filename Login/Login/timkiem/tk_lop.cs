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

namespace Login.timkiem
{
    public partial class tk_lop : Form
    {
        public tk_lop()
        {
            InitializeComponent();
        }

        SqlConnection sqlcon = new SqlConnection();
        public void ketnoi()
        {
            string ketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

            //string ketnoi = @"Data Source=LAPTOP-662R1F6L;Initial Catalog=quanlysinhvien;Integrated Security=True;Encrypt=True;";
            sqlcon = new SqlConnection(ketnoi);
            sqlcon.Open();

        }
        private void LoadData()
        {
            try
            {
                string sql = "SELECT malop AS [Mã lớp], tenlop AS [Tên Lớp], makhoa AS [Mã khoa] FROM [lop]";
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

        private void tk_lop_Load(object sender, EventArgs e)
        {
            ketnoi();
            LoadData();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string timkiem = txttimkiem.Text.Trim();
                if (string.IsNullOrEmpty(timkiem)) 
                {
                    MessageBox.Show("Vui lòng nhập mã lớp hoặc tên lớp để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "SELECT malop AS [Mã lớp], tenlop AS [Tên lớp], makhoa AS [Mã khoa] " +
                             "FROM lop " +
                             "WHERE malop LIKE @searchText OR tenlop LIKE @searchText OR makhoa LIKE @searchText";

                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@searchText", "%" + timkiem + "%"); 

                DataSet ds = new DataSet();
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                sqlda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
