using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pomodoro.Migrations
{
    /// <inheritdoc />
    public partial class users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_AssignmentOwnerId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_AssignmentOwnerId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "AssignmentOwnerId",
                table: "Assignments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Assignments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93f12d48-3838-450b-9f29-f0541105e1f4", "AQAAAAIAAYagAAAAEC0RhSyW0B99y5BnZ7S/ADGhJtFzxuL4EZFTNcIMWkBlyljU1Rkgz3aCGpQQjymZFA==", "9f1a1857-4cab-47a9-ae48-7551e3ee6789" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac82d82b-4cdb-4be1-ade1-d57cf62b3adf", "AQAAAAIAAYagAAAAEImMqY6a3UjUkuZQcYbPw40AmKFwmGZB8orsbWDqh9rcRRcwIOyrTKl9lKR7dsgCew==", "830c0548-1ec6-401a-abf8-79d636085be3" });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignmentCreated",
                value: new DateTime(2024, 11, 27, 12, 3, 8, 362, DateTimeKind.Local).AddTicks(3194));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                column: "AssignmentCreated",
                value: new DateTime(2024, 11, 27, 12, 3, 8, 362, DateTimeKind.Local).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignmentCreated",
                value: new DateTime(2024, 11, 27, 12, 3, 8, 362, DateTimeKind.Local).AddTicks(3217));

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_UserId",
                table: "Assignments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_UserId",
                table: "Assignments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_UserId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_UserId",
                table: "Assignments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AssignmentOwnerId",
                table: "Assignments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2613830-fced-41c9-84bc-aa2d2686a8dd", "AQAAAAIAAYagAAAAEG0a6hedZclUdNfr68dEEbGYrvOP3Gj8HDjAtJNBcOwG7KfAUoxEK0y61qGxTEnSag==", "0732192c-7ef9-4e90-8bb2-8f4b3b3491c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db09c90a-4879-4aa6-a3ad-eb717aa8f1fa", "AQAAAAIAAYagAAAAEFT6hZwKF60CuM8yzCLaTQhN1EmXLBVGgBe3cjo8sVHI/GCfz9nrWm4Fb6RVhwhT9Q==", "9d1c8c72-3a9b-4440-8079-9a3689587971" });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignmentCreated", "AssignmentOwnerId" },
                values: new object[] { new DateTime(2024, 11, 5, 11, 15, 2, 217, DateTimeKind.Local).AddTicks(4097), null });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignmentCreated", "AssignmentOwnerId" },
                values: new object[] { new DateTime(2024, 11, 5, 11, 15, 2, 217, DateTimeKind.Local).AddTicks(4193), null });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignmentCreated", "AssignmentOwnerId" },
                values: new object[] { new DateTime(2024, 11, 5, 11, 15, 2, 217, DateTimeKind.Local).AddTicks(4196), null });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignmentOwnerId",
                table: "Assignments",
                column: "AssignmentOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_AssignmentOwnerId",
                table: "Assignments",
                column: "AssignmentOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
