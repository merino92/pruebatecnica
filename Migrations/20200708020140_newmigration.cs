using Microsoft.EntityFrameworkCore.Migrations;

namespace prueba.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productos_ventasdetalles_VentasdetalleId",
                table: "productos");

            migrationBuilder.DropForeignKey(
                name: "FK_tiendas_ventas_VentasId",
                table: "tiendas");

            migrationBuilder.DropForeignKey(
                name: "FK_ventas_ventasdetalles_VentasdetalleId",
                table: "ventas");

            migrationBuilder.DropIndex(
                name: "IX_ventas_VentasdetalleId",
                table: "ventas");

            migrationBuilder.DropIndex(
                name: "IX_tiendas_VentasId",
                table: "tiendas");

            migrationBuilder.DropIndex(
                name: "IX_productos_VentasdetalleId",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "VentasdetalleId",
                table: "ventas");

            migrationBuilder.DropColumn(
                name: "VentasId",
                table: "tiendas");

            migrationBuilder.DropColumn(
                name: "VentasdetalleId",
                table: "productos");

            migrationBuilder.AddColumn<int>(
                name: "idproducto",
                table: "ventasdetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idventa",
                table: "ventasdetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "productosId",
                table: "ventasdetalles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ventasId",
                table: "ventasdetalles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idtienda",
                table: "ventas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tiendasId",
                table: "ventas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ventasdetalles_productosId",
                table: "ventasdetalles",
                column: "productosId");

            migrationBuilder.CreateIndex(
                name: "IX_ventasdetalles_ventasId",
                table: "ventasdetalles",
                column: "ventasId");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_tiendasId",
                table: "ventas",
                column: "tiendasId");

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_tiendas_tiendasId",
                table: "ventas",
                column: "tiendasId",
                principalTable: "tiendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ventasdetalles_productos_productosId",
                table: "ventasdetalles",
                column: "productosId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ventasdetalles_ventas_ventasId",
                table: "ventasdetalles",
                column: "ventasId",
                principalTable: "ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventas_tiendas_tiendasId",
                table: "ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_ventasdetalles_productos_productosId",
                table: "ventasdetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_ventasdetalles_ventas_ventasId",
                table: "ventasdetalles");

            migrationBuilder.DropIndex(
                name: "IX_ventasdetalles_productosId",
                table: "ventasdetalles");

            migrationBuilder.DropIndex(
                name: "IX_ventasdetalles_ventasId",
                table: "ventasdetalles");

            migrationBuilder.DropIndex(
                name: "IX_ventas_tiendasId",
                table: "ventas");

            migrationBuilder.DropColumn(
                name: "idproducto",
                table: "ventasdetalles");

            migrationBuilder.DropColumn(
                name: "idventa",
                table: "ventasdetalles");

            migrationBuilder.DropColumn(
                name: "productosId",
                table: "ventasdetalles");

            migrationBuilder.DropColumn(
                name: "ventasId",
                table: "ventasdetalles");

            migrationBuilder.DropColumn(
                name: "idtienda",
                table: "ventas");

            migrationBuilder.DropColumn(
                name: "tiendasId",
                table: "ventas");

            migrationBuilder.AddColumn<int>(
                name: "VentasdetalleId",
                table: "ventas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VentasId",
                table: "tiendas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VentasdetalleId",
                table: "productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ventas_VentasdetalleId",
                table: "ventas",
                column: "VentasdetalleId");

            migrationBuilder.CreateIndex(
                name: "IX_tiendas_VentasId",
                table: "tiendas",
                column: "VentasId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_VentasdetalleId",
                table: "productos",
                column: "VentasdetalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_productos_ventasdetalles_VentasdetalleId",
                table: "productos",
                column: "VentasdetalleId",
                principalTable: "ventasdetalles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tiendas_ventas_VentasId",
                table: "tiendas",
                column: "VentasId",
                principalTable: "ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_ventasdetalles_VentasdetalleId",
                table: "ventas",
                column: "VentasdetalleId",
                principalTable: "ventasdetalles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
