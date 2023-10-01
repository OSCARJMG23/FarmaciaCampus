using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMig005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_paciente_IdPacienteFk",
                table: "movimientoInventario");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalGastado",
                table: "paciente",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "IdPacienteFk",
                table: "movimientoInventario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_paciente_IdPacienteFk",
                table: "movimientoInventario",
                column: "IdPacienteFk",
                principalTable: "paciente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_paciente_IdPacienteFk",
                table: "movimientoInventario");

            migrationBuilder.DropColumn(
                name: "TotalGastado",
                table: "paciente");

            migrationBuilder.AlterColumn<int>(
                name: "IdPacienteFk",
                table: "movimientoInventario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_paciente_IdPacienteFk",
                table: "movimientoInventario",
                column: "IdPacienteFk",
                principalTable: "paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
