using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.API.Migrations
{
    public partial class fulluser26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
