using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OnionArchitecture.Application.Abstractions.DB;
using System.Net;

namespace Core.Utilities.Extensions
{

    public class CustomTokenControlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApplicationDbContext _dbContext;

        public CustomTokenControlMiddleware(RequestDelegate next, IApplicationDbContext dbContext)
        {
            _next = next;
            _dbContext = dbContext;
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
                    //Requestden gelen tokeni db-deki ile qarshilashdir
                    var userTokenData = _dbContext.UserTokens.FirstOrDefault(x => x.AccessToken == token && !x.LogOut);

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
                JsonConvert.SerializeObject( new ResultDataGenerator().Generate(ResultInfo.Unauthorized)));
        }
    }
}