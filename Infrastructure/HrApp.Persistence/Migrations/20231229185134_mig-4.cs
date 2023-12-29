using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "664a0e0c-aa4e-4ca5-9959-8c068cf606f4");

            migrationBuilder.DeleteData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cb83f72-898d-440d-8745-e662a4a0c8c4", "cda5dda9-2310-4324-8704-1d81370405a7", "Admin", null });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Erkek" },
                    { 2, "Kadın" }
                });

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "NumDays" },
                values: new object[] { "Evlilik", 3 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "9b2433c0-f90f-47b0-9c77-775eec58a4cd", 0, "address1231231231232", "Istanbul", new DateTime(1993, 12, 29, 21, 51, 34, 36, DateTimeKind.Local).AddTicks(1179), "KOC", "0f461f3a-5a38-4be2-9302-3c595ce40bc7", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEGUrUWTTdoA95VFZcowSaua2OAfwSACM7Bgtxx/WF3M0zq8VlJz27KsyjKAKnhzXZg==", null, false, 20000m, null, null, "398ab1fd-a465-4436-b6ae-f94c190992d7", new DateTime(2013, 12, 29, 21, 51, 34, 36, DateTimeKind.Local).AddTicks(1189), "usersurname", "11111111111", false, "user1", 0m, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "a09e53d6-542e-4dcb-8869-b106cb1d2269", 0, "adminaddress1231231231232", "Ankara", new DateTime(1973, 12, 29, 21, 51, 34, 37, DateTimeKind.Local).AddTicks(1481), "KOC", "37c1839e-0eb9-43fe-a6a1-a693ba7cdc6b", "PATRON", "admin@gmail.com", true, null, 1, null, false, null, "5325323232", "adminname", "ADMIN@GMAIL.COM", "ADMIN", "PATRON", "AQAAAAEAACcQAAAAEMVICnVELlyr6tKz9pSv8AQiFsmF/AMsYgyAyfXGvC/Xs5O0/UQlAwctyvSaofmZ0g==", null, false, 500000m, null, null, "3f1f23a9-33c7-46c3-9380-a8d4f76f2115", new DateTime(2008, 12, 29, 21, 51, 34, 37, DateTimeKind.Local).AddTicks(1482), "adminsurname", "22222222222", false, "admin", 0m, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7cb83f72-898d-440d-8745-e662a4a0c8c4", "a09e53d6-542e-4dcb-8869-b106cb1d2269" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gender_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gender_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7cb83f72-898d-440d-8745-e662a4a0c8c4", "a09e53d6-542e-4dcb-8869-b106cb1d2269" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b2433c0-f90f-47b0-9c77-775eec58a4cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cb83f72-898d-440d-8745-e662a4a0c8c4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09e53d6-542e-4dcb-8869-b106cb1d2269");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[] { "664a0e0c-aa4e-4ca5-9959-8c068cf606f4", 0, "address1231231231232", "Mom", new DateTime(1993, 12, 28, 16, 10, 48, 481, DateTimeKind.Local).AddTicks(1408), "KOC", "df9fcd3f-0cb7-4e70-94d2-cf22455b6bbd", "IT", "user@gmail.com", true, null, null, false, null, "0555555555", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEADi23anjSzu6VkQ/6H37peZUAv5e0MHqO3zBBxack1WawrleG2Zn+qOiSBTlehCbQ==", null, false, 20000m, null, null, "acd5ee1b-cfb0-4d52-8a2f-afd7e844367a", new DateTime(2013, 12, 28, 16, 10, 48, 481, DateTimeKind.Local).AddTicks(1429), "usersurname", "11111111111", false, "user1", 0m, 0 });

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "NumDays" },
                values: new object[] { "Mazeret", 10 });

            migrationBuilder.InsertData(
                table: "LeaveType",
                columns: new[] { "Id", "Name", "NumDays" },
                values: new object[] { 6, "Evlilik", 3 });
        }
    }
}
