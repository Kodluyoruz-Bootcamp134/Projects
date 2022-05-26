using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PokeAPI.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IUserService _userService;
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Validate(model.UserName, model.Password);
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role),
                    };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("TengenToppaGurrenLagan"));
                    var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                    var token = new JwtSecurityToken(
                        issuer: "http://www.kodluyoruz.org",
                        audience: "http://client.kodluyoruz.org",
                        claims = claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddMinutes(15),
                        signingCredentials: signingCredentials
                        );
                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                return Unauthorized();
            }
            return BadRequest(ModelState);
        }
    }
}
