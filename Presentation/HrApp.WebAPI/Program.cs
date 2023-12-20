using HrApp.Persistence.Extensions;
using HrApp.Application.Extensions;
using Microsoft.EntityFrameworkCore;
using HrApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistenceDependencies(builder.Configuration.GetConnectionString("DevConnection"));
builder.Services.AddApplicationDependencies();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
   options.AddPolicy("AllowAll", builder =>
   {
      builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader();
   });
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

    await userManager.CreateAsync(new AppUser()
    {
        UserName = "abc",
        Name = "Ad 1",
        SecondName = "Ad 2",
        Surname = "Soyad 1",
        SecondSurname = "Soyad 2",
        BirthYear = DateTime.Now.AddYears(-30),
        TurkishIdentificationNumber = "12345123451",
        StartDate = DateTime.Now.AddYears(-5),
        EndDate = DateTime.Now.AddYears(-3),
        IsActive = false,
        Department = "IT",
        CompanyName = "BA",
        Occupation = "Full-stack Developer",
        Email = "mail@mail.com",
        Address = "Adres 1",
        MobileNumber = "213451245",
        Salary = 98000,

    });

    var user = await userManager.FindByEmailAsync("mail@mail.com");
    Console.WriteLine(user.Id);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
