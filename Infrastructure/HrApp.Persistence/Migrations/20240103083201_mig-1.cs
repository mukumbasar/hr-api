using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvanceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvanceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseType", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "LeaveTypeFocus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypeFocus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurkishIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    YearlyLeaveDaysLeft = table.Column<int>(type: "int", nullable: false),
                    YearlyAdvanceAmountLeft = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumDays = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeFocusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveType_LeaveTypeFocus_LeaveTypeFocusId",
                        column: x => x.LeaveTypeFocusId,
                        principalTable: "LeaveTypeFocus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvanceTypeId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatusId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advance_AdvanceType_AdvanceTypeId",
                        column: x => x.AdvanceTypeId,
                        principalTable: "AdvanceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advance_ApprovalStatus_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalTable: "ApprovalStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advance_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advance_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Document = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ExpenseTypeId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatusId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_ApprovalStatus_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalTable: "ApprovalStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_ExpenseType_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalTable: "ExpenseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumDays = table.Column<int>(type: "int", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatusId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leave_ApprovalStatus_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalTable: "ApprovalStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leave_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leave_LeaveType_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdvanceType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bireysel" },
                    { 2, "Kurumsal" }
                });

            migrationBuilder.InsertData(
                table: "ApprovalStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Waiting..." },
                    { 2, "Approved!" },
                    { 3, "Declined!" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6093bb0-3d6c-46fd-a83f-8cc8709094fd", "2fce43f5-d4fa-414f-aa5a-581a8936f988", "Admin", null });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "₺" },
                    { 2, "€" },
                    { 3, "$" },
                    { 4, "£" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Yeme-içme" },
                    { 2, "Eğitim" },
                    { 3, "Konaklama" },
                    { 4, "Seyahat" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Erkek" },
                    { 2, "Kadın" },
                    { 3, "Diğer" }
                });

            migrationBuilder.InsertData(
                table: "LeaveTypeFocus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Erkek" },
                    { 2, "Kadın" },
                    { 3, "Herkes" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthPlace", "BirthYear", "CompanyName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "EndDate", "GenderId", "ImageData", "LockoutEnabled", "LockoutEnd", "MobileNumber", "Name", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondName", "SecondSurname", "SecurityStamp", "StartDate", "Surname", "TurkishIdentificationNumber", "TwoFactorEnabled", "UserName", "YearlyAdvanceAmountLeft", "YearlyLeaveDaysLeft" },
                values: new object[,]
                {
                    { "5044c498-2d3c-4aab-b08c-da4277d87e15", 0, "adminaddress1231231231232", "Ankara", new DateTime(1974, 1, 3, 11, 32, 0, 637, DateTimeKind.Local).AddTicks(7069), "KOC", "db0a8755-677a-49bc-ac07-b5e68c0964f4", "PATRON", "admin@gmail.com", true, null, 1, null, false, null, "5325323232", "adminname", "ADMIN@GMAIL.COM", "ADMIN", "PATRON", "AQAAAAEAACcQAAAAEB0DWxeMSV5pM0f8W0C8qWnvvf3yd2w2Ok5CYXNKar/lEJr2HGmqvNgL2wGIcJW06A==", null, false, 500000m, null, null, "2d6ac3d7-d214-426d-a6b6-132cf57e0381", new DateTime(2009, 1, 3, 11, 32, 0, 637, DateTimeKind.Local).AddTicks(7082), "adminsurname", "22222222222", false, "admin", 0m, 0 },
                    { "f64ec7c2-3104-4c8a-8605-181f9d922913", 0, "address1231231231232", "Istanbul", new DateTime(1994, 1, 3, 11, 32, 0, 628, DateTimeKind.Local).AddTicks(2597), "KOC", "fb572aba-19e0-4a0f-9e8b-367a7ca2d710", "IT", "user@gmail.com", true, null, 2, null, false, null, "5554443322", "user", "USER@GMAIL.COM", "USER1", "Formatçı", "AQAAAAEAACcQAAAAEE9dMjsXDht1cB8Ww9XRJZyaQ4+3pMZLexF3MSEU4kr/Og/hV/IVGXeeLQJx/h6qmw==", null, false, 20000m, null, null, "082a0376-a964-4664-af9a-0d47a0cb9337", new DateTime(2014, 1, 3, 11, 32, 0, 628, DateTimeKind.Local).AddTicks(2613), "usersurname", "11111111111", false, "user1", 0m, 0 }
                });

            migrationBuilder.InsertData(
                table: "LeaveType",
                columns: new[] { "Id", "LeaveTypeFocusId", "Name", "NumDays" },
                values: new object[,]
                {
                    { 1, 3, "Yıllık", 1 },
                    { 2, 2, "Doğum", 56 },
                    { 3, 3, "Ölüm", 3 },
                    { 4, 1, "Babalık", 5 },
                    { 5, 3, "Evlilik", 3 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a6093bb0-3d6c-46fd-a83f-8cc8709094fd", "5044c498-2d3c-4aab-b08c-da4277d87e15" });

            migrationBuilder.CreateIndex(
                name: "IX_Advance_AdvanceTypeId",
                table: "Advance",
                column: "AdvanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Advance_ApprovalStatusId",
                table: "Advance",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Advance_AppUserId",
                table: "Advance",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Advance_CurrencyId",
                table: "Advance",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ApprovalStatusId",
                table: "Expense",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_AppUserId",
                table: "Expense",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CurrencyId",
                table: "Expense",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ExpenseTypeId",
                table: "Expense",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_ApprovalStatusId",
                table: "Leave",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_AppUserId",
                table: "Leave",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_LeaveTypeId",
                table: "Leave",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveType_LeaveTypeFocusId",
                table: "LeaveType",
                column: "LeaveTypeFocusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advance");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Leave");

            migrationBuilder.DropTable(
                name: "AdvanceType");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "ExpenseType");

            migrationBuilder.DropTable(
                name: "ApprovalStatus");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LeaveType");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "LeaveTypeFocus");
        }
    }
}
