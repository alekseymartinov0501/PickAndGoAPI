using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndGoAPI.Migrations
{
    public partial class AddedCurrentPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CurrentCost",
                table: "Inventories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCost",
                table: "Inventories");
        }
    }
}
