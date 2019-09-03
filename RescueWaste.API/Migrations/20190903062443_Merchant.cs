using Microsoft.EntityFrameworkCore.Migrations;

namespace RescueWaste.API.Migrations
{
    public partial class Merchant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromoCodes_Merchants_MerchantId",
                table: "PromoCodes");

            migrationBuilder.RenameColumn(
                name: "MerchantId",
                table: "PromoCodes",
                newName: "MerchantID");

            migrationBuilder.RenameIndex(
                name: "IX_PromoCodes_MerchantId",
                table: "PromoCodes",
                newName: "IX_PromoCodes_MerchantID");

            migrationBuilder.AddForeignKey(
                name: "FK_PromoCodes_Merchants_MerchantID",
                table: "PromoCodes",
                column: "MerchantID",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromoCodes_Merchants_MerchantID",
                table: "PromoCodes");

            migrationBuilder.RenameColumn(
                name: "MerchantID",
                table: "PromoCodes",
                newName: "MerchantId");

            migrationBuilder.RenameIndex(
                name: "IX_PromoCodes_MerchantID",
                table: "PromoCodes",
                newName: "IX_PromoCodes_MerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_PromoCodes_Merchants_MerchantId",
                table: "PromoCodes",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
