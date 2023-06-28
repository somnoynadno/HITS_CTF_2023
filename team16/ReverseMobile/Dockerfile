FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY /CtfReverseBackend .
RUN dotnet restore "./CtfReverseBackend.csproj" --disable-parallel
RUN dotnet publish "./CtfReverseBackend.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as serve
WORKDIR /app
COPY --from=build /app .

EXPOSE 5000
ENTRYPOINT ["dotnet", "CtfReverseBackend.dll"]