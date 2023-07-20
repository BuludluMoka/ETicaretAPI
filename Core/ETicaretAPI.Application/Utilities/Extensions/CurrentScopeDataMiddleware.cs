using Microsoft.AspNetCore.Http;
using OnionArchitecture.Application.Abstractions.DB;
using System.Security.Claims;
using System.Security.Principal;

namespace Core.Utilities.Extensions
{
    public class CurrentScopeDataMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApplicationDbContext context;

        public CurrentScopeDataMiddleware(RequestDelegate next, IApplicationDbContext context)
        {
            _next = next;
            this.context = context;
        }

        public Task InvokeAsync(HttpContext httpContext)
        {
            var identifier = GetClaim(httpContext, ClaimTypes.NameIdentifier);

            var getAcceptLanguageInHeader = httpContext.Request.Headers["Accept-Language"].ToString().ToUpper();

            string acceptLanguage = AcceptLanguageInit(getAcceptLanguageInHeader);

            var dataContainer = new CurrentScopeDataContainer
            {
                RequestUrl = $"{httpContext.Request.Host}{httpContext.Request.Path}",
                UserId = int.Parse(identifier?.Value ?? "0"),
                Name = GetClaim(httpContext, ClaimTypes.Name)?.Value ?? string.Empty,
                Email = GetClaim(httpContext, ClaimTypes.Email)?.Value ?? string.Empty,
                IsAuthenticated = identifier != null,
                Language = acceptLanguage
            };


            Thread.CurrentPrincipal = new GenericPrincipal(dataContainer, null);
            return _next(httpContext);
        }



        private  string AcceptLanguageInit(string acceptLanguageInHeader)
        {
            List<string> defaultLanguages = new() { "AZ", "EN", "RU" };

            const string defaultLanguage = "AZ";
            string acceptLanguage;



            if (defaultLanguages.Count(x => x.ToUpper() == acceptLanguageInHeader.ToUpper()) > 0)
            {
                acceptLanguage = acceptLanguageInHeader;
            }
            else
            {
                var languages = context.Languages.FirstOrDefault(x => x.ShortName.ToUpper() == acceptLanguageInHeader);

                acceptLanguage = languages != null ? acceptLanguageInHeader : defaultLanguage;

            }

            return acceptLanguage;
        }

        private static Claim GetClaim(HttpContext httpContext, string type)
        {
            var c = httpContext.User.Claims.FirstOrDefault(c => c.Type == type);
            return c;
        }
    }
}