using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.Migrations
{
    public partial class Log3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExceptionPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
