namespace TraSuaApp.Forms;

partial class FormBanHang
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
        this.menuStrip = new System.Windows.Forms.MenuStrip();
        this.menuHeThong = new System.Windows.Forms.ToolStripMenuItem();
        this.menuThoat = new System.Windows.Forms.ToolStripMenuItem();
        this.menuQuanLy = new System.Windows.Forms.ToolStripMenuItem();
        this.menuThucDon = new System.Windows.Forms.ToolStripMenuItem();
        this.menuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
        this.menuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
        this.menuThongTinTK = new System.Windows.Forms.ToolStripMenuItem();
        this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
        this.grpChonMon = new System.Windows.Forms.GroupBox();
        this.pnlChonMonBottom = new System.Windows.Forms.Panel();
        this.btnThemVaoDon = new System.Windows.Forms.Button();
        this.numSoLy = new System.Windows.Forms.NumericUpDown();
        this.lblSoLy = new System.Windows.Forms.Label();
        this.lstMonUong = new System.Windows.Forms.ListBox();
        this.pnlChonMonTop = new System.Windows.Forms.Panel();
        this.cboDanhMuc = new System.Windows.Forms.ComboBox();
        this.lblDanhMuc = new System.Windows.Forms.Label();
        this.grpDonHienTai = new System.Windows.Forms.GroupBox();
        this.pnlDonBottom = new System.Windows.Forms.Panel();
        this.lblTongTien = new System.Windows.Forms.Label();
        this.btnHuyDon = new System.Windows.Forms.Button();
        this.btnXoaDong = new System.Windows.Forms.Button();
        this.dgvGioHang = new System.Windows.Forms.DataGridView();
        this.grpThanhToan = new System.Windows.Forms.GroupBox();
        this.btnDaNhanTien = new System.Windows.Forms.Button();
        this.pnlQrInfo = new System.Windows.Forms.Panel();
        this.lblThongTinNganHang = new System.Windows.Forms.Label();
        this.lblNoiDung = new System.Windows.Forms.Label();
        this.lblSoTien = new System.Windows.Forms.Label();
        this.picQr = new System.Windows.Forms.PictureBox();
        this.pnlThanhToanButtons = new System.Windows.Forms.Panel();
        this.btnTienMat = new System.Windows.Forms.Button();
        this.btnThanhToanChuyenKhoan = new System.Windows.Forms.Button();
        this.statusStrip = new System.Windows.Forms.StatusStrip();
        this.lblTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
        this.lblShopName = new System.Windows.Forms.ToolStripStatusLabel();

        this.menuStrip.SuspendLayout();
        this.pnlMain.SuspendLayout();
        this.grpChonMon.SuspendLayout();
        this.pnlChonMonBottom.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numSoLy)).BeginInit();
        this.pnlChonMonTop.SuspendLayout();
        this.grpDonHienTai.SuspendLayout();
        this.pnlDonBottom.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
        this.grpThanhToan.SuspendLayout();
        this.pnlQrInfo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.picQr)).BeginInit();
        this.pnlThanhToanButtons.SuspendLayout();
        this.statusStrip.SuspendLayout();
        this.SuspendLayout();

        // 
        // menuStrip
        // 
        this.menuStrip.BackColor = System.Drawing.Color.White;
        this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHeThong,
            this.menuQuanLy,
            this.menuTroGiup});
        this.menuStrip.Location = new System.Drawing.Point(0, 0);
        this.menuStrip.Name = "menuStrip";
        this.menuStrip.Size = new System.Drawing.Size(1104, 25);
        this.menuStrip.TabIndex = 0;
        this.menuStrip.Text = "menuStrip";

        // 
        // menuHeThong
        // 
        this.menuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuThoat});
        this.menuHeThong.Name = "menuHeThong";
        this.menuHeThong.Size = new System.Drawing.Size(73, 21);
        this.menuHeThong.Text = "Hệ thống";

        // 
        // menuThoat
        // 
        this.menuThoat.Name = "menuThoat";
        this.menuThoat.Size = new System.Drawing.Size(109, 22);
        this.menuThoat.Text = "Thoát";
        this.menuThoat.Click += new System.EventHandler(this.menuThoat_Click);

        // 
        // menuQuanLy
        // 
        this.menuQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuThucDon,
            this.menuHoaDon});
        this.menuQuanLy.Name = "menuQuanLy";
        this.menuQuanLy.Size = new System.Drawing.Size(65, 21);
        this.menuQuanLy.Text = "Quản lý";

        // 
        // menuThucDon
        // 
        this.menuThucDon.Name = "menuThucDon";
        this.menuThucDon.Size = new System.Drawing.Size(242, 22);
        this.menuThucDon.Text = "📋 Quản lý thực đơn món";
        this.menuThucDon.Click += new System.EventHandler(this.menuThucDon_Click);

        // 
        // menuHoaDon
        // 
        this.menuHoaDon.Name = "menuHoaDon";
        this.menuHoaDon.Size = new System.Drawing.Size(242, 22);
        this.menuHoaDon.Text = "🧾 Danh sách hóa đơn && Doanh thu";
        this.menuHoaDon.Click += new System.EventHandler(this.menuHoaDon_Click);

        // 
        // menuTroGiup
        // 
        this.menuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuThongTinTK});
        this.menuTroGiup.Name = "menuTroGiup";
        this.menuTroGiup.Size = new System.Drawing.Size(69, 21);
        this.menuTroGiup.Text = "Cấu hình";

        // 
        // menuThongTinTK
        // 
        this.menuThongTinTK.Name = "menuThongTinTK";
        this.menuThongTinTK.Size = new System.Drawing.Size(228, 22);
        this.menuThongTinTK.Text = "💳 Thông tin VietQR thanh toán";
        this.menuThongTinTK.Click += new System.EventHandler(this.menuThongTinTK_Click);

        // 
        // pnlMain
        // 
        this.pnlMain.ColumnCount = 3;
        this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
        this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
        this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
        this.pnlMain.Controls.Add(this.grpChonMon, 0, 0);
        this.pnlMain.Controls.Add(this.grpDonHienTai, 1, 0);
        this.pnlMain.Controls.Add(this.grpThanhToan, 2, 0);
        this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlMain.Location = new System.Drawing.Point(0, 25);
        this.pnlMain.Name = "pnlMain";
        this.pnlMain.Padding = new System.Windows.Forms.Padding(8);
        this.pnlMain.RowCount = 1;
        this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.pnlMain.Size = new System.Drawing.Size(1104, 629);
        this.pnlMain.TabIndex = 1;

        // 
        // grpChonMon
        // 
        this.grpChonMon.Controls.Add(this.lstMonUong);
        this.grpChonMon.Controls.Add(this.pnlChonMonBottom);
        this.grpChonMon.Controls.Add(this.pnlChonMonTop);
        this.grpChonMon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpChonMon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpChonMon.Location = new System.Drawing.Point(11, 11);
        this.grpChonMon.Name = "grpChonMon";
        this.grpChonMon.Padding = new System.Windows.Forms.Padding(8);
        this.grpChonMon.Size = new System.Drawing.Size(298, 607);
        this.grpChonMon.TabIndex = 0;
        this.grpChonMon.TabStop = false;
        this.grpChonMon.Text = "Chọn món";

        // 
        // pnlChonMonTop
        // 
        this.pnlChonMonTop.Controls.Add(this.cboDanhMuc);
        this.pnlChonMonTop.Controls.Add(this.lblDanhMuc);
        this.pnlChonMonTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlChonMonTop.Location = new System.Drawing.Point(8, 26);
        this.pnlChonMonTop.Name = "pnlChonMonTop";
        this.pnlChonMonTop.Size = new System.Drawing.Size(282, 60);
        this.pnlChonMonTop.TabIndex = 0;

        // 
        // lblDanhMuc
        // 
        this.lblDanhMuc.AutoSize = true;
        this.lblDanhMuc.Location = new System.Drawing.Point(3, 8);
        this.lblDanhMuc.Name = "lblDanhMuc";
        this.lblDanhMuc.Size = new System.Drawing.Size(70, 17);
        this.lblDanhMuc.TabIndex = 0;
        this.lblDanhMuc.Text = "Danh mục:";

        // 
        // cboDanhMuc
        // 
        this.cboDanhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboDanhMuc.FormattingEnabled = true;
        this.cboDanhMuc.Location = new System.Drawing.Point(3, 28);
        this.cboDanhMuc.Name = "cboDanhMuc";
        this.cboDanhMuc.Size = new System.Drawing.Size(276, 25);
        this.cboDanhMuc.TabIndex = 1;
        this.cboDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboDanhMuc_SelectedIndexChanged);

        // 
        // lstMonUong
        // 
        this.lstMonUong.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lstMonUong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lstMonUong.FormattingEnabled = true;
        this.lstMonUong.ItemHeight = 17;
        this.lstMonUong.Location = new System.Drawing.Point(8, 86);
        this.lstMonUong.Name = "lstMonUong";
        this.lstMonUong.Size = new System.Drawing.Size(282, 428);
        this.lstMonUong.TabIndex = 1;

        // 
        // pnlChonMonBottom
        // 
        this.pnlChonMonBottom.Controls.Add(this.btnThemVaoDon);
        this.pnlChonMonBottom.Controls.Add(this.numSoLy);
        this.pnlChonMonBottom.Controls.Add(this.lblSoLy);
        this.pnlChonMonBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlChonMonBottom.Location = new System.Drawing.Point(8, 514);
        this.pnlChonMonBottom.Name = "pnlChonMonBottom";
        this.pnlChonMonBottom.Size = new System.Drawing.Size(282, 85);
        this.pnlChonMonBottom.TabIndex = 2;

        // 
        // lblSoLy
        // 
        this.lblSoLy.AutoSize = true;
        this.lblSoLy.Location = new System.Drawing.Point(3, 14);
        this.lblSoLy.Name = "lblSoLy";
        this.lblSoLy.Size = new System.Drawing.Size(40, 17);
        this.lblSoLy.TabIndex = 0;
        this.lblSoLy.Text = "Số ly:";

        // 
        // numSoLy
        // 
        this.numSoLy.Location = new System.Drawing.Point(55, 12);
        this.numSoLy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        this.numSoLy.Name = "numSoLy";
        this.numSoLy.Size = new System.Drawing.Size(75, 25);
        this.numSoLy.TabIndex = 1;
        this.numSoLy.Value = new decimal(new int[] { 1, 0, 0, 0 });

        // 
        // btnThemVaoDon
        // 
        this.btnThemVaoDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.btnThemVaoDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
        this.btnThemVaoDon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnThemVaoDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThemVaoDon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnThemVaoDon.Location = new System.Drawing.Point(3, 47);
        this.btnThemVaoDon.Name = "btnThemVaoDon";
        this.btnThemVaoDon.Size = new System.Drawing.Size(276, 32);
        this.btnThemVaoDon.TabIndex = 2;
        this.btnThemVaoDon.Text = "Thêm vào đơn";
        this.btnThemVaoDon.UseVisualStyleBackColor = false;
        this.btnThemVaoDon.Click += new System.EventHandler(this.btnThemVaoDon_Click);

        // 
        // grpDonHienTai
        // 
        this.grpDonHienTai.Controls.Add(this.dgvGioHang);
        this.grpDonHienTai.Controls.Add(this.pnlDonBottom);
        this.grpDonHienTai.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpDonHienTai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpDonHienTai.Location = new System.Drawing.Point(315, 11);
        this.grpDonHienTai.Name = "grpDonHienTai";
        this.grpDonHienTai.Padding = new System.Windows.Forms.Padding(8);
        this.grpDonHienTai.Size = new System.Drawing.Size(451, 607);
        this.grpDonHienTai.TabIndex = 1;
        this.grpDonHienTai.TabStop = false;
        this.grpDonHienTai.Text = "Đơn hiện tại";

        // 
        // dgvGioHang
        // 
        this.dgvGioHang.AllowUserToAddRows = false;
        this.dgvGioHang.AllowUserToDeleteRows = false;
        this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
        this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvGioHang.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvGioHang.Location = new System.Drawing.Point(8, 26);
        this.dgvGioHang.MultiSelect = false;
        this.dgvGioHang.Name = "dgvGioHang";
        this.dgvGioHang.ReadOnly = true;
        this.dgvGioHang.RowHeadersWidth = 25;
        this.dgvGioHang.RowTemplate.Height = 28;
        this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvGioHang.Size = new System.Drawing.Size(435, 488);
        this.dgvGioHang.TabIndex = 0;

        // 
        // pnlDonBottom
        // 
        this.pnlDonBottom.Controls.Add(this.btnHuyDon);
        this.pnlDonBottom.Controls.Add(this.lblTongTien);
        this.pnlDonBottom.Controls.Add(this.btnXoaDong);
        this.pnlDonBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlDonBottom.Location = new System.Drawing.Point(8, 514);
        this.pnlDonBottom.Name = "pnlDonBottom";
        this.pnlDonBottom.Size = new System.Drawing.Size(435, 85);
        this.pnlDonBottom.TabIndex = 1;

        // 
        // btnXoaDong
        // 
        this.btnXoaDong.Anchor = System.Windows.Forms.AnchorStyles.Top;
        this.btnXoaDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
        this.btnXoaDong.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnXoaDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnXoaDong.Location = new System.Drawing.Point(120, 10);
        this.btnXoaDong.Name = "btnXoaDong";
        this.btnXoaDong.Size = new System.Drawing.Size(100, 30);
        this.btnXoaDong.TabIndex = 0;
        this.btnXoaDong.Text = "Xóa dòng";
        this.btnXoaDong.UseVisualStyleBackColor = false;
        this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);

        // 
        // btnHuyDon
        // 
        this.btnHuyDon.Anchor = System.Windows.Forms.AnchorStyles.Top;
        this.btnHuyDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
        this.btnHuyDon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnHuyDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnHuyDon.Location = new System.Drawing.Point(230, 10);
        this.btnHuyDon.Name = "btnHuyDon";
        this.btnHuyDon.Size = new System.Drawing.Size(100, 30);
        this.btnHuyDon.TabIndex = 1;
        this.btnHuyDon.Text = "Làm mới đơn";
        this.btnHuyDon.UseVisualStyleBackColor = false;
        this.btnHuyDon.Click += new System.EventHandler(this.btnHuyDon_Click);

        // 
        // lblTongTien
        // 
        this.lblTongTien.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
        this.lblTongTien.Location = new System.Drawing.Point(0, 48);
        this.lblTongTien.Name = "lblTongTien";
        this.lblTongTien.Size = new System.Drawing.Size(435, 37);
        this.lblTongTien.TabIndex = 2;
        this.lblTongTien.Text = "Tổng tiền: 0 đ";
        this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        // 
        // grpThanhToan
        // 
        this.grpThanhToan.Controls.Add(this.btnDaNhanTien);
        this.grpThanhToan.Controls.Add(this.pnlQrInfo);
        this.grpThanhToan.Controls.Add(this.picQr);
        this.grpThanhToan.Controls.Add(this.pnlThanhToanButtons);
        this.grpThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpThanhToan.Location = new System.Drawing.Point(772, 11);
        this.grpThanhToan.Name = "grpThanhToan";
        this.grpThanhToan.Padding = new System.Windows.Forms.Padding(8);
        this.grpThanhToan.Size = new System.Drawing.Size(321, 607);
        this.grpThanhToan.TabIndex = 2;
        this.grpThanhToan.TabStop = false;
        this.grpThanhToan.Text = "Thanh toán";

        // 
        // pnlThanhToanButtons
        // 
        this.pnlThanhToanButtons.Controls.Add(this.btnTienMat);
        this.pnlThanhToanButtons.Controls.Add(this.btnThanhToanChuyenKhoan);
        this.pnlThanhToanButtons.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlThanhToanButtons.Location = new System.Drawing.Point(8, 26);
        this.pnlThanhToanButtons.Name = "pnlThanhToanButtons";
        this.pnlThanhToanButtons.Size = new System.Drawing.Size(305, 80);
        this.pnlThanhToanButtons.TabIndex = 0;

        // 
        // btnThanhToanChuyenKhoan
        // 
        this.btnThanhToanChuyenKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.btnThanhToanChuyenKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
        this.btnThanhToanChuyenKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnThanhToanChuyenKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThanhToanChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnThanhToanChuyenKhoan.Location = new System.Drawing.Point(3, 5);
        this.btnThanhToanChuyenKhoan.Name = "btnThanhToanChuyenKhoan";
        this.btnThanhToanChuyenKhoan.Size = new System.Drawing.Size(299, 32);
        this.btnThanhToanChuyenKhoan.TabIndex = 0;
        this.btnThanhToanChuyenKhoan.Text = "Thanh toán chuyển khoản";
        this.btnThanhToanChuyenKhoan.UseVisualStyleBackColor = false;
        this.btnThanhToanChuyenKhoan.Click += new System.EventHandler(this.btnThanhToanChuyenKhoan_Click);

        // 
        // btnTienMat
        // 
        this.btnTienMat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.btnTienMat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
        this.btnTienMat.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnTienMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnTienMat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnTienMat.Location = new System.Drawing.Point(3, 42);
        this.btnTienMat.Name = "btnTienMat";
        this.btnTienMat.Size = new System.Drawing.Size(299, 32);
        this.btnTienMat.TabIndex = 1;
        this.btnTienMat.Text = "Tiền mặt";
        this.btnTienMat.UseVisualStyleBackColor = false;
        this.btnTienMat.Click += new System.EventHandler(this.btnTienMat_Click);

        // 
        // picQr
        // 
        this.picQr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.picQr.BackColor = System.Drawing.Color.White;
        this.picQr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.picQr.Location = new System.Drawing.Point(11, 112);
        this.picQr.Name = "picQr";
        this.picQr.Size = new System.Drawing.Size(299, 350);
        this.picQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.picQr.TabIndex = 1;
        this.picQr.TabStop = false;

        // 
        // pnlQrInfo
        // 
        this.pnlQrInfo.Controls.Add(this.lblThongTinNganHang);
        this.pnlQrInfo.Controls.Add(this.lblNoiDung);
        this.pnlQrInfo.Controls.Add(this.lblSoTien);
        this.pnlQrInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlQrInfo.Location = new System.Drawing.Point(8, 468);
        this.pnlQrInfo.Name = "pnlQrInfo";
        this.pnlQrInfo.Size = new System.Drawing.Size(305, 88);
        this.pnlQrInfo.TabIndex = 2;

        // 
        // lblSoTien
        // 
        this.lblSoTien.AutoSize = true;
        this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblSoTien.Location = new System.Drawing.Point(3, 5);
        this.lblSoTien.Name = "lblSoTien";
        this.lblSoTien.Size = new System.Drawing.Size(52, 17);
        this.lblSoTien.TabIndex = 0;
        this.lblSoTien.Text = "Số tiền: ";

        // 
        // lblNoiDung
        // 
        this.lblNoiDung.AutoSize = true;
        this.lblNoiDung.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblNoiDung.Location = new System.Drawing.Point(3, 28);
        this.lblNoiDung.Name = "lblNoiDung";
        this.lblNoiDung.Size = new System.Drawing.Size(66, 17);
        this.lblNoiDung.TabIndex = 1;
        this.lblNoiDung.Text = "Nội dung: ";

        // 
        // lblThongTinNganHang
        // 
        this.lblThongTinNganHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.lblThongTinNganHang.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
        this.lblThongTinNganHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
        this.lblThongTinNganHang.Location = new System.Drawing.Point(3, 50);
        this.lblThongTinNganHang.Name = "lblThongTinNganHang";
        this.lblThongTinNganHang.Size = new System.Drawing.Size(299, 35);
        this.lblThongTinNganHang.TabIndex = 2;
        this.lblThongTinNganHang.Text = "Ngân hàng: -- | STK: --";

        // 
        // btnDaNhanTien
        // 
        this.btnDaNhanTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
        this.btnDaNhanTien.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnDaNhanTien.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.btnDaNhanTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnDaNhanTien.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnDaNhanTien.ForeColor = System.Drawing.Color.White;
        this.btnDaNhanTien.Location = new System.Drawing.Point(8, 556);
        this.btnDaNhanTien.Name = "btnDaNhanTien";
        this.btnDaNhanTien.Size = new System.Drawing.Size(305, 43);
        this.btnDaNhanTien.TabIndex = 3;
        this.btnDaNhanTien.Text = "Đã nhận tiền";
        this.btnDaNhanTien.UseVisualStyleBackColor = false;
        this.btnDaNhanTien.Click += new System.EventHandler(this.btnDaNhanTien_Click);

        // 
        // statusStrip
        // 
        this.statusStrip.BackColor = System.Drawing.Color.White;
        this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTrangThai,
            this.lblShopName});
        this.statusStrip.Location = new System.Drawing.Point(0, 654);
        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Size = new System.Drawing.Size(1104, 22);
        this.statusStrip.TabIndex = 2;
        this.statusStrip.Text = "statusStrip";

        // 
        // lblTrangThai
        // 
        this.lblTrangThai.Name = "lblTrangThai";
        this.lblTrangThai.Size = new System.Drawing.Size(111, 17);
        this.lblTrangThai.Text = "Sẵn sàng phục vụ";

        // 
        // lblShopName
        // 
        this.lblShopName.Name = "lblShopName";
        this.lblShopName.Size = new System.Drawing.Size(978, 17);
        this.lblShopName.Spring = true;
        this.lblShopName.Text = "Quán trà sữa";
        this.lblShopName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // 
        // FormBanHang
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
        this.ClientSize = new System.Drawing.Size(1104, 676);
        this.Controls.Add(this.pnlMain);
        this.Controls.Add(this.statusStrip);
        this.Controls.Add(this.menuStrip);
        this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.MainMenuStrip = this.menuStrip;
        this.MinimumSize = new System.Drawing.Size(950, 600);
        this.Name = "FormBanHang";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Bán hàng - Quán trà sữa";
        this.Load += new System.EventHandler(this.FormBanHang_Load);
        this.menuStrip.ResumeLayout(false);
        this.menuStrip.PerformLayout();
        this.pnlMain.ResumeLayout(false);
        this.grpChonMon.ResumeLayout(false);
        this.pnlChonMonBottom.ResumeLayout(false);
        this.pnlChonMonBottom.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numSoLy)).EndInit();
        this.pnlChonMonTop.ResumeLayout(false);
        this.pnlChonMonTop.PerformLayout();
        this.grpDonHienTai.ResumeLayout(false);
        this.pnlDonBottom.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
        this.grpThanhToan.ResumeLayout(false);
        this.pnlQrInfo.ResumeLayout(false);
        this.pnlQrInfo.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.picQr)).EndInit();
        this.pnlThanhToanButtons.ResumeLayout(false);
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem menuHeThong;
    private System.Windows.Forms.ToolStripMenuItem menuThoat;
    private System.Windows.Forms.ToolStripMenuItem menuQuanLy;
    private System.Windows.Forms.ToolStripMenuItem menuThucDon;
    private System.Windows.Forms.ToolStripMenuItem menuHoaDon;
    private System.Windows.Forms.ToolStripMenuItem menuTroGiup;
    private System.Windows.Forms.ToolStripMenuItem menuThongTinTK;
    private System.Windows.Forms.TableLayoutPanel pnlMain;
    private System.Windows.Forms.GroupBox grpChonMon;
    private System.Windows.Forms.Panel pnlChonMonTop;
    private System.Windows.Forms.Label lblDanhMuc;
    private System.Windows.Forms.ComboBox cboDanhMuc;
    private System.Windows.Forms.ListBox lstMonUong;
    private System.Windows.Forms.Panel pnlChonMonBottom;
    private System.Windows.Forms.Label lblSoLy;
    private System.Windows.Forms.NumericUpDown numSoLy;
    private System.Windows.Forms.Button btnThemVaoDon;
    private System.Windows.Forms.GroupBox grpDonHienTai;
    private System.Windows.Forms.DataGridView dgvGioHang;
    private System.Windows.Forms.Panel pnlDonBottom;
    private System.Windows.Forms.Button btnXoaDong;
    private System.Windows.Forms.Button btnHuyDon;
    private System.Windows.Forms.Label lblTongTien;
    private System.Windows.Forms.GroupBox grpThanhToan;
    private System.Windows.Forms.Panel pnlThanhToanButtons;
    private System.Windows.Forms.Button btnThanhToanChuyenKhoan;
    private System.Windows.Forms.Button btnTienMat;
    private System.Windows.Forms.PictureBox picQr;
    private System.Windows.Forms.Panel pnlQrInfo;
    private System.Windows.Forms.Label lblSoTien;
    private System.Windows.Forms.Label lblNoiDung;
    private System.Windows.Forms.Label lblThongTinNganHang;
    private System.Windows.Forms.Button btnDaNhanTien;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel lblTrangThai;
    private System.Windows.Forms.ToolStripStatusLabel lblShopName;
}
