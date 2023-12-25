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

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
