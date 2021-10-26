using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanoEnsinoAPI.Migrations
{
    public partial class AttAvaliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_CdDisciplina",
                table: "Avaliacao",
                column: "CdDisciplina",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_PlanoEnsino_CdDisciplina",
                table: "Avaliacao",
                column: "CdDisciplina",
                principalTable: "PlanoEnsino",
                principalColumn: "CdDisciplina",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_PlanoEnsino_CdDisciplina",
                table: "Avaliacao");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacao_CdDisciplina",
                table: "Avaliacao");
        }
    }
}
