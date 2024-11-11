using Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sistema_Ventas.Helpers
{
    public class JwtUtility
    {
        private readonly IConfiguration _config;
        public JwtUtility(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(User user)
        {
            var claim = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, $"{user.FirstName + user.LastName}"),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", user.Id.ToString())
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claim,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:Expire"])),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
