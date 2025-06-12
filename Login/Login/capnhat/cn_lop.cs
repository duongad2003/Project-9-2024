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
    public partial class cn_lop : Form
    {
        public cn_lop()
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

        private void cn_lop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLySinhVienDataSet.lop' table. You can move, or remove it, as needed.
            this.lopTableAdapter.Fill(this.quanLySinhVienDataSet.lop);
            // TODO: This line of code loads data into the 'quanLySinhVienDataSet.khoa' table. You can move, or remove it, as needed.
            this.khoaTableAdapter.Fill(this.quanLySinhVienDataSet.khoa);
            ketnoi();
            LoadData();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();

                string ml = txtMalop.Text;
                string tl = txtTenlop.Text;
                string mk = cboMakhoa.Text;

                if (string.IsNullOrEmpty(ml) || string.IsNullOrEmpty(tl) || string.IsNullOrEmpty(mk))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                string sqlInsert = "INSERT INTO [lop] (malop, tenlop, makhoa) VALUES (@ml, @tl, @mk)";
                SqlCommand cmd = new SqlCommand(sqlInsert, sqlcon);
                cmd.Parameters.AddWithValue("@ml", ml);
                cmd.Parameters.AddWithValue("@tl", tl);
                cmd.Parameters.AddWithValue("@mk", mk);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                reset();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã tồn tại mã lớp này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string ml = txtMalop.Text;
                string tl = txtTenlop.Text;
                string mk = cboMakhoa.Text;

                if (string.IsNullOrEmpty(ml) || string.IsNullOrEmpty(tl) || string.IsNullOrEmpty(mk))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin mã lớp, tên lớp, và mã khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string sqlUpdate = "UPDATE [lop] SET tenlop = @tl, makhoa = @mk WHERE malop = @ml";
                SqlCommand cmd = new SqlCommand(sqlUpdate, sqlcon);
                cmd.Parameters.AddWithValue("@ml", ml);
                cmd.Parameters.AddWithValue("@tl", tl);
                cmd.Parameters.AddWithValue("@mk", mk);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi sửa lớp: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string ml = txtMalop.Text;

                if (string.IsNullOrEmpty(ml))
                {
                    MessageBox.Show("Vui lòng nhập mã lớp cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }

                string sqlDelete = "DELETE FROM [lop] WHERE malop = @ml";
                SqlCommand cmd = new SqlCommand(sqlDelete, sqlcon);
                cmd.Parameters.AddWithValue("@ml", ml);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    reset();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi xóa lớp: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtMalop.Clear();
            txtTenlop.Clear();
            cboMakhoa.SelectedIndex = -1;
            txtMalop.Focus();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Bạn đã đăng xuất thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtMalop.Text = row.Cells["Mã lớp"].Value.ToString();
                    txtTenlop.Text = row.Cells["Tên lớp"].Value.ToString();
                    cboMakhoa.Text = row.Cells["Mã khoa"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }
    }
}
