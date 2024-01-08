using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Log",
                table: "Log");

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

            migrationBuilder.RenameTable(
                name: "Log",
                newName: "Logs");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CompanyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MersisNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxOffice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCount = table.Column<int>(type: "int", nullable: false),
                    FoundationYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CompanyTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_CompanyType_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "CompanyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AdvanceType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Individual");

            migrationBuilder.UpdateData(
                table: "AdvanceType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Corporate");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "090b7410-fa03-4c1b-bcaa-7eea3914ca47", "9b423215-a842-4579-891b-2d3bffab40e0", "Admin", "ADMIN" },
                    { "2", "98a877c5-72ae-40f7-b4b0-d60a37ef8118", "WebsiteManager", "WEBSITEMANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyId", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[,]
                {
                    { "201bcc2f-b7cf-41f3-a84f-262542067522", 0, "adminaddress1231231231232", "Ankara", new DateTime(1974, 1, 8, 15, 18, 13, 987, DateTimeKind.Local).AddTicks(8129), null, "KOC", "b3df58e2-df3f-46b3-a037-61cae8d176fe", "PATRON", "admin@gmail.com", true, null, 1, null, false, null, "5325323232", "adminname", "ADMIN@GMAIL.COM", "ADMIN", "PATRON", "AQAAAAEAACcQAAAAEF17haT15Y02KYgpc42yiD2+k1nd+5jhnIvF3rElVomZzWqHFiELMKTQIpJT+hciKg==", null, false, 500000m, null, null, "9d870f5b-5313-48cd-9a44-40cc7abb2169", new DateTime(2009, 1, 8, 15, 18, 13, 987, DateTimeKind.Local).AddTicks(8130), "adminsurname", "22222222222", false, "admin", 40000m, 20 },
                    { "56a4456f-3e86-4699-b02e-a6db5642ab02", 0, "address1231231231232", "Istanbul", new DateTime(1994, 1, 8, 15, 18, 13, 986, DateTimeKind.Local).AddTicks(8669), null, "KOC", "020d90d9-1e38-42cf-84cf-0fb461129820", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEB3Uz35IMq/+W+89QtDNP1jJNEVKnwl24GvBPsQosmcCLkWiKvjYEdqcHq1WqRf2xw==", null, false, 20000m, null, null, "894218d0-c982-4b92-9eea-d56d19899e2e", new DateTime(2014, 1, 8, 15, 18, 13, 986, DateTimeKind.Local).AddTicks(8681), "usersurname", "11111111111", false, "user1", 40000m, 20 }
                });

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Food and Beverage");

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Education");

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Accommodation");

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Travel");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Other");

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Annual");

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Maternity");

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Bereavement");

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Paternity");

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Marriage");

            migrationBuilder.UpdateData(
                table: "LeaveTypeFocus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "LeaveTypeFocus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "LeaveTypeFocus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Everyone");

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExceptionMessage", "ExceptionMethod", "ExceptionPath", "ExceptionTime" },
                values: new object[] { "Test Exception", "N/A", "N/A", new DateTime(2024, 1, 8, 15, 18, 13, 988, DateTimeKind.Local).AddTicks(7743) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "090b7410-fa03-4c1b-bcaa-7eea3914ca47", "201bcc2f-b7cf-41f3-a84f-262542067522" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyTypeId",
                table: "Company",
                column: "CompanyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "CompanyType");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

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

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "Log");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Log",
                table: "Log",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AdvanceType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Bireysel");

            migrationBuilder.UpdateData(
                table: "AdvanceType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Kurumsal");

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

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Yeme-içme");

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Eğitim");

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Konaklama");

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Seyahat");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Erkek");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Kadın");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Diğer");

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Yıllık");

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Doğum");

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Ölüm");

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Babalık");

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Evlilik");

            migrationBuilder.UpdateData(
                table: "LeaveTypeFocus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Erkek");

            migrationBuilder.UpdateData(
                table: "LeaveTypeFocus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Kadın");

            migrationBuilder.UpdateData(
                table: "LeaveTypeFocus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Herkes");

            migrationBuilder.UpdateData(
                table: "Log",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExceptionMessage", "ExceptionMethod", "ExceptionPath", "ExceptionTime" },
                values: new object[] { "burak", "siki", "tuttu", new DateTime(2024, 1, 7, 0, 54, 19, 881, DateTimeKind.Local).AddTicks(5821) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "334f2cb0-c7b4-4b4e-bdab-4ceb905365eb", "13adc82e-e85e-457a-b84c-6bdbfa27253a" });
        }
    }
}
