using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class changenumbertoPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "ProviderModels");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ProviderModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ProviderModels");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "ProviderModels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
