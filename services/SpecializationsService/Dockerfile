FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SpecializationsService.csproj", "."]
RUN dotnet restore "SpecializationsService.csproj"
COPY . .
RUN dotnet build "SpecializationsService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpecializationsService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpecializationsService.dll"]
