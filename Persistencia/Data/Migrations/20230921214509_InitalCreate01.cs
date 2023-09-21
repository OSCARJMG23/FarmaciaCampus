using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicamentosComprados");

            migrationBuilder.DropTable(
                name: "medicamentosVendidos");

            migrationBuilder.DropTable(
                name: "compra");

            migrationBuilder.DropTable(
                name: "venta");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "proveedor");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "paciente");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "medicamento",
                newName: "IdPresentacionFk");

            migrationBuilder.AddColumn<int>(
                name: "IdDireccionFk",
                table: "proveedor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDireccionFk",
                table: "paciente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdInventarioFk",
                table: "medicamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMarcaFk",
                table: "medicamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "formaPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formaPago", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "presentacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_presentacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "receta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicoRemitente = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPacienteFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_receta_paciente_IdPacienteFk",
                        column: x => x.IdPacienteFk,
                        principalTable: "paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoMovimiento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "factura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalPagar = table.Column<double>(type: "double", nullable: false),
                    IdFormaDePagoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_factura_formaPago_IdFormaDePagoFk",
                        column: x => x.IdFormaDePagoFk,
                        principalTable: "formaPago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPaisFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departamento_pais_IdPaisFk",
                        column: x => x.IdPaisFk,
                        principalTable: "pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movimientoInventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEmpleadoFk = table.Column<int>(type: "int", nullable: false),
                    IdPacienteFk = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdTipoMovimientoFk = table.Column<int>(type: "int", nullable: false),
                    IdFacturaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientoInventario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movimientoInventario_empleado_IdEmpleadoFk",
                        column: x => x.IdEmpleadoFk,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movimientoInventario_factura_IdFacturaFk",
                        column: x => x.IdFacturaFk,
                        principalTable: "factura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movimientoInventario_paciente_IdPacienteFk",
                        column: x => x.IdPacienteFk,
                        principalTable: "paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movimientoInventario_tipoMovimiento_IdTipoMovimientoFk",
                        column: x => x.IdTipoMovimientoFk,
                        principalTable: "tipoMovimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDepartamentoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ciudad_departamento_IdDepartamentoFk",
                        column: x => x.IdDepartamentoFk,
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoViaPrincipal = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroViaPrincipal = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    NumeroViaSecundaria = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Barrio = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCiudadFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_direccion_ciudad_IdCiudadFk",
                        column: x => x.IdCiudadFk,
                        principalTable: "ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_IdDireccionFk",
                table: "proveedor",
                column: "IdDireccionFk");

            migrationBuilder.CreateIndex(
                name: "IX_paciente_IdDireccionFk",
                table: "paciente",
                column: "IdDireccionFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_IdInventarioFk",
                table: "medicamento",
                column: "IdInventarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_IdMarcaFk",
                table: "medicamento",
                column: "IdMarcaFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_IdPresentacionFk",
                table: "medicamento",
                column: "IdPresentacionFk");

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_IdDepartamentoFk",
                table: "ciudad",
                column: "IdDepartamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_IdPaisFk",
                table: "departamento",
                column: "IdPaisFk");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_IdCiudadFk",
                table: "direccion",
                column: "IdCiudadFk");

            migrationBuilder.CreateIndex(
                name: "IX_factura_IdFormaDePagoFk",
                table: "factura",
                column: "IdFormaDePagoFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_IdEmpleadoFk",
                table: "movimientoInventario",
                column: "IdEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_IdFacturaFk",
                table: "movimientoInventario",
                column: "IdFacturaFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_IdPacienteFk",
                table: "movimientoInventario",
                column: "IdPacienteFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_IdTipoMovimientoFk",
                table: "movimientoInventario",
                column: "IdTipoMovimientoFk");

            migrationBuilder.CreateIndex(
                name: "IX_receta_IdPacienteFk",
                table: "receta",
                column: "IdPacienteFk");

            migrationBuilder.AddForeignKey(
                name: "FK_medicamento_inventario_IdInventarioFk",
                table: "medicamento",
                column: "IdInventarioFk",
                principalTable: "inventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicamento_marca_IdMarcaFk",
                table: "medicamento",
                column: "IdMarcaFk",
                principalTable: "marca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicamento_presentacion_IdPresentacionFk",
                table: "medicamento",
                column: "IdPresentacionFk",
                principalTable: "presentacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_paciente_direccion_IdDireccionFk",
                table: "paciente",
                column: "IdDireccionFk",
                principalTable: "direccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_proveedor_direccion_IdDireccionFk",
                table: "proveedor",
                column: "IdDireccionFk",
                principalTable: "direccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicamento_inventario_IdInventarioFk",
                table: "medicamento");

            migrationBuilder.DropForeignKey(
                name: "FK_medicamento_marca_IdMarcaFk",
                table: "medicamento");

            migrationBuilder.DropForeignKey(
                name: "FK_medicamento_presentacion_IdPresentacionFk",
                table: "medicamento");

            migrationBuilder.DropForeignKey(
                name: "FK_paciente_direccion_IdDireccionFk",
                table: "paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_proveedor_direccion_IdDireccionFk",
                table: "proveedor");

            migrationBuilder.DropTable(
                name: "direccion");

            migrationBuilder.DropTable(
                name: "inventario");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "movimientoInventario");

            migrationBuilder.DropTable(
                name: "presentacion");

            migrationBuilder.DropTable(
                name: "receta");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "factura");

            migrationBuilder.DropTable(
                name: "tipoMovimiento");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "formaPago");

            migrationBuilder.DropTable(
                name: "pais");

            migrationBuilder.DropIndex(
                name: "IX_proveedor_IdDireccionFk",
                table: "proveedor");

            migrationBuilder.DropIndex(
                name: "IX_paciente_IdDireccionFk",
                table: "paciente");

            migrationBuilder.DropIndex(
                name: "IX_medicamento_IdInventarioFk",
                table: "medicamento");

            migrationBuilder.DropIndex(
                name: "IX_medicamento_IdMarcaFk",
                table: "medicamento");

            migrationBuilder.DropIndex(
                name: "IX_medicamento_IdPresentacionFk",
                table: "medicamento");

            migrationBuilder.DropColumn(
                name: "IdDireccionFk",
                table: "proveedor");

            migrationBuilder.DropColumn(
                name: "IdDireccionFk",
                table: "paciente");

            migrationBuilder.DropColumn(
                name: "IdInventarioFk",
                table: "medicamento");

            migrationBuilder.DropColumn(
                name: "IdMarcaFk",
                table: "medicamento");

            migrationBuilder.RenameColumn(
                name: "IdPresentacionFk",
                table: "medicamento",
                newName: "Stock");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "proveedor",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "paciente",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProveedorFk = table.Column<int>(type: "int", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                name: "venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEmpleadoFk = table.Column<int>(type: "int", nullable: false),
                    IdPacienteFk = table.Column<int>(type: "int", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                name: "medicamentosComprados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompraId = table.Column<int>(type: "int", nullable: true),
                    IdMedicamentoFk = table.Column<int>(type: "int", nullable: false),
                    CantidadComprada = table.Column<int>(type: "int", nullable: false),
                    IdCompraFk = table.Column<int>(type: "int", nullable: false),
                    PrecioCompra = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamentosComprados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamentosComprados_compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "compra",
                        principalColumn: "Id");
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
                    IdMedicamentoFk = table.Column<int>(type: "int", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: true),
                    CantidadVendida = table.Column<int>(type: "int", nullable: false),
                    IdVentaFk = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_medicamentosVendidos_venta_VentaId",
                        column: x => x.VentaId,
                        principalTable: "venta",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_compra_IdProveedorFk",
                table: "compra",
                column: "IdProveedorFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentosComprados_CompraId",
                table: "medicamentosComprados",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentosComprados_IdMedicamentoFk",
                table: "medicamentosComprados",
                column: "IdMedicamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentosVendidos_IdMedicamentoFk",
                table: "medicamentosVendidos",
                column: "IdMedicamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentosVendidos_VentaId",
                table: "medicamentosVendidos",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_venta_IdEmpleadoFk",
                table: "venta",
                column: "IdEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_venta_IdPacienteFk",
                table: "venta",
                column: "IdPacienteFk");
        }
    }
}
