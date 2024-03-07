using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetCoding.Infrastructure.Migrations
{
    public partial class UpdateRequestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "Requests",
                newName: "DetailsId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Products_DetailsId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_DetailsId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "DetailsId",
                table: "Requests",
                newName: "ProductPrice");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
