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
        public async Task<IActionResult> Update(SupplierViewModel model)
        {
           
            await _supplierService.Update(model);
            return Ok();
           
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ObjectID objectID)
        {
           
            await _supplierService.Delete(objectID);
            return Ok();
          
        }

    }
}