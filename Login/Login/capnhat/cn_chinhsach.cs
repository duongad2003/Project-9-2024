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
    public partial class cn_chinhsach : Form
    {
        public cn_chinhsach()
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


        private void cn_chinhsach_Load(object sender, EventArgs e)
        {
            ketnoi();
            LoadData();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();

                string macs = txtMaCS.Text;
                string tencs = txtTenCS.Text;
                string chedo = txtCheDo.Text;

                if (string.IsNullOrEmpty(macs) || string.IsNullOrEmpty(tencs) || string.IsNullOrEmpty(chedo))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin chính sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string sqlInsert = "INSERT INTO [chinhsach] (macs, tencs, chedo) VALUES (@macs, @tencs, @chedo)";
                SqlCommand cmd = new SqlCommand(sqlInsert, sqlcon);
                cmd.Parameters.AddWithValue("@macs", macs);
                cmd.Parameters.AddWithValue("@tencs", tencs);
                cmd.Parameters.AddWithValue("@chedo", chedo);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm chính sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                reset();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi thêm chính sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string macs = txtMaCS.Text;
                string tencs = txtTenCS.Text;
                string chedo = txtCheDo.Text;

                if (string.IsNullOrEmpty(macs) || string.IsNullOrEmpty(tencs) || string.IsNullOrEmpty(chedo))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin chính sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string sqlUpdate = "UPDATE [chinhsach] SET tencs = @tencs, chedo = @chedo WHERE macs = @macs";
                SqlCommand cmd = new SqlCommand(sqlUpdate, sqlcon);
                cmd.Parameters.AddWithValue("@macs", macs);
                cmd.Parameters.AddWithValue("@tencs", tencs);
                cmd.Parameters.AddWithValue("@chedo", chedo);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật chính sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chính sách để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi sửa chính sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string macs = txtMaCS.Text;

                if (string.IsNullOrEmpty(macs))
                {
                    MessageBox.Show("Vui lòng nhập mã chính sách cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chính sách này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }

                string sqlDelete = "DELETE FROM [chinhsach] WHERE macs = @macs";
                SqlCommand cmd = new SqlCommand(sqlDelete, sqlcon);
                cmd.Parameters.AddWithValue("@macs", macs);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa chính sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    reset();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chính sách để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi xóa chính sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtMaCS.Clear();
            txtTenCS.Clear();
            txtCheDo.Clear();
            txtMaCS.Focus();
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
                    txtMaCS.Text = row.Cells["Mã chính sách"].Value.ToString();
                    txtTenCS.Text = row.Cells["Tên chính sách"].Value.ToString();
                    txtCheDo.Text = row.Cells["Chế độ"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }
    }
}
