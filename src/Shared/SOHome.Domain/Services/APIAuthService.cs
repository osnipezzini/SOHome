using Microsoft.Extensions.Options;

using SOHome.Common.DataModels;
using SOHome.Common.Exceptions;
using SOHome.Common.Interfaces;
using SOHome.Common.Models;

using System.Net;
using System.Text.Json;

namespace SOHome.Domain.Services
{
    public class APIAuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly AuthConfig authConfig;

        public APIAuthService(HttpClient httpClient, IOptions<AuthConfig> options)
        {
            this.httpClient = httpClient;
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

            var realm = "master";
            var authEndpoint = "https://auth.sodevs.xyz/";
            var url = $"{authEndpoint}/auth/realms/{realm}/protocol/openid-connect/auth";
            var request = await httpClient.PostAsync(url, new FormUrlEncodedContent(requestData));
            var content = await request.Content.ReadAsStringAsync();
            if (request.StatusCode == HttpStatusCode.Unauthorized)
                throw new LoginException("Usuário ou senha inválidos!");
            else if (request.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException(content);

            var userDto = JsonSerializer.Deserialize<UserDto>(content);
            if (userDto == null)
                throw new LoginException("Retorno inválido da API de autenticação");

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

            var realm = "master";
            var authEndpoint = "https://auth.sodevs.xyz/";
            var url = $"{authEndpoint}/auth/realms/{realm}/protocol/openid-connect/auth";
            var request = await httpClient.PostAsync(url, new FormUrlEncodedContent(requestData));
            var content = await request.Content.ReadAsStringAsync();
            if (request.StatusCode == HttpStatusCode.Unauthorized)
                throw new LoginException("Usuário ou senha inválidos!");
            else if (request.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException(content);

            var userDto = JsonSerializer.Deserialize<UserDto>(content);
            if (userDto == null)
                throw new LoginException("Retorno inválido da API de autenticação");

            return userDto;
        }

        public Task<UserDto> RegisterAsync(RegisterModel model)
        {
            return Task.FromResult<UserDto>(null);
        }
    }
}
