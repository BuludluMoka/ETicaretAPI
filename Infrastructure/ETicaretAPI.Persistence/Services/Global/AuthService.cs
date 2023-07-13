using OnionArchitecture.Application.Abstractions.Services.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Services.Global
{
    public class AuthService : IAuthSerivce
    {
        public Task PasswordResetAsnyc(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
