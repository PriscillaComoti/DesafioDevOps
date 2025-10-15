![.NET CI](https://github.com/PriscillaComoti/DesafioDevOps/actions/workflows/ci.yml/badge.svg)

# Projeto – ESG.InclusaoDiversidade
API .NET 7 (tema ESG: Automação do processo de recrutamento para priorizar diversidade dos times) com CI/CD, container, orquestração e deploy no Azure.

## Como executar localmente com Docker
**Pré-requisitos:** Docker Desktop.

1. Crie um arquivo `.env` (baseado no `.env.example`):
   ```env
   ASPNETCORE_ENVIRONMENT=Development
   API_PORT=8080
   MONGO_ROOT_USERNAME=admin
   MONGO_ROOT_PASSWORD=admin123
   MONGO_DBNAME=esgdb
   MONGODB_CONNECTION_STRING=mongodb://admin:admin123@mongodb:27017/esgdb?authSource=admin

2. Suba os serviços:

docker compose up -d --build

3. Acesse:

API: http://localhost:8080

Swagger (se habilitado): http://localhost:8080/swagger

Health: http://localhost:8080/health

Logs: docker compose logs -f api | docker compose logs -f mongodb
Parar: docker compose down (ou down -v para limpar o banco)


4. Pipeline CI/CD

Ferramenta: GitHub Actions

CI (.github/workflows/ci.yml): checkout → setup .NET 7 → restore → build (Release) → test (TRX + coverage).
Dispara em PRs para main/dev e push na main.

Publish Docker (GHCR) (.github/workflows/docker-publish.yml): constrói e publica imagem em
ghcr.io/priscillacomoti/desafiodevops/api:latest e :<SHA>.

CD (.github/workflows/cd.yml): deploy em staging → smoke test /health → aprovação → deploy em produção com a mesma tag <SHA>.


Containerização

Dockerfile (multi-stage):

Build: mcr.microsoft.com/dotnet/sdk:7.0

Runtime: mcr.microsoft.com/dotnet/aspnet:7.0

Porta interna 8080, ASPNETCORE_ENVIRONMENT por variável.

Publicação dotnet publish -c Release e ENTRYPOINT para a DLL da API.




Orquestração (Docker Compose)

Arquivo docker-compose.yml com:

Serviço api (imagem da app) e mongodb

Variáveis de ambiente, rede e volume para o Mongo

healthcheck do Mongo + depends_on na API





Ambientes (Staging e Produção)

Plataforma: Azure App Service (Linux, Container)
Imagem: ghcr.io/priscillacomoti/desafiodevops/api:<TAG>
Config por ambiente:

WEBSITES_PORT=8080

ASPNETCORE_ENVIRONMENT=Staging|Production

MongoDB__ConnectionString=<preencher>

Health check do App Service: /health

https://desafiodevops-d5a6e6e6hdabdsdg.brazilsouth-01.azurewebsites.net/









Tecnologias utilizadas

.NET 7 (ASP.NET Core), GitHub Actions (CI/CD), GHCR, Docker & Docker Compose, Azure App Service (Linux), MongoDB, Application Insights, Serilog








Seu-projeto/
├─ Dockerfile
├─ docker-compose.yml
├─ Src/ (se você usa essa pasta; caso contrário, mantenha sua estrutura atual)
├─ readme.md
├─ .github/
│ └─ workflows/
│ ├─ ci.yml
│ ├─ docker-publish.yml
│ └─ cd.yml
├─ .env.example
└─ docs/
├─ Documentacao-Projeto-DevOps.md
├─ Documentacao-Projeto-DevOps.pdf
└─ evidencias/
├─ ci-verde.png
├─ ghcr-image.png
├─ cd-staging.png
├─ cd-approve.png
├─ cd-prod.png
├─ staging-health.png
├─ prod-health.png
├─ compose-ps.png
├─ ai-live-metrics.png
├─ ai-kusto.png
└─ healthcheck-azure.png


