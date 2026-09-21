# Truco para que GitHub no altere el código
ARG REPO=mcr.microsoft.com

# 1. Etapa de compilación utilizando el SDK de .NET
FROM ${REPO}/dotnet/sdk:10.0 AS build-env
WORKDIR /app

# Copiar archivos y restaurar dependencias
COPY *.slnx ./
COPY *.csproj ./
RUN dotnet restore

# Copiar todo el código y compilar la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# 2. Etapa de ejecución utilizando el entorno ligero de ASP.NET Core
FROM ${REPO}/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build-env /app/out .

# Forzar el puerto dinámico para Render
ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "TeleTracker.dll"]
