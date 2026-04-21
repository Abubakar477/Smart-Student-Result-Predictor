# Use the .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY ["student predication.csproj", "./"]
RUN dotnet restore

# Copy the remaining files and build the project
COPY . .
RUN dotnet build "student predication.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "student predication.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage: Use the Windows Runtime for execution
# Note: Executing GUI apps in Docker requires a Windows host and specific configuration
FROM mcr.microsoft.com/dotnet/runtime:8.0-windowsservercore-ltsc2022 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Run the application (This will fail without a display server, but demonstrates the containerization)
ENTRYPOINT ["dotnet", "StudentPredictionSystem.dll"]
