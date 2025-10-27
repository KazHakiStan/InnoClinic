FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["AuthService.csproj", "."]
RUN dotnet restore "AuthService.csproj"

RUN dotnet tool install --global dotnet-ef --version 9.0.0

COPY . .
RUN dotnet build "AuthService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthService.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS final
WORKDIR /app

EXPOSE 5184
ENV ASPNETCORE_URLS=http://+:5184
ENV ASPNETCORE_ENVIRONMENT=Development

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthService.dll"]
