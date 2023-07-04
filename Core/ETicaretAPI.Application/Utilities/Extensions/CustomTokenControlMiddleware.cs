using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using Core.DataAccess.Concrete.EntityFramework.Contexts;

namespace Core.Utilities.Extensions
{

    public class CustomTokenControlMiddleware
    {
        private readonly RequestDelegate _next;


        public CustomTokenControlMiddleware(RequestDelegate next)
        {

            _next = next;
        }


        public Task Invoke(HttpContext context)
        {

            try
            {
                var path = context.Request.Path.ToString().ToLower();

                var pathStateList = new List<bool> {
                   path.Contains("/auth/login".ToLower()),
                   path.Contains("/auth/RefreshTokenLogin".ToLower()),

                   path.Contains("GetSystemLanguages".ToLower()),
                   path.Contains("GetLoginLanguageContent".ToLower()),

                   path.Contains("Documentation/SMQS/References/Set".ToLower())
                };

                var pathCheck = pathStateList.Count(x => x) > 0;
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (pathCheck)
                {
                    return _next(context);
                }

                if (!string.IsNullOrEmpty(token))
                {
                    using var dbContext = new AppDbContext();
                    //Requestden gelen tokeni db-deki ile qarshilashdir
                    var userTokenData = dbContext.UserTokens.FirstOrDefault(x => x.AccessToken == token &&
                    !x.LogOut);

                    if (userTokenData != null)
                    {
                        return _next(context);
                    }
                    else
                    {
                        return HandleAsync(context);
                    }
                }
                else
                {
                    return HandleAsync(context);
                }


            }
            catch (Exception)
            {
                return HandleAsync(context);
            }


        }

        private Task HandleAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            return httpContext.Response.WriteAsync(
                JsonConvert.SerializeObject(ResultDataGenerator.Generate(ResultInfo.Unauthorized)));
        }
    }
}