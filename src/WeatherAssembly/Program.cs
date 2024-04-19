using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TheWeatherLibrary.Components.Weather.Services;
using WeatherAssembly;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var weatherHttpClient = new HttpClient { BaseAddress = new Uri("https://api.weatherapi.com") };
builder.Services.AddSingleton(new WeatherApiClient(weatherHttpClient));


await builder.Build().RunAsync();