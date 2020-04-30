using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class addedvidelinknotworkingyet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageLink1",
                table: "RentalProperties",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "RentalProperties",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageLink1",
                table: "OnSaleProperties",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "OnSaleProperties",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageLink1",
                table: "IndustrialProperties",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "IndustrialProperties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "OnSaleProperties");

            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "IndustrialProperties");

            migrationBuilder.AlterColumn<string>(
                name: "ImageLink1",
                table: "RentalProperties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageLink1",
                table: "OnSaleProperties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageLink1",
                table: "IndustrialProperties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
