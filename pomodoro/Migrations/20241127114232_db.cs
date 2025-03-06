using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pomodoro.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c3e8a73-c134-4297-9dc0-cb8dc307b60b", "AQAAAAIAAYagAAAAECIYodJaqpCUJa/ksfhfBl+2cZUnB5ASwGuMGhXwgScVBc5kQbpEMBF2kQXm8UM/Zw==", "ca27d1ac-6d5f-43f5-be86-4cb804057cc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "389b6f74-2ae9-4722-b746-f4e2c1e894ea", "AQAAAAIAAYagAAAAEChvGIZM96IEhXAqhQrrcASw4C062js2nsiP9yoDEhrmN6is8+7kiu094KhhCieidg==", "b801024e-7c62-444b-8382-371c56af04d7" });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignmentCreated",
                value: new DateTime(2024, 11, 27, 12, 42, 26, 588, DateTimeKind.Local).AddTicks(1339));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                column: "AssignmentCreated",
                value: new DateTime(2024, 11, 27, 12, 42, 26, 588, DateTimeKind.Local).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignmentCreated",
                value: new DateTime(2024, 11, 27, 12, 42, 26, 588, DateTimeKind.Local).AddTicks(1375));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
