using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using SOHome.API.Extensions;
using SOHome.Application;
using SOHome.Common.Models;
using SOHome.Domain.Data;

using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            Implicit = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri("https://auth.sodevs.xyz/realms/master/protocol/openid-connect/auth"),
                TokenUrl = new Uri("https://auth.sodevs.xyz/realms/master/protocol/openid-connect/token"),
            }
        }
    });
});
builder.Services.AddControllers();

builder.Services.AddHttpClient();
builder.Services.RegisterDomainServices();
builder.Services.RegisterHandlers();

builder.Services.AddDbContext<SOHomeDbContext>(opt =>
{
    opt
    .UseSnakeCaseNamingConvention()
    .UseNpgsql(builder.Configuration.GetValue<string>("DbConnection"), b => b.MigrationsAssembly("SOHome.API"));
});

builder.Services.Configure<AuthConfig>(builder.Configuration.GetSection("OAuth"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateActor = false
        };
        x.MetadataAddress = "https://auth.sodevs.xyz/realms/master/.well-known/openid-configuration";
        x.Events = new()
        {
            OnAuthenticationFailed = (AuthenticationFailedContext ctx) =>
            {
                ctx.NoResult();
                ctx.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return Task.CompletedTask;
            },
            OnForbidden = ctx =>
            {
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapRoutes();
app.MapControllers();
app.Run();