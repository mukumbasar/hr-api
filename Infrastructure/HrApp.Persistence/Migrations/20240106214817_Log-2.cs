using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.Migrations
{
    public partial class Log2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fd2ce27d-1ed9-44b7-ae52-08460b72bffd", "5a8817a3-747f-4a69-a55e-0963bc26a876" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a206642b-26d0-4fdb-8273-d7ebb7a943c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd2ce27d-1ed9-44b7-ae52-08460b72bffd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a8817a3-747f-4a69-a55e-0963bc26a876");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfc85b86-5752-440e-86fe-1e76b290c151", "d951aa8f-65ae-483f-a447-e32efa038864", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "13cb8d09-4615-47ea-99df-4ff08481ebf8", 0, "adminaddress1231231231232", "Ankara", new DateTime(1974, 1, 7, 0, 48, 16, 758, DateTimeKind.Local).AddTicks(8005), "KOC", "437d2e06-4a02-4814-9e31-7d82ba26b6bf", "PATRON", "admin@gmail.com", true, null, 1, null, false, null, "5325323232", "adminname", "ADMIN@GMAIL.COM", "ADMIN", "PATRON", "AQAAAAEAACcQAAAAEHl3FI2De69KBMoZFhEDAMGnEbMnvjVMBWG9duQMG85whlYlZw9zi5Ln88VohqyxxA==", null, false, 500000m, null, null, "925dc37c-bf90-471f-bf76-a957830395f8", new DateTime(2009, 1, 7, 0, 48, 16, 758, DateTimeKind.Local).AddTicks(8007), "adminsurname", "22222222222", false, "admin", 40000m, 20 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "6fb924cc-ceac-4b16-ab71-e8e9f33c998b", 0, "address1231231231232", "Istanbul", new DateTime(1994, 1, 7, 0, 48, 16, 757, DateTimeKind.Local).AddTicks(8561), "KOC", "ac1ecd0e-0a02-4578-acd4-5f7bd5addf3d", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAELUiDnKZhUTGZAPnoabXWAlU+pDsiZGiTD/y++1d1Vye8GM9JNfYjIZKFu+sQ6Ueqg==", null, false, 20000m, null, null, "ebd3520b-9c35-4de3-bd84-c2cfa6c3808c", new DateTime(2014, 1, 7, 0, 48, 16, 757, DateTimeKind.Local).AddTicks(8572), "usersurname", "11111111111", false, "user1", 40000m, 20 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfc85b86-5752-440e-86fe-1e76b290c151", "13cb8d09-4615-47ea-99df-4ff08481ebf8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfc85b86-5752-440e-86fe-1e76b290c151", "13cb8d09-4615-47ea-99df-4ff08481ebf8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6fb924cc-ceac-4b16-ab71-e8e9f33c998b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfc85b86-5752-440e-86fe-1e76b290c151");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13cb8d09-4615-47ea-99df-4ff08481ebf8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd2ce27d-1ed9-44b7-ae52-08460b72bffd", "1264c2c5-6fc0-4bc7-965d-d889c75361ea", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "5a8817a3-747f-4a69-a55e-0963bc26a876", 0, "adminaddress1231231231232", "Ankara", new DateTime(1974, 1, 7, 0, 34, 47, 814, DateTimeKind.Local).AddTicks(178), "KOC", "ae2cb8cd-ff57-456b-b0f4-a28d0ee1fd7a", "PATRON", "admin@gmail.com", true, null, 1, null, false, null, "5325323232", "adminname", "ADMIN@GMAIL.COM", "ADMIN", "PATRON", "AQAAAAEAACcQAAAAEGw1HikOuf/G4I3Cn4KOFFAwgxdNlaL745+H5InlYDA8/QdxyunaE3GZHVmSTrf7JQ==", null, false, 500000m, null, null, "c7eb0e46-f8da-4428-b2fc-0fa3750d7941", new DateTime(2009, 1, 7, 0, 34, 47, 814, DateTimeKind.Local).AddTicks(180), "adminsurname", "22222222222", false, "admin", 40000m, 20 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "a206642b-26d0-4fdb-8273-d7ebb7a943c1", 0, "address1231231231232", "Istanbul", new DateTime(1994, 1, 7, 0, 34, 47, 813, DateTimeKind.Local).AddTicks(327), "KOC", "79871e11-abba-4abe-a9ee-5eaf5a7265a0", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEEHyC1u93sRPaHLqYBazQfnEovi795WKf3Ytesr3n+JYDdpdPPBix+68HSxMSkqn0g==", null, false, 20000m, null, null, "cb4c800a-9c23-4159-bd7f-af78c440a71b", new DateTime(2014, 1, 7, 0, 34, 47, 813, DateTimeKind.Local).AddTicks(336), "usersurname", "11111111111", false, "user1", 40000m, 20 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fd2ce27d-1ed9-44b7-ae52-08460b72bffd", "5a8817a3-747f-4a69-a55e-0963bc26a876" });
        }
    }
}
