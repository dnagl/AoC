FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CubeConundrum/CubeConundrum.csproj", "CubeConundrum/"]
RUN dotnet restore "CubeConundrum/CubeConundrum.csproj"
COPY . .
WORKDIR "/src/CubeConundrum"
RUN dotnet build "CubeConundrum.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CubeConundrum.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CubeConundrum.dll"]
