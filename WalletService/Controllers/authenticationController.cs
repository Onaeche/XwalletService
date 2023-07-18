using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WalletService.Cache;
using WalletService.Constants;
using WalletService.Data;
using WalletService.Models;
using WalletService.Requests;
using WalletService.Responses;

namespace WalletService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authenticationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICacheService _cacheService;

        public authenticationController(ApplicationDbContext context, ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;

        }
        [HttpPost("tokenLogin")]
        public IActionResult Login([FromBody] tokenLoginRequest user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            var tokenLogin = _context.tokenLogins.Where(u => u.userName == user.userName && u.password == user.password).Any();


            if (tokenLogin)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"], audience: ConfigurationManager.AppSetting["JWT:ValidAudience"], claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new JWTTokenResponse
                {
                    AccessToken = tokenString
                });
            }
            return Unauthorized();
        }
    }
}