using System.Net;
using System.Text;

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
            context.Response.Body = new MemoryStream(Encoding.UTF8.GetBytes(ex.Message));
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
