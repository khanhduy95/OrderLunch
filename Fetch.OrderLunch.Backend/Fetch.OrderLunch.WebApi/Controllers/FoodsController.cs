using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Fetch.OrderLunch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetALl([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            try
            {
                return Ok(await _foodService.GetAll(pageIndex, pageSize));
            }
            catch (Exception e)
            {

                return NotFound(e);
            }
            
        }

        [HttpGet]
        [Route("Category/{id}")]
        public async Task<IActionResult> GetAll(int id, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            
            return Ok(await _foodService.GetFoodByCategory(id, pageIndex, pageSize));
           
        }

        [HttpGet]
        [Route("Name")]
        public async Task<IActionResult> GetFoodByFoodName(string name, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {

            return Ok(await _foodService.SearchFoodByFoodName(name, pageIndex, pageSize));

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFoodById(int id)
        {
            try
            {
                return Ok(await _foodService.GetFoodById(id));

            }
            catch (Exception)
            {

                return NotFound();
            }
            
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(FoodInput model)
        {
            try
            {
                await _foodService.Add(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
           
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update(FoodViewModel model,int id)
        {
            try
            {
                await _foodService.Update(model, id);
                return Ok();
            }
            catch (Exception )
            {
                return BadRequest($"parameter 'id' Incorrect or Object is null");
            }

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _foodService.Delete(id);
            return Ok();
        }

    }
}