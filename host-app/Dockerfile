
FROM node:18-alpine AS frontend
WORKDIR /src
COPY ["package*.json", "./"]
RUN npm install
COPY [".", "./"]
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HostApp.Server/HostApp.Server.csproj", "./"]
RUN dotnet restore
COPY ["HostApp.Server/", "./"]
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
COPY --from=frontend /src/dist/* ./wwwroot/
COPY --from=frontend /src/wwwroot/index.html ./wwwroot/
ENTRYPOINT ["dotnet", "HostApp.Server.dll"]
