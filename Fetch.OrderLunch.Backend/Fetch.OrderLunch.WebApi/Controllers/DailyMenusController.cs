﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fetch.OrderLunch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = MVSJwtTokens.AuthSchemes)]
    public class DailyMenusController : Controller
    {
        private readonly IDailyMenuService _dailyMenu;

        public DailyMenusController(IDailyMenuService dailyMenu)
        {
            _dailyMenu = dailyMenu;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDailyMenu()
        {
            if (ModelState.IsValid)
            {
                return Ok(await _dailyMenu.GetDailyMenu());
            }
            return NotFound();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(await _dailyMenu.GetAll());
            }
            return NotFound();
        }

        [HttpPost]    
        [Route("")]
        public async Task<IActionResult> Create(CreateDailyMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _dailyMenu.Create(model);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Food")]
        public async Task<IActionResult> AddFoodtoDailyMenu(ObjectID objectID)
        {
            if (ModelState.IsValid)
            {
                await _dailyMenu.AddFoodToDailyMenu(objectID);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]       
        public async Task<IActionResult> Delete(ObjectID objectID)
        {
            if (ModelState.IsValid)
            {
                await _dailyMenu.Delete(objectID);
                return Ok();
            }
            return BadRequest();
        }
    }
}