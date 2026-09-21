# 1. Etapa de compilación utilizando el SDK de .NET 10.0
FROM ://microsoft.com AS build-env
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY *.sln ./
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y compilar el proyecto
COPY . ./
RUN dotnet publish -c Release -o out

# 2. Etapa de ejecución utilizando el entorno de ejecución ligero
FROM ://microsoft.com
WORKDIR /app
COPY --from=build-env /app/out .

# Configurar el puerto dinámico para que Render pueda redirigir el tráfico
ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "TeleTracker.dll"]
