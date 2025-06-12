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

namespace Login.timkiem
{
    public partial class tk_monhoc : Form
    {
        public tk_monhoc()
        {
            InitializeComponent();
        }
        SqlConnection sqlcon = new SqlConnection();
        public void ketnoi()
        {
            string ketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

            //string ketnoi = @"Data Source=LAPTOP-662R1F6L;Initial Catalog=quanlysinhvien;Integrated Security=True;Encrypt=True;";
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

        private void tk_monhoc_Load(object sender, EventArgs e)
        {
            ketnoi();
            LoadData();
        }

        private void btntimkiem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string timkiem = txttimkiem.Text.Trim();
                string loaiTimKiem = combobox1.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(timkiem)) 
                {
                    MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(loaiTimKiem)) 
                {
                    MessageBox.Show("Vui lòng chọn loại tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "";
                switch (loaiTimKiem)
                {
                    case "Mã môn học":
                        sql = "SELECT mamh AS [Mã môn học], tenmh AS [Tên môn học], sotiet AS [Số tiết], magv AS [Mã giáo viên] " +
                              "FROM monhoc " +
                              "WHERE mamh LIKE @searchText";
                        break;
                    case "Tên môn học":
                        sql = "SELECT mamh AS [Mã môn học], tenmh AS [Tên môn học], sotiet AS [Số tiết], magv AS [Mã giáo viên] " +
                              "FROM monhoc " +
                              "WHERE tenmh LIKE @searchText";
                        break;
                    case "Số tiết":
                        sql = "SELECT mamh AS [Mã môn học], tenmh AS [Tên môn học], sotiet AS [Số tiết], magv AS [Mã giáo viên] " +
                              "FROM monhoc " +
                              "WHERE CAST(sotiet AS NVARCHAR) LIKE @searchText";
                        break;
                    case "Mã giáo viên":
                        sql = "SELECT mamh AS [Mã môn học], tenmh AS [Tên môn học], sotiet AS [Số tiết], magv AS [Mã giáo viên] " +
                              "FROM monhoc " +
                              "WHERE magv LIKE @searchText";
                        break;
                    default:
                        MessageBox.Show("Loại tìm kiếm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }

                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@searchText", "%" + timkiem + "%"); 

                DataSet ds = new DataSet();
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                sqlda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //private void btntimkiem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string timkiem = txttimkiem.Text.Trim();
        //        if (string.IsNullOrEmpty(timkiem)) 
        //        {
        //            MessageBox.Show("Vui lòng nhập mã môn học hoặc tên môn học để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        string sql = "SELECT mamh AS [Mã môn học], tenmh AS [Tên môn học], số tiết AS [Số tiết], magv AS [Mã giáo viên] " +
        //                     "FROM monhoc " +
        //                     "WHERE mamh LIKE @searchText OR tenmh LIKE @searchText";

        //        if (sqlcon.State == ConnectionState.Closed)
        //        {
        //            sqlcon.Open();
        //        }

        //        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        //        cmd.Parameters.AddWithValue("@searchText", "%" + timkiem + "%"); 

        //        DataSet ds = new DataSet();
        //        SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
        //        sqlda.Fill(ds);

        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            dataGridView1.DataSource = ds.Tables[0];
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            dataGridView1.DataSource = null; // Xóa dữ liệu cũ nếu không có kết quả
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Đã có lỗi xảy ra khi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

    }
}


