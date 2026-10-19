# BÀI TẬP CHƯƠNG 11 - CÂU 4: BÁN HÀNG QUÁN TRÀ SỮA (WINFORMS EF CORE)

Ứng dụng **"Bán hàng quán trà sữa"** được xây dựng bằng **C# Windows Forms** (.NET 8 LTS), sử dụng **Entity Framework Core Database First (SQL Server)**, tích hợp tạo mã **VietQR** động tự động theo số tiền và nội dung đơn hàng, cấu hình strongly-typed qua `appsettings.json`, ghi nhật ký thao tác bằng **Serilog**, và hỗ trợ đóng gói publish **Framework-Dependent win-x64**.

---

## 1. Cấu trúc thư mục dự án

```
Cau4/
├── QL_TraSua.sql                   <- Script tạo CSDL QL_TraSua và 14 món mẫu
├── .gitignore                      <- Bỏ qua file cấu hình nhạy cảm và thư mục build
├── README.md                       <- Tài liệu hướng dẫn chi tiết
└── TraSuaApp/
    ├── appsettings.json            <- Cấu hình chính (Connection string, Payment)
    ├── appsettings.Development.json<- Cấu hình ghi đè khi phát triển
    ├── appsettings.example.json    <- File cấu hình mẫu không chứa thông tin nhạy cảm
    ├── Program.cs                  <- Điểm khởi chạy, cấu hình Serilog & lỗi toàn cục
    ├── Config/
    │   ├── AppConfig.cs            <- Lớp cấu hình có kiểu (strongly-typed)
    │   ├── PaymentSettings.cs      <- Lớp cấu hình tài khoản VietQR
    │   └── ConfigurationHelper.cs  <- Helper đọc config, cấu hình Serilog, khởi tạo DbContext
    ├── Models/
    │   ├── DanhMucMon.cs           <- Entity DanhMucMon
    │   ├── MonUong.cs              <- Entity MonUong
    │   ├── HoaDon.cs               <- Entity HoaDon
    │   ├── ChiTietHoaDon.cs        <- Entity ChiTietHoaDon (khóa chính kép)
    │   └── QlTraSuaContext.cs      <- DbContext EF Core Database First
    ├── Services/
    │   └── VietQrService.cs        <- Service tạo URL & tải ảnh VietQR bất đồng bộ (async/await)
    ├── Forms/
    │   ├── FormBanHang.cs          <- Form chính: Bán hàng, chọn món, giỏ hàng, quét mã QR VietQR
    │   ├── FormThucDon.cs          <- Form quản lý thực đơn (CRUD món, tìm kiếm, lọc danh mục)
    │   └── FormHoaDon.cs           <- Form danh sách hóa đơn, chi tiết món và doanh thu theo ngày
    └── publish/                    <- Bản đóng gói Framework-Dependent (win-x64)
        ├── TraSuaApp.exe           <- File thực thi
        ├── appsettings.json        <- File cấu hình chỉnh sửa trực tiếp khi sang máy khác
        └── Logs/                   <- Thư mục chứa file log-yyyyMMdd.txt
```

---

## 2. Hướng dẫn cài đặt CSDL

