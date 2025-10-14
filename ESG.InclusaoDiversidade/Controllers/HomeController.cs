using System;
using Microsoft.AspNetCore.Mvc;

namespace ESG.InclusaoDiversidade.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ContentResult Index()
        {
            var html = @"
                <!DOCTYPE html>
                <html lang='pt-BR'>
                <head>
                    <meta charset='UTF-8'>
                    <title>ESG - Inclusão e Diversidade</title>
                    <style>
                        body { font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 40px; }
                        h1 { color: #006699; }
                        ul { list-style-type: none; padding: 0; }
                        li { margin-bottom: 10px; }
                        a { color: #333; text-decoration: none; font-weight: bold; }
                        a:hover { color: #006699; }
                    </style>
                </head>
                <body>
                    <h1>API ESG - Inclusão & Diversidade</h1>
                    <p>Bem-vindo à API de apoio à inclusão e diversidade corporativa.</p>
                    <ul>
                        <li><a href='/swagger'>🔍 Documentação da API (Swagger)</a></li>
                        <li><a href='/api/funcionario'>👥 Funcionários</a></li>
                        <li><a href='/api/candidato'>🧑‍💼 Candidatos</a></li>
                        <li><a href='/api/treinamento'>📚 Treinamentos</a></li>
                        <li><a href='/api/auth/login'>🔐 Autenticação (Login)</a></li>
                    </ul>
                    <p style='margin-top:40px; font-size: 0.9em;'>RM-554564 • Desenvolvido com .NET 7 no Visual Studio para Mac</p>
                </body>
                </html>";

            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }
    }
}


