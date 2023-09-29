using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProveedorFk",
                table: "movimientoInventario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_IdProveedorFk",
                table: "movimientoInventario",
                column: "IdProveedorFk");

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_proveedor_IdProveedorFk",
                table: "movimientoInventario",
                column: "IdProveedorFk",
                principalTable: "proveedor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_proveedor_IdProveedorFk",
                table: "movimientoInventario");

            migrationBuilder.DropIndex(
                name: "IX_movimientoInventario_IdProveedorFk",
                table: "movimientoInventario");

            migrationBuilder.DropColumn(
                name: "IdProveedorFk",
                table: "movimientoInventario");
        }
    }
}
