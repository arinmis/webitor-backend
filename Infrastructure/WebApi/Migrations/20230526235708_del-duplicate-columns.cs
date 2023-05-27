using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.WebApi.Migrations
{
    public partial class delduplicatecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Files");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Files",
                type: "text",
                nullable: true);
        }
    }
}
