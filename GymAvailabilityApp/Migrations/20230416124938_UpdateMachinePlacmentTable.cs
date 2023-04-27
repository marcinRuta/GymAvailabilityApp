using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymAvailabilityApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMachinePlacmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e55398b-ec1a-49a5-a557-33ae69ad0624");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b727d62-cd6e-408d-a4b8-ba281c37cec2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d037140f-121d-46c6-b584-ba47aa61bab2");

            migrationBuilder.AddColumn<int>(
                name: "GymRoomId",
                table: "MachinePlacements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66260f73-160d-42e7-89c4-2367f23e2f53", "4f10c663-d46f-4862-a090-c8b61af4b9c3", "Employee", "EMPLOYEE" },
                    { "81a5437a-656f-44e4-aa35-99c01efcd5e8", "facb5e5f-0fa9-4742-ab45-9241b76ce766", "User", "USER" },
                    { "fc47f0b9-aa3b-400b-8e78-0d500dd04d0f", "e764d9a6-7537-4203-a5f0-f9272fc2cf55", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66260f73-160d-42e7-89c4-2367f23e2f53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81a5437a-656f-44e4-aa35-99c01efcd5e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc47f0b9-aa3b-400b-8e78-0d500dd04d0f");

            migrationBuilder.DropColumn(
                name: "GymRoomId",
                table: "MachinePlacements");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e55398b-ec1a-49a5-a557-33ae69ad0624", "a005cfae-bc8c-47af-8fd8-e8296a547367", "User", "USER" },
                    { "4b727d62-cd6e-408d-a4b8-ba281c37cec2", "ba0bf214-06fa-485b-b57e-5823106e8d53", "Employee", "EMPLOYEE" },
                    { "d037140f-121d-46c6-b584-ba47aa61bab2", "14da8405-7a26-45f3-9545-2f09e4a07aa0", "Admin", "ADMIN" }
                });
        }
    }
}
