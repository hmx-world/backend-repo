using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class addedsomemissinginheritancepropertiesfrombasicproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuildingType",
                table: "RentalProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extras",
                table: "RentalProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink1",
                table: "RentalProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink2",
                table: "RentalProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink3",
                table: "RentalProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "RentalProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RentalProperties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NeighbourhoodSecurity",
                table: "RentalProperties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBedrooms",
                table: "RentalProperties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "RentalProperties",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ProviderName",
                table: "RentalProperties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingType",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "Extras",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "ImageLink1",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "ImageLink2",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "ImageLink3",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "NeighbourhoodSecurity",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "NumberOfBedrooms",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "ProviderName",
                table: "RentalProperties");
        }
    }
}
