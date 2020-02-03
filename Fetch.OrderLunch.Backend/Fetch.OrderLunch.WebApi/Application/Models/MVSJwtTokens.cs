using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Models
{
    public class MVSJwtTokens
    {
        public const string Issuer = "MVS";
        public const string Audience = "ApiUser";
        public const string Key = "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";
        public const string AuthSchemes = JwtBearerDefaults.AuthenticationScheme;
    }
}
