using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicamentosComprados_compra_IdCompraFk",
                table: "medicamentosComprados");

            migrationBuilder.DropForeignKey(
                name: "FK_medicamentosVendidos_venta_IdVentaFk",
                table: "medicamentosVendidos");

            migrationBuilder.DropIndex(
                name: "IX_medicamentosVendidos_IdVentaFk",
                table: "medicamentosVendidos");

            migrationBuilder.DropIndex(
                name: "IX_medicamentosComprados_IdCompraFk",
                table: "medicamentosComprados");

            migrationBuilder.AddColumn<int>(
                name: "VentaId",
                table: "medicamentosVendidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "medicamentosComprados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_medicamentosVendidos_VentaId",
                table: "medicamentosVendidos",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentosComprados_CompraId",
                table: "medicamentosComprados",
                column: "CompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_medicamentosComprados_compra_CompraId",
                table: "medicamentosComprados",
                column: "CompraId",
                principalTable: "compra",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_medicamentosVendidos_venta_VentaId",
                table: "medicamentosVendidos",
                column: "VentaId",
                principalTable: "venta",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicamentosComprados_compra_CompraId",
                table: "medicamentosComprados");

            migrationBuilder.DropForeignKey(
                name: "FK_medicamentosVendidos_venta_VentaId",
                table: "medicamentosVendidos");

            migrationBuilder.DropIndex(
                name: "IX_medicamentosVendidos_VentaId",
                table: "medicamentosVendidos");

            migrationBuilder.DropIndex(
                name: "IX_medicamentosComprados_CompraId",
                table: "medicamentosComprados");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "medicamentosVendidos");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "medicamentosComprados");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentosVendidos_IdVentaFk",
                table: "medicamentosVendidos",
                column: "IdVentaFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentosComprados_IdCompraFk",
                table: "medicamentosComprados",
                column: "IdCompraFk");

            migrationBuilder.AddForeignKey(
                name: "FK_medicamentosComprados_compra_IdCompraFk",
                table: "medicamentosComprados",
                column: "IdCompraFk",
                principalTable: "compra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicamentosVendidos_venta_IdVentaFk",
                table: "medicamentosVendidos",
                column: "IdVentaFk",
                principalTable: "venta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
