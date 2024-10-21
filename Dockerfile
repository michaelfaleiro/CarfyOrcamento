# Etapa base com a imagem leve do Alpine
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 5002
EXPOSE 5003

# Etapa de build usando o SDK completo para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar arquivos de projeto e restaurar dependências
COPY ["src/CarfyOrcamento.Api/CarfyOrcamento.Api.csproj", "src/CarfyOrcamento.Api/"]
COPY ["src/CarfyOrcamento.Infrastructure/CarfyOrcamento.Infrastructure.csproj", "src/CarfyOrcamento.Infrastructure/"]
COPY ["src/CarfyOrcamento.Core/CarfyOrcamento.Core.csproj", "src/CarfyOrcamento.Core/"]
COPY ["src/CarfyOrcamento.Exceptions/CarfyOrcamento.Exceptions.csproj", "src/CarfyOrcamento.Exceptions/"]
COPY ["src/CarfyOrcamento.Communication/CarfyOrcamento.Communication.csproj", "src/CarfyOrcamento.Communication/"]
COPY ["src/CarfyOrcamento.Application/CarfyOrcamento.Application.csproj", "src/CarfyOrcamento.Application/"]
RUN dotnet restore "src/CarfyOrcamento.Api/CarfyOrcamento.Api.csproj"

# Copiar todo o código e compilar
COPY . .
WORKDIR "/src/src/CarfyOrcamento.Api"
RUN dotnet build "CarfyOrcamento.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CarfyOrcamento.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final com a imagem leve
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app

# Copiar apenas os artefatos necessários do estágio de publicação
COPY --from=publish /app/publish .

# Definir o ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "CarfyOrcamento.Api.dll"]
