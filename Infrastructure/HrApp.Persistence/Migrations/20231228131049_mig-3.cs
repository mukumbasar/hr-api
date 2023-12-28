using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66a2ec95-39e5-4e11-910e-bd43433a0877");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Leave",
                newName: "NumDays");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "664a0e0c-aa4e-4ca5-9959-8c068cf606f4", 0, "address1231231231232", "Mom", new DateTime(1993, 12, 28, 16, 10, 48, 481, DateTimeKind.Local).AddTicks(1408), "KOC", "df9fcd3f-0cb7-4e70-94d2-cf22455b6bbd", "IT", "user@gmail.com", true, null, null, false, null, "0555555555", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEADi23anjSzu6VkQ/6H37peZUAv5e0MHqO3zBBxack1WawrleG2Zn+qOiSBTlehCbQ==", null, false, 20000m, null, null, "acd5ee1b-cfb0-4d52-8a2f-afd7e844367a", new DateTime(2013, 12, 28, 16, 10, 48, 481, DateTimeKind.Local).AddTicks(1429), "usersurname", "11111111111", false, "user1", 0m, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "664a0e0c-aa4e-4ca5-9959-8c068cf606f4");

            migrationBuilder.RenameColumn(
                name: "NumDays",
                table: "Leave",
                newName: "Amount");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "66a2ec95-39e5-4e11-910e-bd43433a0877", 0, "address1231231231232", "Mom", new DateTime(1993, 12, 28, 13, 49, 0, 244, DateTimeKind.Local).AddTicks(5057), "KOC", "111888af-f4c8-44d1-bdfa-7663d4383d49", "IT", "user@gmail.com", true, null, null, false, null, "0555555555", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEHbHvKQDQ9mdhU2oOKM11EE/BJKxAKMX+kHY98KlKLdvBuSl031XTvoJW1kMm8HPgA==", null, false, 20000m, null, null, "7d98b023-d508-41b3-87bc-7d60828a1cd8", new DateTime(2013, 12, 28, 13, 49, 0, 244, DateTimeKind.Local).AddTicks(5070), "usersurname", "11111111111", false, "user1", 0m, 0 });
        }
    }
}
