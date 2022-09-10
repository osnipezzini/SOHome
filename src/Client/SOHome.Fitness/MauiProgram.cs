using CommunityToolkit.Maui;

using Refit;

using SOHome.Common.RefitServices;
using SOHome.Fitness.Models;
using SOHome.Fitness.Pages;
using SOHome.Fitness.ViewModels;
using System.Reflection;

namespace SOHome.Fitness
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-solid-900.ttf", "fas");
                fonts.AddFont("fa-brands-400.ttf", "fab");
                fonts.AddFont("fa-regular-400.ttf", "far");
            }).UseMauiCommunityToolkit();

            foreach (var app in typeof(MauiProgram).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(BaseViewModel)) || x.IsSubclassOf(typeof(Page))))
            {
                builder.Services.AddTransient(app);
            } 

            builder.Services
                .AddSingleton<UserProvider>();

            builder.Services.AddRefitClient<IAuthAPI>()
                .ConfigureHttpClient(http =>
                {
                    http.BaseAddress = new Uri("https://api.sodevs.xyz");
                    http.DefaultRequestHeaders.Add("x-client-id", "sohome-fitness");
                });

            return builder.Build();
        }
    }
}