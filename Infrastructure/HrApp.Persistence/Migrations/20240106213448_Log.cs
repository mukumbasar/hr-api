using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.Migrations
{
    public partial class Log : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a6093bb0-3d6c-46fd-a83f-8cc8709094fd", "5044c498-2d3c-4aab-b08c-da4277d87e15" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f64ec7c2-3104-4c8a-8605-181f9d922913");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6093bb0-3d6c-46fd-a83f-8cc8709094fd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5044c498-2d3c-4aab-b08c-da4277d87e15");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "a6093bb0-3d6c-46fd-a83f-8cc8709094fd", "2fce43f5-d4fa-414f-aa5a-581a8936f988", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "5044c498-2d3c-4aab-b08c-da4277d87e15", 0, "adminaddress1231231231232", "Ankara", new DateTime(1974, 1, 3, 11, 32, 0, 637, DateTimeKind.Local).AddTicks(7069), "KOC", "db0a8755-677a-49bc-ac07-b5e68c0964f4", "PATRON", "admin@gmail.com", true, null, 1, null, false, null, "5325323232", "adminname", "ADMIN@GMAIL.COM", "ADMIN", "PATRON", "AQAAAAEAACcQAAAAEB0DWxeMSV5pM0f8W0C8qWnvvf3yd2w2Ok5CYXNKar/lEJr2HGmqvNgL2wGIcJW06A==", null, false, 500000m, null, null, "2d6ac3d7-d214-426d-a6b6-132cf57e0381", new DateTime(2009, 1, 3, 11, 32, 0, 637, DateTimeKind.Local).AddTicks(7082), "adminsurname", "22222222222", false, "admin", 0m, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "f64ec7c2-3104-4c8a-8605-181f9d922913", 0, "address1231231231232", "Istanbul", new DateTime(1994, 1, 3, 11, 32, 0, 628, DateTimeKind.Local).AddTicks(2597), "KOC", "fb572aba-19e0-4a0f-9e8b-367a7ca2d710", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEE9dMjsXDht1cB8Ww9XRJZyaQ4+3pMZLexF3MSEU4kr/Og/hV/IVGXeeLQJx/h6qmw==", null, false, 20000m, null, null, "082a0376-a964-4664-af9a-0d47a0cb9337", new DateTime(2014, 1, 3, 11, 32, 0, 628, DateTimeKind.Local).AddTicks(2613), "usersurname", "11111111111", false, "user1", 0m, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a6093bb0-3d6c-46fd-a83f-8cc8709094fd", "5044c498-2d3c-4aab-b08c-da4277d87e15" });
        }
    }
}
