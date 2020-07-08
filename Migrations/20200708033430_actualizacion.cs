using Microsoft.EntityFrameworkCore.Migrations;

namespace prueba.Migrations
{
    public partial class actualizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productos_categorias_categoriasId",
                table: "productos");

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

            migrationBuilder.DropIndex(
                name: "IX_productos_categoriasId",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "productosId",
                table: "ventasdetalles");

            migrationBuilder.DropColumn(
                name: "ventasId",
                table: "ventasdetalles");

            migrationBuilder.DropColumn(
                name: "tiendasId",
                table: "ventas");

            migrationBuilder.DropColumn(
                name: "categoriasId",
                table: "productos");

            migrationBuilder.AddColumn<decimal>(
                name: "precio",
                table: "ventasdetalles",
                type: "decimal(30, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "precio",
                table: "ventasdetalles");

            migrationBuilder.AddColumn<int>(
                name: "productosId",
                table: "ventasdetalles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ventasId",
                table: "ventasdetalles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tiendasId",
                table: "ventas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "categoriasId",
                table: "productos",
                type: "int",
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

            migrationBuilder.CreateIndex(
                name: "IX_productos_categoriasId",
                table: "productos",
                column: "categoriasId");

            migrationBuilder.AddForeignKey(
                name: "FK_productos_categorias_categoriasId",
                table: "productos",
                column: "categoriasId",
                principalTable: "categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
