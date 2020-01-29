using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnSaleProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    NumberOfBedrooms = table.Column<int>(nullable: false),
                    NeighbourhoodSecurity = table.Column<int>(nullable: false),
                    Extras = table.Column<string>(nullable: true),
                    BuildingType = table.Column<string>(nullable: true),
                    ProviderName = table.Column<string>(nullable: true),
                    LandArea = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SiteDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnSaleProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Light24hours = table.Column<int>(nullable: false),
                    WaterSupply = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalProperties", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnSaleProperties");

            migrationBuilder.DropTable(
                name: "RentalProperties");
        }
    }
}
