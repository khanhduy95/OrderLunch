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
    [EnableCors("localhost")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;


        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetALl([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _foodService.GetAll(pageIndex, pageSize));
            }
            return NotFound();
        }

        [HttpGet]
        [Route("get/category/{id}")]
        public async Task<IActionResult> GetAll(int id, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _foodService.GetFoodByCategory(id, pageIndex, pageSize));
            }
            return NotFound();
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _foodService.GetFoodById(id));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromForm]FoodViewModel model)
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
        [Route("update")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromForm]FoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _foodService.Update(model);
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
                await _foodService.Delete(objectID);
                return Ok();
            }
            return NotFound();

        }

    }
}