using Microsoft.EntityFrameworkCore.Migrations;

namespace VoteCalc.Migrations
{
    public partial class AddValidVoteToVoteEnity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ValidVote",
                table: "Vote",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidVote",
                table: "Vote");
        }
    }
}
