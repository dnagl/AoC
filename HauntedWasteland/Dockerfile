FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HauntedWasteland/HauntedWasteland.csproj", "HauntedWasteland/"]
RUN dotnet restore "HauntedWasteland/HauntedWasteland.csproj"
COPY . .
WORKDIR "/src/HauntedWasteland"
RUN dotnet build "HauntedWasteland.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HauntedWasteland.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HauntedWasteland.dll"]
