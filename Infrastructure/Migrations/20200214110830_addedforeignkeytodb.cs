using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class addedforeignkeytodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndustrialProperties_ProviderModels_ProviderModelId",
                table: "IndustrialProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_OnSaleProperties_ProviderModels_ProviderModelId",
                table: "OnSaleProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalProperties_ProviderModels_ProviderModelId",
                table: "RentalProperties");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderModelId",
                table: "RentalProperties",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProviderModelId",
                table: "OnSaleProperties",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProviderModelId",
                table: "IndustrialProperties",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IndustrialProperties_ProviderModels_ProviderModelId",
                table: "IndustrialProperties",
                column: "ProviderModelId",
                principalTable: "ProviderModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnSaleProperties_ProviderModels_ProviderModelId",
                table: "OnSaleProperties",
                column: "ProviderModelId",
                principalTable: "ProviderModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalProperties_ProviderModels_ProviderModelId",
                table: "RentalProperties",
                column: "ProviderModelId",
                principalTable: "ProviderModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndustrialProperties_ProviderModels_ProviderModelId",
                table: "IndustrialProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_OnSaleProperties_ProviderModels_ProviderModelId",
                table: "OnSaleProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalProperties_ProviderModels_ProviderModelId",
                table: "RentalProperties");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderModelId",
                table: "RentalProperties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProviderModelId",
                table: "OnSaleProperties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProviderModelId",
                table: "IndustrialProperties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_IndustrialProperties_ProviderModels_ProviderModelId",
                table: "IndustrialProperties",
                column: "ProviderModelId",
                principalTable: "ProviderModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OnSaleProperties_ProviderModels_ProviderModelId",
                table: "OnSaleProperties",
                column: "ProviderModelId",
                principalTable: "ProviderModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalProperties_ProviderModels_ProviderModelId",
                table: "RentalProperties",
                column: "ProviderModelId",
                principalTable: "ProviderModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
