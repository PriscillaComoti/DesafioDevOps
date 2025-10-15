# ====== Etapa 1: Build (SDK) ======
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copia apenas arquivos de solução e projetos para restaurar mais rápido
COPY *.sln ./
# Se sua solution tem múltiplos projetos/pastas, copie os .csproj relevantes:
# Exemplo:
# COPY ESG.InclusaoDiversidade/ESG.InclusaoDiversidade.csproj ESG.InclusaoDiversidade/
# COPY ESG.InclusaoDiversidade.Tests/ESG.InclusaoDiversidade.Tests.csproj ESG.InclusaoDiversidade.Tests/

# Copia todo o restante do código (ajuste se necessário)
COPY . .

# >>>>>>>>>>>> AJUSTE ESTA LINHA COM O CAMINHO REAL DO SEU .csproj WEB <<<<<<<<<<<<
# Exemplo:
# RUN dotnet restore "ESG.InclusaoDiversidade/ESG.InclusaoDiversidade.csproj"
RUN dotnet restore "./ESG.InclusaoDiversidade/ESG.InclusaoDiversidade.csproj"

# Publica a aplicação em Release para a pasta /app/publish
RUN dotnet publish "./ESG.InclusaoDiversidade/ESG.InclusaoDiversidade.csproj" -c Release -o /app/publish --no-restore

# ====== Etapa 2: Runtime (ASP.NET) ======
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app

# Variáveis padrão (porta 8080 para facilitar no container)
ENV ASPNETCORE_URLS=http://+:8080
# Se você usa ASPNETCORE_ENVIRONMENT, pode setar Production por padrão:
ENV ASPNETCORE_ENVIRONMENT=Production

# Copia os artefatos publicados
COPY --from=build /app/publish .

# Expõe a porta interna
EXPOSE 8080

# Sobe a aplicação
ENTRYPOINT ["dotnet", "ESG.InclusaoDiversidade.dll"]
