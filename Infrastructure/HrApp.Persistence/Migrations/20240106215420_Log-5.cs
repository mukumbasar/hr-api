using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.Migrations
{
    public partial class Log5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "334f2cb0-c7b4-4b4e-bdab-4ceb905365eb", "d616fa2c-618d-44fe-9430-7cb1b469cde6", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[,]
                {
                    { "13adc82e-e85e-457a-b84c-6bdbfa27253a", 0, "adminaddress1231231231232", "Ankara", new DateTime(1974, 1, 7, 0, 54, 19, 880, DateTimeKind.Local).AddTicks(3140), "KOC", "de8e8a11-69af-42f4-bb52-ee173bbcaab2", "PATRON", "admin@gmail.com", true, null, 1, null, false, null, "5325323232", "adminname", "ADMIN@GMAIL.COM", "ADMIN", "PATRON", "AQAAAAEAACcQAAAAEHItO8KqKoA+1JoK0Q2/dNMyRWn2ui76UlSJLjizO6IEAcAQ9tOsqiJdGluRswuEKg==", null, false, 500000m, null, null, "ae64279f-6d02-4add-bc42-aec59535af7b", new DateTime(2009, 1, 7, 0, 54, 19, 880, DateTimeKind.Local).AddTicks(3141), "adminsurname", "22222222222", false, "admin", 40000m, 20 },
                    { "5d7948eb-de7f-46a8-98ee-6f75981f79c1", 0, "address1231231231232", "Istanbul", new DateTime(1994, 1, 7, 0, 54, 19, 879, DateTimeKind.Local).AddTicks(3669), "KOC", "1e792d31-cbd5-4b9a-8208-c075aa9cfd47", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEOK9fm0QrwD5O3wc+CIoRaSQukhgsi72PEbrAvmk9A5fCRhQM0Xy55CoDAnee2L0qQ==", null, false, 20000m, null, null, "df316aaf-734d-4856-b949-5fbce0c6d19d", new DateTime(2014, 1, 7, 0, 54, 19, 879, DateTimeKind.Local).AddTicks(3677), "usersurname", "11111111111", false, "user1", 40000m, 20 }
                });

            migrationBuilder.InsertData(
                table: "Log",
                columns: new[] { "Id", "ExceptionMessage", "ExceptionMethod", "ExceptionPath", "ExceptionTime" },
                values: new object[] { 1, "burak", "siki", "tuttu", new DateTime(2024, 1, 7, 0, 54, 19, 881, DateTimeKind.Local).AddTicks(5821) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "334f2cb0-c7b4-4b4e-bdab-4ceb905365eb", "13adc82e-e85e-457a-b84c-6bdbfa27253a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "334f2cb0-c7b4-4b4e-bdab-4ceb905365eb", "13adc82e-e85e-457a-b84c-6bdbfa27253a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d7948eb-de7f-46a8-98ee-6f75981f79c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "334f2cb0-c7b4-4b4e-bdab-4ceb905365eb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13adc82e-e85e-457a-b84c-6bdbfa27253a");

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
    }
}
