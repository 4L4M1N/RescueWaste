using Microsoft.EntityFrameworkCore.Migrations;

namespace RescueWaste.API.Migrations
{
    public partial class PromocodePhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "PromoCodes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "PromoCodes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "PromoCodes");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "PromoCodes");
        }
    }
}
