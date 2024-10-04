using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pomodoro.Migrations
{
    /// <inheritdoc />
    public partial class reminder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_Assignments_assignmentId",
                table: "Reminder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reminder",
                table: "Reminder");

            migrationBuilder.RenameTable(
                name: "Reminder",
                newName: "Reminders");

            migrationBuilder.RenameIndex(
                name: "IX_Reminder_assignmentId",
                table: "Reminders",
                newName: "IX_Reminders_assignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reminders",
                table: "Reminders",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignmentCreated",
                value: new DateTime(2024, 9, 28, 19, 48, 8, 989, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                column: "AssignmentCreated",
                value: new DateTime(2024, 9, 28, 19, 48, 8, 989, DateTimeKind.Local).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignmentCreated",
                value: new DateTime(2024, 9, 28, 19, 48, 8, 989, DateTimeKind.Local).AddTicks(5907));

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_Assignments_assignmentId",
                table: "Reminders",
                column: "assignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_Assignments_assignmentId",
                table: "Reminders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reminders",
                table: "Reminders");

            migrationBuilder.RenameTable(
                name: "Reminders",
                newName: "Reminder");

            migrationBuilder.RenameIndex(
                name: "IX_Reminders_assignmentId",
                table: "Reminder",
                newName: "IX_Reminder_assignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reminder",
                table: "Reminder",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignmentCreated",
                value: new DateTime(2024, 9, 27, 12, 11, 23, 51, DateTimeKind.Local).AddTicks(5993));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                column: "AssignmentCreated",
                value: new DateTime(2024, 9, 27, 12, 11, 23, 51, DateTimeKind.Local).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignmentCreated",
                value: new DateTime(2024, 9, 27, 12, 11, 23, 51, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_Assignments_assignmentId",
                table: "Reminder",
                column: "assignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
