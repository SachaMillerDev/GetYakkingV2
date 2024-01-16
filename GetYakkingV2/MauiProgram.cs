using GetYakkingV2.Data;
using Microsoft.Extensions.Configuration;

namespace GetYakkingV2;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Configure app configuration
        builder.Configuration.AddJsonFile("DB_Helper/appsettings.json", optional: false, reloadOnChange: true);

        builder.Services.AddSingleton<PlayerDataService>();
        // Add database context
        builder.Services.AddSingleton<SqlDatabaseService>();


        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();

        return builder.Build();
    }
}
