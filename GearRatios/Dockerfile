FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GearRatios/GearRatios.csproj", "GearRatios/"]
RUN dotnet restore "GearRatios/GearRatios.csproj"
COPY . .
WORKDIR "/src/GearRatios"
RUN dotnet build "GearRatios.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GearRatios.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GearRatios.dll"]
