using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Jcf.QuinzePontos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLotofacilNumeroEstatistica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumeroEstatisticas",
                schema: "loto_facil",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LotofacilConcursoId = table.Column<long>(type: "bigint", nullable: true),
                    NumeroId = table.Column<int>(type: "integer", nullable: false),
                    CurrentStreak = table.Column<int>(type: "integer", nullable: false),
                    CurrentAbsenceStreak = table.Column<int>(type: "integer", nullable: false),
                    FreqLast5 = table.Column<int>(type: "integer", nullable: false),
                    FreqLast10 = table.Column<int>(type: "integer", nullable: false),
                    FreqLast15 = table.Column<int>(type: "integer", nullable: false),
                    FreqLast20 = table.Column<int>(type: "integer", nullable: false),
                    FreqLast100 = table.Column<int>(type: "integer", nullable: false),
                    TotalAppearances = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroEstatisticas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumeroEstatisticas_Concursos_LotofacilConcursoId",
                        column: x => x.LotofacilConcursoId,
                        principalSchema: "loto_facil",
                        principalTable: "Concursos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NumeroEstatisticas_LotofacilConcursoId",
                schema: "loto_facil",
                table: "NumeroEstatisticas",
                column: "LotofacilConcursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumeroEstatisticas",
                schema: "loto_facil");
        }
    }
}
