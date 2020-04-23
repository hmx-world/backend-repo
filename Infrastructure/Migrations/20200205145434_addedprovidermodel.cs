using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class addedprovidermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProviderModelId",
                table: "RentalProperties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProviderModelId",
                table: "OnSaleProperties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProviderModelId",
                table: "IndustrialProperties",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProviderModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ImageUri = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    LoginId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperties_ProviderModelId",
                table: "RentalProperties",
                column: "ProviderModelId");

            migrationBuilder.CreateIndex(
                name: "IX_OnSaleProperties_ProviderModelId",
                table: "OnSaleProperties",
                column: "ProviderModelId");

            migrationBuilder.CreateIndex(
                name: "IX_IndustrialProperties_ProviderModelId",
                table: "IndustrialProperties",
                column: "ProviderModelId");

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

            migrationBuilder.DropTable(
                name: "ProviderModels");

            migrationBuilder.DropIndex(
                name: "IX_RentalProperties_ProviderModelId",
                table: "RentalProperties");

            migrationBuilder.DropIndex(
                name: "IX_OnSaleProperties_ProviderModelId",
                table: "OnSaleProperties");

            migrationBuilder.DropIndex(
                name: "IX_IndustrialProperties_ProviderModelId",
                table: "IndustrialProperties");

            migrationBuilder.DropColumn(
                name: "ProviderModelId",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "ProviderModelId",
                table: "OnSaleProperties");

            migrationBuilder.DropColumn(
                name: "ProviderModelId",
                table: "IndustrialProperties");
        }
    }
}
