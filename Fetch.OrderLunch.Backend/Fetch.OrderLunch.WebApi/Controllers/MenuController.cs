using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fetch.OrderLunch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBySupplierId(int id)
        {
            
             return Ok(await _menuService.GetMenuById(id));
           
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(ObjectID objectID)
        {
            
            await _menuService.Update(objectID);
            return Ok();
           
        }
    }
}