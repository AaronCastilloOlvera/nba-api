using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nba_api.Migrations
{
    public partial class AddColumnPrincipalColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrincipalColor",
                table: "Team",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrincipalColor",
                table: "Team");
        }
    }
}
