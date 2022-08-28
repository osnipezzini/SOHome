using SOHome.Common.DataModels;

namespace SOHome.API.Extensions;

public static class RoutingExtensions
{
    public static void MapRoutes(this WebApplication app)
    {
        app.MediatePost<LoginModel, UserDto>("/api/auth", "Authenticate");
    }
}
