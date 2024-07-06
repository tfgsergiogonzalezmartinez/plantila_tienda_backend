FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["plantilla_tienda_backend.csproj", "./"]
RUN dotnet restore "./plantilla_tienda_backend.csproj"

COPY . .
RUN dotnet publish "./plantilla_tienda_backend.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000
ENTRYPOINT ["dotnet", "plantilla_tienda_backend.dll"]
