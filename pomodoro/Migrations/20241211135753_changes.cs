using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pomodoro.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f25abdc7-1226-4d21-881b-baf69844cb2d", "AQAAAAIAAYagAAAAEMFJDaSs8ngpidno92IU+GZNP9NgydmUdzlji6upZ+LA9D92ntzJShH5i2k2aftvxA==", "2cecde8f-c9d9-46df-bcbd-21ac10031773" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce15ddf7-18d2-4c86-a2a2-bfc4125d511c", "AQAAAAIAAYagAAAAEP0Vj2HHXYAEWL3FmPWLT8Lm3GQCe5tFcEDys2Io54uCK7hFc4hGzpVzuE0LO4o5aA==", "dafb763d-e6c2-4d2c-a235-841e85e3ddf1" });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignmentCreated",
                value: new DateTime(2024, 12, 11, 14, 57, 51, 521, DateTimeKind.Local).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2,
                column: "AssignmentCreated",
                value: new DateTime(2024, 12, 11, 14, 57, 51, 521, DateTimeKind.Local).AddTicks(283));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssignmentCreated",
                value: new DateTime(2024, 12, 11, 14, 57, 51, 521, DateTimeKind.Local).AddTicks(287));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
