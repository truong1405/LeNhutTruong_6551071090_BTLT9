using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using TraSuaApp.Models;

namespace TraSuaApp.Config;

public static class ConfigurationHelper
{
    private static IConfiguration? _configuration;
    private static AppConfig? _appConfig;

    public static IConfiguration Configuration
    {
        get
        {
            if (_configuration == null)
            {
                InitializeConfiguration();
            }
            return _configuration!;
        }
    }

    public static AppConfig Config
    {
        get
        {
            if (_appConfig == null)
            {
                InitializeConfiguration();
            }
            return _appConfig!;
        }
    }

    public static PaymentSettings Payment => Config.Payment;

    public static void InitializeConfiguration()
    {
        var basePath = AppDomain.CurrentDomain.BaseDirectory;

        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

        _configuration = builder.Build();

        _appConfig = new AppConfig();
        _configuration.Bind(_appConfig);

        // Đảm bảo connection string mặc định nếu chưa cấu hình
        if (string.IsNullOrWhiteSpace(_appConfig.ConnectionStrings.DefaultConnection))
        {
            _appConfig.ConnectionStrings.DefaultConnection = 
                "Server=(localdb)\\MSSQLLocalDB;Database=QL_TraSua;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        // Cấu hình Serilog ghi file theo ngày vào thư mục Logs cạnh file .exe
        var logsDir = Path.Combine(basePath, "Logs");
        if (!Directory.Exists(logsDir))
        {
            Directory.CreateDirectory(logsDir);
        }

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(
                path: Path.Combine(logsDir, "log-.txt"),
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        Log.Information("Ứng dụng khởi động. Cấu hình đã được nạp thành công.");
    }

    public static QlTraSuaContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<QlTraSuaContext>();
        optionsBuilder.UseSqlServer(Config.ConnectionStrings.DefaultConnection);
        return new QlTraSuaContext(optionsBuilder.Options);
    }
}
