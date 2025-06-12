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
    public partial class cn_monhoc : Form
    {
        public cn_monhoc()
        {
            InitializeComponent();
        }

        private void cn_monhoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLySinhVienDataSet.monhoc' table. You can move, or remove it, as needed.
            this.monhocTableAdapter.Fill(this.quanLySinhVienDataSet.monhoc);
            ketnoi();
            LoadData();

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
                string sql = "SELECT mamh AS [Mã môn học], tenmh AS [Tên môn học], sotiet AS [Số tiết], magv AS [Mã giáo viên] FROM [monhoc]";
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

                string mamh = txtMaMH.Text;
                string tenmh = txtTenMH.Text;
                string sotiet = txtSoTiet.Text;
                string magv = txtMaGV.Text;

                if (string.IsNullOrEmpty(mamh) || string.IsNullOrEmpty(tenmh) || string.IsNullOrEmpty(sotiet) || string.IsNullOrEmpty(magv))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string sqlInsert = "INSERT INTO [monhoc] (mamh, tenmh, sotiet, magv) VALUES (@mamh, @tenmh, @sotiet, @magv)";
                SqlCommand cmd = new SqlCommand(sqlInsert, sqlcon);
                cmd.Parameters.AddWithValue("@mamh", mamh);
                cmd.Parameters.AddWithValue("@tenmh", tenmh);
                cmd.Parameters.AddWithValue("@sotiet", Convert.ToInt32(sotiet)); // Chuyển đổi về kiểu số nguyên
                cmd.Parameters.AddWithValue("@magv", magv);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                reset();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm môn học: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string mamh = txtMaMH.Text;
                string tenmh = txtTenMH.Text;
                string sotiet = txtSoTiet.Text;
                string magv = txtMaGV.Text;

                if (string.IsNullOrEmpty(mamh) || string.IsNullOrEmpty(tenmh) || string.IsNullOrEmpty(sotiet) || string.IsNullOrEmpty(magv))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin môn học cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string sqlUpdate = "UPDATE [monhoc] SET tenmh = @tenmh, sotiet = @sotiet, magv = @magv WHERE mamh = @mamh";
                SqlCommand cmd = new SqlCommand(sqlUpdate, sqlcon);
                cmd.Parameters.AddWithValue("@mamh", mamh);
                cmd.Parameters.AddWithValue("@tenmh", tenmh);
                cmd.Parameters.AddWithValue("@sotiet", Convert.ToInt32(sotiet));
                cmd.Parameters.AddWithValue("@magv", magv);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy môn học cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi sửa môn học: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string mamh = txtMaMH.Text;

                if (string.IsNullOrEmpty(mamh))
                {
                    MessageBox.Show("Vui lòng nhập mã môn học cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }

                string sqlDelete = "DELETE FROM [monhoc] WHERE mamh = @mamh";
                SqlCommand cmd = new SqlCommand(sqlDelete, sqlcon);
                cmd.Parameters.AddWithValue("@mamh", mamh);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    reset();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy môn học để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa môn học: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtMaMH.Clear();
            txtTenMH.Clear();
            txtSoTiet.Clear();
            txtMaMH.Focus();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtMaMH.Text = row.Cells["Mã môn học"].Value.ToString();
                    txtTenMH.Text = row.Cells["Tên môn học"].Value.ToString();
                    txtSoTiet.Text = row.Cells["Số tiết"].Value.ToString();
                    txtMaGV.Text = row.Cells["Mã giáo viên"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi chọn dòng: " + ex.Message);
            }
        }
    }
}
