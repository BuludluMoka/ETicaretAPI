using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Utilities.Auth
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AuthHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId()
        {
            return int.Parse(GetClaim(ClaimTypes.NameIdentifier));
        }


        public string GetUsername()
        {
            return GetClaim(ClaimTypes.Name);
        }

        public string GetEmail()
        {
            return GetClaim(ClaimTypes.Email);
        }


        private string GetClaim(string type)
        {
     
            Claim c = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == type);
            return c?.Value;
        }




    }
}
