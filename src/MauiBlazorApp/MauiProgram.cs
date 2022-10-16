using MauiBlazorApp.Auth0;
using MauiBlazorApp.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace MauiBlazorApp;

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

		builder.Services.AddMauiBlazorWebView();

		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		#endif

        builder.Services.AddSingleton(new Auth0Client(new Auth0ClientOptions
        {
            //Domain = "<YOUR_AUTH0_DOMAIN>",
            //ClientId = "<YOUR_CLIENT_ID>",
            Domain = "dev-g5zonud4.us.auth0.com",
            ClientId = "B85e445eAgYRUnrC7c7XaAXLCeMNyfLQ",
            Scope = "openid profile",

            // https://github.com/dotnet/maui/issues/8382
            // RedirectUri = "http://localhost/callback"

            RedirectUri = "myapp://callback"

        }));

        builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
