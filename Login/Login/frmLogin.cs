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

namespace Login
{
    public partial class frmLogin : Form
    {
        int sai = 5;
        int tk = 0;
        SqlConnection sqlcon = new SqlConnection();

        public void Ketnoi()
        {

            //string ketnoi = @"Data Source=DESKTOP-B6129AP\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True;";

            string ketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            sqlcon = new SqlConnection(ketnoi);
            sqlcon.Open();

        }
        public frmLogin()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private bool ValidateInputs()
        {
            string tentk = txtUsername.Text.Trim();
            string matkhau = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(tentk))
            {
                MessageBox.Show("Bạn Chưa Nhập Tên Tài Khoản!", "Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return false;
            }

            if (tentk.Length < 1 || tentk.Length > 30)
            {
                MessageBox.Show("Tên Tài Khoản phải từ 1 đến 30 ký tự.", "Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPass.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(matkhau))
            {
                MessageBox.Show("Bạn Chưa Nhập Mật Khẩu!", "Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPass.Focus();
                return false;
            }

            return true;
        } 



        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            if (txtUsername.Text.Contains(" "))
            {
                MessageBox.Show("Tên tài khoản không được chứa khoảng trắng!", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            Ketnoi();
            string tentk = txtUsername.Text;
            string matkhau = txtPass.Text;

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM admin WHERE tk = @tk AND mk = @mk", sqlcon);
            cmd.Parameters.AddWithValue("@tk", tentk);
            cmd.Parameters.AddWithValue("@mk", matkhau);
            int i = (int)cmd.ExecuteScalar();

            cmd.CommandText = "SELECT COUNT(*) FROM nguoidung WHERE tk = @tk AND mk = @mk";
            int u = (int)cmd.ExecuteScalar();

            cmd.CommandText = "SELECT COUNT(*) FROM gv WHERE tk = @tk AND mk = @mk";
            int gv = (int)cmd.ExecuteScalar();

            cmd.CommandText = "SELECT COUNT(*) FROM truongkhoa WHERE tk = @tk AND mk = @mk";
            int tkhoa = (int)cmd.ExecuteScalar();

            if (i != 0 || gv != 0 || u != 0 || tkhoa != 0)
            {
                sai = 3;
                Menu f = new Menu();
                if (i != 0)
                {
                    MessageBox.Show("Bạn đã đăng nhập vào tài khoản Admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.Ts_capnhatdiem.Visible = false;


                }
                else if (gv != 0)
                {
                    MessageBox.Show("Bạn đã đăng nhập vào tài khoản Giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.Ts_Btn_dangnhap.Visible = false;
                    f.Ts_Btn_admin.Visible = false;
                    f.Ts_truongkhoa.Visible = false;
                    f.toolStripSeparator1.Visible = false;
                    f.Ts_gv.Visible = false;
                    f.Ts_Btn_user.Visible = false;
                    f.Ts_Btn_quanly.Visible = false;
                }
                else if (u != 0)
                {
                    MessageBox.Show("Bạn đã đăng nhập vào tài khoản User!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.Ts_Btn_dangnhap.Visible = false;
                    f.Ts_Btn_admin.Visible = false;
                    f.Ts_truongkhoa.Visible = false;
                    f.Ts_gv.Visible = false;
                    f.Ts_Btn_user.Visible = false;
                    f.Ts_Btn_quanly.Visible = false;
                    f.toolStripSeparator1.Visible = false;
                    f.Ts_capnhatdiem.Visible = false;
                }
                else if (tkhoa != 0)
                {
                    MessageBox.Show("Bạn đã đăng nhập vào tài khoản Trưởng khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.Ts_Btn_dangnhap.Visible = false;
                    f.Ts_Btn_admin.Visible = false;
                    f.Ts_truongkhoa.Visible = false;
                    f.toolStripSeparator1.Visible = false;
                    f.Ts_gv.Visible = false;
                    f.Ts_Btn_user.Visible = false;
                    f.Ts_capnhatdiem.Visible = false;
                }

                this.Close(); 
                f.ShowDialog();
            }
            else
            {
                sai--;
                if (sai > 0)
                {
                    MessageBox.Show($"Sai tài khoản hoặc mật khẩu. Còn lại {sai} lần thử!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Bạn đã nhập sai quá 5 lần. Đăng nhập bị khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnOk.Enabled = false;
                }
            }

            sqlcon.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.PerformClick();

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.PerformClick();

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
