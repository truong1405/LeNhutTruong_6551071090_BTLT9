namespace TraSuaApp.Forms;

partial class FormThucDon
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.grpThongTin = new System.Windows.Forms.GroupBox();
        this.chkDangBan = new System.Windows.Forms.CheckBox();
        this.numGiaBan = new System.Windows.Forms.NumericUpDown();
        this.cboDanhMuc = new System.Windows.Forms.ComboBox();
        this.txtTenMon = new System.Windows.Forms.TextBox();
        this.lblDangBan = new System.Windows.Forms.Label();
        this.lblGiaBan = new System.Windows.Forms.Label();
        this.lblDanhMuc = new System.Windows.Forms.Label();
        this.lblTenMon = new System.Windows.Forms.Label();
        this.btnThem = new System.Windows.Forms.Button();
        this.btnSua = new System.Windows.Forms.Button();
        this.btnXoa = new System.Windows.Forms.Button();
        this.btnLamMoi = new System.Windows.Forms.Button();
        this.grpTimKiem = new System.Windows.Forms.GroupBox();
        this.btnBoLoc = new System.Windows.Forms.Button();
        this.cboLocDanhMuc = new System.Windows.Forms.ComboBox();
        this.lblLocDanhMuc = new System.Windows.Forms.Label();
        this.txtTimKiem = new System.Windows.Forms.TextBox();
        this.lblTimKiem = new System.Windows.Forms.Label();
        this.dgvMonUong = new System.Windows.Forms.DataGridView();
        this.lblTongSoMon = new System.Windows.Forms.Label();

        this.grpThongTin.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numGiaBan)).BeginInit();
        this.grpTimKiem.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvMonUong)).BeginInit();
        this.SuspendLayout();

        // 
        // grpThongTin
        // 
        this.grpThongTin.Controls.Add(this.chkDangBan);
        this.grpThongTin.Controls.Add(this.numGiaBan);
        this.grpThongTin.Controls.Add(this.cboDanhMuc);
        this.grpThongTin.Controls.Add(this.txtTenMon);
        this.grpThongTin.Controls.Add(this.lblDangBan);
        this.grpThongTin.Controls.Add(this.lblGiaBan);
        this.grpThongTin.Controls.Add(this.lblDanhMuc);
        this.grpThongTin.Controls.Add(this.lblTenMon);
        this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpThongTin.Location = new System.Drawing.Point(12, 12);
        this.grpThongTin.Name = "grpThongTin";
        this.grpThongTin.Size = new System.Drawing.Size(430, 195);
        this.grpThongTin.TabIndex = 0;
        this.grpThongTin.TabStop = false;
        this.grpThongTin.Text = "Thông tin món uống";

        // 
        // lblTenMon
        // 
        this.lblTenMon.AutoSize = true;
        this.lblTenMon.Location = new System.Drawing.Point(15, 33);
        this.lblTenMon.Name = "lblTenMon";
        this.lblTenMon.Size = new System.Drawing.Size(62, 17);
        this.lblTenMon.TabIndex = 0;
        this.lblTenMon.Text = "Tên món:";

        // 
        // txtTenMon
        // 
        this.txtTenMon.Location = new System.Drawing.Point(100, 30);
        this.txtTenMon.Name = "txtTenMon";
        this.txtTenMon.Size = new System.Drawing.Size(310, 25);
        this.txtTenMon.TabIndex = 1;

        // 
        // lblDanhMuc
        // 
        this.lblDanhMuc.AutoSize = true;
        this.lblDanhMuc.Location = new System.Drawing.Point(15, 73);
        this.lblDanhMuc.Name = "lblDanhMuc";
        this.lblDanhMuc.Size = new System.Drawing.Size(70, 17);
        this.lblDanhMuc.TabIndex = 2;
        this.lblDanhMuc.Text = "Danh mục:";

        // 
        // cboDanhMuc
        // 
        this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboDanhMuc.FormattingEnabled = true;
        this.cboDanhMuc.Location = new System.Drawing.Point(100, 70);
        this.cboDanhMuc.Name = "cboDanhMuc";
        this.cboDanhMuc.Size = new System.Drawing.Size(310, 25);
        this.cboDanhMuc.TabIndex = 3;

        // 
        // lblGiaBan
        // 
        this.lblGiaBan.AutoSize = true;
        this.lblGiaBan.Location = new System.Drawing.Point(15, 113);
        this.lblGiaBan.Name = "lblGiaBan";
        this.lblGiaBan.Size = new System.Drawing.Size(56, 17);
        this.lblGiaBan.TabIndex = 4;
        this.lblGiaBan.Text = "Giá bán:";

        // 
        // numGiaBan
        // 
        this.numGiaBan.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
        this.numGiaBan.Location = new System.Drawing.Point(100, 111);
        this.numGiaBan.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
        this.numGiaBan.Name = "numGiaBan";
        this.numGiaBan.Size = new System.Drawing.Size(310, 25);
        this.numGiaBan.TabIndex = 5;
        this.numGiaBan.ThousandsSeparator = true;

        // 
        // lblDangBan
        // 
        this.lblDangBan.AutoSize = true;
        this.lblDangBan.Location = new System.Drawing.Point(15, 153);
        this.lblDangBan.Name = "lblDangBan";
        this.lblDangBan.Size = new System.Drawing.Size(71, 17);
        this.lblDangBan.TabIndex = 6;
        this.lblDangBan.Text = "Trạng thái:";

        // 
        // chkDangBan
        // 
        this.chkDangBan.AutoSize = true;
        this.chkDangBan.Checked = true;
        this.chkDangBan.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkDangBan.Location = new System.Drawing.Point(100, 152);
        this.chkDangBan.Name = "chkDangBan";
        this.chkDangBan.Size = new System.Drawing.Size(83, 21);
        this.chkDangBan.TabIndex = 7;
        this.chkDangBan.Text = "Đang bán";
        this.chkDangBan.UseVisualStyleBackColor = true;

        // 
        // btnThem
        // 
        this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
        this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnThem.ForeColor = System.Drawing.Color.White;
        this.btnThem.Location = new System.Drawing.Point(12, 217);
        this.btnThem.Name = "btnThem";
        this.btnThem.Size = new System.Drawing.Size(95, 34);
        this.btnThem.TabIndex = 1;
        this.btnThem.Text = "Thêm";
        this.btnThem.UseVisualStyleBackColor = false;
        this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

        // 
        // btnSua
        // 
        this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
        this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnSua.ForeColor = System.Drawing.Color.White;
        this.btnSua.Location = new System.Drawing.Point(123, 217);
        this.btnSua.Name = "btnSua";
        this.btnSua.Size = new System.Drawing.Size(95, 34);
        this.btnSua.TabIndex = 2;
        this.btnSua.Text = "Sửa";
        this.btnSua.UseVisualStyleBackColor = false;
        this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

        // 
        // btnXoa
        // 
        this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnXoa.ForeColor = System.Drawing.Color.White;
        this.btnXoa.Location = new System.Drawing.Point(234, 217);
        this.btnXoa.Name = "btnXoa";
        this.btnXoa.Size = new System.Drawing.Size(95, 34);
        this.btnXoa.TabIndex = 3;
        this.btnXoa.Text = "Xóa";
        this.btnXoa.UseVisualStyleBackColor = false;
        this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

        // 
        // btnLamMoi
        // 
        this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
        this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnLamMoi.ForeColor = System.Drawing.Color.White;
        this.btnLamMoi.Location = new System.Drawing.Point(345, 217);
        this.btnLamMoi.Name = "btnLamMoi";
        this.btnLamMoi.Size = new System.Drawing.Size(97, 34);
        this.btnLamMoi.TabIndex = 4;
        this.btnLamMoi.Text = "Làm mới";
        this.btnLamMoi.UseVisualStyleBackColor = false;
        this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

        // 
        // grpTimKiem
        // 
        this.grpTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.grpTimKiem.Controls.Add(this.btnBoLoc);
        this.grpTimKiem.Controls.Add(this.cboLocDanhMuc);
        this.grpTimKiem.Controls.Add(this.lblLocDanhMuc);
        this.grpTimKiem.Controls.Add(this.txtTimKiem);
        this.grpTimKiem.Controls.Add(this.lblTimKiem);
        this.grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpTimKiem.Location = new System.Drawing.Point(460, 12);
        this.grpTimKiem.Name = "grpTimKiem";
        this.grpTimKiem.Size = new System.Drawing.Size(462, 195);
        this.grpTimKiem.TabIndex = 5;
        this.grpTimKiem.TabStop = false;
        this.grpTimKiem.Text = "Tìm kiếm và lọc";

        // 
        // lblTimKiem
        // 
        this.lblTimKiem.AutoSize = true;
        this.lblTimKiem.Location = new System.Drawing.Point(15, 33);
        this.lblTimKiem.Name = "lblTimKiem";
        this.lblTimKiem.Size = new System.Drawing.Size(111, 17);
        this.lblTimKiem.TabIndex = 0;
        this.lblTimKiem.Text = "Tìm theo tên món:";

        // 
        // txtTimKiem
        // 
        this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.txtTimKiem.Location = new System.Drawing.Point(140, 30);
        this.txtTimKiem.Name = "txtTimKiem";
        this.txtTimKiem.PlaceholderText = "Nhập tên món cần tìm...";
        this.txtTimKiem.Size = new System.Drawing.Size(306, 25);
        this.txtTimKiem.TabIndex = 1;
        this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

        // 
        // lblLocDanhMuc
        // 
        this.lblLocDanhMuc.AutoSize = true;
        this.lblLocDanhMuc.Location = new System.Drawing.Point(15, 73);
        this.lblLocDanhMuc.Name = "lblLocDanhMuc";
        this.lblLocDanhMuc.Size = new System.Drawing.Size(95, 17);
        this.lblLocDanhMuc.TabIndex = 2;
        this.lblLocDanhMuc.Text = "Lọc danh mục:";

        // 
        // cboLocDanhMuc
        // 
        this.cboLocDanhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.cboLocDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboLocDanhMuc.FormattingEnabled = true;
        this.cboLocDanhMuc.Location = new System.Drawing.Point(140, 70);
        this.cboLocDanhMuc.Name = "cboLocDanhMuc";
        this.cboLocDanhMuc.Size = new System.Drawing.Size(306, 25);
        this.cboLocDanhMuc.TabIndex = 3;
        this.cboLocDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboLocDanhMuc_SelectedIndexChanged);

        // 
        // btnBoLoc
        // 
        this.btnBoLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
        this.btnBoLoc.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnBoLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnBoLoc.Location = new System.Drawing.Point(140, 110);
        this.btnBoLoc.Name = "btnBoLoc";
        this.btnBoLoc.Size = new System.Drawing.Size(110, 30);
        this.btnBoLoc.TabIndex = 4;
        this.btnBoLoc.Text = "Bỏ lọc";
        this.btnBoLoc.UseVisualStyleBackColor = false;
        this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);

        // 
        // dgvMonUong
        // 
        this.dgvMonUong.AllowUserToAddRows = false;
        this.dgvMonUong.AllowUserToDeleteRows = false;
        this.dgvMonUong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.dgvMonUong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvMonUong.BackgroundColor = System.Drawing.Color.White;
        this.dgvMonUong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvMonUong.Location = new System.Drawing.Point(12, 265);
        this.dgvMonUong.MultiSelect = false;
        this.dgvMonUong.Name = "dgvMonUong";
        this.dgvMonUong.ReadOnly = true;
        this.dgvMonUong.RowHeadersWidth = 30;
        this.dgvMonUong.RowTemplate.Height = 28;
        this.dgvMonUong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvMonUong.Size = new System.Drawing.Size(910, 300);
        this.dgvMonUong.TabIndex = 6;
        this.dgvMonUong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonUong_CellClick);
        this.dgvMonUong.SelectionChanged += new System.EventHandler(this.dgvMonUong_SelectionChanged);

        // 
        // lblTongSoMon
        // 
        this.lblTongSoMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.lblTongSoMon.AutoSize = true;
        this.lblTongSoMon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
        this.lblTongSoMon.Location = new System.Drawing.Point(12, 575);
        this.lblTongSoMon.Name = "lblTongSoMon";
        this.lblTongSoMon.Size = new System.Drawing.Size(127, 17);
        this.lblTongSoMon.TabIndex = 7;
        this.lblTongSoMon.Text = "Tổng số món hiển thị: 0";

        // 
        // FormThucDon
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
        this.ClientSize = new System.Drawing.Size(934, 605);
        this.Controls.Add(this.lblTongSoMon);
        this.Controls.Add(this.dgvMonUong);
        this.Controls.Add(this.grpTimKiem);
        this.Controls.Add(this.btnLamMoi);
        this.Controls.Add(this.btnXoa);
        this.Controls.Add(this.btnSua);
        this.Controls.Add(this.btnThem);
        this.Controls.Add(this.grpThongTin);
        this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.MinimumSize = new System.Drawing.Size(850, 550);
        this.Name = "FormThucDon";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Quản lý thực đơn món uống";
        this.Load += new System.EventHandler(this.FormThucDon_Load);
        this.grpThongTin.ResumeLayout(false);
        this.grpThongTin.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numGiaBan)).EndInit();
        this.grpTimKiem.ResumeLayout(false);
        this.grpTimKiem.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvMonUong)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.GroupBox grpThongTin;
    private System.Windows.Forms.Label lblTenMon;
    private System.Windows.Forms.TextBox txtTenMon;
    private System.Windows.Forms.Label lblDanhMuc;
    private System.Windows.Forms.ComboBox cboDanhMuc;
    private System.Windows.Forms.Label lblGiaBan;
    private System.Windows.Forms.NumericUpDown numGiaBan;
    private System.Windows.Forms.Label lblDangBan;
    private System.Windows.Forms.CheckBox chkDangBan;
    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;
    private System.Windows.Forms.GroupBox grpTimKiem;
    private System.Windows.Forms.Label lblTimKiem;
    private System.Windows.Forms.TextBox txtTimKiem;
    private System.Windows.Forms.Label lblLocDanhMuc;
    private System.Windows.Forms.ComboBox cboLocDanhMuc;
    private System.Windows.Forms.Button btnBoLoc;
    private System.Windows.Forms.DataGridView dgvMonUong;
    private System.Windows.Forms.Label lblTongSoMon;
}
