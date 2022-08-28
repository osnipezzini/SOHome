using CommunityToolkit.Maui;
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
            }).UseMauiCommunityToolkit();
            builder.Services
                .AddTransient<MainPage>()
                .AddTransient<RegisterExercisePage>()
                .AddTransient<MainViewModel>()
                .AddTransient<RegisterExerciseViewModel>();

            return builder.Build();
        }
    }
}