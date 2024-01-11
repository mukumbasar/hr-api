using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HrApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HrApp.Persistence.Context
{
    public class HrAppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {

        //TODO : Dbset eklenecek
        public DbSet<Log> Logs { get; set; }

        public HrAppDbContext(DbContextOptions<HrAppDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var hasher = new PasswordHasher<AppUser>();

            var user1 = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user1",
                NormalizedUserName = "USER1",
                Name = "user",
                Surname = "usersurname",
                Address = "address1231231231232",
                BirthPlace = "Istanbul",
                BirthYear = DateTime.Now.AddYears(-30),
                CompanyId = 1,
                Department = "IT",
                Occupation = "Formatçı",
                TurkishIdentificationNumber = "11111111111",
                StartDate = DateTime.Now.AddYears(-10),
                Salary = 20000,
                MobileNumber = "5554443322",
                EmailConfirmed = true,
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                GenderId = 2
            };
            user1.PasswordHash = hasher.HashPassword(user1, "123321Qwe!");
            modelBuilder.Entity<AppUser>().HasData(user1);

            var user2 = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user2",
                NormalizedUserName = "USER2",
                Name = "user2",
                Surname = "user2surname",
                Address = "address1231231231232",
                BirthPlace = "Ankara",
                BirthYear = DateTime.Now.AddYears(-30),
                CompanyId = 1,
                Department = "IT",
                Occupation = "Formatçı",
                TurkishIdentificationNumber = "11111111111",
                StartDate = DateTime.Now.AddYears(-10),
                Salary = 20000,
                MobileNumber = "5554443322",
                EmailConfirmed = true,
                Email = "user2@gmail.com",
                NormalizedEmail = "USER2@GMAIL.COM",
                GenderId = 2
            };
            user2.PasswordHash = hasher.HashPassword(user2, "123321Qwe!");
            modelBuilder.Entity<AppUser>().HasData(user2);


            var webadmin = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "webadmin",
                NormalizedUserName = "WEBADMIN",
                Name = "webadmin",
                Surname = "webadminname",
                Address = "webadminaddress1231231231232",
                BirthPlace = "Ank",
                BirthYear = DateTime.Now.AddYears(-30),
                CompanyId = 1,
                Department = "IT",
                Occupation = "Formatçı",
                TurkishIdentificationNumber = "11111111111",
                StartDate = DateTime.Now.AddYears(-10),
                Salary = 20000,
                MobileNumber = "5554443322",
                EmailConfirmed = true,
                Email = "webadmin@gmail.com",
                NormalizedEmail = "WEBADMIN@GMAIL.COM",
                GenderId = 2
            };
            webadmin.PasswordHash = hasher.HashPassword(webadmin, "webadmin");
            modelBuilder.Entity<AppUser>().HasData(webadmin);

            var adminRoleID = Guid.NewGuid().ToString();
            modelBuilder.Entity<AppRole>().HasData(new AppRole { Id = adminRoleID, Name = "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<AppRole>().HasData(new AppRole { Id = "2", Name = "WebsiteManager", NormalizedName = "WEBSITEMANAGER" });

            var adminUser = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Name = "adminname",
                Surname = "adminsurname",
                Address = "adminaddress1231231231232",
                BirthPlace = "Ankara",
                BirthYear = DateTime.Now.AddYears(-50),
                CompanyId = 1,
                Department = "PATRON",
                Occupation = "PATRON",
                TurkishIdentificationNumber = "22222222222",
                StartDate = DateTime.Now.AddYears(-15),
                Salary = 500000,
                MobileNumber = "5325323232",
                EmailConfirmed = true,
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                GenderId = 1
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "admin");
            modelBuilder.Entity<AppUser>().HasData(adminUser);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminUser.Id,
                RoleId = adminRoleID
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = webadmin.Id,
                RoleId = "2"
            });


            modelBuilder.Entity<Company>().HasData(
        new Company
        {
            Id = 1,
            Name = "Company 1",
            MersisNo = "0123456789000015",
            TaxNo = "1234567890",
            TaxOffice = "Ankara",
            ImageData = null, // Replace with actual byte array if needed
            PhoneNumber = "5555555555",
            Address = "123 Main St, City",
            EmailAddress = "company1@example.com",
            EmployeeCount = 100,
            FoundationYear = new DateTime(2000, 1, 1),
            ContractStartDate = new DateTime(2024, 1, 1),
            ContractEndDate = new DateTime(2024, 12, 31),
            IsActive = true,
            CompanyTypeId = 1, // Assuming you have a CompanyType with an Id of 1
        },
        new Company
        {
            Id = 2,
            Name = "Company 2",
            MersisNo = "123",
            TaxNo = "123",
            TaxOffice = "A",
            ImageData = null, // Replace with actual byte array if needed
            PhoneNumber = "5555555555",
            Address = "456 Oak St, City",
            EmailAddress = "company2@example.com",
            EmployeeCount = 50,
            FoundationYear = new DateTime(2005, 3, 15),
            ContractStartDate = new DateTime(2024, 2, 1),
            ContractEndDate = new DateTime(2024, 11, 30),
            IsActive = true,
            CompanyTypeId = 2, // Assuming you have a CompanyType with an Id of 2
        });

            modelBuilder.Entity<LeaveTypeFocus>().HasData(new LeaveTypeFocus { Id = 1, Name = "Male" });
            modelBuilder.Entity<LeaveTypeFocus>().HasData(new LeaveTypeFocus { Id = 2, Name = "Female" });
            modelBuilder.Entity<LeaveTypeFocus>().HasData(new LeaveTypeFocus { Id = 3, Name = "Everyone" });

            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 1, Name = "Annual", NumDays = 1, LeaveTypeFocusId = 3 });
            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 2, Name = "Maternity", NumDays = 56, LeaveTypeFocusId = 2 });
            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 3, Name = "Bereavement", NumDays = 3, LeaveTypeFocusId = 3 });
            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 4, Name = "Paternity", NumDays = 5, LeaveTypeFocusId = 1 });
            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 5, Name = "Marriage", NumDays = 3, LeaveTypeFocusId = 3 });

            modelBuilder.Entity<AdvanceType>().HasData(new AdvanceType { Id = 1, Name = "Individual" });
            modelBuilder.Entity<AdvanceType>().HasData(new AdvanceType { Id = 2, Name = "Corporate" });

            modelBuilder.Entity<ExpenseType>().HasData(new ExpenseType { Id = 1, Name = "Food and Beverage" });
            modelBuilder.Entity<ExpenseType>().HasData(new ExpenseType { Id = 2, Name = "Education" });
            modelBuilder.Entity<ExpenseType>().HasData(new ExpenseType { Id = 3, Name = "Accommodation" });
            modelBuilder.Entity<ExpenseType>().HasData(new ExpenseType { Id = 4, Name = "Travel" });

            modelBuilder.Entity<ApprovalStatus>().HasData(new ApprovalStatus { Id = 1, Name = "Waiting..." });
            modelBuilder.Entity<ApprovalStatus>().HasData(new ApprovalStatus { Id = 2, Name = "Approved!" });
            modelBuilder.Entity<ApprovalStatus>().HasData(new ApprovalStatus { Id = 3, Name = "Declined!" });

            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 1, Name = "₺" });
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 2, Name = "€" });
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 3, Name = "$" });
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 4, Name = "£" });

            modelBuilder.Entity<Gender>().HasData(new Gender { Id = 1, Name = "Male" });
            modelBuilder.Entity<Gender>().HasData(new Gender { Id = 2, Name = "Female" });
            modelBuilder.Entity<Gender>().HasData(new Gender { Id = 3, Name = "Other" });

            modelBuilder.Entity<Log>().HasData(new Log { Id = 1, ExceptionMessage = "Test Exception", ExceptionMethod = "N/A", ExceptionPath = "N/A", ExceptionTime = DateTime.Now });

            modelBuilder.Entity<CompanyType>().HasData(new CompanyType { Id = 1, Name = "Limited" });
            modelBuilder.Entity<CompanyType>().HasData(new CompanyType { Id = 2, Name = "Anonim" });
            modelBuilder.Entity<CompanyType>().HasData(new CompanyType { Id = 3, Name = "Kooperatif" });
            modelBuilder.Entity<CompanyType>().HasData(new CompanyType { Id = 4, Name = "Kollektif" });
            modelBuilder.Entity<CompanyType>().HasData(new CompanyType { Id = 5, Name = "Komandit" });
            modelBuilder.Entity<CompanyType>().HasData(new CompanyType { Id = 6, Name = "Adi" });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
