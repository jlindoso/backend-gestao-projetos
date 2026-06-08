FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src


COPY ["PMOrquestra.sln", "./"]


COPY ["Application/Application.csproj", "Application/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Adapters/Data/Data.csproj", "Adapters/Data/"]


RUN dotnet restore "PMOrquestra.sln"

COPY . .


WORKDIR "/src/Application"
RUN dotnet build "Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Application.dll"]