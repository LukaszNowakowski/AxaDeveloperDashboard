FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Api/Api.csproj", "./Api/"]
COPY ["Logic/Logic.csproj", "./Logic/"]
COPY ["DataAccess/DataAccess.csproj", "./DataAccess/"]
COPY ["UnitTests/UnitTests.csproj", "./UnitTests/"]
COPY ["Api.sln", "./"]
RUN dotnet restore "./Api.sln"

COPY . .

WORKDIR "/src"
RUN dotnet build "./Api.sln" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Api/Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Avanssur.AxaDeveloperDashboard.Api.dll"]

