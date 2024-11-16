# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Services/FlightSearch.API/FlightSearch.API.csproj", "src/Services/FlightSearch.API/"]
COPY ["src/Common/FlightSearch.Common.Application/FlightSearch.Common.Application.csproj", "src/Common/FlightSearch.Common.Application/"]
COPY ["src/Common/FlightSearch.Common.Core/FlightSearch.Common.Core.csproj", "src/Common/FlightSearch.Common.Core/"]
COPY ["src/Common/FlightSearch.Common.HttpClient/FlightSearch.Common.GenericHttpClient.csproj", "src/Common/FlightSearch.Common.HttpClient/"]
COPY ["src/Common/FlightSearch.Common.Utilities/FlightSearch.Common.Utilities.csproj", "src/Common/FlightSearch.Common.Utilities/"]
COPY ["src/Common/FlightSearch.Common.MockGenerator/FlightSearch.Common.MockGenerator.csproj", "src/Common/FlightSearch.Common.MockGenerator/"]
RUN dotnet restore "src/Services/FlightSearch.API/FlightSearch.API.csproj"

COPY . .
WORKDIR "/src/src/Services/FlightSearch.API"
RUN dotnet build "FlightSearch.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish image
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FlightSearch.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlightSearch.API.dll"]