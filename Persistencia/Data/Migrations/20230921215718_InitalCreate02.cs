using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdInventarioFk",
                table: "movimientoInventario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_IdInventarioFk",
                table: "movimientoInventario",
                column: "IdInventarioFk");

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_inventario_IdInventarioFk",
                table: "movimientoInventario",
                column: "IdInventarioFk",
                principalTable: "inventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_inventario_IdInventarioFk",
                table: "movimientoInventario");

            migrationBuilder.DropIndex(
                name: "IX_movimientoInventario_IdInventarioFk",
                table: "movimientoInventario");

            migrationBuilder.DropColumn(
                name: "IdInventarioFk",
                table: "movimientoInventario");
        }
    }
}
