using Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interface;

namespace Sistema_Ventas.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            try
            {
                var response = _authService.Authentication(login);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO register) 
        {
            try
            {
                var response = _authService.Register(register);
                return Ok(response);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
