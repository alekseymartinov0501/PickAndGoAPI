using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndGoAPI.Migrations
{
    public partial class addedDistributionToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistributionId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_DistributionId",
                table: "Products",
                column: "DistributionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Distributions_DistributionId",
                table: "Products",
                column: "DistributionId",
                principalTable: "Distributions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Distributions_DistributionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DistributionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DistributionId",
                table: "Products");
        }
    }
}
