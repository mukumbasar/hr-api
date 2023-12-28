using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aed66109-009f-42b3-9e3d-37f4b4038119");

            migrationBuilder.AddColumn<int>(
                name: "NumDays",
                table: "LeaveType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "66a2ec95-39e5-4e11-910e-bd43433a0877", 0, "address1231231231232", "Mom", new DateTime(1993, 12, 28, 13, 49, 0, 244, DateTimeKind.Local).AddTicks(5057), "KOC", "111888af-f4c8-44d1-bdfa-7663d4383d49", "IT", "user@gmail.com", true, null, null, false, null, "0555555555", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEHbHvKQDQ9mdhU2oOKM11EE/BJKxAKMX+kHY98KlKLdvBuSl031XTvoJW1kMm8HPgA==", null, false, 20000m, null, null, "7d98b023-d508-41b3-87bc-7d60828a1cd8", new DateTime(2013, 12, 28, 13, 49, 0, 244, DateTimeKind.Local).AddTicks(5070), "usersurname", "11111111111", false, "user1", 0m, 0 });

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 1,
                column: "NumDays",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 2,
                column: "NumDays",
                value: 56);

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 3,
                column: "NumDays",
                value: 3);

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 4,
                column: "NumDays",
                value: 5);

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 5,
                column: "NumDays",
                value: 10);

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 6,
                column: "NumDays",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66a2ec95-39e5-4e11-910e-bd43433a0877");

            migrationBuilder.DropColumn(
                name: "NumDays",
                table: "LeaveType");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "aed66109-009f-42b3-9e3d-37f4b4038119", 0, "address1231231231232", "Mom", new DateTime(1993, 12, 28, 12, 52, 58, 703, DateTimeKind.Local).AddTicks(3766), "KOC", "ff9bcecc-e4d8-4c18-8361-acf1adc6a27e", "IT", "user@gmail.com", true, null, null, false, null, "0555555555", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEAt+zPd62N/WxhpvpHje7JijR3Cjic/Vgyj/p2zlZBSsgCMU0aKZZd5WweZDs6SYaQ==", null, false, 20000m, null, null, "0024aa3e-471c-4c5e-afd6-48f8fd029183", new DateTime(2013, 12, 28, 12, 52, 58, 703, DateTimeKind.Local).AddTicks(3779), "usersurname", "11111111111", false, "user1", 0m, 0 });
        }
    }
}
