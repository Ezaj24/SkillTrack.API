# 1) Build stage - uses .NET SDK to compile and publish the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Restore dependencies
RUN dotnet restore "SkillTrack.API.csproj"

# Publish the app
RUN dotnet publish "SkillTrack.API.csproj" -c Release -o /app/publish

# 2) Runtime stage - lightweight image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published output from build stage
COPY --from=build /app/publish .

# Expose port 8080 for Render
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Run the app
ENTRYPOINT ["dotnet", "SkillTrack.API.dll"]
