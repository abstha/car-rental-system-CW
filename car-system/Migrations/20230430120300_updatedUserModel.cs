using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace car_system.Migrations
{
    /// <inheritdoc />
    public partial class updatedUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UsersId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_UsersId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c9ecd2d0-f42d-488f-9555-72f9a92e10c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9d09e32a-5969-4867-8414-4d3b89ec5b47");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "00a6ec98-0eba-46d7-95ee-803df1d8189d");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UsersId",
                table: "AspNetUserRoles",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UsersId",
                table: "AspNetUserRoles",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UsersId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UsersId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "AspNetUserRoles");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "UsersId" },
                values: new object[] { "4810d2af-fcb0-406f-ae08-b7d6dd8db636", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "UsersId" },
                values: new object[] { "6646b66e-d6d2-4ee5-9359-d72b56a35d52", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "UsersId" },
                values: new object[] { "eba3ce0f-6c95-45fb-bf76-dab627112d86", null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UsersId",
                table: "AspNetRoles",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UsersId",
                table: "AspNetRoles",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
