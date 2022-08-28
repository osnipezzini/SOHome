using SOHome.API.Extensions;
using SOHome.Application;
using SOHome.Common.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.RegisterDomainServices();
builder.Services.RegisterHandlers();

builder.Services.Configure<AuthConfig>(builder.Configuration.GetSection("OAuth"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapRoutes();

app.Run();