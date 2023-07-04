using Microsoft.AspNetCore.Builder;

namespace Core.Application.Utilities.Extensions
{
    public static class CoreMiddlewareInitializer
    {
        //Exception middleware istisna olmaqla yaradılan
        //bütün middleware-də Invoke metodu async yox sadəcə Task olmalıdır
        //və return _next(context) olmalıdır.

        public static void UseCoreMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<CurrentScopeDataMiddleware>();
            app.UseMiddleware<CustomTokenControlMiddleware>();
        }
    }
}