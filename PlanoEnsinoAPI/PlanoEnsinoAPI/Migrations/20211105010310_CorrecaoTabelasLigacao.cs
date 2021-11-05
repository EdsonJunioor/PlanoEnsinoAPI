using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanoEnsinoAPI.Migrations
{
    public partial class CorrecaoTabelasLigacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SugestaoPlanoEnsino_PlanoEnsino_CdDisciplina",
                table: "SugestaoPlanoEnsino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioPlanoEnsino",
                table: "UsuarioPlanoEnsino");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioPlanoEnsino_CdDisciplina",
                table: "UsuarioPlanoEnsino");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioPlanoEnsino_CdUsuario",
                table: "UsuarioPlanoEnsino");

            migrationBuilder.DropIndex(
                name: "IX_SugestaoPlanoEnsino_CdDisciplina",
                table: "SugestaoPlanoEnsino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CursoPlanoEnsino",
                table: "CursoPlanoEnsino");

            migrationBuilder.DropIndex(
                name: "IX_CursoPlanoEnsino_CdCurso",
                table: "CursoPlanoEnsino");

            migrationBuilder.DropIndex(
                name: "IX_CursoPlanoEnsino_CdDisciplina",
                table: "CursoPlanoEnsino");

            migrationBuilder.AddColumn<int>(
                name: "PlanoEnsinoCdDisciplina",
                table: "SugestaoPlanoEnsino",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioPlanoEnsino",
                table: "UsuarioPlanoEnsino",
                columns: new[] { "CdUsuario", "CdDisciplina" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CursoPlanoEnsino",
                table: "CursoPlanoEnsino",
                columns: new[] { "CdCurso", "CdDisciplina" });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPlanoEnsino_CdDisciplina",
                table: "UsuarioPlanoEnsino",
                column: "CdDisciplina");

            migrationBuilder.CreateIndex(
                name: "IX_SugestaoPlanoEnsino_PlanoEnsinoCdDisciplina",
                table: "SugestaoPlanoEnsino",
                column: "PlanoEnsinoCdDisciplina");

            migrationBuilder.CreateIndex(
                name: "IX_CursoPlanoEnsino_CdDisciplina",
                table: "CursoPlanoEnsino",
                column: "CdDisciplina");

            migrationBuilder.AddForeignKey(
                name: "FK_SugestaoPlanoEnsino_PlanoEnsino_PlanoEnsinoCdDisciplina",
                table: "SugestaoPlanoEnsino",
                column: "PlanoEnsinoCdDisciplina",
                principalTable: "PlanoEnsino",
                principalColumn: "CdDisciplina",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SugestaoPlanoEnsino_PlanoEnsino_PlanoEnsinoCdDisciplina",
                table: "SugestaoPlanoEnsino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioPlanoEnsino",
                table: "UsuarioPlanoEnsino");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioPlanoEnsino_CdDisciplina",
                table: "UsuarioPlanoEnsino");

            migrationBuilder.DropIndex(
                name: "IX_SugestaoPlanoEnsino_PlanoEnsinoCdDisciplina",
                table: "SugestaoPlanoEnsino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CursoPlanoEnsino",
                table: "CursoPlanoEnsino");

            migrationBuilder.DropIndex(
                name: "IX_CursoPlanoEnsino_CdDisciplina",
                table: "CursoPlanoEnsino");

            migrationBuilder.DropColumn(
                name: "PlanoEnsinoCdDisciplina",
                table: "SugestaoPlanoEnsino");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioPlanoEnsino",
                table: "UsuarioPlanoEnsino",
                column: "CdUsuarioPlanoEnsino");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CursoPlanoEnsino",
                table: "CursoPlanoEnsino",
                column: "CdCursoPlanoEnsino");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPlanoEnsino_CdDisciplina",
                table: "UsuarioPlanoEnsino",
                column: "CdDisciplina",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPlanoEnsino_CdUsuario",
                table: "UsuarioPlanoEnsino",
                column: "CdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SugestaoPlanoEnsino_CdDisciplina",
                table: "SugestaoPlanoEnsino",
                column: "CdDisciplina",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CursoPlanoEnsino_CdCurso",
                table: "CursoPlanoEnsino",
                column: "CdCurso",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CursoPlanoEnsino_CdDisciplina",
                table: "CursoPlanoEnsino",
                column: "CdDisciplina",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SugestaoPlanoEnsino_PlanoEnsino_CdDisciplina",
                table: "SugestaoPlanoEnsino",
                column: "CdDisciplina",
                principalTable: "PlanoEnsino",
                principalColumn: "CdDisciplina",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
