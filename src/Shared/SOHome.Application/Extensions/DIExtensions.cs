using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace SOHome.Application;

public static class DIExtensions
{
    public static IServiceCollection RegisterHandlers(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DIExtensions));
        return services;
    }
}