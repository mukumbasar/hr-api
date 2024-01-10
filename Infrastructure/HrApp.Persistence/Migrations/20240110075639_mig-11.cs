using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "090b7410-fa03-4c1b-bcaa-7eea3914ca47", "201bcc2f-b7cf-41f3-a84f-262542067522" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "56a4456f-3e86-4699-b02e-a6db5642ab02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "090b7410-fa03-4c1b-bcaa-7eea3914ca47");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "201bcc2f-b7cf-41f3-a84f-262542067522");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "19269b9e-136c-4d30-883f-fa2ffb011ca4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8c4f993-9672-4261-b6ac-ebd546239bcd", "47763abd-0d48-472c-8717-f655519b5ac9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyId", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[,]
                {
                    { "7a115d7d-3d13-490c-9bc3-cd9f81275b9a", 0, "address1231231231232", "Istanbul", new DateTime(1994, 1, 10, 10, 56, 39, 210, DateTimeKind.Local).AddTicks(6081), null, "KOC", "f5be3672-5253-4750-84b3-60828884a28a", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEPeRGjYdaAckjQs8XoW+iVC1aw+UmZUOuKS4gXm7F5XdkDsaBKG6jTZzJeDw7MfSYg==", null, false, 20000m, null, null, "1f4f8dad-a5aa-4865-9fb8-c8d7f528b8ae", new DateTime(2014, 1, 10, 10, 56, 39, 210, DateTimeKind.Local).AddTicks(6091), "usersurname", "11111111111", false, "user1", 40000m, 20 },
                    { "edfb8623-b946-4462-b096-69266f6fee1d", 0, "adminaddress1231231231232", "Ankara", new DateTime(1974, 1, 10, 10, 56, 39, 211, DateTimeKind.Local).AddTicks(5959), null, "KOC", "2ec498a5-5e3b-4d4a-b2bc-7addb9dfec70", "PATRON", "admin@gmail.com", true, null, 1, null, false, null, "5325323232", "adminname", "ADMIN@GMAIL.COM", "ADMIN", "PATRON", "AQAAAAEAACcQAAAAEH0S5fNXucYnydDOZn8USXwLzFzomuJjkYHP5DJaEf8jEMnfpMJ4R8mdarvGM32sDA==", null, false, 500000m, null, null, "c18b379a-d188-4d00-b9de-5759cdd0874d", new DateTime(2009, 1, 10, 10, 56, 39, 211, DateTimeKind.Local).AddTicks(5960), "adminsurname", "22222222222", false, "admin", 40000m, 20 }
                });

            migrationBuilder.InsertData(
                table: "CompanyType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Limited" },
                    { 2, "Anonim" },
                    { 3, "Kooperatif" },
                    { 4, "Kollektif" },
                    { 5, "Komandit" },
                    { 6, "Adi" }
                });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExceptionTime",
                value: new DateTime(2024, 1, 10, 10, 56, 39, 212, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f8c4f993-9672-4261-b6ac-ebd546239bcd", "edfb8623-b946-4462-b096-69266f6fee1d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f8c4f993-9672-4261-b6ac-ebd546239bcd", "edfb8623-b946-4462-b096-69266f6fee1d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a115d7d-3d13-490c-9bc3-cd9f81275b9a");

            migrationBuilder.DeleteData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8c4f993-9672-4261-b6ac-ebd546239bcd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edfb8623-b946-4462-b096-69266f6fee1d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "98a877c5-72ae-40f7-b4b0-d60a37ef8118");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "090b7410-fa03-4c1b-bcaa-7eea3914ca47", "9b423215-a842-4579-891b-2d3bffab40e0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyId", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[,]
                {
                    { "201bcc2f-b7cf-41f3-a84f-262542067522", 0, "adminaddress1231231231232", "Ankara", new DateTime(1974, 1, 8, 15, 18, 13, 987, DateTimeKind.Local).AddTicks(8129), null, "KOC", "b3df58e2-df3f-46b3-a037-61cae8d176fe", "PATRON", "admin@gmail.com", true, null, 1, null, false, null, "5325323232", "adminname", "ADMIN@GMAIL.COM", "ADMIN", "PATRON", "AQAAAAEAACcQAAAAEF17haT15Y02KYgpc42yiD2+k1nd+5jhnIvF3rElVomZzWqHFiELMKTQIpJT+hciKg==", null, false, 500000m, null, null, "9d870f5b-5313-48cd-9a44-40cc7abb2169", new DateTime(2009, 1, 8, 15, 18, 13, 987, DateTimeKind.Local).AddTicks(8130), "adminsurname", "22222222222", false, "admin", 40000m, 20 },
                    { "56a4456f-3e86-4699-b02e-a6db5642ab02", 0, "address1231231231232", "Istanbul", new DateTime(1994, 1, 8, 15, 18, 13, 986, DateTimeKind.Local).AddTicks(8669), null, "KOC", "020d90d9-1e38-42cf-84cf-0fb461129820", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEB3Uz35IMq/+W+89QtDNP1jJNEVKnwl24GvBPsQosmcCLkWiKvjYEdqcHq1WqRf2xw==", null, false, 20000m, null, null, "894218d0-c982-4b92-9eea-d56d19899e2e", new DateTime(2014, 1, 8, 15, 18, 13, 986, DateTimeKind.Local).AddTicks(8681), "usersurname", "11111111111", false, "user1", 40000m, 20 }
                });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExceptionTime",
                value: new DateTime(2024, 1, 8, 15, 18, 13, 988, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "090b7410-fa03-4c1b-bcaa-7eea3914ca47", "201bcc2f-b7cf-41f3-a84f-262542067522" });
        }
    }
}
