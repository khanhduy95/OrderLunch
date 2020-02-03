
using Fetch.OrderLunch.WebApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Interfaces
{
    public interface IUserService
    {
        Task<RegisterViewModel> UserRegister(RegisterViewModel model);

        Task<UserOutputViewModel> Authenticate(UserLoginViewModel model);

        void Update();
    }
}
