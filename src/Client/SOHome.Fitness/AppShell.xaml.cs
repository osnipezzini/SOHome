namespace SOHome.Fitness;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(typeof(RegisterExercisePage));
    }
}