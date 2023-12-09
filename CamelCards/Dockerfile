FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CamelCards/CamelCards.csproj", "CamelCards/"]
RUN dotnet restore "CamelCards/CamelCards.csproj"
COPY . .
WORKDIR "/src/CamelCards"
RUN dotnet build "CamelCards.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CamelCards.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CamelCards.dll"]
