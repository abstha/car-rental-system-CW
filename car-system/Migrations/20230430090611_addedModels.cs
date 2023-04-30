using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace car_system.Migrations
{
    /// <inheritdoc />
    public partial class addedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarsCarId",
                table: "RentalRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "RentalRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Availability",
                table: "Cars",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrivingLicense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Citizenship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfRents = table.Column<int>(type: "int", nullable: false),
                    ActivityStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK_Attachments_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attachments_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OfferDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferID);
                    table.ForeignKey(
                        name: "FK_Offers_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UsersId" },
                values: new object[,]
                {
                    { "1", "903c7acb-8b18-4065-9cfc-2eb2bf144a41", "Staff", "STAFF", null },
                    { "2", "788cb95f-2a38-46e6-a1a3-2bf0e95cddef", "Admin", "ADMIN", null },
                    { "3", "c7f861ce-c19f-4b0e-842c-b49eb62e8d61", "Customer", "CUSTOMER", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalRequests_CarsCarId",
                table: "RentalRequests",
                column: "CarsCarId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalRequests_UsersId",
                table: "RentalRequests",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UsersId",
                table: "AspNetRoles",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_UserID",
                table: "Attachments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_UsersId",
                table: "Attachments",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CreatedByUserID",
                table: "Offers",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UsersId",
                table: "Offers",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UsersId",
                table: "AspNetRoles",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalRequests_AspNetUsers_UsersId",
                table: "RentalRequests",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalRequests_Cars_CarsCarId",
                table: "RentalRequests",
                column: "CarsCarId",
                principalTable: "Cars",
                principalColumn: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UsersId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalRequests_AspNetUsers_UsersId",
                table: "RentalRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalRequests_Cars_CarsCarId",
                table: "RentalRequests");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_RentalRequests_CarsCarId",
                table: "RentalRequests");

            migrationBuilder.DropIndex(
                name: "IX_RentalRequests_UsersId",
                table: "RentalRequests");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_UsersId",
                table: "AspNetRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DropColumn(
                name: "CarsCarId",
                table: "RentalRequests");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "RentalRequests");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Availability",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
