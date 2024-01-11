using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.Migrations
{
    public partial class mig13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bc393177-e917-4e1e-8b37-fb42a1f6a6a7", "7dc571ac-07c5-4f6e-bdd0-3fc8303112db" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "cd131289-4c0d-47d3-8b37-8069e6d8ece8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28fb4f54-9fd7-4bc6-a565-c6640a534d3b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f2c79b7-f774-436f-bb4a-27bcaaa134e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc393177-e917-4e1e-8b37-fb42a1f6a6a7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7dc571ac-07c5-4f6e-bdd0-3fc8303112db");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd131289-4c0d-47d3-8b37-8069e6d8ece8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "722d01b9-5dfa-4795-a8ae-efc8f8b71a1f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62e90be7-9942-4c31-9923-86ba0cafba13", "29cec39b-1430-42a5-8bd7-dd76a946ce9f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyId", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[,]
                {
                    { "7ba9de78-27ed-4689-b4ee-eae290c65212", 0, "address1231231231232", "Istanbul", new DateTime(1994, 1, 11, 23, 52, 31, 359, DateTimeKind.Local).AddTicks(4612), 2, "156ddc0a-1214-4623-827c-67b6d390a5c9", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAENbfIX4PXkh7hWwfRn3TfVCvowiR+Z9MqXhI3cAnl/DTmdEZSrOT/fP619J/EBn6SA==", null, false, 20000m, null, null, "26b04f68-2c01-4019-82e6-33b62284086a", new DateTime(2014, 1, 11, 23, 52, 31, 359, DateTimeKind.Local).AddTicks(4630), "usersurname", "11111111111", false, "user1", 40000m, 20 },
                    { "87dbdd45-6efc-44e1-8526-5772b145ff1f", 0, "adminaddress1231231231232", "Ankara", new DateTime(1974, 1, 11, 23, 52, 31, 362, DateTimeKind.Local).AddTicks(3609), 1, "f9c59715-f42c-4492-a508-c6124a758b7b", "PATRON", "admin@gmail.com", true, null, 1, null, false, null, "5325323232", "adminname", "ADMIN@GMAIL.COM", "ADMIN", "PATRON", "AQAAAAEAACcQAAAAEPdD2DyQxNTg/aHT2V/DQWTFXcOOwhI2hbSh2UVBP0o7A9kegicvIq6Zr2BUrAKLbQ==", null, false, 500000m, null, null, "595f593c-0675-4fc6-9f14-3c19af2c6326", new DateTime(2009, 1, 11, 23, 52, 31, 362, DateTimeKind.Local).AddTicks(3610), "adminsurname", "22222222222", false, "admin", 40000m, 20 },
                    { "95bf72c4-a923-49f0-9474-0bd47e07504d", 0, "webadminaddress1231231231232", "Ank", new DateTime(1994, 1, 11, 23, 52, 31, 361, DateTimeKind.Local).AddTicks(4283), 2, "820dc388-addf-4fe0-95cc-90719c03aa42", "IT", "webadmin@gmail.com", true, null, 2, null, false, null, "5554443322", "webadmin", "WEBADMIN@GMAIL.COM", "WEBADMIN", "Formatçı", "AQAAAAEAACcQAAAAEFe5cw3M3Gy0TRWohH/FoMJNPK3L4XZ0I8pWRfhBAKEh3IY84yVXUuBASxx3qmPl6Q==", null, false, 20000m, null, null, "61f7e64b-9e96-45df-b4f0-b2ecb6ee8736", new DateTime(2014, 1, 11, 23, 52, 31, 361, DateTimeKind.Local).AddTicks(4287), "webadminname", "11111111111", false, "webadmin", 40000m, 20 },
                    { "e26b22d9-bf40-4162-941c-d80c8522be32", 0, "address1231231231232", "Ankara", new DateTime(1994, 1, 11, 23, 52, 31, 360, DateTimeKind.Local).AddTicks(4209), 1, "d170c4d0-c557-44b8-a137-dccc5df1905f", "IT", "user2@gmail.com", true, null, 2, null, false, null, "5554443322", "user2", "USER2@GMAIL.COM", "USER2", "Formatçı", "AQAAAAEAACcQAAAAEEFK6MUFHPft8Si2yr0Mycbl60VRXjhV0f24M14WiQPqw65BYcPgMzRcjaftOe5DiQ==", null, false, 20000m, null, null, "8c9dfeae-2701-441a-bba9-b1b1ff8d51f1", new DateTime(2014, 1, 11, 23, 52, 31, 360, DateTimeKind.Local).AddTicks(4210), "user2surname", "11111111111", false, "user2", 40000m, 20 }
                });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExceptionTime",
                value: new DateTime(2024, 1, 11, 23, 52, 31, 363, DateTimeKind.Local).AddTicks(3208));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "62e90be7-9942-4c31-9923-86ba0cafba13", "87dbdd45-6efc-44e1-8526-5772b145ff1f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "95bf72c4-a923-49f0-9474-0bd47e07504d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "62e90be7-9942-4c31-9923-86ba0cafba13", "87dbdd45-6efc-44e1-8526-5772b145ff1f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "95bf72c4-a923-49f0-9474-0bd47e07504d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ba9de78-27ed-4689-b4ee-eae290c65212");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e26b22d9-bf40-4162-941c-d80c8522be32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62e90be7-9942-4c31-9923-86ba0cafba13");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87dbdd45-6efc-44e1-8526-5772b145ff1f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95bf72c4-a923-49f0-9474-0bd47e07504d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2b4a4226-63aa-4259-a431-752ef99b61d0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bc393177-e917-4e1e-8b37-fb42a1f6a6a7", "baac6b24-611f-4d58-a4ba-ec74a48e7a56", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyId", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[,]
                {
                    { "28fb4f54-9fd7-4bc6-a565-c6640a534d3b", 0, "address1231231231232", "Ankara", new DateTime(1994, 1, 10, 22, 41, 17, 761, DateTimeKind.Local).AddTicks(671), 1, "f996c44e-e812-4caf-9976-9f28d52cafd5", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user2", "USER@GMAIL.COM", "USER2", "Formatçı", null, null, false, 20000m, null, null, "0128fdbf-7359-4ad3-ba14-e1381b5ca5f1", new DateTime(2014, 1, 10, 22, 41, 17, 761, DateTimeKind.Local).AddTicks(674), "user2surname", "11111111111", false, "user2", 40000m, 20 },
                    { "7dc571ac-07c5-4f6e-bdd0-3fc8303112db", 0, "adminaddress1231231231232", "Ankara", new DateTime(1974, 1, 10, 22, 41, 17, 763, DateTimeKind.Local).AddTicks(665), 1, "64047ccb-2db4-4ee3-9dad-8585162d85ca", "PATRON", "admin@gmail.com", true, null, 1, null, false, null, "5325323232", "adminname", "ADMIN@GMAIL.COM", "ADMIN", "PATRON", "AQAAAAEAACcQAAAAEIhy91fup2dDsWiihVTxjoV+BUTgYpgUNtXUED2uNynErvzkxS3mhCUmt3EoLkkO8g==", null, false, 500000m, null, null, "16415e4d-a773-4dbc-b4bb-ed124881c9ab", new DateTime(2009, 1, 10, 22, 41, 17, 763, DateTimeKind.Local).AddTicks(667), "adminsurname", "22222222222", false, "admin", 40000m, 20 },
                    { "7f2c79b7-f774-436f-bb4a-27bcaaa134e4", 0, "address1231231231232", "Istanbul", new DateTime(1994, 1, 10, 22, 41, 17, 759, DateTimeKind.Local).AddTicks(9072), 2, "212f2f4a-a4b8-45a0-88e1-d1d95c514aff", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEHc6PPxktw7ly6lF349aUj09ZpkbwiWD6IOeeymOXXh5N37cA11klBuHqd27hAPD7g==", null, false, 20000m, null, null, "142f830d-dc48-462f-b773-09437040d13d", new DateTime(2014, 1, 10, 22, 41, 17, 759, DateTimeKind.Local).AddTicks(9086), "usersurname", "11111111111", false, "user1", 40000m, 20 },
                    { "cd131289-4c0d-47d3-8b37-8069e6d8ece8", 0, "webadminaddress1231231231232", "Ank", new DateTime(1994, 1, 10, 22, 41, 17, 762, DateTimeKind.Local).AddTicks(600), 2, "97fda14e-d580-4e32-b40e-214ecaa1e183", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "webadmin", "USER@GMAIL.COM", "WEBADMIN", "Formatçı", null, null, false, 20000m, null, null, "2a629d8b-4bcc-4cdc-9a8f-63dfe85a36a8", new DateTime(2014, 1, 10, 22, 41, 17, 762, DateTimeKind.Local).AddTicks(601), "webadminname", "11111111111", false, "webadmin", 40000m, 20 }
                });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExceptionTime",
                value: new DateTime(2024, 1, 10, 22, 41, 17, 764, DateTimeKind.Local).AddTicks(729));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bc393177-e917-4e1e-8b37-fb42a1f6a6a7", "7dc571ac-07c5-4f6e-bdd0-3fc8303112db" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "cd131289-4c0d-47d3-8b37-8069e6d8ece8" });
        }
    }
}
