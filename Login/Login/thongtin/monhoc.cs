using Login.In;
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

namespace Login.thongtin
{
    public partial class monhoc : Form
    {
        public monhoc()
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


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtMamh.Text = row.Cells["Mã môn học"].Value.ToString();
                    txtTenmh.Text = row.Cells["Tên môn học"].Value.ToString();
                    txtSotiet.Text = row.Cells["Số tiết"].Value.ToString();
                    txtMagv.Text = row.Cells["Mã giáo viên"].Value.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            InMonHoc f = new InMonHoc();    
            f.ShowDialog();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void monhoc_Load(object sender, EventArgs e)
        {
            ketnoi();
            LoadData();
        }
    }
}
