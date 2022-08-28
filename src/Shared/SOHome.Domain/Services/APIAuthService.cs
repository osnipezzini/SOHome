using AutoMapper;

using Microsoft.Extensions.Options;

using SOHome.Common.DataModels;
using SOHome.Common.Exceptions;
using SOHome.Common.Interfaces;
using SOHome.Common.Models;
using SOHome.Domain.Models;

using System.Net;
using System.Text.Json;

namespace SOHome.Domain.Services;

public class APIAuthService : IAuthService
{
    private readonly HttpClient httpClient;
    private readonly IMapper mapper;
    private readonly AuthConfig authConfig;

    public APIAuthService(HttpClient httpClient, IOptions<AuthConfig> options, IMapper mapper)
    {
        this.httpClient = httpClient;
        this.mapper = mapper;
        authConfig = options.Value;
    }

    public async Task<UserDto> LoginAsync(LoginModel model)
    {
        var requestData = new Dictionary<string, string>()
        {
            {"client_id", authConfig.ClientId },
            {"username", model.Username},
            {"password", model.Password},
            {"grant_type", "password" },
            {"scope", "email openid profile" }
        };

        var realm = authConfig.Realm;
        var authEndpoint = authConfig.Authority.EndsWith("/") ? authConfig.Authority[..^1] : authConfig.Authority;
        var url = $"{authEndpoint}/realms/{realm}/protocol/openid-connect/token";
        var request = await httpClient.PostAsync(url, new FormUrlEncodedContent(requestData));
        var content = await request.Content.ReadAsStringAsync();
        if (request.StatusCode == HttpStatusCode.Unauthorized)
            throw new LoginException("Usuário ou senha inválidos!");
        else if (request.StatusCode != HttpStatusCode.OK)
            throw new HttpRequestException(content);

        var token = JsonSerializer.Deserialize<OpenIdToken>(content);
        if (token == null)
            throw new LoginException("Retorno inválido da API de autenticação");

        return mapper.Map<UserDto>(token);
    }

    public async Task LogoutAsync()
    {
        httpClient.DefaultRequestHeaders.Authorization = null;
        await Task.CompletedTask;
    }

    public async Task<UserDto> RefreshTokenAsync(string refreshToken)
    {
        var requestData = new Dictionary<string, string>()
        {
            {"client_id", authConfig.ClientId },
            {"grant_type", "refresh_token" },
            {"scope", "email openid profile" },
            {"refresh_token", refreshToken }
        };

        var realm = authConfig.Realm;
        var authEndpoint = authConfig.Authority.EndsWith("/") ? authConfig.Authority[..^1] : authConfig.Authority;
        var url = $"{authEndpoint}/realms/{realm}/protocol/openid-connect/token";
        var request = await httpClient.PostAsync(url, new FormUrlEncodedContent(requestData));
        var content = await request.Content.ReadAsStringAsync();
        if (request.StatusCode == HttpStatusCode.Unauthorized)
            throw new LoginException("Usuário ou senha inválidos!");
        else if (request.StatusCode != HttpStatusCode.OK)
            throw new HttpRequestException(content);

        var token = JsonSerializer.Deserialize<OpenIdToken>(content);
        if (token == null)
            throw new LoginException("Retorno inválido da API de autenticação");

        return mapper.Map<UserDto>(token);
    }

    public Task<UserDto> RegisterAsync(RegisterModel model)
    {
        return Task.FromResult<UserDto>(null);
    }
}
