#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
EXPOSE 1234
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Metrics/Metrics.csproj", "Metrics/"]
RUN dotnet restore "Metrics/Metrics.csproj"
COPY . .
WORKDIR "/src/Metrics"
RUN dotnet build "Metrics.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Metrics.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Metrics.dll"]