using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empleado_rol_IdRolFk",
                table: "empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_empleado_IdEmpleadoFk",
                table: "RefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_rol_empleado_EmpleadoId",
                table: "rol");

            migrationBuilder.DropIndex(
                name: "IX_rol_EmpleadoId",
                table: "rol");

            migrationBuilder.DropIndex(
                name: "IX_empleado_IdRolFk",
                table: "empleado");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "rol");

            migrationBuilder.RenameColumn(
                name: "IdEmpleadoFk",
                table: "RefreshToken",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_IdEmpleadoFk",
                table: "RefreshToken",
                newName: "IX_RefreshToken_UserId");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "RefreshToken",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "empleado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userRol",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRol", x => new { x.UsuarioId, x.RolId });
                    table.ForeignKey(
                        name: "FK_userRol_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRol_user_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_EmpleadoId",
                table: "RefreshToken",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_RolId",
                table: "empleado",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_userRol_RolId",
                table: "userRol",
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

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_user_UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empleado_rol_RolId",
                table: "empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_empleado_EmpleadoId",
                table: "RefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_user_UserId",
                table: "RefreshToken");

            migrationBuilder.DropTable(
                name: "userRol");

            migrationBuilder.DropTable(
                name: "user");

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
                name: "RolId",
                table: "empleado");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RefreshToken",
                newName: "IdEmpleadoFk");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                newName: "IX_RefreshToken_IdEmpleadoFk");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "rol",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_rol_EmpleadoId",
                table: "rol",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_IdRolFk",
                table: "empleado",
                column: "IdRolFk");

            migrationBuilder.AddForeignKey(
                name: "FK_empleado_rol_IdRolFk",
                table: "empleado",
                column: "IdRolFk",
                principalTable: "rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_empleado_IdEmpleadoFk",
                table: "RefreshToken",
                column: "IdEmpleadoFk",
                principalTable: "empleado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rol_empleado_EmpleadoId",
                table: "rol",
                column: "EmpleadoId",
                principalTable: "empleado",
                principalColumn: "Id");
        }
    }
}
