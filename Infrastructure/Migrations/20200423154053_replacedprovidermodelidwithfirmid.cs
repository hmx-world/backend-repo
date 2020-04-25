using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class replacedprovidermodelidwithfirmid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommercialProperties_Firms_FirmId",
                table: "CommercialProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_LandProperties_Firms_FirmId",
                table: "LandProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_OnSaleProperties_Firms_FirmId",
                table: "OnSaleProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalProperties_Firms_FirmId",
                table: "RentalProperties");

            migrationBuilder.DropIndex(
                name: "IX_RentalProperties_FirmId",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "FirmId",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "ProviderModelId",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "ProviderModelId",
                table: "OnSaleProperties");

            migrationBuilder.DropColumn(
                name: "ProviderModelId",
                table: "LandProperties");

            migrationBuilder.DropColumn(
                name: "ProviderModelId",
                table: "CommercialProperties");

            migrationBuilder.AddColumn<int>(
                name: "FrimId",
                table: "RentalProperties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FirmId",
                table: "OnSaleProperties",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FirmId",
                table: "LandProperties",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FirmId",
                table: "CommercialProperties",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperties_FrimId",
                table: "RentalProperties",
                column: "FrimId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommercialProperties_Firms_FirmId",
                table: "CommercialProperties",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LandProperties_Firms_FirmId",
                table: "LandProperties",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnSaleProperties_Firms_FirmId",
                table: "OnSaleProperties",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalProperties_Firms_FrimId",
                table: "RentalProperties",
                column: "FrimId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommercialProperties_Firms_FirmId",
                table: "CommercialProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_LandProperties_Firms_FirmId",
                table: "LandProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_OnSaleProperties_Firms_FirmId",
                table: "OnSaleProperties");

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
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProviderModelId",
                table: "RentalProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FirmId",
                table: "OnSaleProperties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProviderModelId",
                table: "OnSaleProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FirmId",
                table: "LandProperties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProviderModelId",
                table: "LandProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FirmId",
                table: "CommercialProperties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProviderModelId",
                table: "CommercialProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperties_FirmId",
                table: "RentalProperties",
                column: "FirmId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommercialProperties_Firms_FirmId",
                table: "CommercialProperties",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LandProperties_Firms_FirmId",
                table: "LandProperties",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OnSaleProperties_Firms_FirmId",
                table: "OnSaleProperties",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalProperties_Firms_FirmId",
                table: "RentalProperties",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
