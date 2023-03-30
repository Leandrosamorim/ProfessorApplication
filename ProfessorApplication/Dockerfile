#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5099

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProfessorApplication/ProfessorApplication.csproj", "ProfessorApplication/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["IoC/IoC.csproj", "IoC/"]
RUN dotnet restore "ProfessorApplication/ProfessorApplication.csproj"
COPY . .
WORKDIR "/src/ProfessorApplication"
RUN dotnet build "ProfessorApplication.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "ProfessorApplication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProfessorApplication.dll"]

