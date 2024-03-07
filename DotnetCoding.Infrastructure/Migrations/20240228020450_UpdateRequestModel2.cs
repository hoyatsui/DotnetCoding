using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetCoding.Infrastructure.Migrations
{
    public partial class UpdateRequestModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousPrice",
                table: "Requests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreviousPrice",
                table: "Requests",
                type: "int",
                nullable: true);
        }
    }
}
