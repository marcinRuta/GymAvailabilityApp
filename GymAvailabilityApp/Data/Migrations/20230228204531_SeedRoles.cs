using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymAvailabilityApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03e0a4a9-ba76-4464-a944-50934f6bd437", "30e66ef4-6d1e-4cdc-a6cc-c82a3d3875df", "Admin", "ADMIN" },
                    { "3cd2e66e-e8aa-4eda-8275-36c797447bc0", "f0fe49b2-0a4c-48d5-a64a-fc422c958594", "User", "USER" },
                    { "dae93dd2-c82b-403e-993d-bd1e50bc97e1", "a37b53d5-5f13-4d6c-933c-d42b8637f1d1", "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03e0a4a9-ba76-4464-a944-50934f6bd437");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cd2e66e-e8aa-4eda-8275-36c797447bc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dae93dd2-c82b-403e-993d-bd1e50bc97e1");
        }
    }
}
