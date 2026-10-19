namespace TraSuaApp.Forms;

partial class FormHoaDon
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
        this.pnlTop = new System.Windows.Forms.Panel();
        this.lblDoanhThuNgay = new System.Windows.Forms.Label();
        this.btnTatCa = new System.Windows.Forms.Button();
        this.btnLoc = new System.Windows.Forms.Button();
        this.dtpNgay = new System.Windows.Forms.DateTimePicker();
        this.lblNgay = new System.Windows.Forms.Label();
        this.splitContainer = new System.Windows.Forms.SplitContainer();
        this.grpHoaDon = new System.Windows.Forms.GroupBox();
        this.dgvHoaDon = new System.Windows.Forms.DataGridView();
        this.grpChiTiet = new System.Windows.Forms.GroupBox();
        this.dgvChiTiet = new System.Windows.Forms.DataGridView();
        this.lblThongTinChiTiet = new System.Windows.Forms.Label();
        this.pnlTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        this.grpHoaDon.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
        this.grpChiTiet.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
        this.SuspendLayout();

        // 
        // pnlTop
        // 
        this.pnlTop.BackColor = System.Drawing.Color.White;
        this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlTop.Controls.Add(this.lblDoanhThuNgay);
        this.pnlTop.Controls.Add(this.btnTatCa);
        this.pnlTop.Controls.Add(this.btnLoc);
        this.pnlTop.Controls.Add(this.dtpNgay);
        this.pnlTop.Controls.Add(this.lblNgay);
        this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlTop.Location = new System.Drawing.Point(0, 0);
        this.pnlTop.Name = "pnlTop";
        this.pnlTop.Size = new System.Drawing.Size(984, 65);
        this.pnlTop.TabIndex = 0;

        // 
        // lblNgay
        // 
        this.lblNgay.AutoSize = true;
        this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblNgay.Location = new System.Drawing.Point(15, 23);
        this.lblNgay.Name = "lblNgay";
        this.lblNgay.Size = new System.Drawing.Size(95, 17);
        this.lblNgay.TabIndex = 0;
        this.lblNgay.Text = "Lọc theo ngày:";

        // 
        // dtpNgay
        // 
        this.dtpNgay.CustomFormat = "dd/MM/yyyy";
        this.dtpNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        this.dtpNgay.Location = new System.Drawing.Point(115, 19);
        this.dtpNgay.Name = "dtpNgay";
        this.dtpNgay.Size = new System.Drawing.Size(130, 25);
        this.dtpNgay.TabIndex = 1;
        this.dtpNgay.ValueChanged += new System.EventHandler(this.dtpNgay_ValueChanged);

        // 
        // btnLoc
        // 
        this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
        this.btnLoc.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnLoc.ForeColor = System.Drawing.Color.White;
        this.btnLoc.Location = new System.Drawing.Point(255, 17);
        this.btnLoc.Name = "btnLoc";
        this.btnLoc.Size = new System.Drawing.Size(90, 30);
        this.btnLoc.TabIndex = 2;
        this.btnLoc.Text = "Hôm nay";
        this.btnLoc.UseVisualStyleBackColor = false;
        this.btnLoc.Click += new System.EventHandler(this.btnHomNay_Click);

        // 
        // btnTatCa
        // 
        this.btnTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
        this.btnTatCa.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnTatCa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnTatCa.ForeColor = System.Drawing.Color.White;
        this.btnTatCa.Location = new System.Drawing.Point(355, 17);
        this.btnTatCa.Name = "btnTatCa";
        this.btnTatCa.Size = new System.Drawing.Size(90, 30);
        this.btnTatCa.TabIndex = 3;
        this.btnTatCa.Text = "Tất cả";
        this.btnTatCa.UseVisualStyleBackColor = false;
        this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);

        // 
        // lblDoanhThuNgay
        // 
        this.lblDoanhThuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblDoanhThuNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblDoanhThuNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        this.lblDoanhThuNgay.Location = new System.Drawing.Point(550, 15);
        this.lblDoanhThuNgay.Name = "lblDoanhThuNgay";
        this.lblDoanhThuNgay.Size = new System.Drawing.Size(420, 32);
        this.lblDoanhThuNgay.TabIndex = 4;
        this.lblDoanhThuNgay.Text = "Doanh thu ngày: 0 đ";
        this.lblDoanhThuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // 
        // splitContainer
        // 
        this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitContainer.Location = new System.Drawing.Point(0, 65);
        this.splitContainer.Name = "splitContainer";
        // 
        // splitContainer.Panel1
        // 
        this.splitContainer.Panel1.Controls.Add(this.grpHoaDon);
        this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(10);
        // 
        // splitContainer.Panel2
        // 
        this.splitContainer.Panel2.Controls.Add(this.grpChiTiet);
        this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(10);
        this.splitContainer.Size = new System.Drawing.Size(984, 526);
        this.splitContainer.SplitterDistance = 540;
        this.splitContainer.TabIndex = 1;

        // 
        // grpHoaDon
        // 
        this.grpHoaDon.Controls.Add(this.dgvHoaDon);
        this.grpHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpHoaDon.Location = new System.Drawing.Point(10, 10);
        this.grpHoaDon.Name = "grpHoaDon";
        this.grpHoaDon.Size = new System.Drawing.Size(520, 506);
        this.grpHoaDon.TabIndex = 0;
        this.grpHoaDon.TabStop = false;
        this.grpHoaDon.Text = "Danh sách hóa đơn (Mã HD, giờ lập, hình thức, tổng tiền)";

        // 
        // dgvHoaDon
        // 
        this.dgvHoaDon.AllowUserToAddRows = false;
        this.dgvHoaDon.AllowUserToDeleteRows = false;
        this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
        this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvHoaDon.Location = new System.Drawing.Point(3, 21);
        this.dgvHoaDon.MultiSelect = false;
        this.dgvHoaDon.Name = "dgvHoaDon";
        this.dgvHoaDon.ReadOnly = true;
        this.dgvHoaDon.RowHeadersWidth = 30;
        this.dgvHoaDon.RowTemplate.Height = 28;
        this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvHoaDon.Size = new System.Drawing.Size(514, 482);
        this.dgvHoaDon.TabIndex = 0;
        this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellClick);
        this.dgvHoaDon.SelectionChanged += new System.EventHandler(this.dgvHoaDon_SelectionChanged);

        // 
        // grpChiTiet
        // 
        this.grpChiTiet.Controls.Add(this.dgvChiTiet);
        this.grpChiTiet.Controls.Add(this.lblThongTinChiTiet);
        this.grpChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpChiTiet.Location = new System.Drawing.Point(10, 10);
        this.grpChiTiet.Name = "grpChiTiet";
        this.grpChiTiet.Size = new System.Drawing.Size(420, 506);
        this.grpChiTiet.TabIndex = 0;
        this.grpChiTiet.TabStop = false;
        this.grpChiTiet.Text = "Chi tiết các món trong hóa đơn";

        // 
        // lblThongTinChiTiet
        // 
        this.lblThongTinChiTiet.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblThongTinChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
        this.lblThongTinChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
        this.lblThongTinChiTiet.Location = new System.Drawing.Point(3, 21);
        this.lblThongTinChiTiet.Name = "lblThongTinChiTiet";
        this.lblThongTinChiTiet.Size = new System.Drawing.Size(414, 25);
        this.lblThongTinChiTiet.TabIndex = 0;
        this.lblThongTinChiTiet.Text = "Chọn một hóa đơn ở danh sách bên trái để xem chi tiết";

        // 
        // dgvChiTiet
        // 
        this.dgvChiTiet.AllowUserToAddRows = false;
        this.dgvChiTiet.AllowUserToDeleteRows = false;
        this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
        this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvChiTiet.Location = new System.Drawing.Point(3, 46);
        this.dgvChiTiet.MultiSelect = false;
        this.dgvChiTiet.Name = "dgvChiTiet";
        this.dgvChiTiet.ReadOnly = true;
        this.dgvChiTiet.RowHeadersWidth = 30;
        this.dgvChiTiet.RowTemplate.Height = 28;
        this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvChiTiet.Size = new System.Drawing.Size(414, 457);
        this.dgvChiTiet.TabIndex = 1;

        // 
        // FormHoaDon
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
        this.ClientSize = new System.Drawing.Size(984, 591);
        this.Controls.Add(this.splitContainer);
        this.Controls.Add(this.pnlTop);
        this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.MinimumSize = new System.Drawing.Size(850, 500);
        this.Name = "FormHoaDon";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Danh sách hóa đơn & Doanh thu";
        this.Load += new System.EventHandler(this.FormHoaDon_Load);
        this.pnlTop.ResumeLayout(false);
        this.pnlTop.PerformLayout();
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
        this.splitContainer.ResumeLayout(false);
        this.grpHoaDon.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
        this.grpChiTiet.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlTop;
    private System.Windows.Forms.Label lblNgay;
    private System.Windows.Forms.DateTimePicker dtpNgay;
    private System.Windows.Forms.Button btnLoc;
    private System.Windows.Forms.Button btnTatCa;
    private System.Windows.Forms.Label lblDoanhThuNgay;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.GroupBox grpHoaDon;
    private System.Windows.Forms.DataGridView dgvHoaDon;
    private System.Windows.Forms.GroupBox grpChiTiet;
    private System.Windows.Forms.Label lblThongTinChiTiet;
    private System.Windows.Forms.DataGridView dgvChiTiet;
}
