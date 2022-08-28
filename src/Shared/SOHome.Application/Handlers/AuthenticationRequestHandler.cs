using MediatR;

using SOHome.Common.DataModels;
using SOHome.Common.Interfaces;

namespace SOHome.Application.Handlers;

internal class AuthenticationRequestHandler : IRequestHandler<LoginModel, UserDto>
{
    private readonly IAuthService authService;

    public AuthenticationRequestHandler(IAuthService authService)
    {
        this.authService = authService;
    }
    public Task<UserDto> Handle(LoginModel request, CancellationToken cancellationToken)
    {
        return authService.LoginAsync(request);
    }
}
