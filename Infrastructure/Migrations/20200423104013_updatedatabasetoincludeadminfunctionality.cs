using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class updatedatabasetoincludeadminfunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndustrialProperties");

            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "OnSaleProperties");

            migrationBuilder.AddColumn<string>(
                name: "ImageLink4",
                table: "RentalProperties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink4",
                table: "OnSaleProperties",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommercialProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    NumberOfBedrooms = table.Column<int>(nullable: false),
                    NeighbourhoodSecurity = table.Column<int>(nullable: false),
                    Extras = table.Column<string>(nullable: true),
                    BuildingType = table.Column<string>(nullable: false),
                    ProviderName = table.Column<string>(nullable: false),
                    ImageLink1 = table.Column<string>(nullable: true),
                    ImageLink2 = table.Column<string>(nullable: true),
                    ImageLink3 = table.Column<string>(nullable: true),
                    ImageLink4 = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Town = table.Column<string>(nullable: false),
                    Area = table.Column<double>(nullable: false),
                    ParkingSpace = table.Column<bool>(nullable: false),
                    Purpose = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ProviderModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommercialProperties_ProviderModels_ProviderModelId",
                        column: x => x.ProviderModelId,
                        principalTable: "ProviderModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(nullable: false),
                    PropertyType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoForCheckOrRedirects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(nullable: false),
                    FirmAction = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoForCheckOrRedirects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchQueryLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchQuery = table.Column<string>(nullable: true),
                    SearchLocation = table.Column<string>(nullable: true),
                    QueriedFirm = table.Column<string>(nullable: true),
                    purpose = table.Column<int>(nullable: false),
                    CountResultFoundInQueriedFirm = table.Column<int>(nullable: false),
                    CountResultFoundInOtherFirms = table.Column<int>(nullable: false),
                    DateQueried = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchQueryLogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommercialProperties_ProviderModelId",
                table: "CommercialProperties",
                column: "ProviderModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommercialProperties");

            migrationBuilder.DropTable(
                name: "EmergencyProperties");

            migrationBuilder.DropTable(
                name: "GoForCheckOrRedirects");

            migrationBuilder.DropTable(
                name: "SearchQueryLogs");

            migrationBuilder.DropColumn(
                name: "ImageLink4",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "ImageLink4",
                table: "OnSaleProperties");

            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "RentalProperties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "OnSaleProperties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IndustrialProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<double>(type: "float", nullable: false),
                    BuildingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLink1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLink2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLink3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeighbourhoodSecurity = table.Column<int>(type: "int", nullable: false),
                    NumberOfBedrooms = table.Column<int>(type: "int", nullable: false),
                    ParkingSpace = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProviderModelId = table.Column<int>(type: "int", nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    purpose = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustrialProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndustrialProperties_ProviderModels_ProviderModelId",
                        column: x => x.ProviderModelId,
                        principalTable: "ProviderModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndustrialProperties_ProviderModelId",
                table: "IndustrialProperties",
                column: "ProviderModelId");
        }
    }
}
