using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Application.DTOs.Jwt;
using ETicaretAPI.Application.Abstractions.Security;

namespace ETicaretAPI.Application.Utilities.Security.Jwt
{
    public class JwtService : IJwtService
    {
        private JwtOptions _jwtOptions;
        public JwtService()
        {
            _jwtOptions = AppSettings.Settings.JwtOptions;
        }

        /// <summary>
        /// Create Access and  Refresh Token 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="isAdminState"></param>
        /// <returns></returns>
        public AccessToken CreateToken(User user, bool isAdminState = false)
        {
            var accessToken = GenerateToken(user, _jwtOptions.SecurityKey,
                DateTime.Now.AddMinutes(_jwtOptions.AccessTokenExpiration), isAdminState);

            var refreshToken = GenerateToken(user,
                _jwtOptions.RefreshTokenSecurityKey,
                DateTime.Now.AddMinutes(_jwtOptions.AccessTokenExpiration * 2), isAdminState);

            return new AccessToken
            {
                Token = accessToken,
                Expiration = DateTime.Now.AddMinutes(_jwtOptions.AccessTokenExpiration),
                RefreshToken = refreshToken
            };

        }


        private string GenerateToken(User user, string secretKey, DateTime expiration, bool isAdminState = false)
        {
            var token = TokenGenerator(user, secretKey, expiration, isAdminState);
            return token;
        }


        public bool ValidateRefreshToken(string refreshToken)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.RefreshTokenSecurityKey)),
                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Audience,
                ClockSkew = TimeSpan.Zero
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            try
            {
                jwtSecurityTokenHandler.ValidateToken(refreshToken, validationParameters,
                    out SecurityToken _);
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }


        /// <summary>
        /// Verilen sec secretKey-e gore token yaradir
        /// </summary>
        /// <param name="user"></param>
        /// <param name="secretKey"></param>
        /// <param name="expiration"></param>
        /// <param name="isAdminState"></param>
        /// <returns></returns>
        private string TokenGenerator(User user, string secretKey, DateTime expiration, bool isAdminState = false)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtSecurityToken = CreateJwtSecurityToken(_jwtOptions, user, signingCredentials, expiration,  isAdminState);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return token;
        }


        
        private JwtSecurityToken CreateJwtSecurityToken(JwtOptions JwtOptions, User user,
            SigningCredentials signingCredentials, DateTime expiration, bool isAdminState = false)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: JwtOptions.Issuer,
                audience: JwtOptions.Audience,
                expires: expiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, isAdminState),
                signingCredentials: signingCredentials
            );
            return jwtSecurityToken;
        }


        private IEnumerable<Claim> SetClaims(User user,bool isAdminState=false)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            claims.Add(new Claim("userId", user.Id.ToString()));
            claims.Add(new Claim("fullName", $"{user.FirstName} {user.LastName}"));
            claims.Add(new Claim("passwordStatus", user.PasswordStatus.ToString()));
            claims.Add(new Claim("isAdmin", isAdminState.ToString()));

            // roles?.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role.Name)));

            return claims;
        }






    }
}
