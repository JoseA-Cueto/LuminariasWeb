using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuminariasWeb.sln.Migrations
{
    public partial class AddCantidadToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Products",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Products");
        }
    }
}
