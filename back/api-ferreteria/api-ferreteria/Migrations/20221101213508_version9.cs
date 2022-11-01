using Microsoft.EntityFrameworkCore.Migrations;

namespace api_ferreteria.Migrations
{
    public partial class version9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "importe",
                table: "Detalle",
                type: "decimal(20,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "subtotal",
                table: "Comprobante",
                type: "decimal(20,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "total",
                table: "Comprobante",
                type: "decimal(20,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "importe",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "subtotal",
                table: "Comprobante");

            migrationBuilder.DropColumn(
                name: "total",
                table: "Comprobante");
        }
    }
}
