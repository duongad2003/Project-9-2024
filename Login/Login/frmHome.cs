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
    public partial class frmHome : Form
    {
        

        public frmHome()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form f = new frmLogin();
            f.ShowDialog();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            Form f = new frmSignup();
            f.ShowDialog();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            string tt;
            tt = "Phần mềm: QUẢN LÝ SINH VIÊN\n";
            tt += "\n";
            tt += "Version: 1.1 \n";
            tt += "Học phần Thực hành:\n\n";
            tt += "Thực hành lập trình .NET \n";
            tt += "\n\n";
            tt += "Copy right @ năm 2024\n";
            tt += "Designer by: Nguyễn Thái Dương \n";
            tt += "Email: ntd@gmail.com\n\n";
            MessageBox.Show((tt), "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbHome.Left -= 5;
            if (lbHome.Right <= (this.Width - 1000))
            {
                timer1.Enabled = false;
                lbHome.Left = 0;
                timer1.Enabled = true;
            }
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
