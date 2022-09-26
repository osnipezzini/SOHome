using SOHome.Common.DataModels;
using SOHome.Common.DataModels.Requests;

namespace SOHome.API.Extensions;

public static class RoutingExtensions
{
    public static void MapRoutes(this WebApplication app)
    {
        app.MediatePost<LoginModel, UserDto>("/api/auth", "Authenticate");
        app.MediatePost<ExerciseCreateModel>("/api/exercises", "ExerciseCreate");
    }
}
