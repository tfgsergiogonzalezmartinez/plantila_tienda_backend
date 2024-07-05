# Utilizar la imagen base de .NET SDK para construir el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar y restaurar dependencias
COPY ["plantilla_tienda_backend.csproj", "./"]
RUN dotnet restore "./plantilla_tienda_backend.csproj"

# Copiar el resto del código y compilar
COPY . .
RUN dotnet publish "./plantilla_tienda_backend.csproj" -c Release -o /app

# Utilizar la imagen base de .NET runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

# Establecer la variable de entorno para cambiar el puerto
ENV ASPNETCORE_URLS=http://+:5000
# Exponer el puerto
EXPOSE 5000
ENTRYPOINT ["dotnet", "plantilla_tienda_backend.dll"]
