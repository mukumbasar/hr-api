using HrApp.Persistence.Extensions;
using HrApp.Application.Extensions;
using Microsoft.EntityFrameworkCore;
using HrApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using HrApp.WebAPI;

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
        builder.WithOrigins("https://ank14hrmvc.azurewebsites.net", "https://localhost:7298")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
