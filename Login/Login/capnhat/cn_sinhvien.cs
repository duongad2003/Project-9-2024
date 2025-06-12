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

namespace Login.capnhat
{
    public partial class cn_sinhvien : Form
    {
        public cn_sinhvien()
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
                string sql = "SELECT masv AS [Mã sinh viên], tensv AS [Tên sinh viên], gioitinh AS [Giới tính], ngaysinh AS [Ngày sinh], sdt AS [Số điện thoại], diachi AS [Địa chỉ], macs AS [Mã chính sách], malop AS [Mã lớp] FROM [dbo].[sinhvien];";
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

        private void cn_sinhvien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLySinhVienDataSet.diem' table. You can move, or remove it, as needed.
            this.diemTableAdapter.Fill(this.quanLySinhVienDataSet.diem);
            // TODO: This line of code loads data into the 'quanLySinhVienDataSet.sinhvien' table. You can move, or remove it, as needed.
            this.sinhvienTableAdapter.Fill(this.quanLySinhVienDataSet.sinhvien);
            ketnoi();
            LoadData();

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();
                string sqlInsert = "INSERT INTO [sinhvien] (masv, tensv, gioitinh, ngaysinh, sdt, diachi, macs, malop) VALUES " +
                                   "(@masv, @tensv, @gioitinh, @ngaysinh, @sdt, @diachi, @macs, @malop)";

                SqlCommand cmd = new SqlCommand(sqlInsert, sqlcon);
                cmd.Parameters.AddWithValue("@masv", txtMasv.Text);
                cmd.Parameters.AddWithValue("@tensv", txtTensv.Text);
                cmd.Parameters.AddWithValue("@gioitinh", rdNam.Checked ? "Nam" : "Nữ");
                cmd.Parameters.AddWithValue("@ngaysinh", dtNgaysinh.Value);
                cmd.Parameters.AddWithValue("@sdt", txtSdt.Text);
                cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                cmd.Parameters.AddWithValue("@macs", txtMacs.Text);
                cmd.Parameters.AddWithValue("@malop", txtMalop.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlcon.Close();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();
                string sqlUpdate = "UPDATE [sinhvien] SET tensv = @tensv, gioitinh = @gioitinh, ngaysinh = @ngaysinh, " +
                                   "sdt = @sdt, diachi = @diachi, macs = @macs, malop = @malop WHERE masv = @masv";

                SqlCommand cmd = new SqlCommand(sqlUpdate, sqlcon);
                cmd.Parameters.AddWithValue("@masv", txtMasv.Text);
                cmd.Parameters.AddWithValue("@tensv", txtTensv.Text);
                cmd.Parameters.AddWithValue("@gioitinh", rdNam.Checked ? "Nam" : "Nữ");
                cmd.Parameters.AddWithValue("@ngaysinh", dtNgaysinh.Value);
                cmd.Parameters.AddWithValue("@sdt", txtSdt.Text);
                cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);
                cmd.Parameters.AddWithValue("@macs", txtMacs.Text);
                cmd.Parameters.AddWithValue("@malop", txtMalop.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa sinh viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlcon.Close();
            }
        }

        private void btn_Xóa_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();
                string sqlDelete = "DELETE FROM [sinhvien] WHERE masv = @masv";

                SqlCommand cmd = new SqlCommand(sqlDelete, sqlcon);
                cmd.Parameters.AddWithValue("@masv", txtMasv.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlcon.Close();
            }
        }

        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtMasv.Text = row.Cells["Mã sinh viên"].Value.ToString();
                    txtTensv.Text = row.Cells["Tên sinh viên"].Value.ToString();
                    string gt = row.Cells["Giới tính"].Value.ToString();
                    if (gt == "Nam")
                    {
                        rdNam.Checked = true;
                        rdNu.Checked = false;
                    }
                    else
                    {
                        rdNam.Checked = false;
                        rdNu.Checked = true;
                    }
                    dtNgaysinh.Value = Convert.ToDateTime(row.Cells["Ngày sinh"].Value);
                    txtSdt.Text = row.Cells["Số điện thoại"].Value.ToString();
                    txtDiachi.Text = row.Cells["Địa chỉ"].Value.ToString();
                    txtMacs.Text = row.Cells["Mã chính sách"].Value.ToString();
                    txtMalop.Text = row.Cells["Mã lớp"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void reset()
        {
            txtMasv.Text = "";
            txtTensv.Text = "";
            rdNam.Checked = false;
            rdNu.Checked = false;
            dtNgaysinh.Value = DateTime.Now;
            txtSdt.Text = "";
            txtDiachi.Text = "";
            txtMacs.Text = "";
            txtMalop.Text = "";
        }
    }
}
