using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Models.UserViewModel
{
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>() 
        { 
            new Claim("Create Role","true"),
            new Claim("Edit Role","true"),
            new Claim("Delete Role","true")
        };
    }
}
