using AutoMapper;

using Microsoft.Extensions.Options;

using SOHome.Common.DataModels;
using SOHome.Common.Exceptions;
using SOHome.Common.Interfaces;
using SOHome.Common.Models;
using SOHome.Domain.Models;
using SOHome.Domain.Responses;

using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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
    private async Task<OAuthUrls> GetOAuthUrlsAsync()
    {
        var realm = authConfig.Realm;
        var authEndpoint = authConfig.Authority.EndsWith("/") ? authConfig.Authority[..^1] : authConfig.Authority;
        var url = $"{authEndpoint}/realms/{realm}/.well-known/openid-configuration";

        var oauthUrls = await httpClient.GetFromJsonAsync<OAuthUrls>(url);
        return oauthUrls;
    }
    private async Task<UserDto> GetUserInfo()
    {
        var realm = authConfig.Realm;
        var authEndpoint = authConfig.Authority.EndsWith("/") ? authConfig.Authority[..^1] : authConfig.Authority;
        var url = $"{authEndpoint}/realms/{realm}/protocol/openid-connect/userinfo";

        var userInfo = await httpClient.GetFromJsonAsync<UserInfo>(url);
        return mapper.Map<UserDto>(userInfo);
    }
    public async Task<UserDto> LoginAsync(LoginModel model)
    {
        var requestData = new Dictionary<string, string>()
        {
            {"client_id", authConfig.ClientId },
            {"username", model.Username},
            {"password", model.Password},
            {"grant_type", "password" },
            {"totp", model.TOTP },
            {"scope", "email openid profile" }
        };

        var realm = authConfig.Realm;
        var authEndpoint = authConfig.Authority.EndsWith("/") ? authConfig.Authority[..^1] : authConfig.Authority;
        var url = new Uri($"{authEndpoint}/realms/{realm}/protocol/openid-connect/token");
        var httpMessage = new HttpRequestMessage(HttpMethod.Post, url);
        httpMessage.Headers.Clear();
        httpMessage.Headers.Add("Host", url.Host);
        httpMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("br"));
        httpMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        httpMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
        httpMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

        httpMessage.Content = new FormUrlEncodedContent(requestData);

        var request = await httpClient.SendAsync(httpMessage);
        var content = await request.Content.ReadAsStringAsync();
        if (request.StatusCode == HttpStatusCode.Unauthorized)
            throw new LoginException("Usuário ou senha inválidos!");
        else if (request.StatusCode != HttpStatusCode.OK)
            throw new HttpRequestException(content);

        var token = JsonSerializer.Deserialize<OpenIdToken>(content);
        if (token == null)
            throw new LoginException("Retorno inválido da API de autenticação");

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

        var userDto = await GetUserInfo();
        mapper.Map(token, userDto);

        return userDto;
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
        var url = new Uri($"{authEndpoint}/realms/{realm}/protocol/openid-connect/token");
        var httpMessage = new HttpRequestMessage(HttpMethod.Post, url);
        httpMessage.Headers.Clear();
        httpMessage.Headers.Add("Host", url.Host);
        httpMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("br"));
        httpMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        httpMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
        httpMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

        httpMessage.Content = new FormUrlEncodedContent(requestData);

        var request = await httpClient.SendAsync(httpMessage);
        var content = await request.Content.ReadAsStringAsync();
        if (request.StatusCode == HttpStatusCode.Unauthorized)
            throw new LoginException("Usuário ou senha inválidos!");
        else if (request.StatusCode != HttpStatusCode.OK)
            throw new HttpRequestException(content);

        var token = JsonSerializer.Deserialize<OpenIdToken>(content);
        if (token == null)
            throw new LoginException("Retorno inválido da API de autenticação");

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

        return mapper.Map<UserDto>(token);
    }

    public Task<UserDto> RegisterAsync(RegisterModel model)
    {
        return Task.FromResult<UserDto>(null);
    }
}
