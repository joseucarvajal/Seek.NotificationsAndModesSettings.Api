#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SeekQ.NotificationsAndModesSettings.Api/SeekQ.NotificationsAndModesSettings.Api.csproj", "SeekQ.NotificationsAndModesSettings.Api/"]
RUN dotnet restore "SeekQ.NotificationsAndModesSettings.Api/SeekQ.NotificationsAndModesSettings.Api.csproj"
COPY . .
WORKDIR "/src/SeekQ.NotificationsAndModesSettings.Api"
RUN dotnet build "SeekQ.NotificationsAndModesSettings.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SeekQ.NotificationsAndModesSettings.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SeekQ.NotificationsAndModesSettings.Api.dll"]