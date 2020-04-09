#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MusicRoom.csproj", "MusicRoom/"]
RUN dotnet restore "MusicRoom/MusicRoom.csproj"
COPY . ./MusicRoom/
WORKDIR "/src/MusicRoom"
RUN dotnet build "MusicRoom.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusicRoom.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicRoom.dll"]