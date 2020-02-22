using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Fetch.OrderLunch.WebApi.Application.Models;
using Fetch.OrderLunch.WebApi.Application.Models.UserViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Fetch.OrderLunch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
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
                return Created("","");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Login")]
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
                    claims.Add(roles.Select(Role => new Claim("Role", Role)).FirstOrDefault());

                    var token = new JwtSecurityToken
                        (MVSJwtTokens.Issuer,
                         MVSJwtTokens.Audience,
                         claims,
                         expires: DateTime.UtcNow.AddDays(1),
                         signingCredentials: creds);

                    var results = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    };

                    return Created("",results);
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("")]
        public  async Task<IActionResult> GetUser()
        {
            try
            {
                var users=await _userManager.Users
                    .Select(x => new UserInfor
                    {
                        UserId=x.Id,
                        UserName = x.UserName,
                        PhoneNumber = x.PhoneNumber
                    })
                    .ToListAsync();
                return Ok(users);
            }
            catch (Exception e)
            {
                return NotFound(nameof(e));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            try
            {
                var user = new UserInfor
                {
                    UserId = result.Id,
                    UserName = result.UserName,
                    PhoneNumber = result.PhoneNumber,
                    Email = result.Email
                };

                return Ok(user);
            }
            catch (Exception e)
            {
                return NotFound(nameof(e));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
           var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id}/Role")]
        public async Task<IActionResult> SetRole(string id, Role role)
        {
            var user =await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, role.Name);
                return Ok();
            }
            return BadRequest();
        }

    }
}