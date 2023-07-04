using ETicaretAPI.Application.DTOs.Jwt;
using ETicaretAPI.Application.Utilities.Security.Jwt;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Security
{
    public interface IJwtService
    {
        AccessToken CreateToken(User user, bool isAdminState = false);
        bool ValidateRefreshToken(string refreshToken);
    }
}
