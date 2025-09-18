using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Stock.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2a4a5ff-cb7d-4149-a85d-8750d0cbb04f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd955084-c69a-4a1c-ac81-3f2fa6c98b38");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9F2F43E3-5B0D-4C5D-9B4E-987654321DEF", null, "User", "USER" },
                    { "B6A6C99A-7C19-4BE8-B7B6-123456789ABC", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9F2F43E3-5B0D-4C5D-9B4E-987654321DEF");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B6A6C99A-7C19-4BE8-B7B6-123456789ABC");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b2a4a5ff-cb7d-4149-a85d-8750d0cbb04f", null, "User", "USER" },
                    { "dd955084-c69a-4a1c-ac81-3f2fa6c98b38", null, "Admin", "ADMIN" }
                });
        }
    }
}
