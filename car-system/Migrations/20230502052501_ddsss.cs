using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace car_system.Migrations
{
    /// <inheritdoc />
    public partial class ddsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalRequests_AspNetUsers_AuthorizedById",
                table: "RentalRequests");

            migrationBuilder.DropIndex(
                name: "IX_RentalRequests_AuthorizedById",
                table: "RentalRequests");

            migrationBuilder.DropColumn(
                name: "AuthorizedById",
                table: "RentalRequests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d903bcb9-f4e5-488c-94dd-f31d92aca3ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a534dbe1-5b7a-4433-96a3-ce4fa5ed9fca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "faa8a187-2851-4381-bb85-2529dda389cd");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorizedById",
                table: "RentalRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "da70864f-17f3-400e-a5c1-27d4295c82fc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7e796f4f-23fa-4e31-afc3-e86e9d7a3bed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "568a7d64-3daf-48c0-ad61-e9681eb585de");

            migrationBuilder.CreateIndex(
                name: "IX_RentalRequests_AuthorizedById",
                table: "RentalRequests",
                column: "AuthorizedById");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalRequests_AspNetUsers_AuthorizedById",
                table: "RentalRequests",
                column: "AuthorizedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
