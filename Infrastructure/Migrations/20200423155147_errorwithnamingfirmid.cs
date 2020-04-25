using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class errorwithnamingfirmid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalProperties_Firms_FrimId",
                table: "RentalProperties");

            migrationBuilder.DropIndex(
                name: "IX_RentalProperties_FrimId",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "FrimId",
                table: "RentalProperties");

            migrationBuilder.AddColumn<int>(
                name: "FirmId",
                table: "RentalProperties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperties_FirmId",
                table: "RentalProperties",
                column: "FirmId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalProperties_Firms_FirmId",
                table: "RentalProperties",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalProperties_Firms_FirmId",
                table: "RentalProperties");

            migrationBuilder.DropIndex(
                name: "IX_RentalProperties_FirmId",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "FirmId",
                table: "RentalProperties");

            migrationBuilder.AddColumn<int>(
                name: "FrimId",
                table: "RentalProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperties_FrimId",
                table: "RentalProperties",
                column: "FrimId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalProperties_Firms_FrimId",
                table: "RentalProperties",
                column: "FrimId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
