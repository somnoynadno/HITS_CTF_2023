FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY /SqliCtf .
RUN dotnet restore "./SqliCtf.csproj" --disable-parallel
RUN dotnet publish "./SqliCtf.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as serve
WORKDIR /app
COPY --from=build /app .

EXPOSE 5000
ENTRYPOINT ["dotnet", "SqliCtf.dll"]