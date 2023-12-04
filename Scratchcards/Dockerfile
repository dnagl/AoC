FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Scratchcards/Scratchcards.csproj", "Scratchcards/"]
RUN dotnet restore "Scratchcards/Scratchcards.csproj"
COPY . .
WORKDIR "/src/Scratchcards"
RUN dotnet build "Scratchcards.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Scratchcards.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Scratchcards.dll"]
