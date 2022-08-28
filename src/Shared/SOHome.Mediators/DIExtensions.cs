using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace SOHome.Mediators
{
    public static class DIExtensions
    {
        public static IServiceCollection AddMediators(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DIExtensions));
            return services;
        }
    }
}