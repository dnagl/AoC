FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MirageMaintenance/MirageMaintenance.csproj", "MirageMaintenance/"]
RUN dotnet restore "MirageMaintenance/MirageMaintenance.csproj"
COPY . .
WORKDIR "/src/MirageMaintenance"
RUN dotnet build "MirageMaintenance.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MirageMaintenance.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MirageMaintenance.dll"]
