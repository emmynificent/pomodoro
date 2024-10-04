using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pomodoro.Migrations
{
    /// <inheritdoc />
    public partial class time : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignmentCreated",
                value: new DateTime(2024, 9, 27, 0, 6, 9, 374, DateTimeKind.Local).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignmentCreated", "DueDate" },
                values: new object[] { new DateTime(2024, 9, 27, 0, 6, 9, 374, DateTimeKind.Local).AddTicks(8258), new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignmentCreated",
                value: new DateTime(2024, 9, 27, 0, 6, 9, 374, DateTimeKind.Local).AddTicks(8262));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignmentCreated",
                value: new DateTime(2024, 9, 26, 23, 39, 20, 749, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignmentCreated", "DueDate" },
                values: new object[] { new DateTime(2024, 9, 26, 23, 39, 20, 749, DateTimeKind.Local).AddTicks(9479), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022) });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignmentCreated",
                value: new DateTime(2024, 9, 26, 23, 39, 20, 749, DateTimeKind.Local).AddTicks(9487));
        }
    }
}
