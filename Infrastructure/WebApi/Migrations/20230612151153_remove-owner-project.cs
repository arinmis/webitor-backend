using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.WebApi.Migrations
{
    public partial class removeownerproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Projects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Projects",
                type: "text",
                nullable: true);
        }
    }
}
