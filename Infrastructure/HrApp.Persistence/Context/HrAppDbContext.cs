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
                CompanyName = "KOC",
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


            var adminRoleID = Guid.NewGuid().ToString();
            modelBuilder.Entity<AppRole>().HasData(new AppRole { Id = adminRoleID, Name = "Admin" });

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
                CompanyName = "KOC",
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
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "123321Qwe!");
            modelBuilder.Entity<AppUser>().HasData(adminUser);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminUser.Id,
                RoleId = adminRoleID
            });

            modelBuilder.Entity<LeaveTypeFocus>().HasData(new LeaveTypeFocus { Id = 1, Name = "Erkek" });
            modelBuilder.Entity<LeaveTypeFocus>().HasData(new LeaveTypeFocus { Id = 2, Name = "Kadın" });
            modelBuilder.Entity<LeaveTypeFocus>().HasData(new LeaveTypeFocus { Id = 3, Name = "Herkes" });

            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 1, Name="Yıllık", NumDays=1, LeaveTypeFocusId = 3});
            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 2, Name="Doğum", NumDays = 56, LeaveTypeFocusId = 2 });
            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 3, Name="Ölüm", NumDays = 3 , LeaveTypeFocusId = 3});
            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 4, Name="Babalık", NumDays = 5, LeaveTypeFocusId = 1 });
            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 5, Name="Evlilik", NumDays = 3 , LeaveTypeFocusId = 3 });

            modelBuilder.Entity<AdvanceType>().HasData(new AdvanceType { Id = 1, Name = "Bireysel" });
            modelBuilder.Entity<AdvanceType>().HasData(new AdvanceType { Id = 2, Name = "Kurumsal" });

            modelBuilder.Entity<ExpenseType>().HasData(new ExpenseType { Id = 1, Name = "Yeme-içme" });
            modelBuilder.Entity<ExpenseType>().HasData(new ExpenseType { Id = 2, Name = "Eğitim" });
            modelBuilder.Entity<ExpenseType>().HasData(new ExpenseType { Id = 3, Name = "Konaklama" });
            modelBuilder.Entity<ExpenseType>().HasData(new ExpenseType { Id = 4, Name = "Seyahat" });

            modelBuilder.Entity<ApprovalStatus>().HasData(new ApprovalStatus { Id = 1, Name = "Waiting..." });
            modelBuilder.Entity<ApprovalStatus>().HasData(new ApprovalStatus { Id = 2, Name = "Approved!" });
            modelBuilder.Entity<ApprovalStatus>().HasData(new ApprovalStatus { Id = 3, Name = "Declined!" });

            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 1, Name = "₺" });
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 2, Name = "€" });
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 3, Name = "$" });
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 4, Name = "£" });

            modelBuilder.Entity<Gender>().HasData(new Gender { Id = 1, Name = "Erkek" });
            modelBuilder.Entity<Gender>().HasData(new Gender { Id = 2, Name = "Kadın" });
            modelBuilder.Entity<Gender>().HasData(new Gender { Id = 3, Name = "Diğer" });

            modelBuilder.Entity<Log>().HasData(new Log { Id = 1, ExceptionMessage = "burak", ExceptionMethod = "siki", ExceptionPath = "tuttu", ExceptionTime = DateTime.Now });


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
