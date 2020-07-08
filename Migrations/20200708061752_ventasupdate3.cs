using Microsoft.EntityFrameworkCore.Migrations;

namespace prueba.Migrations
{
    public partial class ventasupdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "borrado",
                table: "ventas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "borrado",
                table: "ventas");
        }
    }
}
