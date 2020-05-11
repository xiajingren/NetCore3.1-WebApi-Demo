#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NetCore3.1-WebApi-Demo/NetCore3.1-WebApi-Demo.csproj", "NetCore3.1-WebApi-Demo/"]
RUN dotnet restore "NetCore3.1-WebApi-Demo/NetCore3.1-WebApi-Demo.csproj"
COPY . .
WORKDIR "/src/NetCore3.1-WebApi-Demo"
RUN dotnet build "NetCore3.1-WebApi-Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCore3.1-WebApi-Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCore3.1-WebApi-Demo.dll"]