using Login.capnhat;
using Login.Quanly;
using Login.thongtin;
using Login.timkiem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Login
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lbtextchay.Left -= 5;
            if (lbtextchay.Right <= (this.Width - 1000))
            {
                timer1.Enabled = false;
                lbtextchay.Left = 0;
                timer1.Enabled = true;
            }

        }

        private void Ts_Btn_admin_Click(object sender, EventArgs e)
        {
            admin sv = new admin();
            sv.Show();
        }

        private void Ts_truongkhoa_Click(object sender, EventArgs e)
        {
            ac_truongkhoa f = new ac_truongkhoa();
            f.Show();
        }

        private void Ts_gv_Click(object sender, EventArgs e)
        {
            capnhat.ac_giaovien f = new capnhat.ac_giaovien();
            f.Show();
        }

        private void Ts_Btn_user_Click(object sender, EventArgs e)
        {
            ac_user f = new ac_user();
            f.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick; 
            timer1.Start();
        }

        private void lbtextchay_Click(object sender, EventArgs e)
        {
            String tt;
            tt = "Phần mềm: QUẢN LÝ SINH VIÊN \n";
            tt += "\n";
            tt += "Version: 1.1 \n";
            tt += "\n";
            tt += "Học phần thực tập: \n\n";
            tt += "Lập trình hướng cơ sở dữ liệu \n";
            tt += "\n\n";
            tt += "Copy right @ năm 2024 \n";
            tt += "Designer by: Nguyễn Thái Dương \n";
            tt += "Email: ntd@gmail.com \n";
            MessageBox.Show((tt), "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Ts_Btn_khoa_Click(object sender, EventArgs e)
        {
            Ts_Btn_dangnhap.Visible = true;
            Ts_Btn_admin.Visible = false;
            Ts_Btn_user.Visible = false;
            Ts_Btn_dangxuat.Visible = false;
            Ts_Btn_khoa.Visible = false;

            Ts_Btn_timkiem.Enabled = false;
            Ts_Btn_quanly.Enabled = false;
            Ts_capnhatdiem.Visible = false;
            Ts_Btn_hienthi.Enabled = false;
            Ts_Btn_tienich.Enabled = false;
            Ts_gv.Visible = false;
            Ts_truongkhoa.Visible = false;
            Ts_Btn_thongtin.Enabled = false;
        }

        private void Ts_Btn_doimatkhau_Click(object sender, EventArgs e)
        {

        }

        private void Ts_Btn_dangnhap_Click(object sender, EventArgs e)
        {
            Form f = new frmLogin();
            f.ShowDialog();
            
            this.Close();
        }

        private void Ts_Btn_dangxuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Bạn đã đăng xuất thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmHome f = new frmHome ();

                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String tt;
            tt = "Phần mềm: QUẢN LÝ SINH VIÊN \n";
            tt += "\n";
            tt += "Version: 1.1 \n";
            tt += "\n";
            tt += "Học phần thực tập: \n\n";
            tt += "Lập trình hướng cơ sở dữ liệu \n";
            tt += "\n\n";
            tt += "Copy right @ năm 2024 \n";
            tt += "Designer by: Nguyễn Thái Dương \n";
            tt += "Email: ntd@gmail.com \n";
            MessageBox.Show((tt), "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String tt;
            tt = "Phần mềm: QUẢN LÝ SINH VIÊN \n";
            tt += "\n";
            tt += "Version: 1.1 \n";
            tt += "\n";
            tt += "Học phần thực tập: \n\n";
            tt += "Lập trình hướng cơ sở dữ liệu \n";
            tt += "\n\n";
            tt += "Copy right @ năm 2024 \n";
            tt += "Designer by: Nguyễn Thái Dương \n";
            tt += "Email: ntd@gmail.com \n";
            MessageBox.Show((tt), "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cậpNhậtPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không có bản cập nhật nào !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Ts_Btn_ti_pain_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\WindowsApps\Microsoft.Paint_11.2408.30.0_x64__8wekyb3d8bbwe\PaintApp\mspaint.exe");
        }

        private void Ts_Btn_ti_cmd_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Windows\System32\cmd.exe");
        }

        private void Ts_Btn_ti_note_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\WindowsApps\Microsoft.WindowsNotepad_11.2409.9.0_x64__8wekyb3d8bbwe\Notepad\Notepad.exe");
        }

        private void Ts_Btn_ti_cal_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Windows\System32\calc.exe");
        }

        private void Ts_Btn_ti_mw_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE");
        }

        private void Ts_thoat_Click(object sender, EventArgs e)
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

        private void Ts_Btn_tt_khoa_Click(object sender, EventArgs e)
        {
            Form f = new khoa();
            f.ShowDialog();
        }

        private void Ts_Btn_tk_khoa_Click(object sender, EventArgs e)
        {
            tk_khoa f = new tk_khoa();
            f.ShowDialog();
        }

        private void Ts_Btn_ql_khoa_Click(object sender, EventArgs e)
        {
            Form f = new ql_khoa();
            f.ShowDialog();
        }

        private void Ts_Btn_ht_op50_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.8;
            
        }

        private void Ts_Btn_ht_op100_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.45;
        }

        private void mặcDịnhdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void Ts_Btn_ql_giaovien_Click(object sender, EventArgs e)
        {
            Form f = new cn_giaovien();
            f.ShowDialog();
        }


        private void Ts_Btn_ql_monhoc_Click(object sender, EventArgs e)
        {
            cn_monhoc f = new cn_monhoc();
            f.ShowDialog();
        }

        private void Ts_Btn_tt_giaovien_Click(object sender, EventArgs e)
        {
            Form f = new giaovien();
            f.ShowDialog();
        }

        private void Ts_Btn_tt_chinhsach_Click(object sender, EventArgs e)
        {
            Form f = new chinhsach();
            f.ShowDialog(); 
        }

        private void Ts_Btn_tt_lop_Click(object sender, EventArgs e)
        {
            lop f = new lop();
            f.ShowDialog();
        }

        private void Ts_Btn_tt_sinhvien_Click(object sender, EventArgs e)
        {
            Sinhvien f = new Sinhvien();    
            f.ShowDialog();
        }

        private void Ts_Btn_tt_monhoc_Click(object sender, EventArgs e)
        {
            monhoc f = new monhoc();
            f.ShowDialog();
        }

        private void Ts_Btn_tt_diem_Click(object sender, EventArgs e)
        {
            diem f = new diem();
            f.ShowDialog();
        }

        private void Ts_Btn_ql_chinhsach_Click(object sender, EventArgs e)
        {
            cn_chinhsach f = new cn_chinhsach();
            f .ShowDialog();
        }

        private void cn_Lop_Click(object sender, EventArgs e)
        {
            Form f = new cn_lop();
            f.ShowDialog();
        }

        private void cn_sinhvien_Click(object sender, EventArgs e)
        {
            Form f = new cn_sinhvien();
            f .ShowDialog();
        }

        private void Ts_Btn_ql_diem_Click(object sender, EventArgs e)
        {
            cn_diem f = new cn_diem();
            f .ShowDialog();
        }

        private void Ts_Btn_tk_giaovien_Click(object sender, EventArgs e)
        {
            tk_giaovien f = new tk_giaovien();
            f .ShowDialog();    
        }

        private void Ts_Btn_tk_lop_Click(object sender, EventArgs e)
        {
            tk_lop f = new tk_lop();
            f .ShowDialog();
        }

        private void Ts_Btn_tk_sv_Click(object sender, EventArgs e)
        {
            tk_sinhvien f = new tk_sinhvien();
            f .ShowDialog();

        }

        private void Ts_Btn_tk_monhoc_Click(object sender, EventArgs e)
        {
            tk_monhoc f = new tk_monhoc();
            f .ShowDialog();
        }

        private void Ts_Btn_tk_chinhsach_Click(object sender, EventArgs e)
        {
            tk_chinhsach f = new tk_chinhsach();
            f .ShowDialog();
        }
    }
}
