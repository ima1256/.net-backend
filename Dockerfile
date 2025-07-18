# Usar la imagen oficial de .NET SDK para construir la app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar csproj y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar todo y publicar la app en modo Release
COPY . ./
RUN dotnet publish -c Release -o out

# Imagen runtime para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Exponer el puerto que usa la app (ejemplo 5000)
EXPOSE 5000

# Comando para iniciar la app
ENTRYPOINT ["dotnet", "AccessControlAPI.dll"]
