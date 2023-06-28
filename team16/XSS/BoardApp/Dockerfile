# build
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /source
COPY . .
RUN dotnet restore "./BoardApp.csproj" --disable-parallel && dotnet publish "./BoardApp.csproj" -c debug -o /app --no-restore

# runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 
WORKDIR /app
COPY --from=build /app ./
ENV ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:27000
ENV ASPNETCORE_HTTP_PORT=https://+:27001

EXPOSE 27000 27001

ENTRYPOINT ["dotnet", "BoardApp.dll", "--environment=Development"]
