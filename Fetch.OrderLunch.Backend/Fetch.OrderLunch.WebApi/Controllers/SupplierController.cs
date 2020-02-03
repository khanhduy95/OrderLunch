using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fetch.OrderLunch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(await _supplierService.GetAll());

            }
            return NotFound();
        }


        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _supplierService.GetById(id));
            }
            return NotFound();
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(SupplierInput model)
        {
            if (ModelState.IsValid)
            {
                await _supplierService.Add(model);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(SupplierViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _supplierService.Update(model);
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
                await _supplierService.Delete(objectID);
                return Ok();
            }
            return BadRequest();
        }

    }
}