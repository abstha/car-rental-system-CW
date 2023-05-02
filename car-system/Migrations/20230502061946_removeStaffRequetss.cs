using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace car_system.Migrations
{
    /// <inheritdoc />
    public partial class removeStaffRequetss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffRequests");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByStaffId",
                table: "RentalRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "RentalRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b14e3a55-dbcc-4c64-8186-ac668fe05de3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "565e231f-c2ab-44c7-8d71-972a0dc88597");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a2ba5241-3b6d-4b9f-a3ea-9ee8d00eb943");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedByStaffId",
                table: "RentalRequests");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "RentalRequests");

            migrationBuilder.CreateTable(
                name: "StaffRequests",
                columns: table => new
                {
                    StaffRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalRequestId = table.Column<int>(type: "int", nullable: false),
                    StaffMemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRequests", x => x.StaffRequestId);
                    table.ForeignKey(
                        name: "FK_StaffRequests_AspNetUsers_StaffMemberId",
                        column: x => x.StaffMemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffRequests_RentalRequests_RentalRequestId",
                        column: x => x.RentalRequestId,
                        principalTable: "RentalRequests",
                        principalColumn: "RentalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e44aa0d0-c3f9-47da-b137-9467cb3fa382");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c9acf5ba-9248-4862-b211-273cb167f61d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "20129ae8-91ce-4d70-9131-40d7f51a85e7");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRequests_RentalRequestId",
                table: "StaffRequests",
                column: "RentalRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffRequests_StaffMemberId",
                table: "StaffRequests",
                column: "StaffMemberId");
        }
    }
}
