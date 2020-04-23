using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class numbertotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "ProviderModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "ProviderModels");
        }
    }
}
