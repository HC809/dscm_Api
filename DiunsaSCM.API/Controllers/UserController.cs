using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DiunsaSCM.API.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/user/login
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] UserCredentialDTO userCredential)
        {
            var validCredentials = _userService.ValidateCredentialsAsync(userCredential);
            if (!validCredentials.Result)
                return BadRequest(new { message = "User name or password is incorrect" });
            userCredential.Role = "user";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Startup.SECRET);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userCredential.UserName),
                    new Claim(ClaimTypes.Role, userCredential.Role)
                }),

                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            userCredential.Token = tokenHandler.WriteToken(token);
            return Ok(userCredential);
        }


        [Authorize]        
        [HttpGet("userpermissions")]
        public async Task<ActionResult<string>> GetUserPermissionsAsyn()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            var permissions = await _userService.GetUserPermissionsAsync(userName);
            return Ok(permissions);
        }
    }
}


