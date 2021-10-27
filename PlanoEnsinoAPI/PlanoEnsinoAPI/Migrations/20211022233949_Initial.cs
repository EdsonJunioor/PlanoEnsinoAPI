using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanoEnsinoAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    CdAutor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.CdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    CdAvaliacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdDisciplina = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DsAluno = table.Column<string>(nullable: true),
                    DsConsulta = table.Column<string>(nullable: true),
                    DsAvaliacao = table.Column<string>(nullable: true),
                    DsConteudo = table.Column<string>(nullable: true),
                    DsObservacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.CdAvaliacao);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    CdCurso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DsCurso = table.Column<string>(nullable: true),
                    TpGraduacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.CdCurso);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    CdLivro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DsLivro = table.Column<string>(nullable: true),
                    Editora = table.Column<string>(nullable: true),
                    Ano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.CdLivro);
                });

            migrationBuilder.CreateTable(
                name: "PlanoEnsino",
                columns: table => new
                {
                    CdDisciplina = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DsDisciplina = table.Column<string>(nullable: true),
                    NrCreditos = table.Column<int>(nullable: false),
                    NrHorasSala = table.Column<int>(nullable: false),
                    NrHorasPP = table.Column<int>(nullable: false),
                    AnoSemestre = table.Column<string>(nullable: true),
                    DsEmenta = table.Column<string>(nullable: true),
                    DsObjetivo = table.Column<string>(nullable: true),
                    DsMTDGeral = table.Column<string>(nullable: true),
                    DsObservecao = table.Column<string>(nullable: true),
                    DsBiblioBasica = table.Column<string>(nullable: true),
                    DsBiblioComplementar = table.Column<string>(nullable: true),
                    DsSemana1 = table.Column<string>(nullable: true),
                    DsSemana2 = table.Column<string>(nullable: true),
                    DsSemana3 = table.Column<string>(nullable: true),
                    DsSemana4 = table.Column<string>(nullable: true),
                    DsSemana5 = table.Column<string>(nullable: true),
                    DsSemana6 = table.Column<string>(nullable: true),
                    DsSemana7 = table.Column<string>(nullable: true),
                    DsSemana8 = table.Column<string>(nullable: true),
                    DsSemana9 = table.Column<string>(nullable: true),
                    DsSemana10 = table.Column<string>(nullable: true),
                    DsSemana11 = table.Column<string>(nullable: true),
                    DsSemana12 = table.Column<string>(nullable: true),
                    DsSemana13 = table.Column<string>(nullable: true),
                    DsSemana14 = table.Column<string>(nullable: true),
                    DsSemana15 = table.Column<string>(nullable: true),
                    DsSemana16 = table.Column<string>(nullable: true),
                    DsSemana17 = table.Column<string>(nullable: true),
                    DsSemana18 = table.Column<string>(nullable: true),
                    DsSemana19 = table.Column<string>(nullable: true),
                    DsSemana20 = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    DtAtualização = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoEnsino", x => x.CdDisciplina);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    CdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    DtNascimento = table.Column<DateTime>(nullable: false),
                    TpUsuario = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.CdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "SugestaoPlanoEnsino",
                columns: table => new
                {
                    CdSugestaoPlanoEnsino = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdDisciplina = table.Column<int>(nullable: false),
                    DsDisciplina = table.Column<string>(nullable: true),
                    DsPlanoEnsino = table.Column<string>(nullable: true),
                    NrCreditos = table.Column<int>(nullable: false),
                    NrHorasSala = table.Column<int>(nullable: false),
                    NrHorasPP = table.Column<int>(nullable: false),
                    AnoSemestre = table.Column<string>(nullable: true),
                    DsEmenta = table.Column<string>(nullable: true),
                    DsObjetivo = table.Column<string>(nullable: true),
                    DsMTDGeral = table.Column<string>(nullable: true),
                    DsObservecao = table.Column<string>(nullable: true),
                    DsBiblioBasica = table.Column<string>(nullable: true),
                    DsBiblioComplementar = table.Column<string>(nullable: true),
                    DsSemana1 = table.Column<string>(nullable: true),
                    DsSemana2 = table.Column<string>(nullable: true),
                    DsSemana3 = table.Column<string>(nullable: true),
                    DsSemana4 = table.Column<string>(nullable: true),
                    DsSemana5 = table.Column<string>(nullable: true),
                    DsSemana6 = table.Column<string>(nullable: true),
                    DsSemana7 = table.Column<string>(nullable: true),
                    DsSemana8 = table.Column<string>(nullable: true),
                    DsSemana9 = table.Column<string>(nullable: true),
                    DsSemana10 = table.Column<string>(nullable: true),
                    DsSemana11 = table.Column<string>(nullable: true),
                    DsSemana12 = table.Column<string>(nullable: true),
                    DsSemana13 = table.Column<string>(nullable: true),
                    DsSemana14 = table.Column<string>(nullable: true),
                    DsSemana15 = table.Column<string>(nullable: true),
                    DsSemana16 = table.Column<string>(nullable: true),
                    DsSemana17 = table.Column<string>(nullable: true),
                    DsSemana18 = table.Column<string>(nullable: true),
                    DsSemana19 = table.Column<string>(nullable: true),
                    DsSemana20 = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    DtAtualização = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SugestaoPlanoEnsino", x => x.CdSugestaoPlanoEnsino);
                    table.ForeignKey(
                        name: "FK_SugestaoPlanoEnsino_PlanoEnsino_CdDisciplina",
                        column: x => x.CdDisciplina,
                        principalTable: "PlanoEnsino",
                        principalColumn: "CdDisciplina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SugestaoPlanoEnsino_CdDisciplina",
                table: "SugestaoPlanoEnsino",
                column: "CdDisciplina",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "SugestaoPlanoEnsino");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "PlanoEnsino");
        }
    }
}
