FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["estudo_dot_net/estudo_dot_net.csproj", "estudo_dot_net/"]
RUN dotnet restore "estudo_dot_net/estudo_dot_net.csproj"
COPY . .
WORKDIR "/src/estudo_dot_net"
RUN dotnet build "estudo_dot_net.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "estudo_dot_net.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "estudo_dot_net.dll"]