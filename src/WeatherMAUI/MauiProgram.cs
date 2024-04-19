using Microsoft.Extensions.Logging;
using TheWeatherLibrary.Components.Weather.Services;

namespace WeatherMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(
                fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                }
            );

        builder.Services.AddMauiBlazorWebView();
        
        var weatherHttpClient = new HttpClient { BaseAddress = new Uri("https://api.weatherapi.com") };
        builder.Services.AddSingleton(new WeatherApiClient(weatherHttpClient));

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
