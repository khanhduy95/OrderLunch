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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(await _categoryService.GetAll());
            }
            return NotFound();
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _categoryService.GetById(id));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(model);
                return Ok();
            }
            return BadRequest();

        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Update(model);
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
                await _categoryService.Delete(objectID);
                return Ok();
            }
            return BadRequest();
        }


    }
}