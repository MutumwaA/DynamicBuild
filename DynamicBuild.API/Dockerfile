#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DynamicBuild.API/DynamicBuild.API.csproj", "DynamicBuild.API/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Persistence/Persistence.csproj", "Persistence/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "DynamicBuild.API/DynamicBuild.API.csproj"
COPY . .
WORKDIR "/src/DynamicBuild.API"
RUN dotnet build "DynamicBuild.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DynamicBuild.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DynamicBuild.API.dll"]