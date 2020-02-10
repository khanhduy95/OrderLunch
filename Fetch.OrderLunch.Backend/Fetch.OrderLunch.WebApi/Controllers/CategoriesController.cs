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
  //[Authorize(AuthenticationSchemes = MVSJwtTokens.AuthSchemes,Policy = "AdminRolePolicy")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]     
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _categoryService.GetAll());
            }
            catch 
            {
                return NotFound();
            }
               
            
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _categoryService.GetById(id));
            
        }

        [HttpPost]       
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
           
                await _categoryService.Add(model);
                return Ok();
           

        }

        [HttpPut]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update(CategoryViewModel model)
        {
            
                await _categoryService.Update(model);
                return Ok();
            
        }

        [HttpDelete]       
        public async Task<IActionResult> Delete(ObjectID objectID)
        {
            
                await _categoryService.Delete(objectID);
                return Ok();
            
        }


    }
}