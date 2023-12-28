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

        public HrAppDbContext(DbContextOptions<HrAppDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var hasher = new PasswordHasher<AppUser>();


            var adminUser = new AppUser
            {
                Id = Guid.NewGuid().ToString(), // Dinamik bir kullanıcı Id oluştur
                UserName = "user1",
                NormalizedUserName = "USER1",
                Name = "user",
                Surname = "usersurname",
                Address = "address1231231231232",
                BirthPlace = "Mom",
                BirthYear = DateTime.Now.AddYears(-30),
                CompanyName = "KOC",
                Department = "IT",
                Occupation = "Formatçı",
                TurkishIdentificationNumber = "11111111111",
                StartDate = DateTime.Now.AddYears(-10),
                Salary = 20000,
                MobileNumber = "0555555555",
                EmailConfirmed = true,
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM"
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "123321Qwe!");

            modelBuilder.Entity<AppUser>().HasData(adminUser);


            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 1, Name="Yıllık"});
            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 2, Name="Doğum"});
            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 3, Name="Ölüm"});
            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 4, Name="Babalık"});
            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 5, Name="Mazeret"});
            modelBuilder.Entity<LeaveType>().HasData(new LeaveType { Id = 6, Name="Evlilik"});

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

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
