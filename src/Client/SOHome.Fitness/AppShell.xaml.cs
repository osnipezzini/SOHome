using SOHome.Fitness.Pages;

namespace SOHome.Fitness
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(Routes.RegisterExercise, typeof(RegisterExercisePage));
        }
    }
}