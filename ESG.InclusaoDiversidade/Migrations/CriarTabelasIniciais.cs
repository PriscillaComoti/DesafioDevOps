using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESG.InclusaoDiversidade.Migrations
{
    public partial class CriarTabelasIniciais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EQUIPE",
                columns: table => new
                {
                    EquipeID = table.Column<int>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", Oracle.EntityFrameworkCore.Metadata.OracleValueGenerationStrategy.IdentityColumn),
                    NomeEquipe = table.Column<string>(type: "VARCHAR2(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPE", x => x.EquipeID);
                });

            migrationBuilder.CreateTable(
                name: "BANCO_TALENTOS",
                columns: table => new
                {
                    CandidatoID = table.Column<int>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", Oracle.EntityFrameworkCore.Metadata.OracleValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "VARCHAR2(100)", nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    Etnia = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    Deficiencia = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    CargoPretendido = table.Column<string>(type: "VARCHAR2(100)", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR2(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANCO_TALENTOS", x => x.CandidatoID);
                });

            migrationBuilder.CreateTable(
                name: "TREINAMENTOS",
                columns: table => new
                {
                    TreinamentoID = table.Column<int>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", Oracle.EntityFrameworkCore.Metadata.OracleValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "VARCHAR2(200)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR2(500)", nullable: false),
                    Tipo = table.Column<string>(type: "VARCHAR2(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TREINAMENTOS", x => x.TreinamentoID);
                });

            migrationBuilder.CreateTable(
                name: "FUNCIONARIOS",
                columns: table => new
                {
                    FuncionarioID = table.Column<int>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", Oracle.EntityFrameworkCore.Metadata.OracleValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "VARCHAR2(100)", nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    Etnia = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    Deficiencia = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    Cargo = table.Column<string>(type: "VARCHAR2(100)", nullable: false),
                    Salario = table.Column<decimal>(type: "NUMBER", nullable: false),
                    EquipeID = table.Column<int>(type: "NUMBER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIONARIOS", x => x.FuncionarioID);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIOS_EQUIPE",
                        column: x => x.EquipeID,
                        principalTable: "EQUIPE",
                        principalColumn: "EquipeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PARTICIPACOES_TREINAMENTOS",
                columns: table => new
                {
                    ParticipacaoID = table.Column<int>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", Oracle.EntityFrameworkCore.Metadata.OracleValueGenerationStrategy.IdentityColumn),
                    FuncionarioID = table.Column<int>(type: "NUMBER", nullable: false),
                    TreinamentoID = table.Column<int>(type: "NUMBER", nullable: false),
                    DataParticipacao = table.Column<DateTime>(type: "DATE", nullable: false),
                    Estrelas = table.Column<int>(type: "NUMBER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARTICIPACOES", x => x.ParticipacaoID);
                    table.ForeignKey(
                        name: "FK_PARTICIPACAO_FUNCIONARIO",
                        column: x => x.FuncionarioID,
                        principalTable: "FUNCIONARIOS",
                        principalColumn: "FuncionarioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PARTICIPACAO_TREINAMENTO",
                        column: x => x.TreinamentoID,
                        principalTable: "TREINAMENTOS",
                        principalColumn: "TreinamentoID",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "PARTICIPACOES_TREINAMENTOS");
            migrationBuilder.DropTable(name: "BANCO_TALENTOS");
            migrationBuilder.DropTable(name: "FUNCIONARIOS");
            migrationBuilder.DropTable(name: "TREINAMENTOS");
            migrationBuilder.DropTable(name: "EQUIPE");
        }
    }
}


