#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/AmourLink.Recommendation/AmourLink.Recommendation.csproj", "Services/AmourLink.Recommendation/"]
RUN dotnet restore "./Services/AmourLink.Recommendation/AmourLink.Recommendation.csproj"
COPY . .
WORKDIR "/src/Services/AmourLink.Recommendation"
RUN dotnet build "./AmourLink.Recommendation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AmourLink.Recommendation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AmourLink.Recommendation.dll"]