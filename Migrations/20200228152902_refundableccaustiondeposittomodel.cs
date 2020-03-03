using Microsoft.EntityFrameworkCore.Migrations;

namespace tinder4apartment.Migrations
{
    public partial class refundableccaustiondeposittomodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RefundableCautionDeposit",
                table: "RentalProperties",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "RefundableCautionDepositPrice",
                table: "RentalProperties",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefundableCautionDeposit",
                table: "RentalProperties");

            migrationBuilder.DropColumn(
                name: "RefundableCautionDepositPrice",
                table: "RentalProperties");
        }
    }
}
