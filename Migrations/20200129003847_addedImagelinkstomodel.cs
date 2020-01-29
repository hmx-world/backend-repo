using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class addedImagelinkstomodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink1",
                table: "OnSaleProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink2",
                table: "OnSaleProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink3",
                table: "OnSaleProperties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink1",
                table: "OnSaleProperties");

            migrationBuilder.DropColumn(
                name: "ImageLink2",
                table: "OnSaleProperties");

            migrationBuilder.DropColumn(
                name: "ImageLink3",
                table: "OnSaleProperties");
        }
    }
}
