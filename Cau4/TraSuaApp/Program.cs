using System;
using System.Threading;
using System.Windows.Forms;
using Serilog;
using TraSuaApp.Config;
using TraSuaApp.Forms;

namespace TraSuaApp;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // 1. Khởi tạo cấu hình strongly-typed và Serilog
        ConfigurationHelper.InitializeConfiguration();

        // 2. Cài đặt chế độ xử lý lỗi toàn cục (Global Exception Handling)
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

        Application.ThreadException += (sender, e) =>
        {
            Log.Error(e.Exception, "Lỗi UI ThreadException chưa xử lý");
            MessageBox.Show(
                "Đã xảy ra sự cố không mong muốn trong ứng dụng.\nChi tiết lỗi đã được ghi vào file log.",
                "Thông báo lỗi hệ thống",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        };

        AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        {
            if (e.ExceptionObject is Exception ex)
            {
                Log.Fatal(ex, "Lỗi nghiêm trọng UnhandledException");
            }
        };

        // 3. Khởi tạo Windows Forms
        ApplicationConfiguration.Initialize();
        
        try
        {
            Application.Run(new FormBanHang());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Lỗi khi chạy FormBanHang");
            MessageBox.Show("Không thể khởi động ứng dụng: " + ex.Message, "Lỗi khởi động", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }    
}