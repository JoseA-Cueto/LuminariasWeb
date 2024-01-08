using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuminariasWeb.sln.Migrations
{
    public partial class AddCantidadToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Products",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "Cantidad");
        }
    }
}
