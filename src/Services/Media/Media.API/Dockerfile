#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Services/Media/Media.API/Media.API.csproj", "src/Services/Media/Media.API/"]
RUN dotnet restore "src/Services/Media/Media.API/Media.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Media/Media.API"
RUN dotnet build "Media.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Media.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Media.API.dll"]