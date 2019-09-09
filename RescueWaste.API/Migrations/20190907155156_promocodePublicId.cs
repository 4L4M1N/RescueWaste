using Microsoft.EntityFrameworkCore.Migrations;

namespace RescueWaste.API.Migrations
{
    public partial class promocodePublicId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "PromocodePhotos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "PromocodePhotos");
        }
    }
}
