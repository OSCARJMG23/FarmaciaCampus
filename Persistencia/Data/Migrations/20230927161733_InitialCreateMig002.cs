using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMig002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_paciente_PacienteId",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_PacienteId",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "RefreshToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "RefreshToken",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_PacienteId",
                table: "RefreshToken",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_paciente_PacienteId",
                table: "RefreshToken",
                column: "PacienteId",
                principalTable: "paciente",
                principalColumn: "Id");
        }
    }
}
