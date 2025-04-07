# src/CQRS.Api/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/CQRS.Api/CQRS.Api.csproj", "CQRS.Api/"]
RUN dotnet restore "CQRS.Api/CQRS.Api.csproj"
COPY . .
WORKDIR "/src/CQRS.Api"
RUN dotnet build "CQRS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CQRS.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:5000
ENTRYPOINT ["dotnet", "CQRS.Api.dll"]