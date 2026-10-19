using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Serilog;
using TraSuaApp.Config;

namespace TraSuaApp.Services;

public class VietQrService
{
    private static readonly HttpClient _httpClient = new()
    {
        Timeout = TimeSpan.FromSeconds(10)
    };

    /// <summary>
    /// Tạo đường dẫn URL mã QR thanh toán VietQR chuẩn
    /// </summary>
    public static string BuildQrUrl(PaymentSettings payment, decimal amount, string noiDung)
    {
        var bankId = Uri.EscapeDataString(payment.BankId.Trim());
        var accountNo = Uri.EscapeDataString(payment.AccountNo.Trim());
        var template = Uri.EscapeDataString(string.IsNullOrWhiteSpace(payment.Template) ? "compact2" : payment.Template.Trim());
        var amountStr = Convert.ToInt64(amount).ToString();
        var addInfo = Uri.EscapeDataString(noiDung.Trim());
        var accountName = Uri.EscapeDataString(payment.AccountName.Trim());

        return $"https://img.vietqr.io/image/{bankId}-{accountNo}-{template}.png?amount={amountStr}&addInfo={addInfo}&accountName={accountName}";
    }

    /// <summary>
    /// Tải ảnh mã QR VietQR từ web bất đồng bộ (async/await)
    /// </summary>
    public static async Task<Image?> FetchQrImageAsync(string qrUrl, string maHdStr, decimal amount)
    {
        try
        {
            // Log Information khi tạo QR (mã HD, số tiền - không ghi số tài khoản đầy đủ)
            Log.Information("Yêu cầu tạo VietQR cho hóa đơn: {MaHD}, Số tiền: {Amount:N0} đ", maHdStr, amount);

            var imageBytes = await _httpClient.GetByteArrayAsync(qrUrl);
            using var ms = new MemoryStream(imageBytes);
            // Nhân bản ảnh để không bị lỗi GDI+ khi stream đóng
            var image = Image.FromStream(ms);
            return new Bitmap(image);
        }
        catch (Exception ex)
        {
            // Log Error khi tải ảnh thất bại
            Log.Error(ex, "Lỗi khi tải ảnh VietQR từ đường dẫn {QrUrl} cho hóa đơn {MaHD}", qrUrl, maHdStr);
            return null;
        }
    }

    /// <summary>
    /// Rút gọn số tài khoản để hiển thị hoặc log an toàn
    /// </summary>
    public static string MaskAccountNumber(string accountNo)
    {
        if (string.IsNullOrEmpty(accountNo) || accountNo.Length <= 4)
            return "****";
        return new string('*', accountNo.Length - 4) + accountNo[^4..];
    }
}
