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
         //log to console
         Console.WriteLine(ex.Message);
      }
   }
}
