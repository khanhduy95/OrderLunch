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
        public async Task<IActionResult> Create(CategoryInput category)
        {
           
                await _categoryService.Add(category);
                return Ok();
           

        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update(int id,CategoryViewModel category)
        {
            try
            {
                await _categoryService.Update(category, id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest($"parameter 'id' Incorrect or Object is null");
            }


        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            
                await _categoryService.Delete(id);
                return Ok();
            
        }


    }
}