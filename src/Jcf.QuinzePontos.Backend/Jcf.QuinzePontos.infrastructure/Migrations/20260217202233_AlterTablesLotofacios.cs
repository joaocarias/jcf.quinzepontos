using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jcf.QuinzePontos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTablesLotofacios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dezenas_Concursos_ConcursoId",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropForeignKey(
                name: "FK_GanhadoresUF_Concursos_ConcursoId",
                schema: "loto_facil",
                table: "GanhadoresUF");

            migrationBuilder.DropForeignKey(
                name: "FK_Rateios_Concursos_ConcursoId",
                schema: "loto_facil",
                table: "Rateios");

            migrationBuilder.DropIndex(
                name: "IX_Rateios_ConcursoId",
                schema: "loto_facil",
                table: "Rateios");

            migrationBuilder.DropIndex(
                name: "IX_GanhadoresUF_ConcursoId",
                schema: "loto_facil",
                table: "GanhadoresUF");

            migrationBuilder.DropIndex(
                name: "IX_Dezenas_ConcursoId",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "ConcursoId",
                schema: "loto_facil",
                table: "Rateios");

            migrationBuilder.DropColumn(
                name: "ConcursoId",
                schema: "loto_facil",
                table: "GanhadoresUF");

            migrationBuilder.DropColumn(
                name: "ConcursoId",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPremio",
                schema: "loto_facil",
                table: "Rateios",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroDeGanhadores",
                schema: "loto_facil",
                table: "Rateios",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Faixa",
                schema: "loto_facil",
                table: "Rateios",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoFaixa",
                schema: "loto_facil",
                table: "Rateios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "LotofacilConcursoId",
                schema: "loto_facil",
                table: "Rateios",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                schema: "loto_facil",
                table: "GanhadoresUF",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Municipio",
                schema: "loto_facil",
                table: "GanhadoresUF",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Ganhadores",
                schema: "loto_facil",
                table: "GanhadoresUF",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<long>(
                name: "LotofacilConcursoId",
                schema: "loto_facil",
                table: "GanhadoresUF",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LotofacilConcursoId",
                schema: "loto_facil",
                table: "Dezenas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorEstimadoProximoConcurso",
                schema: "loto_facil",
                table: "Concursos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorArrecadado",
                schema: "loto_facil",
                table: "Concursos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorAcumuladoProximoConcurso",
                schema: "loto_facil",
                table: "Concursos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorAcumuladoConcursoEspecial",
                schema: "loto_facil",
                table: "Concursos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<bool>(
                name: "UltimoConcurso",
                schema: "loto_facil",
                table: "Concursos",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                schema: "loto_facil",
                table: "Concursos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NomeMunicipioUFSorteio",
                schema: "loto_facil",
                table: "Concursos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LocalSorteio",
                schema: "loto_facil",
                table: "Concursos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataProximoConcurso",
                schema: "loto_facil",
                table: "Concursos",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<bool>(
                name: "Acumulado",
                schema: "loto_facil",
                table: "Concursos",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.CreateIndex(
                name: "IX_Rateios_LotofacilConcursoId",
                schema: "loto_facil",
                table: "Rateios",
                column: "LotofacilConcursoId");

            migrationBuilder.CreateIndex(
                name: "IX_GanhadoresUF_LotofacilConcursoId",
                schema: "loto_facil",
                table: "GanhadoresUF",
                column: "LotofacilConcursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dezenas_LotofacilConcursoId",
                schema: "loto_facil",
                table: "Dezenas",
                column: "LotofacilConcursoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dezenas_Concursos_LotofacilConcursoId",
                schema: "loto_facil",
                table: "Dezenas",
                column: "LotofacilConcursoId",
                principalSchema: "loto_facil",
                principalTable: "Concursos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GanhadoresUF_Concursos_LotofacilConcursoId",
                schema: "loto_facil",
                table: "GanhadoresUF",
                column: "LotofacilConcursoId",
                principalSchema: "loto_facil",
                principalTable: "Concursos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rateios_Concursos_LotofacilConcursoId",
                schema: "loto_facil",
                table: "Rateios",
                column: "LotofacilConcursoId",
                principalSchema: "loto_facil",
                principalTable: "Concursos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dezenas_Concursos_LotofacilConcursoId",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropForeignKey(
                name: "FK_GanhadoresUF_Concursos_LotofacilConcursoId",
                schema: "loto_facil",
                table: "GanhadoresUF");

            migrationBuilder.DropForeignKey(
                name: "FK_Rateios_Concursos_LotofacilConcursoId",
                schema: "loto_facil",
                table: "Rateios");

            migrationBuilder.DropIndex(
                name: "IX_Rateios_LotofacilConcursoId",
                schema: "loto_facil",
                table: "Rateios");

            migrationBuilder.DropIndex(
                name: "IX_GanhadoresUF_LotofacilConcursoId",
                schema: "loto_facil",
                table: "GanhadoresUF");

            migrationBuilder.DropIndex(
                name: "IX_Dezenas_LotofacilConcursoId",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.DropColumn(
                name: "LotofacilConcursoId",
                schema: "loto_facil",
                table: "Rateios");

            migrationBuilder.DropColumn(
                name: "LotofacilConcursoId",
                schema: "loto_facil",
                table: "GanhadoresUF");

            migrationBuilder.DropColumn(
                name: "LotofacilConcursoId",
                schema: "loto_facil",
                table: "Dezenas");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPremio",
                schema: "loto_facil",
                table: "Rateios",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumeroDeGanhadores",
                schema: "loto_facil",
                table: "Rateios",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Faixa",
                schema: "loto_facil",
                table: "Rateios",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoFaixa",
                schema: "loto_facil",
                table: "Rateios",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ConcursoId",
                schema: "loto_facil",
                table: "Rateios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                schema: "loto_facil",
                table: "GanhadoresUF",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Municipio",
                schema: "loto_facil",
                table: "GanhadoresUF",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Ganhadores",
                schema: "loto_facil",
                table: "GanhadoresUF",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ConcursoId",
                schema: "loto_facil",
                table: "GanhadoresUF",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ConcursoId",
                schema: "loto_facil",
                table: "Dezenas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorEstimadoProximoConcurso",
                schema: "loto_facil",
                table: "Concursos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorArrecadado",
                schema: "loto_facil",
                table: "Concursos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorAcumuladoProximoConcurso",
                schema: "loto_facil",
                table: "Concursos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorAcumuladoConcursoEspecial",
                schema: "loto_facil",
                table: "Concursos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "UltimoConcurso",
                schema: "loto_facil",
                table: "Concursos",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                schema: "loto_facil",
                table: "Concursos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeMunicipioUFSorteio",
                schema: "loto_facil",
                table: "Concursos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LocalSorteio",
                schema: "loto_facil",
                table: "Concursos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataProximoConcurso",
                schema: "loto_facil",
                table: "Concursos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Acumulado",
                schema: "loto_facil",
                table: "Concursos",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rateios_ConcursoId",
                schema: "loto_facil",
                table: "Rateios",
                column: "ConcursoId");

            migrationBuilder.CreateIndex(
                name: "IX_GanhadoresUF_ConcursoId",
                schema: "loto_facil",
                table: "GanhadoresUF",
                column: "ConcursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dezenas_ConcursoId",
                schema: "loto_facil",
                table: "Dezenas",
                column: "ConcursoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dezenas_Concursos_ConcursoId",
                schema: "loto_facil",
                table: "Dezenas",
                column: "ConcursoId",
                principalSchema: "loto_facil",
                principalTable: "Concursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GanhadoresUF_Concursos_ConcursoId",
                schema: "loto_facil",
                table: "GanhadoresUF",
                column: "ConcursoId",
                principalSchema: "loto_facil",
                principalTable: "Concursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rateios_Concursos_ConcursoId",
                schema: "loto_facil",
                table: "Rateios",
                column: "ConcursoId",
                principalSchema: "loto_facil",
                principalTable: "Concursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
