﻿using System;
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
        public async Task<IActionResult> GetBySupplierId(int id)
        {
            if (ModelState.IsValid)
            {
                
                return Ok(await _menuService.GetMenuById(id));
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(MenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _menuService.Update(model);
                return Ok();
            }
            return BadRequest();
        }
    }
}