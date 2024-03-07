using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetCoding.Infrastructure.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Products_DetailsId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_DetailsId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DetailsId",
                table: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "NewProductDescription",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewProductName",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewProductPrice",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Requests",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewProductDescription",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "NewProductName",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "NewProductPrice",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "DetailsId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DetailsId",
                table: "Requests",
                column: "DetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Products_DetailsId",
                table: "Requests",
                column: "DetailsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
