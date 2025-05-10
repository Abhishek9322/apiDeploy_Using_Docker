# Use .NET 9.0 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./apiDeploy_Using_Docker/apiDeploy_Using_Docker.csproj" --disable -parallel
RUN dotnet publish "./apiDeploy_Using_Docker/apiDeploy_Using_Docker.csproj" -c Release -o /app --no-restore

# Use .NET 9.0 runtime for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=build /app .

EXPOSE 5000


ENTRYPOINT ["dotnet", "apiDeploy_Using_Docker.dll"]