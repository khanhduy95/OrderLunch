using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fetch.OrderLunch.WebApi.Application.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm]FileInputModel file)
        {
            try
            {
                if (file.FileToUpload == null || file.FileToUpload.Length == 0)
                {
                    throw new ArgumentNullException("file null");
                }

                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot\\images",
                            file.FileToUpload.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.FileToUpload.CopyToAsync(stream);
                }
                return Ok(file);
            }
            catch 
            {
                throw new ArgumentNullException("file not selected");
            }
           
        }
    }
}