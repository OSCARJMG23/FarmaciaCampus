using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empleado_rol_RolId",
                table: "empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_empleado_EmpleadoId",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_EmpleadoId",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_empleado_RolId",
                table: "empleado");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "IdRolFk",
                table: "empleado");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "empleado");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "empleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "RefreshToken",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdRolFk",
                table: "empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "empleado",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "empleado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_EmpleadoId",
                table: "RefreshToken",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_RolId",
                table: "empleado",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_empleado_rol_RolId",
                table: "empleado",
                column: "RolId",
                principalTable: "rol",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_empleado_EmpleadoId",
                table: "RefreshToken",
                column: "EmpleadoId",
                principalTable: "empleado",
                principalColumn: "Id");
        }
    }
}
