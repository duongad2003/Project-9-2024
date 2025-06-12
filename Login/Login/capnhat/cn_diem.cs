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
    public partial class cn_diem : Form
    {
        public cn_diem()
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
                string sql = "SELECT masv AS [Mã sinh viên], mamh AS [Mã môn học], diem AS [Điểm] FROM [diem]";
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

        private void cn_diem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLySinhVienDataSet.diem' table. You can move, or remove it, as needed.
            this.diemTableAdapter.Fill(this.quanLySinhVienDataSet.diem);

            ketnoi();
            LoadData();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtMaSV.Text = row.Cells["Mã sinh viên"].Value.ToString();
                    txtMaMH.Text = row.Cells["Mã môn học"].Value.ToString();
                    txtDiem.Text = row.Cells["Điểm"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi chọn dòng: " + ex.Message);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();

                string masv = txtMaSV.Text;
                string mamh = txtMaMH.Text;
                string diem = txtDiem.Text;

                if (string.IsNullOrEmpty(masv) || string.IsNullOrEmpty(mamh) || string.IsNullOrEmpty(diem))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string sqlInsert = "INSERT INTO [diem] (masv, mamh, diem) VALUES (@masv, @mamh, @diem)";
                SqlCommand cmd = new SqlCommand(sqlInsert, sqlcon);
                cmd.Parameters.AddWithValue("@masv", masv);
                cmd.Parameters.AddWithValue("@mamh", mamh);
                cmd.Parameters.AddWithValue("@diem", Convert.ToDouble(diem)); // Chuyển đổi về kiểu số nếu cần

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                reset();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi thêm điểm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string masv = txtMaSV.Text;
                string mamh = txtMaMH.Text;
                string diem = txtDiem.Text;

                if (string.IsNullOrEmpty(masv) || string.IsNullOrEmpty(mamh) || string.IsNullOrEmpty(diem))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string sqlUpdate = "UPDATE [diem] SET diem = @diem WHERE masv = @masv AND mamh = @mamh";
                SqlCommand cmd = new SqlCommand(sqlUpdate, sqlcon);
                cmd.Parameters.AddWithValue("@masv", masv);
                cmd.Parameters.AddWithValue("@mamh", mamh);
                cmd.Parameters.AddWithValue("@diem", Convert.ToDouble(diem));

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu điểm cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi sửa điểm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string masv = txtMaSV.Text;
                string mamh = txtMaMH.Text;

                if (string.IsNullOrEmpty(masv) || string.IsNullOrEmpty(mamh))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên và mã môn học cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa điểm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }

                string sqlDelete = "DELETE FROM [diem] WHERE masv = @masv AND mamh = @mamh";
                SqlCommand cmd = new SqlCommand(sqlDelete, sqlcon);
                cmd.Parameters.AddWithValue("@masv", masv);
                cmd.Parameters.AddWithValue("@mamh", mamh);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    reset();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy điểm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi xóa điểm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void reset()
        {
            txtMaSV.Clear();
            txtDiem.Clear();
            txtMaSV.Focus();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
