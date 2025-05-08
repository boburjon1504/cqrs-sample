# src/Sample.Api/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/Sample.Api/Sample.Api.csproj", "Sample.Api/"]
RUN dotnet restore "Sample.Api/Sample.Api.csproj"
COPY . .
WORKDIR "/src/Sample.Api"
RUN dotnet build "Sample.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:5001
ENTRYPOINT ["dotnet", "Sample.Api.dll"]