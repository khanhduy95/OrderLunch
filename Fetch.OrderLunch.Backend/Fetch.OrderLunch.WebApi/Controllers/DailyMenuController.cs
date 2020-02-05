using System;
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
    public class DailyMenuController : Controller
    {
        private readonly IDailyMenuService _dailyMenu;

        public DailyMenuController(IDailyMenuService dailyMenu)
        {
            _dailyMenu = dailyMenu;
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetDailyMenu()
        {
            if (ModelState.IsValid)
            {
                return Ok(await _dailyMenu.GetDailyMenu());
            }
            return NotFound();
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(await _dailyMenu.GetAll());
            }
            return NotFound();
        }

        [HttpPost]
        [Route("create")]
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
        [Route("addFood")]
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
        [Route("delete")]
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