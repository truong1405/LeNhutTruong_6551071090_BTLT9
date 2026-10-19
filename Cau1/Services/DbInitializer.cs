using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Bai_01.Configurations;
using Bai_01.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Bai_01.Services;

public static class DbInitializer
{
    private static readonly string[] CandidateServers = new[]
    {
        @"(localdb)\MSSQLLocalDB",
        @".\SQLEXPRESS",
        @"localhost\SQLEXPRESS",
        @".",
        @"localhost",
        @"(local)",
        @"127.0.0.1",
        @".\SQL2025",
        @".\SQL2022",
        @".\SQL2019"
    };

    /// <summary>
    /// Tự động khởi động LocalDB, dò tìm SQL Server đang chạy, tạo CSDL QL_ChiTieu và nạp 12 dòng dữ liệu mẫu nếu CSDL rỗng.
    /// </summary>
    public static async Task<bool> InitializeAsync()
    {
        try
        {
            // 1. Tự động kiểm tra và khởi động LocalDB nếu máy có cài đặt
            TryStartLocalDb();

            // 2. Dò tìm máy chủ SQL Server đang hoạt động
            string? workingServer = await FindWorkingServerAsync();
            if (!string.IsNullOrEmpty(workingServer))
            {
                string connStr = $"Server={workingServer};Database=QL_ChiTieu;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
                AppConfigManager.ConnectionString = connStr;
                SaveConnectionStringToConfig(connStr);
                Log.Information("Đã kết nối thành công tới máy chủ SQL Server: {Server}", workingServer);
            }
            else
            {
                Log.Warning("Không tìm thấy máy chủ SQL Server nào hoạt động trên máy.");
                return false;
            }

            // 3. Khởi tạo Database và Bảng ChiTieu nếu chưa tồn tại
            using var context = new QL_ChiTieuContext();
            await context.Database.EnsureCreatedAsync();

            // 4. Nếu bảng chưa có dữ liệu, nạp dữ liệu mẫu theo đúng kịch bản đề bài
            if (!await context.ChiTieus.AnyAsync())
            {
                var sampleList = new List<ChiTieu>
                {
                    new() { NgayChi = new DateOnly(2026, 10, 1), NoiDung = "Cơm trưa", LoaiChi = "Ăn uống", SoTien = 35000, GhiChu = "Cơm văn phòng" },
                    new() { NgayChi = new DateOnly(2026, 10, 2), NoiDung = "Xăng xe", LoaiChi = "Đi lại", SoTien = 60000, GhiChu = "Đổ xăng xe máy" },
                    new() { NgayChi = new DateOnly(2026, 10, 3), NoiDung = "Photo giáo trình", LoaiChi = "Học tập", SoTien = 25000, GhiChu = "Tài liệu C# WinForms" },
                    new() { NgayChi = new DateOnly(2026, 10, 4), NoiDung = "Xem phim", LoaiChi = "Giải trí", SoTien = 90000, GhiChu = "Vé xem phim rạp cuối tuần" },
                    new() { NgayChi = new DateOnly(2026, 10, 5), NoiDung = "Trà sữa", LoaiChi = "Ăn uống", SoTien = 40000, GhiChu = "Uống cùng đồng nghiệp" },
                    new() { NgayChi = new DateOnly(2026, 10, 6), NoiDung = "Mua đồ dùng cá nhân", LoaiChi = "Khác", SoTien = 150000, GhiChu = "Sữa tắm, kem đánh răng" },
                    new() { NgayChi = new DateOnly(2026, 10, 7), NoiDung = "Tiền điện thoại", LoaiChi = "Khác", SoTien = 100000, GhiChu = "Nạp thẻ cào Viettel" },
                    new() { NgayChi = new DateOnly(2026, 10, 8), NoiDung = "Ăn sáng", LoaiChi = "Ăn uống", SoTien = 25000, GhiChu = "Phở bò" },
                    new() { NgayChi = new DateOnly(2026, 10, 9), NoiDung = "Mua sách tham khảo", LoaiChi = "Học tập", SoTien = 120000, GhiChu = "Giáo trình Lập trình .NET" },
                    new() { NgayChi = new DateOnly(2026, 10, 10), NoiDung = "Thay nhớt xe máy", LoaiChi = "Đi lại", SoTien = 150000, GhiChu = "Bảo dưỡng định kỳ" },
                    new() { NgayChi = new DateOnly(2026, 10, 15), NoiDung = "Cà phê với bạn", LoaiChi = "Ăn uống", SoTien = 45000, GhiChu = "Họp nhóm đồ án" },
                    new() { NgayChi = new DateOnly(2026, 10, 18), NoiDung = "Mua vé ca nhạc", LoaiChi = "Giải trí", SoTien = 200000, GhiChu = "Cuối tuần cùng bạn bè" }
                };

                await context.ChiTieus.AddRangeAsync(sampleList);
                await context.SaveChangesAsync();
                Log.Information("Đã khởi tạo thành công {Count} dòng dữ liệu mẫu vào CSDL QL_ChiTieu.", sampleList.Count);
            }

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi trong quá trình tự động khởi tạo CSDL.");
            return false;
        }
    }

    private static void TryStartLocalDb()
    {
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = "sqllocaldb",
                Arguments = "start MSSQLLocalDB",
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            using var proc = Process.Start(psi);
            proc?.WaitForExit(3000);
        }
        catch
        {
            // Bỏ qua nếu máy không hỗ trợ sqllocaldb CLI
        }
    }

    private static async Task<string?> FindWorkingServerAsync()
    {
        // 1. Kiểm tra chuỗi kết nối đang được cấu hình trong appsettings
        string configuredConn = AppConfigManager.ConnectionString;
        string? configuredServer = ExtractServerFromConnectionString(configuredConn);
        if (!string.IsNullOrEmpty(configuredServer))
        {
            if (await CanConnectToServerAsync(configuredServer))
            {
                return configuredServer;
            }
        }

        // 2. Thử lần lượt các máy chủ SQL Server thông dụng
        foreach (var server in CandidateServers)
        {
            if (string.Equals(server, configuredServer, StringComparison.OrdinalIgnoreCase))
                continue;

            if (await CanConnectToServerAsync(server))
            {
                return server;
            }
        }

        return null;
    }

    private static string? ExtractServerFromConnectionString(string connectionString)
    {
        try
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            return builder.DataSource;
        }
        catch
        {
            return null;
        }
    }

    private static async Task<bool> CanConnectToServerAsync(string serverName)
    {
        string testConnStr = $"Server={serverName};Database=master;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=2;";
        try
        {
            using var conn = new SqlConnection(testConnStr);
            await conn.OpenAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static void SaveConnectionStringToConfig(string newConnectionString)
    {
        try
        {
            var appsettingsPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            var devSettingsPath = Path.Combine(AppContext.BaseDirectory, "appsettings.Development.json");

            UpdateJsonConfigFile(appsettingsPath, newConnectionString);
            UpdateJsonConfigFile(devSettingsPath, newConnectionString);
        }
        catch
        {
            // Không làm gián đoạn nếu không có quyền ghi file
        }
    }

    private static void UpdateJsonConfigFile(string filePath, string newConnectionString)
    {
        if (!File.Exists(filePath)) return;

        var dict = new Dictionary<string, object>
        {
            ["ConnectionStrings"] = new Dictionary<string, string>
            {
                ["DefaultConnection"] = newConnectionString
            }
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        var updatedJson = JsonSerializer.Serialize(dict, options);
        File.WriteAllText(filePath, updatedJson);
    }
}
