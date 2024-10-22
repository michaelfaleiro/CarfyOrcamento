FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 5002
EXPOSE 5003

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/CarfyOrcamento.Api/CarfyOrcamento.Api.csproj", "src/CarfyOrcamento.Api/"]
COPY ["src/CarfyOrcamento.Infrastructure/CarfyOrcamento.Infrastructure.csproj", "src/CarfyOrcamento.Infrastructure/"]
COPY ["src/CarfyOrcamento.Core/CarfyOrcamento.Core.csproj", "src/CarfyOrcamento.Core/"]
COPY ["src/CarfyOrcamento.Exceptions/CarfyOrcamento.Exceptions.csproj", "src/CarfyOrcamento.Exceptions/"]
COPY ["src/CarfyOrcamento.Communication/CarfyOrcamento.Communication.csproj", "src/CarfyOrcamento.Communication/"]
COPY ["src/CarfyOrcamento.Application/CarfyOrcamento.Application.csproj", "src/CarfyOrcamento.Application/"]
RUN dotnet restore "src/CarfyOrcamento.Api/CarfyOrcamento.Api.csproj"

COPY . .
WORKDIR "/src/src/CarfyOrcamento.Api"
RUN dotnet build "CarfyOrcamento.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CarfyOrcamento.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "CarfyOrcamento.Api.dll"]
