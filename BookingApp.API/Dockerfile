FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["BookingApp.API/BookingApp.API.csproj", "BookingApp.API/"]
COPY ["BookingApp.Application/BookingApp.Application.csproj", "BookingApp.Application/"]
COPY ["BookingApp.Domain/BookingApp.Domain.csproj", "BookingApp.Domain/"]
COPY ["BookingApp.Infrastructure/BookingApp.Infrastructure.csproj", "BookingApp.Infrastructure/"]
RUN dotnet restore "BookingApp.API/BookingApp.API.csproj"
COPY . .

WORKDIR "/src/BookingApp.API"
RUN dotnet build "BookingApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingApp.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingApp.API.dll"]