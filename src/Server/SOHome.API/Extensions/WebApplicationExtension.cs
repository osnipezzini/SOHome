using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace SOHome.API.Extensions;

public static class WebApplicationExtension
{
    public static WebApplication MediateGet<TRequest, TResponse>(this WebApplication app, string template)
        where TRequest : IRequest<TResponse>
    {
        app.MapGet(template, ([FromServices] IMediator mediator, [FromBody] TRequest request) => mediator.Send(request));
        return app;
    }
    public static WebApplication MediateGet<TRequest, TResponse>(this WebApplication app, string template, string routeName)
        where TRequest : IRequest<TResponse>
    {
        app.MapGet(template, ([FromServices] IMediator mediator, [FromBody] TRequest request) => mediator.Send(request))
            .WithName(routeName);
        return app;
    }
    public static WebApplication MediatePost<TRequest, TResponse>(this WebApplication app, string template)
        where TRequest : IRequest<TResponse>
    {
        app.MapPost(template, ([FromServices] IMediator mediator, [FromBody] TRequest request) => mediator.Send(request));
        return app;
    }
    public static WebApplication MediatePost<TRequest, TResponse>(this WebApplication app, string template, string routeName)
        where TRequest : IRequest<TResponse>
    {
        app.MapPost(template, ([FromServices] IMediator mediator, [FromBody] TRequest request) => mediator.Send(request))
            .WithName(routeName);
        return app;
    }
    public static WebApplication MediatePost<TRequest>(this WebApplication app, string template, string routeName)
        where TRequest : IRequest
    {
        app.MapPost(template, ([FromServices] IMediator mediator, [FromBody] TRequest request) => mediator.Send(request))
            .WithName(routeName);
        return app;
    }
    public static WebApplication MediatePut<TRequest, TResponse>(this WebApplication app, string template)
        where TRequest : IRequest<TResponse>
    {
        app.MapPut(template, ([FromServices] IMediator mediator, [FromBody] TRequest request) => mediator.Send(request));
        return app;
    }
    public static WebApplication MediatePut<TRequest, TResponse>(this WebApplication app, string template, string routeName)
        where TRequest : IRequest<TResponse>
    {
        app.MapPut(template, ([FromServices] IMediator mediator, [FromBody] TRequest request) => mediator.Send(request))
            .WithName(routeName);
        return app;
    }
    public static WebApplication MediateDelete<TRequest, TResponse>(this WebApplication app, string template)
        where TRequest : IRequest<TResponse>
    {
        app.MapDelete(template, ([FromServices] IMediator mediator, [FromBody] TRequest request) => mediator.Send(request));
        return app;
    }
    public static WebApplication MediateDelete<TRequest, TResponse>(this WebApplication app, string template, string routeName)
        where TRequest : IRequest<TResponse>
    {
        app.MapDelete(template, ([FromServices] IMediator mediator, [FromBody] TRequest request) => mediator.Send(request))
            .WithName(routeName);
        return app;
    }
}
