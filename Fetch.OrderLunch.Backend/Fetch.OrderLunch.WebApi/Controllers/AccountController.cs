using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Fetch.OrderLunch.WebApi.Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Fetch.OrderLunch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(RegisterViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            var result = await _userManager.FindByNameAsync(model.UserName);
            if (result == null)
            {
                var user = new IdentityUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                await _userManager.CreateAsync(user);

                ViewBag.Message = "User was created";
                return Created("", user);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(UserLoginViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody]UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var signResult = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (signResult.Succeeded)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MVSJwtTokens.Key));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var claims = new List<Claim>()
                    {
                        new Claim("Id",user.Id),
                        new Claim(JwtRegisteredClaimNames.Sub,model.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    };

                    var roles = await _userManager.GetRolesAsync(user);
                    claims.Add(roles.Select(Role => new Claim(ClaimTypes.Role, Role)).FirstOrDefault());

                    var token = new JwtSecurityToken
                        (MVSJwtTokens.Issuer,
                         MVSJwtTokens.Audience,
                         claims,
                         expires: DateTime.UtcNow.AddMinutes(30),
                         signingCredentials: creds);

                    var results = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    };

                    return Created("", results);
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}