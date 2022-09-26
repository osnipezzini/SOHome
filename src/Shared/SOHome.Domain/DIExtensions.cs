using Microsoft.Extensions.DependencyInjection;

using SOHome.Common.Interfaces;
using SOHome.Common.Services;
using SOHome.Domain.Services;

namespace SOHome.Application;

public static class DIExtensions
{
    public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, APIAuthService>();
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddAutoMapper(typeof(DIExtensions));
        return services;
    }
}