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
    public partial class tk_chinhsach : Form
    {
        public tk_chinhsach()
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
                string sql = "SELECT macs AS [Mã chính sách], tencs AS [Tên chính sách] FROM [chinhsach]";
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
        private void tk_chinhsach_Load(object sender, EventArgs e)
        {
            ketnoi();
            LoadData();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string timkiem = txttimkiem.Text.Trim();
                string loaiTimKiem = combobox1.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(timkiem)) 
                {
                    MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(loaiTimKiem)) 
                {
                    MessageBox.Show("Vui lòng chọn loại tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                string sql = "";
                if (loaiTimKiem == "Mã chính sách")
                {
                    sql = "SELECT macs AS [Mã chính sách], tencs AS [Tên chính sách] " +
                          "FROM chinhsach " +
                          "WHERE macs LIKE @searchText";
                }
                else if (loaiTimKiem == "Tên chính sách")
                {
                    sql = "SELECT macs AS [Mã chính sách], tencs AS [Tên chính sách] " +
                          "FROM chinhsach " +
                          "WHERE tencs LIKE @searchText";
                }
                else
                {
                    MessageBox.Show("Loại tìm kiếm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
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
