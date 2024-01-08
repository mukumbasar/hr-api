using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.Migrations
{
    public partial class Log4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f214a544-9e44-45b0-ae6a-2c0af3eacfe5", "459218c7-612c-403a-be2b-ad49c54b39cc" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5083b60-5943-421c-b693-03457f7ee5d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f214a544-9e44-45b0-ae6a-2c0af3eacfe5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "459218c7-612c-403a-be2b-ad49c54b39cc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fbc8d05e-fbd7-4e04-92be-3c99148ea94e", "661075e7-bae1-4a06-9735-c0155bd6457b", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "aa56d33a-026a-4538-8d32-9612dbd8dd43", 0, "address1231231231232", "Istanbul", new DateTime(1994, 1, 7, 0, 51, 53, 454, DateTimeKind.Local).AddTicks(717), "KOC", "a6407f6e-89d6-4330-98d7-dcbf726ad3b4", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEA0ae7jTTTWbSVHjfZeUqrl+MnGp9hhfW50VxA/f15AhEwAZ0V9UyiAWsxyLee2uIw==", null, false, 20000m, null, null, "ba2e7574-3d6b-4259-94b2-02d25f475176", new DateTime(2014, 1, 7, 0, 51, 53, 454, DateTimeKind.Local).AddTicks(729), "usersurname", "11111111111", false, "user1", 40000m, 20 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "c9d7f449-5b7d-40a5-9436-acf7f6f6f9c9", 0, "adminaddress1231231231232", "Ankara", new DateTime(1974, 1, 7, 0, 51, 53, 455, DateTimeKind.Local).AddTicks(3277), "KOC", "ca02cc73-2e7c-41fb-8777-84788c7287de", "PATRON", "admin@gmail.com", true, null, 1, null, false, null, "5325323232", "adminname", "ADMIN@GMAIL.COM", "ADMIN", "PATRON", "AQAAAAEAACcQAAAAEBqYQLWxk16E5HNz9FqdguW9093EKhZUkqvrHroaNdT+nyJSWeNbFubKv/cFHlnWmw==", null, false, 500000m, null, null, "d6e8b8e3-7e88-4c95-984a-793f001eb506", new DateTime(2009, 1, 7, 0, 51, 53, 455, DateTimeKind.Local).AddTicks(3280), "adminsurname", "22222222222", false, "admin", 40000m, 20 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fbc8d05e-fbd7-4e04-92be-3c99148ea94e", "c9d7f449-5b7d-40a5-9436-acf7f6f6f9c9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fbc8d05e-fbd7-4e04-92be-3c99148ea94e", "c9d7f449-5b7d-40a5-9436-acf7f6f6f9c9" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa56d33a-026a-4538-8d32-9612dbd8dd43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbc8d05e-fbd7-4e04-92be-3c99148ea94e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9d7f449-5b7d-40a5-9436-acf7f6f6f9c9");

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f214a544-9e44-45b0-ae6a-2c0af3eacfe5", "c9fd89b0-2831-4157-a48d-6f35609a47c6", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[,]
                {
                    { "459218c7-612c-403a-be2b-ad49c54b39cc", 0, "adminaddress1231231231232", "Ankara", new DateTime(1974, 1, 7, 0, 50, 37, 790, DateTimeKind.Local).AddTicks(6546), "KOC", "cf880f5d-18bc-4660-997f-557a8bfc1adf", "PATRON", "admin@gmail.com", true, null, 1, null, false, null, "5325323232", "adminname", "ADMIN@GMAIL.COM", "ADMIN", "PATRON", "AQAAAAEAACcQAAAAEJdfgOuPl8rJYX3XOMb+vCwmMXKXaSzdBdskQjLzYs3CgSrSW3JtPXEBTb5sX90N/A==", null, false, 500000m, null, null, "a9df7917-5bff-4150-8b67-b9c984ce28da", new DateTime(2009, 1, 7, 0, 50, 37, 790, DateTimeKind.Local).AddTicks(6547), "adminsurname", "22222222222", false, "admin", 40000m, 20 },
                    { "c5083b60-5943-421c-b693-03457f7ee5d5", 0, "address1231231231232", "Istanbul", new DateTime(1994, 1, 7, 0, 50, 37, 789, DateTimeKind.Local).AddTicks(6947), "KOC", "e0314c99-77c7-423b-bed7-0ca5f98f35bf", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEMZ6A/RcFWTZpVwkaZHBfImxYSUbqm+QO/ONLLuOKbdt3JLnbGjz0RtlxVkMVe7s9A==", null, false, 20000m, null, null, "2657597a-ef21-4ad7-b3a0-840460f3e056", new DateTime(2014, 1, 7, 0, 50, 37, 789, DateTimeKind.Local).AddTicks(6957), "usersurname", "11111111111", false, "user1", 40000m, 20 }
                });

            migrationBuilder.InsertData(
                table: "Log",
                columns: new[] { "Id", "ExceptionMessage", "ExceptionMethod", "ExceptionPath", "ExceptionTime" },
                values: new object[] { 1, "burak", "siki", "tuttu", new DateTime(2024, 1, 7, 0, 50, 37, 791, DateTimeKind.Local).AddTicks(9411) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f214a544-9e44-45b0-ae6a-2c0af3eacfe5", "459218c7-612c-403a-be2b-ad49c54b39cc" });
        }
    }
}
