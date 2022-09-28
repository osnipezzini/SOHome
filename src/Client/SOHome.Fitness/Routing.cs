namespace SOHome.Fitness
{
    public static class Routing
    {
        public static void RegisterRoute(Type type)
        {
            Microsoft.Maui.Controls.Routing.RegisterRoute(nameof(type), type);
        }
    }
}
