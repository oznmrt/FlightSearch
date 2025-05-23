#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Providers/HopeAir.Provider/HopeAir.Provider.csproj", "src/Services/Providers/HopeAir.Provider/"]
COPY ["src/Common/FlightSearch.Common.Application/FlightSearch.Common.Application.csproj", "src/Common/FlightSearch.Common.Application/"]
COPY ["src/Common/FlightSearch.Common.Core/FlightSearch.Common.Core.csproj", "src/Common/FlightSearch.Common.Core/"]
COPY ["src/Common/FlightSearch.Common.HttpClient/FlightSearch.Common.GenericHttpClient.csproj", "src/Common/FlightSearch.Common.HttpClient/"]
COPY ["src/Common/FlightSearch.Common.Utilities/FlightSearch.Common.Utilities.csproj", "src/Common/FlightSearch.Common.Utilities/"]
COPY ["src/Common/FlightSearch.Common.MockGenerator/FlightSearch.Common.MockGenerator.csproj", "src/Common/FlightSearch.Common.MockGenerator/"]
RUN dotnet restore "./src/Services/Providers/HopeAir.Provider/./HopeAir.Provider.csproj"
COPY . .
WORKDIR "/src/src/Services/Providers/HopeAir.Provider"
RUN dotnet build "./HopeAir.Provider.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HopeAir.Provider.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HopeAir.Provider.dll"]