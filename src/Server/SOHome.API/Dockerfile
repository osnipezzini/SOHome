#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.config", "."]
COPY ["src/Server/SOHome.API/SOHome.API.csproj", "src/Server/SOHome.API/"]
RUN dotnet restore "src/Server/SOHome.API/SOHome.API.csproj"
COPY . .
WORKDIR "/src/src/Server/SOHome.API"
RUN dotnet build "SOHome.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SOHome.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SOHome.API.dll"]