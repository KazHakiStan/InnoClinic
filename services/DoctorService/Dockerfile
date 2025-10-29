FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["DoctorService.csproj", "."]
RUN dotnet restore "DoctorService.csproj"
COPY . .
RUN dotnet build "DoctorService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DoctorService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DoctorService.dll"]
