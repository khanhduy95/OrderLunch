using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi
{
    public static class ExtensionMethod
    {
               
        public static string GetUserId(HttpContext _httpContext)
        {
            return _httpContext.User.FindFirstValue("Id");
        }
    }
}
