using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace decentraMed.Migrations
{
    public partial class idNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "idNumber",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idNumber",
                table: "User");
        }
    }
}
