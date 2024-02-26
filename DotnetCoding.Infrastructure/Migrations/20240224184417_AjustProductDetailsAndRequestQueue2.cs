using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetCoding.Infrastructure.Migrations
{
    public partial class AjustProductDetailsAndRequestQueue2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductStatus",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "PreviousPrice",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousPrice",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductStatus",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
