using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate333 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDireccionFk = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_paciente_direccion_IdDireccionFk",
                        column: x => x.IdDireccionFk,
                        principalTable: "direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Contacto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDireccionFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proveedor_direccion_IdDireccionFk",
                        column: x => x.IdDireccionFk,
                        principalTable: "direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
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
                name: "medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<double>(type: "double", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdProveedorFk = table.Column<int>(type: "int", nullable: false),
                    IdPresentacionFk = table.Column<int>(type: "int", nullable: false),
                    IdMarcaFk = table.Column<int>(type: "int", nullable: false),
                    IdInventarioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamento_inventario_IdInventarioFk",
                        column: x => x.IdInventarioFk,
                        principalTable: "inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicamento_marca_IdMarcaFk",
                        column: x => x.IdMarcaFk,
                        principalTable: "marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicamento_presentacion_IdPresentacionFk",
                        column: x => x.IdPresentacionFk,
                        principalTable: "presentacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicamento_proveedor_IdProveedorFk",
                        column: x => x.IdProveedorFk,
                        principalTable: "proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
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
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaContratacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdRolFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado", x => x.Id);
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
                    Cantidad = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Precio = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdTipoMovimientoFk = table.Column<int>(type: "int", nullable: false),
                    IdFacturaFk = table.Column<int>(type: "int", nullable: false),
                    IdInventarioFk = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_movimientoInventario_inventario_IdInventarioFk",
                        column: x => x.IdInventarioFk,
                        principalTable: "inventario",
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
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEmpleadoFk = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_empleado_IdEmpleadoFk",
                        column: x => x.IdEmpleadoFk,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rol_empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "empleado",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "IX_empleado_IdRolFk",
                table: "empleado",
                column: "IdRolFk");

            migrationBuilder.CreateIndex(
                name: "IX_factura_IdFormaDePagoFk",
                table: "factura",
                column: "IdFormaDePagoFk");

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
                name: "IX_medicamento_IdProveedorFk",
                table: "medicamento",
                column: "IdProveedorFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_IdEmpleadoFk",
                table: "movimientoInventario",
                column: "IdEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_IdFacturaFk",
                table: "movimientoInventario",
                column: "IdFacturaFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_IdInventarioFk",
                table: "movimientoInventario",
                column: "IdInventarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_IdPacienteFk",
                table: "movimientoInventario",
                column: "IdPacienteFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_IdTipoMovimientoFk",
                table: "movimientoInventario",
                column: "IdTipoMovimientoFk");

            migrationBuilder.CreateIndex(
                name: "IX_paciente_IdDireccionFk",
                table: "paciente",
                column: "IdDireccionFk");

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_IdDireccionFk",
                table: "proveedor",
                column: "IdDireccionFk");

            migrationBuilder.CreateIndex(
                name: "IX_receta_IdPacienteFk",
                table: "receta",
                column: "IdPacienteFk");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_IdEmpleadoFk",
                table: "RefreshToken",
                column: "IdEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_rol_EmpleadoId",
                table: "rol",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_empleado_rol_IdRolFk",
                table: "empleado",
                column: "IdRolFk",
                principalTable: "rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empleado_rol_IdRolFk",
                table: "empleado");

            migrationBuilder.DropTable(
                name: "medicamento");

            migrationBuilder.DropTable(
                name: "movimientoInventario");

            migrationBuilder.DropTable(
                name: "receta");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "presentacion");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "factura");

            migrationBuilder.DropTable(
                name: "inventario");

            migrationBuilder.DropTable(
                name: "tipoMovimiento");

            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "formaPago");

            migrationBuilder.DropTable(
                name: "direccion");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "pais");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "empleado");
        }
    }
}
