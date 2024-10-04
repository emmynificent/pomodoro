using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pomodoro.Migrations
{
    /// <inheritdoc />
    public partial class setreminder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SetReminder",
                table: "Assignments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignmentCreated", "SetReminder" },
                values: new object[] { new DateTime(2024, 9, 27, 12, 11, 23, 51, DateTimeKind.Local).AddTicks(5993), false });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignmentCreated", "SetReminder" },
                values: new object[] { new DateTime(2024, 9, 27, 12, 11, 23, 51, DateTimeKind.Local).AddTicks(6008), false });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignmentCreated", "SetReminder" },
                values: new object[] { new DateTime(2024, 9, 27, 12, 11, 23, 51, DateTimeKind.Local).AddTicks(6010), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SetReminder",
                table: "Assignments");

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
                column: "AssignmentCreated",
                value: new DateTime(2024, 9, 27, 0, 6, 9, 374, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignmentCreated",
                value: new DateTime(2024, 9, 27, 0, 6, 9, 374, DateTimeKind.Local).AddTicks(8262));
        }
    }
}
