using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.WebApi.Migrations
{
    public partial class makeprojectidforeing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Files_ProjectName_CreatedBy_Path",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Collaborators");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Files",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Collaborators",
                newName: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CreatedBy_Path",
                table: "Files",
                columns: new[] { "CreatedBy", "Path" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Files_CreatedBy_Path",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Files",
                newName: "ProjectName");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Collaborators",
                newName: "ProjectName");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Collaborators",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_ProjectName_CreatedBy_Path",
                table: "Files",
                columns: new[] { "ProjectName", "CreatedBy", "Path" },
                unique: true);
        }
    }
}
