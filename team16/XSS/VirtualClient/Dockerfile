# build
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /source
COPY . .
RUN dotnet restore "./VirtualClient.csproj" --disable-parallel && dotnet publish "./VirtualClient.csproj" -c debug -o /app --no-restore

# runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 
WORKDIR /app
COPY --from=build /app ./
ENV ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:10000
ENV ASPNETCORE_HTTP_PORT=https://+:10001

RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano && \
curl -sL https://deb.nodesource.com/setup_16.x | bash - && apt-get install -yq nodejs build-essential && \
apt-get install -yq nodejs build-essential && \
npm install -g npm

RUN apt-get install -y wget xvfb unzip

# Set up the Chrome PPA
RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - && \
echo "deb http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list

# Update the package list and install chrome
RUN apt-get update -y && \
apt-get install -y google-chrome-stable

RUN npx playwright@1.34 install --with-deps chromium

EXPOSE 10000

ENTRYPOINT ["dotnet", "VirtualClient.dll", "--environment=Development"]