1. Mở file [QL_TraSua.sql](file:///c:/Users/Truong/Downloads/Cau4/QL_TraSua.sql) trong **SQL Server Management Studio (SSMS)** hoặc chạy lệnh qua command line:
   ```cmd
   sqlcmd -S "(localdb)\MSSQLLocalDB" -i "QL_TraSua.sql"
   ```
2. CSDL `QL_TraSua` sẽ được tạo gồm 4 bảng:
   - `DanhMucMon` (MaDM, TenDM)
   - `MonUong` (MaMon, TenMon, GiaBan, DangBan, MaDM)
   - `HoaDon` (MaHD, NgayLap, TongTien, HinhThucTT, DaThanhToan)
   - `ChiTietHoaDon` (MaHD, MaMon, SoLy, DonGia - Khóa chính kép)
   - Đã nạp sẵn 4 danh mục và 14 món uống đa dạng.

---

## 3. Cách chạy ứng dụng

### Chạy trực tiếp từ mã nguồn:
```cmd
cd TraSuaApp
dotnet run
```

### Chạy bản đã đóng gói (Publish):
Vào thư mục `TraSuaApp/publish/` và nhấp đúp vào `TraSuaApp.exe`.

---

## 4. Các tính năng đáp ứng đầy đủ yêu cầu đề bài

1. **Scaffold EF Core Database First (Task 1)**:
   - Sinh DbContext `QlTraSuaContext` và các Models với đầy đủ quan hệ Navigation properties và composite PK.

2. **Quản lý thực đơn món uống (FormThucDon - Task 2)**:
   - Đầy đủ các control: Tên món, ComboBox danh mục, NumericUpDown giá bán (bước nhảy 1.000), CheckBox Đang bán, DataGridView hiển thị món kèm tên danh mục (JOIN).
   - CRUD hoàn chỉnh: Thêm / Sửa / Xóa (có hỏi xác nhận) / Làm mới.
   - Tìm kiếm thời gian thực theo tên món và lọc theo danh mục.
   - Kiểm tra hợp lệ: Tên món không rỗng, giá bán > 0.
   - Ghi log Serilog Information khi thêm/sửa/xóa kèm `MaMon`.

3. **Lập đơn bán hàng (FormBanHang - Task 3)**:
   - ComboBox chọn danh mục -> ListBox hiển thị các món đang bán của danh mục kèm giá tiền.
   - NumericUpDown chọn số ly.
   - Nút **"Thêm vào đơn"**: Tự động cộng dồn số lượng nếu món đã tồn tại trong giỏ hàng.
   - DataGridView giỏ hàng: Tên món, SL, Đơn giá, Thành tiền.
   - Nút **"Xóa dòng"**, nút **"Làm mới đơn"**, Label tổng tiền cập nhật tức thì.

4. **Cấu hình thanh toán & Strongly-typed (Task 4 & Mục 9.2)**:
   - Cấu hình trong `appsettings.json` với mục `"Payment"` (BankId, AccountNo, AccountName, Template, ShopName).
   - Đọc qua `ConfigurationBuilder` và ánh xạ vào lớp `PaymentSettings` strongly-typed.
   - Đặt `Copy to Output Directory = Copy if newer`.
   - Có kèm `appsettings.example.json` và `.gitignore`.

5. **Thanh toán mã QR VietQR (Task 5 & Mục 9.4)**:
   - Ghép URL VietQR chuẩn với các tham số được mã hóa `Uri.EscapeDataString`.
   - Tải ảnh bằng `HttpClient.GetByteArrayAsync` qua `async/await`, dựng `MemoryStream` gán vào `PictureBox.Image`.
   - Hiển thị kèm số tiền và nội dung chuyển khoản dạng chữ: `TRASUA HD{MaHD}`.
   - Nút **"Đã nhận tiền"**: Lưu cả `HoaDon` và toàn bộ `ChiTietHoaDon` trong cùng **1 lần SaveChanges()** duy nhất.
   - Nút **"Tiền mặt"**: Lưu hóa đơn trực tiếp mà không cần QR.

6. **Danh sách hóa đơn & Doanh thu (FormHoaDon - Task 6)**:
   - DataGridView hóa đơn (Mã HD, giờ lập, hình thức, tổng tiền, trạng thái).
   - Khi chọn một dòng hóa đơn, DataGridView thứ hai tự động hiển thị chi tiết các món trong hóa đơn đó.
   - DateTimePicker lọc theo ngày, nút "Hôm nay", nút "Tất cả".
   - Label **"Doanh thu ngày: ... đ"** tự động cập nhật tổng tiền các hóa đơn trong ngày.

7. **Ghi log Serilog & Chịu lỗi mạng (Task 7 & Mục 9.3)**:
   - Ghi file theo ngày vào thư mục `Logs/log-yyyyMMdd.txt` cạnh file `.exe`.
   - Ghi Information khi tạo QR (mã HD, số tiền - không ghi số tài khoản đầy đủ để bảo mật).
   - Ghi Error khi lỗi mạng tải ảnh QR thất bại; khi mất mạng vẫn hiển thị số tài khoản và nội dung chuyển khoản dạng chữ để khách chuyển tay, cho phép tiếp tục nhận tiền hoặc chuyển sang tiền mặt.
   - Bắt lỗi toàn cục với `Application.ThreadException` và `AppDomain.UnhandledException`.
