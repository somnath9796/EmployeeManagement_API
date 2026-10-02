using Employee_Management.DTO.Login;
using Employee_Management.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {

                var userName = loginDto.UserName;
                var password = loginDto.Password;

                if (userName != "admin" || password != "admin123")
                {
                    return BadRequest("Enter Valid Username & Password");
                }

                var token = _tokenService.GenerateToken(userName);

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
