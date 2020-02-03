
using Fetch.OrderLunch.WebApi.Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Interfaces
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<UserService> _logger;
        private readonly AppSetting _appSetting;

        public UserService(UserManager<IdentityUser> userManager,
                           SignInManager<IdentityUser> signInManager,
                           ILogger<UserService> logger,
                           IOptions<AppSetting> appSetting)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _appSetting = appSetting.Value;
        }

        public async Task<UserOutputViewModel> Authenticate(UserLoginViewModel model)
        {

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var roles = await _userManager.GetRolesAsync(user);
                UserOutputViewModel outputModel = new UserOutputViewModel
                {
                    UserId = user.Id,
                    Token = CreateJwt(user.Id, roles.FirstOrDefault(), user.Email)
                };              

                return outputModel;
            }

            throw new ArgumentNullException(nameof(UserLoginViewModel));

        }

        public void Update()
        {

        }

        public async Task<RegisterViewModel> UserRegister(RegisterViewModel model)
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

                return model;
            }
            throw new ArgumentNullException(nameof(RegisterViewModel));
        }       

        private string CreateJwt(string id ,string roles, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {                       
                        new Claim(ClaimTypes.Name,id.ToString()),
                        new Claim(ClaimTypes.Role,roles),
                        new Claim(ClaimTypes.Email,email),
                        new Claim("Id",id.ToString()),


                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var Token = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(Token);
            return token;
        }

    }
}
