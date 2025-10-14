# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar arquivos .csproj e restaurar dependências
COPY *.sln .
COPY ./*.csproj ./
RUN dotnet restore

# Copiar tudo e compilar
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "ESG.InclusaoDiversidade.dll"]
