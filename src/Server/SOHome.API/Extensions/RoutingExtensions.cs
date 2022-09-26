using SOHome.Common.DataModels;
using SOHome.Common.DataModels.Requests;
using SOHome.Common.DataModels.Responses;

namespace SOHome.API.Extensions;

public static class RoutingExtensions
{
    public static void MapRoutes(this WebApplication app)
    {
        app.MediatePost<LoginModel, UserDto>("/api/auth", "Authenticate");
        app.MediatePost<ExerciseCreateModel, ExerciseResponse>("/api/exercises", "ExerciseCreate");
    }
}
