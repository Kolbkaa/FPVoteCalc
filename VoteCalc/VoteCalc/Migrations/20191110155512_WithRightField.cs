using Microsoft.EntityFrameworkCore.Migrations;

namespace VoteCalc.Migrations
{
    public partial class WithRightField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "WithoutRight",
                table: "Vote",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WithoutRight",
                table: "Vote");
        }
    }
}
