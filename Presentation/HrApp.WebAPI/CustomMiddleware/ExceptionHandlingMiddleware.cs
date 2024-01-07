using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using HrApp.Application.Wrappers;
using HrApp.Domain.Entities;
using HrApp.Persistence.Context;

namespace HrApp.WebAPI;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HrAppDbContext _dbContext;
    public ExceptionHandlingMiddleware(RequestDelegate next, HrAppDbContext dbContext)
    {
        _next = next;
        _dbContext = dbContext;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Log log = new Log()
            {
                ExceptionMessage = ex.Message,
                ExceptionMethod = context.Request.Method,
                ExceptionPath = context.Request.Path,
                ExceptionTime = DateTime.Now
            };

            _dbContext.Logs.Add(log);
            _dbContext.SaveChanges();

            context.Response.ContentType = "application/json";
            var temp = new ServiceResponse<string>(ex.Message) { IsSuccess = false };
            var jsonBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(temp));
            await context.Response.Body.WriteAsync(jsonBytes);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
