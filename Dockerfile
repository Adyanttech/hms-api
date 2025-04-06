# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project files
COPY *.sln .
COPY HospitalManagementSystem.API/*.csproj ./HospitalManagementSystem.API/
COPY HospitalManagementSystem.Application/*.csproj ./HospitalManagementSystem.Application/
COPY HospitalManagementSystem.Infrastructure/*.csproj ./HospitalManagementSystem.Infrastructure/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the application files
COPY . .

# Build the application
RUN dotnet publish HospitalManagementSystem.API/HospitalManagementSystem.API.csproj -c Release -o /out

# Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /out .

# Expose the port the application runs on
EXPOSE 80
EXPOSE 443

# Set the entry point for the container
ENTRYPOINT ["dotnet", "HospitalManagementSystem.API.dll"]