using Microsoft.EntityFrameworkCore.Migrations;

namespace prueba.Migrations
{
    public partial class ventasupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cliente",
                table: "ventas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cliente",
                table: "ventas");
        }
    }
}
