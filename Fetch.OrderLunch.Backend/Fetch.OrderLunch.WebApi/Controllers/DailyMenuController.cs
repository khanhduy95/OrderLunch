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
        [Route("id")]
        public async Task<IActionResult> GetDailyMenu(string userId)
        {
            
            return Ok(await _dailyMenu.GetDailyMenu(userId));
           
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
           
             return Ok(await _dailyMenu.GetAll());
           
        }

        [HttpPost]    
        [Route("")]
        public async Task<IActionResult> Create(CreateDailyMenu model)
        {
            
            await _dailyMenu.Create(model);
            return Ok();
            
        }

        [HttpPost]
        [Route("id/Food")]
        public async Task<IActionResult> AddFoodtoDailyMenu(FoodDaily model)
        {
            
            await _dailyMenu.AddFoodToDailyMenu(model);
            return Ok();
           
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(ObjectID objectID)
        {
            
            await _dailyMenu.Delete(objectID);
            return Ok();
           
        }
    }
}