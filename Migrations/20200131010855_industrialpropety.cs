using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class industrialpropety : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndustrialProperties",
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
                    ImageLink1 = table.Column<string>(nullable: false),
                    ImageLink2 = table.Column<string>(nullable: true),
                    ImageLink3 = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Area = table.Column<double>(nullable: false),
                    ParkingSpace = table.Column<bool>(nullable: false),
                    Mode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustrialProperties", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndustrialProperties");
        }
    }
}
