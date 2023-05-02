using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace car_system.Migrations
{
    /// <inheritdoc />
    public partial class addedRentApproved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalRequests_AspNetUsers_UserId",
                table: "RentalRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalRequests_AspNetUsers_UsersId",
                table: "RentalRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalRequests_Cars_CarRented",
                table: "RentalRequests");

            migrationBuilder.DropIndex(
                name: "IX_RentalRequests_UsersId",
                table: "RentalRequests");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "RentalRequests");

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
                value: "7b7efcbd-73a1-4e6e-95c0-007b972ecd7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "636bc57c-3694-44b9-9123-01a2dd8f90fe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "d9b0f587-ee2d-411a-bd72-5b692973b180");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RentalRequests_AspNetUsers_UserId",
                table: "RentalRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalRequests_Cars_CarRented",
                table: "RentalRequests",
                column: "CarRented",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalRequests_AspNetUsers_AuthorizedById",
                table: "RentalRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalRequests_AspNetUsers_UserId",
                table: "RentalRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalRequests_Cars_CarRented",
                table: "RentalRequests");

            migrationBuilder.DropIndex(
                name: "IX_RentalRequests_AuthorizedById",
                table: "RentalRequests");

            migrationBuilder.DropColumn(
                name: "AuthorizedById",
                table: "RentalRequests");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "RentalRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0cf85811-9f7d-4ca8-916a-d5a97a068328");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4b94b029-b9ef-4ba0-952e-2d0759807d2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "c035e603-7ded-46a4-891e-6102b2adaa0c");

            migrationBuilder.CreateIndex(
                name: "IX_RentalRequests_UsersId",
                table: "RentalRequests",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalRequests_AspNetUsers_UserId",
                table: "RentalRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalRequests_AspNetUsers_UsersId",
                table: "RentalRequests",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalRequests_Cars_CarRented",
                table: "RentalRequests",
                column: "CarRented",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
