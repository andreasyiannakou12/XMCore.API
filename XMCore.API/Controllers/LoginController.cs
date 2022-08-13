using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XMCore.API.Data;
using XMCore.API.Models;
using XMCore.API.Reponses;

namespace XMCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly UserDbContext _userDbContext;

        public LoginController(IConfiguration config, UserDbContext userDbContext)
        {
            _config = config;
            _userDbContext = userDbContext;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel userModel)
        {
            var user = Authenticate(userModel);
            if (user != null)
            {
                var token = Generate(user);
                var response = new Response<object>(token);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(UserModel user)
        {
            var currentUser = UserDummyRow.DummyAdmin;
            var u = new User();
            bool check = false;
            if (currentUser.Username.ToLower() == user.Username.ToLower() && currentUser.Password == user.Password)
            {
                u.UserName = currentUser.Username;
                u.Password = currentUser.Password;
                check = true;
            }

            if (check)
            {
                return u;
            }

            return null;

        }
    }
}
