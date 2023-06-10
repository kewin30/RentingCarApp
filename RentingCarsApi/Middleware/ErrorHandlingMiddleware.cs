using RentingCarsApi.Exceptions;

namespace RentingCarsApi.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestException badRequest)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequest.Message);
            }
            catch (UnauthorizedException unauthorized)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(unauthorized.Message);
            }
            catch (NotFoundException notFound)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFound.Message);
            }
            catch(Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong! " + e.Message);
            }
        }
    }
}
