using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pomodoro.Migrations
{
    /// <inheritdoc />
    public partial class parse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssignmentStatus",
                table: "Assignments",
                newName: "priority");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Assignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Reminder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assignmentId = table.Column<int>(type: "int", nullable: false),
                    reminder_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notification = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminder_Assignments_assignmentId",
                        column: x => x.assignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "AssignmentCreated", "AssignmentDescription", "AssignmentTitle", "DueDate", "priority" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 26, 23, 39, 20, 749, DateTimeKind.Local).AddTicks(9456), "", "Chemistry", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2024, 9, 26, 23, 39, 20, 749, DateTimeKind.Local).AddTicks(9479), "", "Physics", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022), 1 },
                    { 3, new DateTime(2024, 9, 26, 23, 39, 20, 749, DateTimeKind.Local).AddTicks(9487), "", "Go", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Reminder",
                columns: new[] { "Id", "Notification", "assignmentId", "reminder_time" },
                values: new object[,]
                {
                    { 1, false, 1, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, 3, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_assignmentId",
                table: "Reminder",
                column: "assignmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reminder");

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "priority",
                table: "Assignments",
                newName: "AssignmentStatus");
        }
    }
}
