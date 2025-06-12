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
    public partial class tk_sinhvien : Form
    {
        public tk_sinhvien()
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
                string sql = "SELECT masv AS [Mã sinh viên], tensv AS [Tên sinh viên], gioitinh AS [Giới tính], ngaysinh AS [Ngày sinh], sdt AS [Số điện thoại],diachi AS [Địa chỉ], macs AS [Mã chính sách], malop AS [Mã lớp] FROM [sinhvien]";
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
                switch (loaiTimKiem)
                {
                    case "Mã sinh viên":
                        sql = "SELECT masv AS [Mã sinh viên], tensv AS [Tên sinh viên], gioitinh AS [Giới tính], ngaysinh AS [Ngày sinh], sdt AS [Số điện thoại], diachi AS [Địa chỉ], macs AS [Mã chính sách], malop AS [Mã lớp] " +
                              "FROM sinhvien " +
                              "WHERE masv LIKE @searchText";
                        break;
                    case "Tên sinh viên":
                        sql = "SELECT masv AS [Mã sinh viên], tensv AS [Tên sinh viên], gioitinh AS [Giới tính], ngaysinh AS [Ngày sinh], sdt AS [Số điện thoại], diachi AS [Địa chỉ], macs AS [Mã chính sách], malop AS [Mã lớp] " +
                              "FROM sinhvien " +
                              "WHERE tensv LIKE @searchText";
                        break;
                    case "Giới tính":
                        sql = "SELECT masv AS [Mã sinh viên], tensv AS [Tên sinh viên], gioitinh AS [Giới tính], ngaysinh AS [Ngày sinh], sdt AS [Số điện thoại], diachi AS [Địa chỉ], macs AS [Mã chính sách], malop AS [Mã lớp] " +
                              "FROM sinhvien " +
                              "WHERE gioitinh LIKE @searchText";
                        break;
                    case "Số điện thoại":
                        sql = "SELECT masv AS [Mã sinh viên], tensv AS [Tên sinh viên], gioitinh AS [Giới tính], ngaysinh AS [Ngày sinh], sdt AS [Số điện thoại], diachi AS [Địa chỉ], macs AS [Mã chính sách], malop AS [Mã lớp] " +
                              "FROM sinhvien " +
                              "WHERE sdt LIKE @searchText";
                        break;
                    case "Địa chỉ":
                        sql = "SELECT masv AS [Mã sinh viên], tensv AS [Tên sinh viên], gioitinh AS [Giới tính], ngaysinh AS [Ngày sinh], sdt AS [Số điện thoại], diachi AS [Địa chỉ], macs AS [Mã chính sách], malop AS [Mã lớp] " +
                              "FROM sinhvien " +
                              "WHERE diachi LIKE @searchText";
                        break;
                    case "Mã lớp":
                        sql = "SELECT masv AS [Mã sinh viên], tensv AS [Tên sinh viên], gioitinh AS [Giới tính], ngaysinh AS [Ngày sinh], sdt AS [Số điện thoại], diachi AS [Địa chỉ], macs AS [Mã chính sách], malop AS [Mã lớp] " +
                              "FROM sinhvien " +
                              "WHERE malop LIKE @searchText";
                        break;
                    default:
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





            //try
            //{
            //    // Lấy dữ liệu từ ô tìm kiếm
            //    string timkiem = txttimkiem.Text.Trim();
            //    if (string.IsNullOrEmpty(timkiem)) // Kiểm tra nếu không nhập từ khóa
            //    {
            //        MessageBox.Show("Vui lòng nhập mã sinh viên hoặc tên sinh viên để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    // Câu truy vấn SQL tìm kiếm theo mã sinh viên hoặc tên sinh viên
            //    string sql = "SELECT masv AS [Mã sinh viên], tensv AS [Tên sinh viên], gioitinh AS [Giới tính], ngaysinh AS [Ngày sinh], sdt AS [Số điện thoại], diachi AS [Địa chỉ], macs AS [Mã chính sách], malop AS [Mã lớp] " +
            //                 "FROM sinhvien " +
            //                 "WHERE masv LIKE @searchText OR tensv LIKE @searchText";

            //    // Mở kết nối
            //    if (sqlcon.State == ConnectionState.Closed)
            //    {
            //        sqlcon.Open();
            //    }

            //    SqlCommand cmd = new SqlCommand(sql, sqlcon);
            //    cmd.Parameters.AddWithValue("@searchText", "%" + timkiem + "%"); // Thêm tham số tìm kiếm

            //    DataSet ds = new DataSet();
            //    SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            //    sqlda.Fill(ds);

            //    // Hiển thị dữ liệu vào DataGridView
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        dataGridView1.DataSource = ds.Tables[0];
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dataGridView1.DataSource = null; // Xóa dữ liệu cũ nếu không có kết quả
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Đã có lỗi xảy ra khi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tk_sinhvien_Load(object sender, EventArgs e)
        {
            ketnoi();
            LoadData();
        }
    }
}
