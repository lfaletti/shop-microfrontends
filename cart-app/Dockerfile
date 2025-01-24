# Build SPA
FROM node:latest as spa-build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# Build API
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS api-build
WORKDIR /src
COPY ["CartApp.Server/CartApp.Server.csproj", "CartApp.Server/"]
RUN dotnet restore "CartApp.Server/CartApp.Server.csproj"
COPY . .
WORKDIR "/src/CartApp.Server"
RUN dotnet build "CartApp.Server.csproj" -c Release -o /app/build
RUN dotnet publish "CartApp.Server.csproj" -c Release -o /app/publish

# Final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=api-build /app/publish .
COPY --from=spa-build /app/dist /app/wwwroot
ENTRYPOINT ["dotnet", "CartApp.Server.dll"]