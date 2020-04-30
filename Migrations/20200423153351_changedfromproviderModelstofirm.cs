using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class changedfromproviderModelstofirm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommercialProperties_ProviderModels_ProviderModelId",
                table: "CommercialProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_OnSaleProperties_ProviderModels_ProviderModelId",
                table: "OnSaleProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalProperties_ProviderModels_ProviderModelId",
                table: "RentalProperties");

            migrationBuilder.DropIndex(
                name: "IX_RentalProperties_ProviderModelId",
                table: "RentalProperties");

            migrationBuilder.DropIndex(
                name: "IX_OnSaleProperties_ProviderModelId",
                table: "OnSaleProperties");

            migrationBuilder.DropIndex(
                name: "IX_CommercialProperties_ProviderModelId",
                table: "CommercialProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProviderModels",
                table: "ProviderModels");

            migrationBuilder.DropColumn(
                name: "purpose",
                table: "SearchQueryLogs");

            migrationBuilder.RenameTable(
                name: "ProviderModels",
                newName: "Firms");

            migrationBuilder.AddColumn<int>(
                name: "PropertyType",
                table: "SearchQueryLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirmId",
                table: "RentalProperties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirmId",
                table: "OnSaleProperties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyType",
                table: "GoForCheckOrRedirects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirmId",
                table: "CommercialProperties",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Firms",
                table: "Firms",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LandProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Town = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    AreaSize = table.Column<double>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ImageLink1 = table.Column<string>(nullable: true),
                    ImageLink2 = table.Column<string>(nullable: true),
                    ImageLink3 = table.Column<string>(nullable: true),
                    FirmId = table.Column<int>(nullable: true),
                    ProviderModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandProperties_Firms_FirmId",
                        column: x => x.FirmId,
                        principalTable: "Firms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperties_FirmId",
                table: "RentalProperties",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_OnSaleProperties_FirmId",
                table: "OnSaleProperties",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_CommercialProperties_FirmId",
                table: "CommercialProperties",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_LandProperties_FirmId",
                table: "LandProperties",
                column: "FirmId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommercialProperties_Firms_FirmId",
                table: "CommercialProperties",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommercialProperties_Firms_FirmId",
                table: "CommercialProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_OnSaleProperties_Firms_FirmId",
                table: "OnSaleProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalProperties_Firms_FirmId",
                table: "RentalProperties");

            migrationBuilder.DropTable(
                name: "LandProperties");

            migrationBuilder.DropIndex(
                name: "IX_RentalProperties_FirmId",
                table: "RentalProperties");

            migrationBuilder.DropIndex(
                name: "IX_OnSaleProperties_FirmId",
                table: "OnSaleProperties");

            migrationBuilder.DropIndex(
                name: "IX_CommercialProperties_FirmId",
                table: "CommercialProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Firms",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "PropertyType",
                table: "SearchQueryLogs");

            migrationBuilder.DropColumn(
                name: "FirmId",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "FirmId",
                table: "OnSaleProperties");

            migrationBuilder.DropColumn(
                name: "PropertyType",
                table: "GoForCheckOrRedirects");

            migrationBuilder.DropColumn(
                name: "FirmId",
                table: "CommercialProperties");

            migrationBuilder.RenameTable(
                name: "Firms",
                newName: "ProviderModels");

            migrationBuilder.AddColumn<int>(
                name: "purpose",
                table: "SearchQueryLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProviderModels",
                table: "ProviderModels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperties_ProviderModelId",
                table: "RentalProperties",
                column: "ProviderModelId");

            migrationBuilder.CreateIndex(
                name: "IX_OnSaleProperties_ProviderModelId",
                table: "OnSaleProperties",
                column: "ProviderModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CommercialProperties_ProviderModelId",
                table: "CommercialProperties",
                column: "ProviderModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommercialProperties_ProviderModels_ProviderModelId",
                table: "CommercialProperties",
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
    }
}
