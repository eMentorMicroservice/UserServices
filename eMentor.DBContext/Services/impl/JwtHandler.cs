using eMentor.Common.Utils;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.DBContext.Services.impl
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private readonly SecurityKey _securityKey;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtHeader _jwtHeader;

        public JwtHandler()
        {
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.API_KEY));
            _signingCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
            _jwtHeader = new JwtHeader(_signingCredentials);
        }

        public string Create(string id, int exp, UserRole role)
        {
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, id),
                new Claim("Role", ((int)role).ToString()),
                new Claim(ClaimTypes.Role, role.ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.UtcNow.AddDays(exp == 0? 1: exp)).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()}")};

            var token = new JwtSecurityToken(
                issuer: Constants.API_ISSUER,
                audience: Constants.API_CLIENT,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(exp == 0 ? 1 : exp),
                signingCredentials: new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256)
            );

            return _jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}
