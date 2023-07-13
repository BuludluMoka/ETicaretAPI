using OnionArchitecture.Application.DTOs.Jwt;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Abstractions.Security
{
    public interface ITokenHandler
    {
        AccessToken CreateToken(AppUser user, bool isAdminState = false);
        bool ValidateRefreshToken(string refreshToken);
    }
}
