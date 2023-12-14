#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SekerTeshisApp.WebApi/SekerTeshisApp.WebApi.csproj", "SekerTeshisApp.WebApi/"]
COPY ["SeherTeshisApp.Application/SekerTeshisApp.Application.csproj", "SeherTeshisApp.Application/"]
COPY ["SekerTeshis.Entity/SekerTeshis.Entity.csproj", "SekerTeshis.Entity/"]
COPY ["SekerTeshis.Core/SekerTeshis.Core.csproj", "SekerTeshis.Core/"]
COPY ["SekerTeshisApp.Data/SekerTeshisApp.Data.csproj", "SekerTeshisApp.Data/"]
RUN dotnet restore "./SekerTeshisApp.WebApi/./SekerTeshisApp.WebApi.csproj"
COPY . .
WORKDIR "/src/SekerTeshisApp.WebApi"
RUN dotnet build "./SekerTeshisApp.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SekerTeshisApp.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SekerTeshisApp.WebApi.dll"]