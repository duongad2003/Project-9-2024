﻿using Login.In;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.thongtin
{
    public partial class Sinhvien : Form
    {
        public Sinhvien()
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
                string sql = "SELECT masv AS [Mã sinh viên], tensv AS [Tên sinh viên], gioitinh AS [Giới tính], ngaysinh AS [Ngày sinh], sdt AS [Số điện thoại], diachi AS [Địa chỉ], macs AS [Mã chính sách], malop AS [Mã lớp] FROM [dbo].[sinhvien];";
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

        private void Sinhvien_Load(object sender, EventArgs e)
        {
            ketnoi();
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtMasv.Text = row.Cells["Mã sinh viên"].Value.ToString();
                    txtTensv.Text = row.Cells["Tên sinh viên"].Value.ToString();
                    string gt = row.Cells["Giới tính"].Value.ToString();
                    if (gt == "Nam")
                    {
                        rdNam.Checked = true;
                        rdNu.Checked = false;
                    }
                    else
                    {
                        rdNam.Checked = false;
                        rdNu.Checked = true;
                    }
                    dtNs.Value = Convert.ToDateTime(row.Cells["Ngày sinh"].Value);
                    txtSdt.Text = row.Cells["Số điện thoại"].Value.ToString();
                    txtDiachi.Text = row.Cells["Địa chỉ"].Value.ToString();
                    txtCs.Text = row.Cells["Mã chính sách"].Value.ToString();
                    txtMalop.Text = row.Cells["Mã lớp"].Value.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            InSinhVien f = new InSinhVien();    
            f.ShowDialog();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
