using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagerApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedTaskEntityData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "DueDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 21, 16, 47, 40, 185, DateTimeKind.Local).AddTicks(2950), "Task 1", 0 },
                    { 2, new DateTime(2024, 8, 22, 16, 47, 40, 185, DateTimeKind.Local).AddTicks(3056), "Task 2", 1 },
                    { 3, new DateTime(2024, 8, 23, 16, 47, 40, 185, DateTimeKind.Local).AddTicks(3062), "Task 3", 2 },
                    { 4, new DateTime(2024, 8, 24, 16, 47, 40, 185, DateTimeKind.Local).AddTicks(3068), "Task 4", 3 },
                    { 5, new DateTime(2024, 8, 25, 16, 47, 40, 185, DateTimeKind.Local).AddTicks(3073), "Task 5", 0 },
                    { 6, new DateTime(2024, 8, 26, 16, 47, 40, 185, DateTimeKind.Local).AddTicks(3078), "Task 6", 1 },
                    { 7, new DateTime(2024, 8, 27, 16, 47, 40, 185, DateTimeKind.Local).AddTicks(3083), "Task 7", 2 },
                    { 8, new DateTime(2024, 8, 28, 16, 47, 40, 185, DateTimeKind.Local).AddTicks(3087), "Task 8", 3 },
                    { 9, new DateTime(2024, 8, 29, 16, 47, 40, 185, DateTimeKind.Local).AddTicks(3092), "Task 9", 0 },
                    { 10, new DateTime(2024, 8, 30, 16, 47, 40, 185, DateTimeKind.Local).AddTicks(3098), "Task 10", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
