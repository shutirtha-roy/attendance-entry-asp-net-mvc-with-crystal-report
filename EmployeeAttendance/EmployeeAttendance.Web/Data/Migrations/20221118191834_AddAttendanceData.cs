using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAttendance.Web.Data.Migrations
{
    public partial class AddAttendanceData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "Id", "CreatedDate", "EmployeeId", "InTime", "OutTime", "Remarks" },
                values: new object[,]
                {
                    { new Guid("15dc6496-95a4-48ec-a0fa-08dac3136953"), new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6eb1d2cc-ec99-4370-a3b7-65e3e56c3ef4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 5, 4, 0, 0, DateTimeKind.Unspecified), "Samin1" },
                    { new Guid("3c9e7381-3bd7-4dfa-a0fb-08dac3136953"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("17ef6e14-7450-4f45-a3ff-3fe63969efef"), new DateTime(1, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 7, 3, 0, 0, DateTimeKind.Unspecified), "Junu1" },
                    { new Guid("7594f0c8-e28c-489a-a0fc-08dac3136953"), new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6eb1d2cc-ec99-4370-a3b7-65e3e56c3ef4"), new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samin2" },
                    { new Guid("ab08d369-3d9b-432e-7b69-08dac318037d"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("794f9d2a-b884-44c6-a36a-f35d8a3b8368"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hallo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "Id",
                keyValue: new Guid("15dc6496-95a4-48ec-a0fa-08dac3136953"));

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "Id",
                keyValue: new Guid("3c9e7381-3bd7-4dfa-a0fb-08dac3136953"));

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "Id",
                keyValue: new Guid("7594f0c8-e28c-489a-a0fc-08dac3136953"));

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "Id",
                keyValue: new Guid("ab08d369-3d9b-432e-7b69-08dac318037d"));
        }
    }
}
