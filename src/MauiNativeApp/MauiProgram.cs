using MauiNativeApp.Auth0;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace MauiNativeApp
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton(new Auth0Client(new Auth0ClientOptions
            {
                Domain = "<YOUR_AUTH0_DOMAIN>",
                ClientId = "<YOUR_CLIENT_ID>",
                Scope = "openid profile",

                // https://github.com/dotnet/maui/issues/8382
                RedirectUri = "http://localhost/callback"
                // RedirectUri = "myapp://callback"

            }));

            return builder.Build();
        }
    }
}