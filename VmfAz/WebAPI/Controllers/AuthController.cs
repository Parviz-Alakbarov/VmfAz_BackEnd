using Business.Abstract;
using Core.Utilities.Security.JWT;
using Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginDto userForLoginDto)
        {
            var userToLogin = await _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return Unauthorized(userToLogin);
            }
            return Ok(userToLogin);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterDto userForRegisterDto)
        {
            var registerResult = await _authService.Register(userForRegisterDto);
            if (registerResult.Success)
            {
                var result = await _authService.CreateAccessToken(registerResult.Data);
                return Ok(result);
            }

            return BadRequest(registerResult);
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var result = await _authService.UpdateUser(userUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword(UserChangePasswordDto userForChangePasswordDto)
        {
            var result = await _authService.ChangePassword(userForChangePasswordDto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("logout")]
        public async Task<IActionResult> Logout()
        {
            var auth = Request.Headers["Authorization"];

            var userToLogout = await _authService.Logout(auth);
            if (!userToLogout.Success)
            {
                return BadRequest(userToLogout.Message);
            }
            return Ok(userToLogout);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(UserForRefreshTokenDto refreshTokenDto)
        {
            var userRefreshResult = await _authService.RefreshToken(refreshTokenDto);
            if (!userRefreshResult.Success)
            {
                return BadRequest(userRefreshResult.Message);
            }
            return Ok(userRefreshResult);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetPofile()
        {
            var result = await _authService.GetUser();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("test")]
        public IActionResult LoginTest()
        {
            var auth = Request.Headers["Authorization"];
            var token = new JwtHelper(_configuration).DecodeToken(auth);

            return Ok(token);
        }
    }
}
