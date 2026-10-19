using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TraSuaApp.Config;
using TraSuaApp.Models;

namespace TraSuaApp.Forms;

public partial class FormThucDon : Form
{
    private int? _selectedMaMon = null;

    public FormThucDon()
    {
        InitializeComponent();
    }

    private void FormThucDon_Load(object sender, EventArgs e)
    {
        LoadDanhMuc();
        LoadDanhSachMon();
    }

    private void LoadDanhMuc()
    {
        try
        {
            using var context = ConfigurationHelper.CreateDbContext();
            var danhMucs = context.DanhMucMons
                .OrderBy(d => d.MaDm)
                .ToList();

            // Nạp vào ComboBox chọn danh mục cho món
            cboDanhMuc.DataSource = new List<DanhMucMon>(danhMucs);
            cboDanhMuc.DisplayMember = "TenDm";
            cboDanhMuc.ValueMember = "MaDm";

            // Nạp vào ComboBox lọc (thêm lựa chọn 'Tất cả')
            var listLoc = new List<DanhMucMon>
            {
                new DanhMucMon { MaDm = 0, TenDm = "-- Tất cả danh mục --" }
            };
            listLoc.AddRange(danhMucs);

            cboLocDanhMuc.DataSource = listLoc;
            cboLocDanhMuc.DisplayMember = "TenDm";
            cboLocDanhMuc.ValueMember = "MaDm";
            cboLocDanhMuc.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi tải danh mục món uống từ CSDL");
            MessageBox.Show("Không thể tải danh sách danh mục. Vui lòng kiểm tra kết nối CSDL!", 
                "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void LoadDanhSachMon()
    {
        try
        {
            using var context = ConfigurationHelper.CreateDbContext();

            // Query join MonUong với DanhMucMon
            var query = context.MonUongs
                .Include(m => m.MaDmNavigation)
                .AsQueryable();

            // Lọc theo tên món nếu có nhập
            var keyword = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(m => m.TenMon.Contains(keyword));
            }

            // Lọc theo danh mục nếu được chọn
            if (cboLocDanhMuc.SelectedValue is int maDm && maDm > 0)
            {
                query = query.Where(m => m.MaDm == maDm);
            }

            var list = query
                .OrderBy(m => m.MaDm)
                .ThenBy(m => m.TenMon)
                .Select(m => new
                {
                    m.MaMon,
                    m.TenMon,
                    DanhMuc = m.MaDmNavigation.TenDm,
                    m.GiaBan,
                    TrangThai = m.DangBan ? "Đang bán" : "Ngừng bán",
                    m.DangBan,
                    m.MaDm
                })
                .ToList();

            dgvMonUong.DataSource = list;

            // Định dạng các cột
            if (dgvMonUong.Columns["MaMon"] != null)
            {
                dgvMonUong.Columns["MaMon"].HeaderText = "Mã món";
                dgvMonUong.Columns["MaMon"].Width = 80;
            }
            if (dgvMonUong.Columns["TenMon"] != null)
            {
                dgvMonUong.Columns["TenMon"].HeaderText = "Tên món";
                dgvMonUong.Columns["TenMon"].Width = 220;
            }
            if (dgvMonUong.Columns["DanhMuc"] != null)
            {
                dgvMonUong.Columns["DanhMuc"].HeaderText = "Danh mục";
                dgvMonUong.Columns["DanhMuc"].Width = 140;
            }
            if (dgvMonUong.Columns["GiaBan"] != null)
            {
                dgvMonUong.Columns["GiaBan"].HeaderText = "Giá bán";
                dgvMonUong.Columns["GiaBan"].DefaultCellStyle.Format = "#,##0 đ";
                dgvMonUong.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMonUong.Columns["GiaBan"].Width = 120;
            }
            if (dgvMonUong.Columns["TrangThai"] != null)
            {
                dgvMonUong.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgvMonUong.Columns["TrangThai"].Width = 110;
            }

            // Ẩn các cột bổ trợ
            if (dgvMonUong.Columns["DangBan"] != null) dgvMonUong.Columns["DangBan"].Visible = false;
            if (dgvMonUong.Columns["MaDm"] != null) dgvMonUong.Columns["MaDm"].Visible = false;

            lblTongSoMon.Text = $"Tổng số món hiển thị: {list.Count}";
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi tải danh sách món uống từ CSDL");
            MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu món uống. Chi tiết đã được ghi vào file log.", 
                "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvMonUong_SelectionChanged(object sender, EventArgs e)
    {
        HienThiDongDangChon();
    }

    private void dgvMonUong_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        HienThiDongDangChon();
    }

    private void HienThiDongDangChon()
    {
        if (dgvMonUong.CurrentRow != null && dgvMonUong.CurrentRow.Index >= 0)
        {
            var row = dgvMonUong.CurrentRow;
            _selectedMaMon = Convert.ToInt32(row.Cells["MaMon"].Value);
            txtTenMon.Text = row.Cells["TenMon"].Value?.ToString() ?? string.Empty;
            numGiaBan.Value = Convert.ToDecimal(row.Cells["GiaBan"].Value);
            chkDangBan.Checked = Convert.ToBoolean(row.Cells["DangBan"].Value);

            var maDm = Convert.ToInt32(row.Cells["MaDm"].Value);
            cboDanhMuc.SelectedValue = maDm;
        }
    }

    private bool KiemTraHopLe()
    {
        if (string.IsNullOrWhiteSpace(txtTenMon.Text))
        {
            MessageBox.Show("Tên món không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenMon.Focus();
            return false;
        }

        if (numGiaBan.Value <= 0)
        {
            MessageBox.Show("Giá bán phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numGiaBan.Focus();
            return false;
        }

        if (cboDanhMuc.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn danh mục cho món!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboDanhMuc.Focus();
            return false;
        }

        return true;
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (!KiemTraHopLe()) return;

        try
        {
            using var context = ConfigurationHelper.CreateDbContext();

            var monMoi = new MonUong
            {
                TenMon = txtTenMon.Text.Trim(),
                GiaBan = numGiaBan.Value,
                DangBan = chkDangBan.Checked,
                MaDm = Convert.ToInt32(cboDanhMuc.SelectedValue)
            };

            context.MonUongs.Add(monMoi);
            context.SaveChanges();

            // Log Information khi thêm (kèm MaMon)
            Log.Information("Thêm món uống thành công: MaMon={MaMon}, TenMon={TenMon}, GiaBan={GiaBan:N0}", 
                monMoi.MaMon, monMoi.TenMon, monMoi.GiaBan);

            MessageBox.Show($"Thêm món '{monMoi.TenMon}' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDanhSachMon();
            LamMoiForm();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi thêm món uống vào CSDL");
            MessageBox.Show("Không thể thêm món uống. Đã có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        if (_selectedMaMon == null)
        {
            MessageBox.Show("Vui lòng chọn món cần sửa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (!KiemTraHopLe()) return;

        try
        {
            using var context = ConfigurationHelper.CreateDbContext();
            var mon = context.MonUongs.Find(_selectedMaMon.Value);
            if (mon == null)
            {
                MessageBox.Show("Không tìm thấy món cần sửa trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mon.TenMon = txtTenMon.Text.Trim();
            mon.GiaBan = numGiaBan.Value;
            mon.DangBan = chkDangBan.Checked;
            mon.MaDm = Convert.ToInt32(cboDanhMuc.SelectedValue);

            context.SaveChanges();

            // Log Information khi sửa (kèm MaMon)
            Log.Information("Cập nhật món uống thành công: MaMon={MaMon}, TenMon={TenMon}, GiaBan={GiaBan:N0}", 
                mon.MaMon, mon.TenMon, mon.GiaBan);

            MessageBox.Show($"Cập nhật món '{mon.TenMon}' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDanhSachMon();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi cập nhật món uống MaMon={MaMon}", _selectedMaMon);
            MessageBox.Show("Không thể cập nhật món uống. Đã có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (_selectedMaMon == null)
        {
            MessageBox.Show("Vui lòng chọn món cần xóa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var dialogResult = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa món '{txtTenMon.Text}' (Mã: {_selectedMaMon}) không?",
            "Xác nhận xóa món",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (dialogResult != DialogResult.Yes) return;

        try
        {
            using var context = ConfigurationHelper.CreateDbContext();
            var mon = context.MonUongs.Find(_selectedMaMon.Value);
            if (mon == null)
            {
                MessageBox.Show("Món không tồn tại hoặc đã bị xóa trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem món đã từng được bán trong hóa đơn nào chưa
            var daCoHoaDon = context.ChiTietHoaDons.Any(ct => ct.MaMon == _selectedMaMon.Value);
            if (daCoHoaDon)
            {
                var chuyenTrangThai = MessageBox.Show(
                    "Món này đã tồn tại trong các hóa đơn đã bán nên không thể xóa khỏi CSDL.\nBạn có muốn chuyển trạng thái món sang 'Ngừng bán' không?",
                    "Món đã có hóa đơn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (chuyenTrangThai == DialogResult.Yes)
                {
                    mon.DangBan = false;
                    context.SaveChanges();
                    Log.Information("Món MaMon={MaMon} đã được chuyển sang ngừng bán vì đã có hóa đơn", mon.MaMon);
                    MessageBox.Show("Đã chuyển món sang trạng thái 'Ngừng bán'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachMon();
                }
                return;
            }

            var maXoa = mon.MaMon;
            var tenXoa = mon.TenMon;
            context.MonUongs.Remove(mon);
            context.SaveChanges();

            // Log Information khi xóa (kèm MaMon)
            Log.Information("Xóa món uống thành công: MaMon={MaMon}, TenMon={TenMon}", maXoa, tenXoa);

            MessageBox.Show($"Đã xóa món '{tenXoa}'!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiForm();
            LoadDanhSachMon();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi xóa món uống MaMon={MaMon}", _selectedMaMon);
            MessageBox.Show("Không thể xóa món uống. Đã có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        LamMoiForm();
    }

    private void LamMoiForm()
    {
        _selectedMaMon = null;
        txtTenMon.Text = string.Empty;
        numGiaBan.Value = 0;
        chkDangBan.Checked = true;
        if (cboDanhMuc.Items.Count > 0)
        {
            cboDanhMuc.SelectedIndex = 0;
        }
        txtTenMon.Focus();
    }

    private void txtTimKiem_TextChanged(object sender, EventArgs e)
    {
        LoadDanhSachMon();
    }

    private void cboLocDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDanhSachMon();
    }

    private void btnBoLoc_Click(object sender, EventArgs e)
    {
        txtTimKiem.Text = string.Empty;
        if (cboLocDanhMuc.Items.Count > 0)
        {
            cboLocDanhMuc.SelectedIndex = 0;
        }
        LoadDanhSachMon();
    }
}
