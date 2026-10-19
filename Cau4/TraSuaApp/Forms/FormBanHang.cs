using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TraSuaApp.Config;
using TraSuaApp.Models;
using TraSuaApp.Services;

namespace TraSuaApp.Forms;

public partial class FormBanHang : Form
{
    // Lớp nội bộ lưu từng món trong giỏ hàng hiện tại
    public class CartItem
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;
    }

    // Danh sách các món trong giỏ hàng
    private readonly BindingList<CartItem> _gioHang = new();
    private string _currentPaymentMethod = "Tiền mặt";
    private int _currentExpectedMaHd = 0;

    public FormBanHang()
    {
        InitializeComponent();
    }

    private void FormBanHang_Load(object sender, EventArgs e)
    {
        CaiDatGiaoDienBanDau();
        LoadDanhMuc();
        CapNhatThongTinNganHang();
    }

    private void CaiDatGiaoDienBanDau()
    {
        // Cấu hình DataGridView giỏ hàng
        dgvGioHang.AutoGenerateColumns = false;
        dgvGioHang.Columns.Clear();

        dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "TenMon",
            HeaderText = "Tên món",
            Width = 170,
            ReadOnly = true
        });

        dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "SoLuong",
            HeaderText = "SL",
            Width = 50,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
            ReadOnly = true
        });

        dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "DonGia",
            HeaderText = "Đơn giá",
            Width = 90,
            DefaultCellStyle = { Format = "#,##0", Alignment = DataGridViewContentAlignment.MiddleRight },
            ReadOnly = true
        });

        dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "ThanhTien",
            HeaderText = "Thành tiền",
            Width = 100,
            DefaultCellStyle = { Format = "#,##0", Alignment = DataGridViewContentAlignment.MiddleRight },
            ReadOnly = true
        });

        dgvGioHang.DataSource = _gioHang;
        _gioHang.ListChanged += (s, ev) => CapNhatTongTien();

        CapNhatTongTien();
        ResetKhungThanhToan();
    }

    private void CapNhatThongTinNganHang()
    {
        var payment = ConfigurationHelper.Payment;
        lblShopName.Text = $"Quán: {payment.ShopName} | Ngân hàng: {payment.BankId} - STK: {payment.AccountNo}";
        lblThongTinNganHang.Text = $"Chủ TK: {payment.AccountName}\nNgân hàng: {payment.BankId} - STK: {payment.AccountNo}";
    }

    private void LoadDanhMuc()
    {
        try
        {
            using var context = ConfigurationHelper.CreateDbContext();
            var danhMucs = context.DanhMucMons
                .OrderBy(d => d.MaDm)
                .ToList();

            cboDanhMuc.DataSource = danhMucs;
            cboDanhMuc.DisplayMember = "TenDm";
            cboDanhMuc.ValueMember = "MaDm";

            if (cboDanhMuc.Items.Count > 0)
            {
                cboDanhMuc.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp danh mục tại FormBanHang");
            MessageBox.Show("Không thể tải danh sách danh mục món uống. Vui lòng kiểm tra CSDL!", 
                "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboDanhMuc.SelectedValue is int maDm)
        {
            LoadMonUongTheoDanhMuc(maDm);
        }
    }

    private void LoadMonUongTheoDanhMuc(int maDm)
    {
        try
        {
            using var context = ConfigurationHelper.CreateDbContext();
            // Chỉ lấy các món đang bán (DangBan == true)
            var monUongs = context.MonUongs
                .Where(m => m.MaDm == maDm && m.DangBan)
                .OrderBy(m => m.TenMon)
                .ToList();

            // Định dạng chuỗi hiển thị ví dụ: "Trà sữa trân châu - 35.000"
            var items = monUongs.Select(m => new
            {
                m.MaMon,
                m.TenMon,
                m.GiaBan,
                DisplayText = $"{m.TenMon} - {m.GiaBan:N0}"
            }).ToList();

            lstMonUong.DataSource = items;
            lstMonUong.DisplayMember = "DisplayText";
            lstMonUong.ValueMember = "MaMon";
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp món uống theo danh mục MaDM={MaDM}", maDm);
        }
    }

    private void btnThemVaoDon_Click(object sender, EventArgs e)
    {
        if (lstMonUong.SelectedItem == null)
        {
            MessageBox.Show("Vui lòng chọn một món trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        dynamic selectedItem = lstMonUong.SelectedItem;
        int maMon = selectedItem.MaMon;
        string tenMon = selectedItem.TenMon;
        decimal giaBan = selectedItem.GiaBan;
        int soLy = (int)numSoLy.Value;

        if (soLy <= 0)
        {
            MessageBox.Show("Số ly phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Kiểm tra xem món đã có trong giỏ hàng chưa -> cộng dồn số lượng
        var existing = _gioHang.FirstOrDefault(i => i.MaMon == maMon);
        if (existing != null)
        {
            existing.SoLuong += soLy;
            dgvGioHang.Refresh();
        }
        else
        {
            _gioHang.Add(new CartItem
            {
                MaMon = maMon,
                TenMon = tenMon,
                SoLuong = soLy,
                DonGia = giaBan
            });
        }

        // Reset số ly về 1
        numSoLy.Value = 1;
        CapNhatTongTien();
        ResetKhungThanhToan();
    }

    private void btnXoaDong_Click(object sender, EventArgs e)
    {
        if (dgvGioHang.CurrentRow != null && dgvGioHang.CurrentRow.Index >= 0)
        {
            var item = dgvGioHang.CurrentRow.DataBoundItem as CartItem;
            if (item != null)
            {
                _gioHang.Remove(item);
                CapNhatTongTien();
                ResetKhungThanhToan();
            }
        }
        else
        {
            MessageBox.Show("Vui lòng chọn dòng cần xóa trong giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnHuyDon_Click(object sender, EventArgs e)
    {
        if (_gioHang.Count > 0)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn làm mới toàn bộ đơn hàng hiện tại?", 
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _gioHang.Clear();
                CapNhatTongTien();
                ResetKhungThanhToan();
            }
        }
    }

    private void CapNhatTongTien()
    {
        var tongTien = _gioHang.Sum(i => i.ThanhTien);
        lblTongTien.Text = $"Tổng tiền: {tongTien:N0} đ";
    }

    private void ResetKhungThanhToan()
    {
        picQr.Image?.Dispose();
        picQr.Image = null;
        lblSoTien.Text = "Số tiền: --";
        lblNoiDung.Text = "Nội dung: --";
        btnDaNhanTien.Enabled = false;
        btnDaNhanTien.BackColor = Color.FromArgb(165, 214, 167); // Xanh nhạt khi chưa kích hoạt
    }

    private int LayMaHdTiepTheo()
    {
        try
        {
            using var context = ConfigurationHelper.CreateDbContext();
            var maxId = context.HoaDons.Max(h => (int?)h.MaHd) ?? 1000;
            return Math.Max(1001, maxId + 1);
        }
        catch
        {
            return 1024; // Giá trị mẫu dự phòng
        }
    }

    private async void btnThanhToanChuyenKhoan_Click(object sender, EventArgs e)
    {
        var tongTien = _gioHang.Sum(i => i.ThanhTien);
        if (tongTien <= 0)
        {
            MessageBox.Show("Đơn hàng đang trống! Vui lòng chọn món trước khi thanh toán.", 
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _currentPaymentMethod = "Chuyển khoản";
        _currentExpectedMaHd = LayMaHdTiepTheo();
        var noiDung = $"TRASUA HD{_currentExpectedMaHd}";

        lblSoTien.Text = $"Số tiền: {tongTien:N0} đ";
        lblNoiDung.Text = $"Nội dung: {noiDung}";

        var payment = ConfigurationHelper.Payment;
        lblThongTinNganHang.Text = $"Chủ TK: {payment.AccountName}\nNgân hàng: {payment.BankId} - STK: {payment.AccountNo}";

        lblTrangThai.Text = "Đang tải mã VietQR...";
        picQr.Image?.Dispose();
        picQr.Image = null;

        var qrUrl = VietQrService.BuildQrUrl(payment, tongTien, noiDung);

        try
        {
            btnThanhToanChuyenKhoan.Enabled = false;
            var qrImage = await VietQrService.FetchQrImageAsync(qrUrl, _currentExpectedMaHd.ToString(), tongTien);

            if (qrImage != null)
            {
                picQr.Image = qrImage;
                lblTrangThai.Text = "Đã tạo mã VietQR thành công.";
            }
            else
            {
                // Mất mạng hoặc không tải được ảnh -> Chịu lỗi: vẫn hiện số tài khoản và nội dung chuyển khoản dạng chữ
                lblTrangThai.Text = "Không thể tải ảnh QR từ máy chủ VietQR (Lỗi mạng).";
                TaoAnhThongBaoLoiMang();
                MessageBox.Show(
                    "Không tải được ảnh mã QR do sự cố mạng.\n" +
                    $"Quý khách vui lòng chuyển khoản theo số tài khoản: {payment.AccountNo} ({payment.BankId})\n" +
                    $"Chủ TK: {payment.AccountName}\n" +
                    $"Nội dung: {noiDung}\n" +
                    "Hoặc chuyển sang hình thức thanh toán Tiền mặt!",
                    "Thông báo mạng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // Kích hoạt nút 'Đã nhận tiền'
            btnDaNhanTien.Enabled = true;
            btnDaNhanTien.BackColor = Color.FromArgb(46, 125, 50); // Xanh lá đậm nổi bật
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi không xác định khi xử lý thanh toán chuyển khoản");
            MessageBox.Show("Có lỗi xảy ra khi tạo thanh toán chuyển khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnThanhToanChuyenKhoan.Enabled = true;
        }
    }

    private void TaoAnhThongBaoLoiMang()
    {
        try
        {
            var bmp = new Bitmap(280, 280);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(250, 250, 250));
                using var borderPen = new Pen(Color.FromArgb(220, 220, 220), 2);
                g.DrawRectangle(borderPen, 5, 5, 270, 270);

                using var fontBold = new Font("Segoe UI", 10, FontStyle.Bold);
                using var fontRegular = new Font("Segoe UI", 9, FontStyle.Regular);
                using var brushText = new SolidBrush(Color.FromArgb(198, 40, 40));
                using var brushDark = new SolidBrush(Color.FromArgb(50, 50, 50));

                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString("MẤT KẾT NỐI MẠNG", fontBold, brushText, new RectangleF(10, 40, 260, 30), sf);
                g.DrawString("Không thể tải ảnh VietQR.\nQuý khách vui lòng chuyển khoản\ntheo thông tin văn bản bên dưới\nhoặc thanh toán TIỀN MẶT.", 
                    fontRegular, brushDark, new RectangleF(10, 80, 260, 100), sf);
            }
            picQr.Image?.Dispose();
            picQr.Image = bmp;
        }
        catch
        {
            // Bỏ qua lỗi vẽ ảnh dự phòng
        }
    }

    private void btnTienMat_Click(object sender, EventArgs e)
    {
        var tongTien = _gioHang.Sum(i => i.ThanhTien);
        if (tongTien <= 0)
        {
            MessageBox.Show("Đơn hàng đang trống! Vui lòng chọn món trước khi thanh toán.", 
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Xác nhận thanh toán TIỀN MẶT cho đơn hàng này?\nTổng tiền: {tongTien:N0} đ",
            "Xác nhận thanh toán tiền mặt",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm == DialogResult.Yes)
        {
            _currentPaymentMethod = "Tiền mặt";
            LuuHoaDonVaoCsdl(false);
        }
    }

    private void btnDaNhanTien_Click(object sender, EventArgs e)
    {
        var tongTien = _gioHang.Sum(i => i.ThanhTien);
        if (tongTien <= 0) return;

        var confirm = MessageBox.Show(
            $"Bạn đã kiểm tra thông báo ngân hàng và xác nhận đã nhận đủ {tongTien:N0} đ chuyển khoản?",
            "Xác nhận nhận tiền chuyển khoản",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm == DialogResult.Yes)
        {
            _currentPaymentMethod = "Chuyển khoản";
            LuuHoaDonVaoCsdl(true);
        }
    }

    /// <summary>
    /// Lưu HoaDon + ChiTietHoaDon trong cùng MỘT lần SaveChanges (theo đúng yêu cầu Task 5)
    /// </summary>
    private void LuuHoaDonVaoCsdl(bool isChuyenKhoan)
    {
        var tongTien = _gioHang.Sum(i => i.ThanhTien);
        if (tongTien <= 0 || _gioHang.Count == 0) return;

        try
        {
            using var context = ConfigurationHelper.CreateDbContext();

            // Tạo đối tượng HoaDon
            var hoaDon = new HoaDon
            {
                NgayLap = DateTime.Now,
                TongTien = tongTien,
                HinhThucTt = _currentPaymentMethod,
                DaThanhToan = true
            };

            // Thêm các ChiTietHoaDon vào Navigation Property của HoaDon
            foreach (var item in _gioHang)
            {
                hoaDon.ChiTietHoaDons.Add(new ChiTietHoaDon
                {
                    MaMon = item.MaMon,
                    SoLy = item.SoLuong,
                    DonGia = item.DonGia
                });
            }

            // Lưu cả HoaDon và ChiTietHoaDon trong cùng một lần SaveChanges()
            context.HoaDons.Add(hoaDon);
            context.SaveChanges();

            // Log Information khi lưu đơn hàng thành công
            Log.Information("Thanh toán thành công: MaHD={MaHD}, TongTien={TongTien:N0} đ, HinhThuc={HinhThuc}, SoMon={SoMon}", 
                hoaDon.MaHd, hoaDon.TongTien, hoaDon.HinhThucTt, hoaDon.ChiTietHoaDons.Count);

            MessageBox.Show(
                $"Thanh toán thành công hóa đơn HD{hoaDon.MaHd}!\n" +
                $"Hình thức: {hoaDon.HinhThucTt}\n" +
                $"Tổng tiền: {hoaDon.TongTien:N0} đ\n" +
                $"Thời gian: {hoaDon.NgayLap:dd/MM/yyyy HH:mm:ss}",
                "Thanh toán thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Làm mới giỏ hàng và khung thanh toán
            _gioHang.Clear();
            CapNhatTongTien();
            ResetKhungThanhToan();
            lblTrangThai.Text = $"Đã lập thành công hóa đơn HD{hoaDon.MaHd}";
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi lưu hóa đơn vào CSDL");
            MessageBox.Show("Có lỗi xảy ra khi lưu hóa đơn vào CSDL: " + ex.Message, 
                "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void menuThucDon_Click(object sender, EventArgs e)
    {
        using var form = new FormThucDon();
        form.ShowDialog(this);
        // Sau khi đóng form thực đơn, nạp lại danh sách món uống
        if (cboDanhMuc.SelectedValue is int maDm)
        {
            LoadMonUongTheoDanhMuc(maDm);
        }
    }

    private void menuHoaDon_Click(object sender, EventArgs e)
    {
        using var form = new FormHoaDon();
        form.ShowDialog(this);
    }

    private void menuThongTinTK_Click(object sender, EventArgs e)
    {
        var p = ConfigurationHelper.Payment;
        MessageBox.Show(
            $"THÔNG TIN THANH TOÁN VIETQR (Đọc từ appsettings.json):\n\n" +
            $"- Tên quán: {p.ShopName}\n" +
            $"- Mã ngân hàng (BankId): {p.BankId}\n" +
            $"- Số tài khoản: {p.AccountNo}\n" +
            $"- Chủ tài khoản: {p.AccountName}\n" +
            $"- Mẫu VietQR: {p.Template}\n\n" +
            $"Để thay đổi thông tin này, bạn chỉ cần sửa file appsettings.json cạnh file .exe mà không cần build lại ứng dụng!",
            "Cấu hình thanh toán VietQR",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void menuThoat_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
