using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class frmSignup : Form
    {
        public frmSignup()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            signup();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void signup()
        {

            SqlConnection conn;
            SqlDataReader dr;
            SqlCommand cmd;
            String cn = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            conn = new SqlConnection(cn);
            conn.Open();


            if (txtRepass.Text != string.Empty || txtPass.Text != string.Empty || txtUsername.Text != string.Empty)
            {
                if (txtPass.Text == txtRepass.Text)
                {
                    try
                    {
                        cmd = new SqlCommand("insert into nguoidung values(@username,@password)", conn);
                        cmd.Parameters.AddWithValue("username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("password", txtPass.Text);
                        cmd.ExecuteNonQuery();
                        DialogResult dialogResult = MessageBox.Show("Tạo tài khoản thành công. Quay lại đăng nhập chứ", "Đăng ký thành công", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Form f = new frmLogin();
                            f.ShowDialog();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            clear();
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Xác nhận mật khâu không trùng khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void clear()
        {
            txtPass.Text = "";
            txtRepass.Text = "";
            txtUsername.Text = "";
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

        private void txtRepass_KeyDown(object sender, KeyEventArgs e)
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
