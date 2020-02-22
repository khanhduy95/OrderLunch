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
    
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           
            return Ok(await _supplierService.GetAll());

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           
             return Ok(await _supplierService.GetById(id));
           
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(SupplierInput model)
        {
            
            await _supplierService.Add(model);
            return Ok();
           
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id,SupplierViewModel supplier)
        {
            try
            {
                await _supplierService.Update(supplier, id);
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
            await _supplierService.Delete(id);
            return Ok();
        }

    }
}