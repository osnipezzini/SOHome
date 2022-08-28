using MediatR;

namespace SOHome.API.Extensions
{
    public static class WebApplicationExtension
    {
        public static WebApplication MediateGet<TRequest, TResponse>(this WebApplication app, string template) where TRequest : IRequest<TResponse>
        {
            app.MapGet(template, (IMediator mediator, TRequest request) => mediator.Send(request));
            return app;
        }
        public static WebApplication MediatePost<TRequest, TResponse>(this WebApplication app, string template) where TRequest : IRequest<TResponse>
        {
            app.MapPost(template, (IMediator mediator, TRequest request) => mediator.Send(request));
            return app;
        }
    }
}
