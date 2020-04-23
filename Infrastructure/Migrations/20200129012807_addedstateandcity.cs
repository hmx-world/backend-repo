using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class addedstateandcity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "OnSaleProperties");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "RentalProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "RentalProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "OnSaleProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "OnSaleProperties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "State",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "City",
                table: "OnSaleProperties");

            migrationBuilder.DropColumn(
                name: "State",
                table: "OnSaleProperties");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "RentalProperties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "OnSaleProperties",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
