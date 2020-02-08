using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Fetch.OrderLunch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicController : Controller
    {
        private readonly IHostingEnvironment _env;
        public PicController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpGet]     
        public IActionResult GetImage(string pictureName)
        {
            var webRoot = _env.WebRootPath;
            var path = Path.Combine(webRoot+"\\images", pictureName);
            Byte[] b = System.IO.File.ReadAllBytes(path);
            return File(b, "image/png");
        }
    }
}