using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class changeareatotown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "OnSaleProperties");

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "RentalProperties",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "OnSaleProperties",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "IndustrialProperties",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Town",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "OnSaleProperties");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "IndustrialProperties");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "RentalProperties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "OnSaleProperties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
