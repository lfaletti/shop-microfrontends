FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["main-api.csproj", "./"]
RUN dotnet restore "main-api.csproj"
COPY . .
RUN dotnet build "main-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "main-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "main-api.dll"]