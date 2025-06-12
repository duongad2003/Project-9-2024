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
    public partial class ql_khoa : Form
    {
        public ql_khoa()
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
                string sql = "SELECT makhoa AS [Mã khoa], tenkhoa AS [Tên khoa] FROM [khoa]";
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

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();

                string mk = txtMakho.Text;
                string tk = txtTenkhoa.Text;

                if (string.IsNullOrEmpty(mk) || string.IsNullOrEmpty(tk))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                string sqlInsert = "INSERT INTO [khoa] (makhoa, tenkhoa) VALUES (@mk, @tk)";
                SqlCommand cmd = new SqlCommand(sqlInsert, sqlcon);
                cmd.Parameters.AddWithValue("@mk", mk);
                cmd.Parameters.AddWithValue("@tk", tk);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                reset();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mã khoa đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Lấy dữ liệu từ các ô nhập
                string mk = txtMakho.Text;
                string tk = txtTenkhoa.Text;

                if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin mã khoa và tên khoa để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Câu lệnh SQL để cập nhật tài khoản
                string sqlUpdate = "UPDATE [khoa] SET tenkhoa = @tk WHERE makhoa = @mk";
                SqlCommand cmd = new SqlCommand(sqlUpdate, sqlcon);
                cmd.Parameters.AddWithValue("@tk", tk);
                cmd.Parameters.AddWithValue("@mk", mk);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khoa để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi sửa khoa: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string mk = txtMakho.Text;

                if (string.IsNullOrEmpty(mk))
                {
                    MessageBox.Show("Vui lòng nhập mã khoa cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khoa này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Câu lệnh SQL để xóa tài khoản
                string sqlDelete = "DELETE FROM [khoa] WHERE makhoa = @mk";
                SqlCommand cmd = new SqlCommand(sqlDelete, sqlcon);
                cmd.Parameters.AddWithValue("@mk", mk);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    reset();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khoa để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi xóa khoa: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (MessageBox.Show("Bạn có chắc muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Bạn đã đăng xuất thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();

            }
            else
            {
                this.Show();
            }
        }

        private void reset()
        {
            txtMakho.Clear();
            txtTenkhoa.Clear();
            txtMakho.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtMakho.Text = row.Cells["Mã khoa"].Value.ToString();
                    txtTenkhoa.Text = row.Cells["Tên khoa"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

        private void cn_khoa_Load(object sender, EventArgs e)
        {
            ketnoi();
            LoadData();
        }
    }
}
