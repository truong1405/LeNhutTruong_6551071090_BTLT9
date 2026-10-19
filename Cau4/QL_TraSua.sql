IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_TraSua')
BEGIN
    CREATE DATABASE QL_TraSua;
END
GO

USE QL_TraSua;
GO

-- Xoa bang neu da ton tai
IF OBJECT_ID('ChiTietHoaDon', 'U') IS NOT NULL DROP TABLE ChiTietHoaDon;
IF OBJECT_ID('HoaDon', 'U') IS NOT NULL DROP TABLE HoaDon;
IF OBJECT_ID('MonUong', 'U') IS NOT NULL DROP TABLE MonUong;
IF OBJECT_ID('DanhMucMon', 'U') IS NOT NULL DROP TABLE DanhMucMon;
GO

-- 1. Bang DanhMucMon
CREATE TABLE DanhMucMon (
    MaDM INT IDENTITY(1,1) PRIMARY KEY,
    TenDM NVARCHAR(50) NOT NULL
);
GO

-- 2. Bang MonUong
CREATE TABLE MonUong (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    GiaBan DECIMAL(18,0) NOT NULL,
    DangBan BIT NOT NULL DEFAULT 1,
    MaDM INT NOT NULL,
    CONSTRAINT FK_MonUong_DanhMuc FOREIGN KEY (MaDM) REFERENCES DanhMucMon(MaDM) ON DELETE CASCADE
);
GO

-- 3. Bang HoaDon
CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    TongTien DECIMAL(18,0) NOT NULL DEFAULT 0,
    HinhThucTT NVARCHAR(20) NOT NULL, -- N'Tiền mặt' / N'Chuyển khoản'
    DaThanhToan BIT NOT NULL DEFAULT 1
);
GO

-- 4. Bang ChiTietHoaDon (Khoa chinh kep: MaHD + MaMon)
CREATE TABLE ChiTietHoaDon (
    MaHD INT NOT NULL,
    MaMon INT NOT NULL,
    SoLy INT NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL,
    CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaHD, MaMon),
    CONSTRAINT FK_ChiTiet_HoaDon FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    CONSTRAINT FK_ChiTiet_MonUong FOREIGN KEY (MaMon) REFERENCES MonUong(MaMon)
);
GO

-- Nhap 4 danh muc mau
SET IDENTITY_INSERT DanhMucMon ON;
INSERT INTO DanhMucMon (MaDM, TenDM) VALUES
(1, N'Trà sữa'),
(2, N'Trà trái cây'),
(3, N'Topping'),
(4, N'Đồ ăn vặt');
SET IDENTITY_INSERT DanhMucMon OFF;
GO

-- Nhap it nhat 12 mon uong mau
SET IDENTITY_INSERT MonUong ON;
INSERT INTO MonUong (MaMon, TenMon, GiaBan, DangBan, MaDM) VALUES
(1, N'Trà sữa trân châu', 35000, 1, 1),
(2, N'Trà sữa matcha', 40000, 1, 1),
(3, N'Hồng trà sữa', 32000, 1, 1),
(4, N'Trà sữa khoai môn', 38000, 1, 1),
(5, N'Trà đào cam sả', 42000, 1, 2),
(6, N'Trà dâu tằm', 39000, 1, 2),
(7, N'Trà chanh hoa đậu biếc', 35000, 1, 2),
(8, N'Trà vải nhiệt đới', 40000, 1, 2),
(9, N'Trân châu đen', 5000, 1, 3),
(10, N'Trân châu trắng', 5000, 1, 3),
(11, N'Thạch pudding trứng', 8000, 1, 3),
(12, N'Bánh tráng trộn', 25000, 1, 4),
(13, N'Khoai tây chiên', 30000, 1, 4),
(14, N'Khô gà lá chanh', 28000, 1, 4);
SET IDENTITY_INSERT MonUong OFF;
GO
