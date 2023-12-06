FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WaitForIt/WaitForIt.csproj", "WaitForIt/"]
RUN dotnet restore "WaitForIt/WaitForIt.csproj"
COPY . .
WORKDIR "/src/WaitForIt"
RUN dotnet build "WaitForIt.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WaitForIt.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WaitForIt.dll"]
