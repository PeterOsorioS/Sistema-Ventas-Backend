using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Sistema_Ventas.Middleware
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;
        public TokenValidationMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task Invoke(HttpContext context)
        {
            var Token = context.Request.Headers.Authorization.ToString().Replace("Bearer ","");
            if (!string.IsNullOrEmpty(Token)) 
            { 
                var TokenHandler = new JwtSecurityTokenHandler();
                try
                {
                    var claims= TokenHandler.ValidateToken(Token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
                        ValidateIssuer = true,
                        ValidIssuer = _config["Jwt:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = _config["Jwt:Audience"]
                    }, out SecurityToken validatedToken);
                    context.User = claims;
                }
                catch (Exception)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Invalid Token.");
                    return;
                }
            }
            await _next(context);
        }
    }
}
