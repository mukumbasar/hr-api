using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using HrApp.Application.Wrappers;

namespace HrApp.WebAPI;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            var temp = new ServiceResponse<string>(ex.Message) { IsSuccess = false };
            var jsonBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(temp));
            await context.Response.Body.WriteAsync(jsonBytes);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
