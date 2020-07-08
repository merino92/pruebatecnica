using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace prueba.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ventasdetalles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(30, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventasdetalles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    existencia = table.Column<int>(nullable: false),
                    precio = table.Column<decimal>(type: "decimal(30, 2)", nullable: false),
                    categoriaid = table.Column<int>(nullable: false),
                    categoriasId = table.Column<int>(nullable: true),
                    VentasdetalleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productos_ventasdetalles_VentasdetalleId",
                        column: x => x.VentasdetalleId,
                        principalTable: "ventasdetalles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productos_categorias_categoriasId",
                        column: x => x.categoriasId,
                        principalTable: "categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(nullable: false),
                    total = table.Column<decimal>(type: "decimal(30, 2)", nullable: false),
                    VentasdetalleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ventas_ventasdetalles_VentasdetalleId",
                        column: x => x.VentasdetalleId,
                        principalTable: "ventasdetalles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tiendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    VentasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tiendas_ventas_VentasId",
                        column: x => x.VentasId,
                        principalTable: "ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productos_VentasdetalleId",
                table: "productos",
                column: "VentasdetalleId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_categoriasId",
                table: "productos",
                column: "categoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_tiendas_VentasId",
                table: "tiendas",
                column: "VentasId");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_VentasdetalleId",
                table: "ventas",
                column: "VentasdetalleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "tiendas");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "ventasdetalles");
        }
    }
}
