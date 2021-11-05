using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanoEnsinoAPI.Migrations
{
    public partial class CorrecaoLivroEAutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroAutor",
                table: "LivroAutor");

            migrationBuilder.DropIndex(
                name: "IX_LivroAutor_CdAutor",
                table: "LivroAutor");

            migrationBuilder.DropIndex(
                name: "IX_LivroAutor_CdLivro",
                table: "LivroAutor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroAutor",
                table: "LivroAutor",
                columns: new[] { "CdLivro", "CdAutor" });

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_CdAutor",
                table: "LivroAutor",
                column: "CdAutor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroAutor",
                table: "LivroAutor");

            migrationBuilder.DropIndex(
                name: "IX_LivroAutor_CdAutor",
                table: "LivroAutor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroAutor",
                table: "LivroAutor",
                column: "CdLivroAutor");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_CdAutor",
                table: "LivroAutor",
                column: "CdAutor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_CdLivro",
                table: "LivroAutor",
                column: "CdLivro",
                unique: true);
        }
    }
}
