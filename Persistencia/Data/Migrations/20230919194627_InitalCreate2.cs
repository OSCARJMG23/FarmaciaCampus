using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicamento_medicamentosComprados_MedicamentoCompradoId",
                table: "medicamento");

            migrationBuilder.DropForeignKey(
                name: "FK_medicamento_medicamentosVendidos_MedicamentoVendidoId",
                table: "medicamento");

            migrationBuilder.DropIndex(
                name: "IX_medicamento_MedicamentoCompradoId",
                table: "medicamento");

            migrationBuilder.DropIndex(
                name: "IX_medicamento_MedicamentoVendidoId",
                table: "medicamento");

            migrationBuilder.DropColumn(
                name: "MedicamentoCompradoId",
                table: "medicamento");

            migrationBuilder.DropColumn(
                name: "MedicamentoVendidoId",
                table: "medicamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicamentoCompradoId",
                table: "medicamento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicamentoVendidoId",
                table: "medicamento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_MedicamentoCompradoId",
                table: "medicamento",
                column: "MedicamentoCompradoId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_MedicamentoVendidoId",
                table: "medicamento",
                column: "MedicamentoVendidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_medicamento_medicamentosComprados_MedicamentoCompradoId",
                table: "medicamento",
                column: "MedicamentoCompradoId",
                principalTable: "medicamentosComprados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_medicamento_medicamentosVendidos_MedicamentoVendidoId",
                table: "medicamento",
                column: "MedicamentoVendidoId",
                principalTable: "medicamentosVendidos",
                principalColumn: "Id");
        }
    }
}
