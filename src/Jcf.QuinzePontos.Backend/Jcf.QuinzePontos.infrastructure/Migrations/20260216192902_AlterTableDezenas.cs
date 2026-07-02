using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jcf.QuinzePontos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableDezenas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dezenas_ConcursoId",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.RenameColumn(
                name: "Numero",
                schema: "loto_facil",
                table: "Dezenas",
                newName: "N9");

            migrationBuilder.AddColumn<int>(
                name: "N1",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N10",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N11",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N12",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N13",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N14",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N15",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N2",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N3",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N4",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N5",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N6",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N7",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N8",
                schema: "loto_facil",
                table: "Dezenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dezenas_ConcursoId",
                schema: "loto_facil",
                table: "Dezenas",
                column: "ConcursoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dezenas_ConcursoId",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N1",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N10",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N11",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N12",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N13",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N14",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N15",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N2",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N3",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N4",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N5",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N6",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N7",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "N8",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.RenameColumn(
                name: "N9",
                schema: "loto_facil",
                table: "Dezenas",
                newName: "Numero");

            migrationBuilder.CreateIndex(
                name: "IX_Dezenas_ConcursoId",
                schema: "loto_facil",
                table: "Dezenas",
                column: "ConcursoId");
        }
    }
}
