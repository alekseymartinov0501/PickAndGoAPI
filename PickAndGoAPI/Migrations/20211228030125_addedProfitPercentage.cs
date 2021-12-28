using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndGoAPI.Migrations
{
    public partial class addedProfitPercentage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfitPercentage",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfitPercentage",
                table: "Inventories");
        }
    }
}
