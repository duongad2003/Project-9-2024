namespace Login.capnhat
{
    partial class cn_sinhvien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_dong = new System.Windows.Forms.Button();
            this.btn_nhaplai = new System.Windows.Forms.Button();
            this.btn_Xóa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.txtMalop = new System.Windows.Forms.ComboBox();
            this.sinhvienBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.quanLySinhVienDataSet = new Login.QuanLySinhVienDataSet();
            this.txtMacs = new System.Windows.Forms.ComboBox();
            this.sinhvienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.dtNgaysinh = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTensv = new System.Windows.Forms.TextBox();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMasv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sinhvienTableAdapter = new Login.QuanLySinhVienDataSetTableAdapters.sinhvienTableAdapter();
            this.fKdiemsinhvienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.diemTableAdapter = new Login.QuanLySinhVienDataSetTableAdapters.diemTableAdapter();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sinhvienBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySinhVienDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinhvienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fKdiemsinhvienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_dong);
            this.groupBox2.Controls.Add(this.btn_nhaplai);
            this.groupBox2.Controls.Add(this.btn_Xóa);
            this.groupBox2.Controls.Add(this.btn_Sua);
            this.groupBox2.Controls.Add(this.btn_Them);
            this.groupBox2.Controls.Add(this.txtMalop);
            this.groupBox2.Controls.Add(this.txtMacs);
            this.groupBox2.Controls.Add(this.rdNu);
            this.groupBox2.Controls.Add(this.rdNam);
            this.groupBox2.Controls.Add(this.dtNgaysinh);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtDiachi);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTensv);
            this.groupBox2.Controls.Add(this.txtSdt);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtMasv);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 449);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin khoa";
            // 
            // btn_dong
            // 
            this.btn_dong.Location = new System.Drawing.Point(259, 397);
            this.btn_dong.Name = "btn_dong";
            this.btn_dong.Size = new System.Drawing.Size(89, 34);
            this.btn_dong.TabIndex = 18;
            this.btn_dong.Text = "Đóng";
            this.btn_dong.UseVisualStyleBackColor = true;
            this.btn_dong.Click += new System.EventHandler(this.btn_dong_Click);
            // 
            // btn_nhaplai
            // 
            this.btn_nhaplai.Location = new System.Drawing.Point(126, 397);
            this.btn_nhaplai.Name = "btn_nhaplai";
            this.btn_nhaplai.Size = new System.Drawing.Size(89, 34);
            this.btn_nhaplai.TabIndex = 17;
            this.btn_nhaplai.Text = "Nhập lại";
            this.btn_nhaplai.UseVisualStyleBackColor = true;
            this.btn_nhaplai.Click += new System.EventHandler(this.btn_nhaplai_Click);
            // 
            // btn_Xóa
            // 
            this.btn_Xóa.Location = new System.Drawing.Point(318, 343);
            this.btn_Xóa.Name = "btn_Xóa";
            this.btn_Xóa.Size = new System.Drawing.Size(89, 34);
            this.btn_Xóa.TabIndex = 16;
            this.btn_Xóa.Text = "Xóa";
            this.btn_Xóa.UseVisualStyleBackColor = true;
            this.btn_Xóa.Click += new System.EventHandler(this.btn_Xóa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Location = new System.Drawing.Point(194, 343);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(89, 34);
            this.btn_Sua.TabIndex = 15;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(64, 343);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(89, 34);
            this.btn_Them.TabIndex = 14;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // txtMalop
            // 
            this.txtMalop.DataSource = this.sinhvienBindingSource1;
            this.txtMalop.DisplayMember = "malop";
            this.txtMalop.FormattingEnabled = true;
            this.txtMalop.Location = new System.Drawing.Point(161, 285);
            this.txtMalop.Name = "txtMalop";
            this.txtMalop.Size = new System.Drawing.Size(328, 27);
            this.txtMalop.TabIndex = 11;
            this.txtMalop.ValueMember = "malop";
            // 
            // sinhvienBindingSource1
            // 
            this.sinhvienBindingSource1.DataMember = "sinhvien";
            this.sinhvienBindingSource1.DataSource = this.quanLySinhVienDataSet;
            // 
            // quanLySinhVienDataSet
            // 
            this.quanLySinhVienDataSet.DataSetName = "QuanLySinhVienDataSet";
            this.quanLySinhVienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtMacs
            // 
            this.txtMacs.DataSource = this.sinhvienBindingSource;
            this.txtMacs.DisplayMember = "macs";
            this.txtMacs.FormattingEnabled = true;
            this.txtMacs.Location = new System.Drawing.Point(161, 252);
            this.txtMacs.Name = "txtMacs";
            this.txtMacs.Size = new System.Drawing.Size(328, 27);
            this.txtMacs.TabIndex = 11;
            this.txtMacs.ValueMember = "macs";
            // 
            // sinhvienBindingSource
            // 
            this.sinhvienBindingSource.DataMember = "sinhvien";
            this.sinhvienBindingSource.DataSource = this.quanLySinhVienDataSet;
            // 
            // rdNu
            // 
            this.rdNu.AutoSize = true;
            this.rdNu.Location = new System.Drawing.Point(307, 114);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(52, 23);
            this.rdNu.TabIndex = 10;
            this.rdNu.TabStop = true;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            // 
            // rdNam
            // 
            this.rdNam.AutoSize = true;
            this.rdNam.Location = new System.Drawing.Point(161, 114);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(64, 23);
            this.rdNam.TabIndex = 10;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            // 
            // dtNgaysinh
            // 
            this.dtNgaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgaysinh.Location = new System.Drawing.Point(161, 150);
            this.dtNgaysinh.Name = "dtNgaysinh";
            this.dtNgaysinh.Size = new System.Drawing.Size(328, 27);
            this.dtNgaysinh.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Mã lớp";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Mã chính sách";
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(161, 219);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Size = new System.Drawing.Size(328, 27);
            this.txtDiachi.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Địa chỉ";
            // 
            // txtTensv
            // 
            this.txtTensv.Location = new System.Drawing.Point(161, 81);
            this.txtTensv.Name = "txtTensv";
            this.txtTensv.Size = new System.Drawing.Size(328, 27);
            this.txtTensv.TabIndex = 2;
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(161, 183);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(328, 27);
            this.txtSdt.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ngày sinh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Số điện thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên sinh viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Giới tính";
            // 
            // txtMasv
            // 
            this.txtMasv.Location = new System.Drawing.Point(161, 48);
            this.txtMasv.Name = "txtMasv";
            this.txtMasv.Size = new System.Drawing.Size(328, 27);
            this.txtMasv.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã sinh viên";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(513, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(812, 449);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1313, 119);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(434, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách sinh viên";
            // 
            // sinhvienTableAdapter
            // 
            this.sinhvienTableAdapter.ClearBeforeFill = true;
            // 
            // fKdiemsinhvienBindingSource
            // 
            this.fKdiemsinhvienBindingSource.DataMember = "FK_diem_sinhvien";
            this.fKdiemsinhvienBindingSource.DataSource = this.sinhvienBindingSource;
            // 
            // diemTableAdapter
            // 
            this.diemTableAdapter.ClearBeforeFill = true;
            // 
            // cn_sinhvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 594);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "cn_sinhvien";
            this.Text = "cn_sinhvien";
            this.Load += new System.EventHandler(this.cn_sinhvien_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sinhvienBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySinhVienDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinhvienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fKdiemsinhvienBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.DateTimePicker dtNgaysinh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTensv;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMasv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtMalop;
        private System.Windows.Forms.ComboBox txtMacs;
        private QuanLySinhVienDataSet quanLySinhVienDataSet;
        private System.Windows.Forms.BindingSource sinhvienBindingSource;
        private QuanLySinhVienDataSetTableAdapters.sinhvienTableAdapter sinhvienTableAdapter;
        private System.Windows.Forms.BindingSource fKdiemsinhvienBindingSource;
        private QuanLySinhVienDataSetTableAdapters.diemTableAdapter diemTableAdapter;
        private System.Windows.Forms.BindingSource sinhvienBindingSource1;
        private System.Windows.Forms.Button btn_dong;
        private System.Windows.Forms.Button btn_nhaplai;
        private System.Windows.Forms.Button btn_Xóa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Them;
    }
}