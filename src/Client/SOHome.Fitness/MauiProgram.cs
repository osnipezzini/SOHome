using CommunityToolkit.Maui;

using Refit;

using SOHome.Common.RefitServices;
using SOHome.Fitness.Models;
using SOHome.Fitness.Pages;
using SOHome.Fitness.ViewModels;

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

            builder.Services
                .AddSingleton<UserProvider>()
                .AddTransient<MainPage>()
                .AddTransient<RegisterExercisePage>()
                .AddTransient<LoginPage>()
                .AddTransient<LoginViewModel>()
                .AddTransient<MainViewModel>()
                .AddTransient<RegisterExerciseViewModel>();

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