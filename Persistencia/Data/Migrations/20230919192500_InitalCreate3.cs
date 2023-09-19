using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cargo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaContratacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "long", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paciente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contacto = table.Column<string>(type: "long", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaVenta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdPacienteFk = table.Column<int>(type: "int", nullable: false),
                    IdEmpleadoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_venta_empleado_IdEmpleadoFk",
                        column: x => x.IdEmpleadoFk,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_venta_paciente_IdPacienteFk",
                        column: x => x.IdPacienteFk,
                        principalTable: "paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCompra = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdProveedorFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_compra_proveedor_IdProveedorFk",
                        column: x => x.IdProveedorFk,
                        principalTable: "proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<double>(type: "double", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdProveedorFk = table.Column<int>(type: "int", nullable: false),
                    MedicamentoCompradoId = table.Column<int>(type: "int", nullable: true),
                    MedicamentoVendidoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamento_proveedor_IdProveedorFk",
                        column: x => x.IdProveedorFk,
                        principalTable: "proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamentosComprados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCompraFk = table.Column<int>(type: "int", nullable: false),
                    IdMedicamentoFk = table.Column<int>(type: "int", nullable: false),
                    CantidadComprada = table.Column<int>(type: "long", nullable: false),
                    PrecioCompra = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamentosComprados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamentosComprados_compra_IdCompraFk",
                        column: x => x.IdCompraFk,
                        principalTable: "compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicamentosComprados_medicamento_IdMedicamentoFk",
                        column: x => x.IdMedicamentoFk,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamentosVendidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdVentaFk = table.Column<int>(type: "int", nullable: false),
                    IdMedicamentoFk = table.Column<int>(type: "int", nullable: false),
                    CantidadVendida = table.Column<int>(type: "long", nullable: false),
                    Precio = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamentosVendidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamentosVendidos_medicamento_IdMedicamentoFk",
                        column: x => x.IdMedicamentoFk,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicamentosVendidos_venta_IdVentaFk",
                        column: x => x.IdVentaFk,
                        principalTable: "venta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_compra_IdProveedorFk",
                table: "compra",
                column: "IdProveedorFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_IdProveedorFk",
                table: "medicamento",
                column: "IdProveedorFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_MedicamentoCompradoId",
                table: "medicamento",
                column: "MedicamentoCompradoId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_MedicamentoVendidoId",
                table: "medicamento",
                column: "MedicamentoVendidoId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentosComprados_IdCompraFk",
                table: "medicamentosComprados",
                column: "IdCompraFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentosComprados_IdMedicamentoFk",
                table: "medicamentosComprados",
                column: "IdMedicamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentosVendidos_IdMedicamentoFk",
                table: "medicamentosVendidos",
                column: "IdMedicamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentosVendidos_IdVentaFk",
                table: "medicamentosVendidos",
                column: "IdVentaFk");

            migrationBuilder.CreateIndex(
                name: "IX_venta_IdEmpleadoFk",
                table: "venta",
                column: "IdEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_venta_IdPacienteFk",
                table: "venta",
                column: "IdPacienteFk");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compra_proveedor_IdProveedorFk",
                table: "compra");

            migrationBuilder.DropForeignKey(
                name: "FK_medicamento_proveedor_IdProveedorFk",
                table: "medicamento");

            migrationBuilder.DropForeignKey(
                name: "FK_medicamento_medicamentosComprados_MedicamentoCompradoId",
                table: "medicamento");

            migrationBuilder.DropForeignKey(
                name: "FK_medicamento_medicamentosVendidos_MedicamentoVendidoId",
                table: "medicamento");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "medicamentosComprados");

            migrationBuilder.DropTable(
                name: "compra");

            migrationBuilder.DropTable(
                name: "medicamentosVendidos");

            migrationBuilder.DropTable(
                name: "medicamento");

            migrationBuilder.DropTable(
                name: "venta");

            migrationBuilder.DropTable(
                name: "empleado");

            migrationBuilder.DropTable(
                name: "paciente");
        }
    }
}
