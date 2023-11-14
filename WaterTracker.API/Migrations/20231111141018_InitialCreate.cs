using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WaterTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterIntakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IntakeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsumedWater = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterIntakes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Firstname", "Surname" },
                values: new object[,]
                {
                    { 1, "gladys.stevens@example.com", "Gladys", "Stevens" },
                    { 2, "jean.garza@example.com", "Jean", "Garza" },
                    { 3, "suzanne.lambert@example.com", "Suzanne ", "Lambert" },
                    { 4, "james.cooper@example.com", "James ", "Cooper" },
                    { 5, "steven .rice@example.com", "Steven ", "Rice" }
                });

            migrationBuilder.InsertData(
                table: "WaterIntakes",
                columns: new[] { "Id", "ConsumedWater", "IntakeDate", "UserId" },
                values: new object[,]
                {
                    { 1, 6287, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 4856, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 6832, new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 1387, new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 8567, new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WaterIntakes");
        }
    }
}
