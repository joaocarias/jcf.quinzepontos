using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Jcf.QuinzePontos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialLotoFacil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "loto_facil");

            migrationBuilder.CreateTable(
                name: "Concursos",
                schema: "loto_facil",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    DataApuracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataProximoConcurso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Acumulado = table.Column<bool>(type: "boolean", nullable: false),
                    UltimoConcurso = table.Column<bool>(type: "boolean", nullable: false),
                    LocalSorteio = table.Column<string>(type: "text", nullable: false),
                    NomeMunicipioUFSorteio = table.Column<string>(type: "text", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: false),
                    ValorArrecadado = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorEstimadoProximoConcurso = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorAcumuladoProximoConcurso = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorAcumuladoConcursoEspecial = table.Column<decimal>(type: "numeric", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dezenas",
                schema: "loto_facil",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConcursoId = table.Column<long>(type: "bigint", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dezenas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dezenas_Concursos_ConcursoId",
                        column: x => x.ConcursoId,
                        principalSchema: "loto_facil",
                        principalTable: "Concursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GanhadoresUF",
                schema: "loto_facil",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConcursoId = table.Column<long>(type: "bigint", nullable: false),
                    UF = table.Column<string>(type: "text", nullable: false),
                    Municipio = table.Column<string>(type: "text", nullable: false),
                    Ganhadores = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GanhadoresUF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GanhadoresUF_Concursos_ConcursoId",
                        column: x => x.ConcursoId,
                        principalSchema: "loto_facil",
                        principalTable: "Concursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rateios",
                schema: "loto_facil",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConcursoId = table.Column<long>(type: "bigint", nullable: false),
                    Faixa = table.Column<int>(type: "integer", nullable: false),
                    DescricaoFaixa = table.Column<string>(type: "text", nullable: false),
                    NumeroDeGanhadores = table.Column<int>(type: "integer", nullable: false),
                    ValorPremio = table.Column<decimal>(type: "numeric", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rateios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rateios_Concursos_ConcursoId",
                        column: x => x.ConcursoId,
                        principalSchema: "loto_facil",
                        principalTable: "Concursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concursos_Numero",
                schema: "loto_facil",
                table: "Concursos",
                column: "Numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dezenas_ConcursoId",
                schema: "loto_facil",
                table: "Dezenas",
                column: "ConcursoId");

            migrationBuilder.CreateIndex(
                name: "IX_GanhadoresUF_ConcursoId",
                schema: "loto_facil",
                table: "GanhadoresUF",
                column: "ConcursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Rateios_ConcursoId",
                schema: "loto_facil",
                table: "Rateios",
                column: "ConcursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dezenas",
                schema: "loto_facil");

            migrationBuilder.DropTable(
                name: "GanhadoresUF",
                schema: "loto_facil");

            migrationBuilder.DropTable(
                name: "Rateios",
                schema: "loto_facil");

            migrationBuilder.DropTable(
                name: "Concursos",
                schema: "loto_facil");
        }
    }
}
