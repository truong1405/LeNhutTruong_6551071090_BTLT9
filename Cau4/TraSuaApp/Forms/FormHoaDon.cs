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

public partial class FormHoaDon : Form
{
    private bool _filterByDate = true;

    public FormHoaDon()
    {
        InitializeComponent();
    }

    private void FormHoaDon_Load(object sender, EventArgs e)
    {
        dtpNgay.Value = DateTime.Today;
        LoadDanhSachHoaDon();
    }

    public void LoadDanhSachHoaDon()
    {
        try
        {
            using var context = ConfigurationHelper.CreateDbContext();

            var query = context.HoaDons.AsQueryable();

            if (_filterByDate)
            {
                var selectedDate = dtpNgay.Value.Date;
                var nextDate = selectedDate.AddDays(1);
                query = query.Where(h => h.NgayLap >= selectedDate && h.NgayLap < nextDate);
            }

            var list = query
                .OrderByDescending(h => h.NgayLap)
                .Select(h => new
                {
                    h.MaHd,
                    GioLap = h.NgayLap,
                    HinhThuc = h.HinhThucTt,
                    h.TongTien,
                    TrangThai = h.DaThanhToan ? "Đã thanh toán" : "Chưa thanh toán"
                })
                .ToList();

            dgvHoaDon.DataSource = list;

            // Định dạng cột
            if (dgvHoaDon.Columns["MaHd"] != null)
            {
                dgvHoaDon.Columns["MaHd"].HeaderText = "Mã HD";
                dgvHoaDon.Columns["MaHd"].Width = 70;
            }
            if (dgvHoaDon.Columns["GioLap"] != null)
            {
                dgvHoaDon.Columns["GioLap"].HeaderText = "Giờ lập";
                dgvHoaDon.Columns["GioLap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                dgvHoaDon.Columns["GioLap"].Width = 150;
            }
            if (dgvHoaDon.Columns["HinhThuc"] != null)
            {
                dgvHoaDon.Columns["HinhThuc"].HeaderText = "Hình thức";
                dgvHoaDon.Columns["HinhThuc"].Width = 110;
            }
            if (dgvHoaDon.Columns["TongTien"] != null)
            {
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "#,##0 đ";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHoaDon.Columns["TongTien"].Width = 120;
            }
            if (dgvHoaDon.Columns["TrangThai"] != null)
            {
                dgvHoaDon.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgvHoaDon.Columns["TrangThai"].Width = 110;
            }

            // Tính doanh thu ngày
            var tongDoanhThu = list.Sum(h => h.TongTien);
            if (_filterByDate)
            {
                lblDoanhThuNgay.Text = $"Doanh thu ngày ({dtpNgay.Value:dd/MM/yyyy}): {tongDoanhThu:N0} đ";
            }
            else
            {
                lblDoanhThuNgay.Text = $"Tổng doanh thu toàn bộ: {tongDoanhThu:N0} đ";
            }

            // Tự động load chi tiết của hóa đơn đầu tiên nếu có
            if (list.Count > 0)
            {
                LoadChiTiet(list[0].MaHd);
            }
            else
            {
                dgvChiTiet.DataSource = null;
                lblThongTinChiTiet.Text = "Không có hóa đơn nào phù hợp với bộ lọc.";
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi tải danh sách hóa đơn từ CSDL");
            MessageBox.Show("Có lỗi xảy ra khi tải danh sách hóa đơn. Chi tiết đã được ghi vào file log.", 
                "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadChiTiet(int maHd)
    {
        try
        {
            using var context = ConfigurationHelper.CreateDbContext();

            var chiTiets = context.ChiTietHoaDons
                .Where(ct => ct.MaHd == maHd)
                .Include(ct => ct.MaMonNavigation)
                .Select(ct => new
                {
                    TenMon = ct.MaMonNavigation.TenMon,
                    SL = ct.SoLy,
                    DonGia = ct.DonGia,
                    ThanhTien = ct.SoLy * ct.DonGia
                })
                .ToList();

            dgvChiTiet.DataSource = chiTiets;

            if (dgvChiTiet.Columns["TenMon"] != null)
            {
                dgvChiTiet.Columns["TenMon"].HeaderText = "Tên món";
                dgvChiTiet.Columns["TenMon"].Width = 160;
            }
            if (dgvChiTiet.Columns["SL"] != null)
            {
                dgvChiTiet.Columns["SL"].HeaderText = "SL";
                dgvChiTiet.Columns["SL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvChiTiet.Columns["SL"].Width = 60;
            }
            if (dgvChiTiet.Columns["DonGia"] != null)
            {
                dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "#,##0 đ";
                dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTiet.Columns["DonGia"].Width = 100;
            }
            if (dgvChiTiet.Columns["ThanhTien"] != null)
            {
                dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "#,##0 đ";
                dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTiet.Columns["ThanhTien"].Width = 110;
            }

            var tongTienHd = chiTiets.Sum(c => c.ThanhTien);
            lblThongTinChiTiet.Text = $"Chi tiết hóa đơn HD{maHd} - Tổng tiền: {tongTienHd:N0} đ ({chiTiets.Count} món)";
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi tải chi tiết hóa đơn MaHD={MaHD}", maHd);
        }
    }

    private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
    {
        HienThiChiTietHoaDonDangChon();
    }

    private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        HienThiChiTietHoaDonDangChon();
    }

    private void HienThiChiTietHoaDonDangChon()
    {
        if (dgvHoaDon.CurrentRow != null && dgvHoaDon.CurrentRow.Index >= 0)
        {
            var maHd = Convert.ToInt32(dgvHoaDon.CurrentRow.Cells["MaHd"].Value);
            LoadChiTiet(maHd);
        }
    }

    private void dtpNgay_ValueChanged(object sender, EventArgs e)
    {
        _filterByDate = true;
        LoadDanhSachHoaDon();
    }

    private void btnHomNay_Click(object sender, EventArgs e)
    {
        _filterByDate = true;
        dtpNgay.Value = DateTime.Today;
        LoadDanhSachHoaDon();
    }

    private void btnTatCa_Click(object sender, EventArgs e)
    {
        _filterByDate = false;
        LoadDanhSachHoaDon();
    }
}
