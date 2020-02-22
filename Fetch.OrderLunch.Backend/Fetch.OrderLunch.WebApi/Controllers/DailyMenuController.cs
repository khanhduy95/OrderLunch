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
    //[Authorize(AuthenticationSchemes = MVSJwtTokens.AuthSchemes)]
    public class DailyMenuController : Controller
    {
        private readonly IDailyMenuService _dailyMenu;

        public DailyMenuController(IDailyMenuService dailyMenu)
        {
            _dailyMenu = dailyMenu;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetDailyMenu(string userId)
        {
            
            return Ok(await _dailyMenu.GetDailyMenu(userId));
           
        }

        [HttpGet]
        [Route("Today")]
        public async Task<IActionResult> GetDailyMenuToday()
        {
            try
            {
                return Ok(await _dailyMenu.GetDailyMenuToDay());

            }
            catch 
            {
                return NotFound();
            }
           
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _dailyMenu.GetAll());
            }
            catch (Exception)
            {

                return NotFound();
            }
           
           
        }

        [HttpPost]    
        [Route("")]
        public async Task<IActionResult> Create(CreateDailyMenu model)
        {
            
            await _dailyMenu.Create(model);
            return Ok();
            
        }

        [HttpPost]
        [Route("{userId}/Food")]
        public async Task<IActionResult> AddFoodtoDailyMenu(string userId, FoodDaily food)
        {

            await _dailyMenu.AddFoodToDailyMenu(food, userId);
            return Ok();

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            await _dailyMenu.Delete(id);
            return Ok();
           
        }
    }
}