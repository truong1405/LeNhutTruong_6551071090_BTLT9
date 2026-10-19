namespace TraSuaApp.Config;

public class AppConfig
{
    public ConnectionStringsConfig ConnectionStrings { get; set; } = new();
    public PaymentSettings Payment { get; set; } = new();
}

public class ConnectionStringsConfig
{
    public string DefaultConnection { get; set; } = string.Empty;
}
