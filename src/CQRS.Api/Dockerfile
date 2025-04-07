# CQRS.Api/Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["CQRS.Api.csproj", "./"]
RUN dotnet restore "CQRS.Api.csproj"
COPY . .
RUN dotnet build "CQRS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CQRS.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRS.Api.dll"]