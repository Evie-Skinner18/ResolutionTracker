using Microsoft.EntityFrameworkCore.Migrations;

namespace ResolutionTracker.Migrations
{
    public partial class ResolutionIsCompleteProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Resolutions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Resolutions");
        }
    }
}
