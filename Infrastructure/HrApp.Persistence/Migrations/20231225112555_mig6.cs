using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64561faf-464b-4c9c-8c01-50f6f74da301");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "ImageData", "IsActive", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName" },
                values: new object[] { "db4a6a28-d39d-4a79-af5a-72b9bafdba74", 0, "address1231231231232", "Mom", new DateTime(1993, 12, 25, 14, 25, 54, 928, DateTimeKind.Local).AddTicks(4098), "KOC", "115c6e23-68dc-482e-979a-10f233298545", "IT", "user@gmail.com", true, null, null, false, false, null, "0555555555", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEK8rBRRSs7HiSzSlAR4YVGOUcV6w962rXTFhUywkAzCt/vf0CUQyZFPyYa1wd6TQSw==", null, false, 20000m, null, null, "609e478b-6c9c-4eb0-8d38-e6deee103ed8", new DateTime(2013, 12, 25, 14, 25, 54, 928, DateTimeKind.Local).AddTicks(4107), "usersurname", "11111111111", false, "user1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db4a6a28-d39d-4a79-af5a-72b9bafdba74");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "ImageData", "IsActive", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName" },
                values: new object[] { "64561faf-464b-4c9c-8c01-50f6f74da301", 0, "address1231231231232", "Mom", new DateTime(1993, 12, 25, 13, 47, 21, 703, DateTimeKind.Local).AddTicks(6193), "KOC", "2aa40e22-a024-40f4-8182-7db9e4b24108", "IT", "user@gmail.com", true, null, null, false, false, null, "0555555555", "user", "ADMIN@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEMoCjL3ztDmGeNj/GiBdGTkipyF05dAPRC89/gYYTWRsUTgNhq/3lc6FVsLB8sHzfg==", null, false, 20000m, null, null, "5d35e8f2-4a2b-4127-8495-afaaba0d9f82", new DateTime(2013, 12, 25, 13, 47, 21, 703, DateTimeKind.Local).AddTicks(6205), "usersurname", "11111111111", false, "user1" });
        }
    }
}
