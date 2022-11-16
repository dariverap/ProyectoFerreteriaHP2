using Microsoft.EntityFrameworkCore.Migrations;

namespace api_ferreteria.Migrations
{
    public partial class inicialv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "stock",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stock",
                table: "Producto");
        }
    }
}
