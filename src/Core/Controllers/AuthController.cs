using Microsoft.AspNetCore.Mvc;
using quiz_app_api.src.Core.Database;
using quiz_app_api.src.Core.Modules.Auth.Dto;
using quiz_app_api.src.Core.Modules.Auth.Service;
using quiz_app_api.src.Packages.HttpExceptions;

namespace quiz_app_api.src.Core.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;

        public AuthController(AppDbContext context)
        {
            authService = new AuthService(context);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto model)
        {
            try
            {
                return Ok(authService.Login(model));
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.statusCode, ex.response);
            }
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto model)
        {
            try
            {
                return Created("CREATED", authService.Register(model));
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.statusCode, ex.response);
            }
        }

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken(RefreshTokenDto model)
        {
            try
            {
                return Ok(authService.GenerateAccessToken(model));
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.statusCode, ex.response);
            }
        }
    }
}
