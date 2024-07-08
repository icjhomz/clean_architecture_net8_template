#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

# Use a Linux-based .NET ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use a Linux-based .NET SDK image for the build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Bookify.API/Bookify.API.csproj", "Bookify.API/"]
COPY ["Bookify.Application/Bookify.Application.csproj", "Bookify.Application/"]
COPY ["Bookify.Domain/Bookify.Domain.csproj", "Bookify.Domain/"]
COPY ["Bookify.Infrastructure/Bookify.Infrastructure.csproj", "Bookify.Infrastructure/"]
RUN dotnet restore "./Bookify.API/Bookify.API.csproj"
COPY . .
WORKDIR "/src/Bookify.API"
RUN dotnet build "./Bookify.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Bookify.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bookify.API.dll"]