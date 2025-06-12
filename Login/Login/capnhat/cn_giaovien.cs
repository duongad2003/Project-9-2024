using Login.timkiem;
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
    public partial class cn_giaovien : Form
    {
        public cn_giaovien()
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
                string sql = "SELECT magv AS [Mã giáo viên], tengv AS [Tên giáo viên], gioitinh AS [Giới tính], ngaysinh AS [Ngày sinh], sdt AS [Số điện thoại], diachi AS [Địa chỉ] FROM [dbo].[giaovien];";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtMagv.Text = row.Cells["Mã giáo viên"].Value.ToString();
                    txtTengv.Text = row.Cells["Tên giáo viên"].Value.ToString();
                    string gt = row.Cells["Giới tính"].Value.ToString();
                    if(gt == "Nam")
                    {
                        rdNam.Checked = true;
                        rdNu.Checked = false;
                    }
                    else
                    {
                        rdNam.Checked = false;
                        rdNu.Checked = true;
                    }
                    dtNs.Value = Convert.ToDateTime(row.Cells["Ngày sinh"].Value);
                    txtSdt.Text = row.Cells["Số điện thoại"].Value.ToString();
                    txtDiachi.Text = row.Cells["Địa chỉ"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                reset();
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();

                string magv = txtMagv.Text;
                string tengv = txtTengv.Text;
                string gt = null;

                if(rdNu.Checked = true)
                {
                    gt = "Nữ";
                }
                else 
                if(rdNam.Checked = true)
                {
                    gt = "Nam";
                }

                DateTime ngaysinh = dtNs.Value;
                string sdt = txtSdt.Text;
                string diachi = txtDiachi.Text;

                if (string.IsNullOrEmpty(magv) || string.IsNullOrEmpty(tengv) || string.IsNullOrEmpty(gt) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diachi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string sql = @" INSERT INTO [dbo].[giaovien] ([magv], [tengv], [gioitinh], [ngaysinh], [sdt], [diachi]) VALUES (@magv, @tengv, @gioitinh, @ngaysinh, @sdt, @diachi)";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@magv", magv);
                cmd.Parameters.AddWithValue("@tengv", tengv);
                cmd.Parameters.AddWithValue("@gioitinh", gt);
                cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh); 
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.Parameters.AddWithValue("@diachi", diachi);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                reset();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi thêm giáo viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string magv = txtMagv.Text;
                string tengv = txtTengv.Text;
                string gt = null;
                if (rdNu.Checked = true)
                {
                    gt = "Nữ";
                }
                else
                if (rdNam.Checked = true)
                {
                    gt = "Nam";
                }
                DateTime ngaysinh = dtNs.Value;
                string sdt = txtSdt.Text;
                string diachi = txtDiachi.Text;

                if (string.IsNullOrEmpty(magv) || string.IsNullOrEmpty(tengv) || string.IsNullOrEmpty(gt) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diachi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Câu lệnh SQL để cập nhật tài khoản
                string sqlUpdate = "UPDATE [dbo].[giaovien] SET [tengv] = @tengv, [gioitinh] = @gioitinh, [ngaysinh] = @ngaysinh, [sdt] = @sdt, [diachi] = @diachi WHERE [magv] = @magv;";
                SqlCommand cmd = new SqlCommand(sqlUpdate, sqlcon);
                cmd.Parameters.AddWithValue("@magv", magv);
                cmd.Parameters.AddWithValue("@tengv", tengv);
                cmd.Parameters.AddWithValue("@gioitinh", gt);
                cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.Parameters.AddWithValue("@diachi", diachi);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy giáo viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi sửa: ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Lấy tên tài khoản từ ô nhập
                string xgv = txtMagv.Text;

                if (string.IsNullOrEmpty(xgv))
                {
                    MessageBox.Show("Vui lòng nhập mã giáo viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Câu lệnh SQL để xóa tài khoản
                string sqlDelete = "DELETE FROM [dbo].[giaovien] WHERE [magv] = @magv;";
                SqlCommand cmd = new SqlCommand(sqlDelete, sqlcon);
                cmd.Parameters.AddWithValue("@magv", xgv);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    reset();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy giáo viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi xóa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void reset()
        {
            txtMagv.Text = "";
            txtTengv.Text = "";
            rdNu.Checked = false;
            rdNam.Checked = false;   
            txtSdt.Text = "";
            txtDiachi.Text = "";
        }

        private void cn_giaovien_Load(object sender, EventArgs e)
        {
            ketnoi();
            LoadData();
        }
    }
}
