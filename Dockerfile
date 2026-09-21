# 1. Etapa de compilación utilizando el SDK de .NET
FROM ://microsoft.com AS build-env
WORKDIR /app

# Copiar archivos y restaurar dependencias de la solución
COPY *.slnx ./
COPY *.csproj ./
RUN dotnet restore

# Copiar todo el código y compilar la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# 2. Etapa de ejecución utilizando el entorno ligero de ASP.NET Core
FROM ://microsoft.com
WORKDIR /app
COPY --from=build-env /app/out .

# Forzar el puerto correcto para Render
ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "TeleTracker.dll"]
