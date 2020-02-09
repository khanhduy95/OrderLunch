using System;
using System.Collections.Generic;
using System.Linq;
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
    public class BasketsController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create()
        {
            if (ModelState.IsValid)
            {
                await _basketService.CreateBasket();
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]  
        [Route("get")]
        public async Task<ActionResult> GetBasket()
        {
            if (ModelState.IsValid)
            {
                return Ok(await _basketService.Getbasket());
            }
            return NotFound();
        }

        [HttpPost]
        [Route("AddItem")]       
        public async Task<IActionResult> AddItemToBasket(BasketItemViewModel basketItem)
        {
            if (ModelState.IsValid)
            {
                await _basketService.AddItemToBasket(basketItem);
                return Ok();
            }
            return NotFound();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateBasket(BasketItemViewModel basketItem)
        {
            if (ModelState.IsValid)
            {
                await _basketService.UpdateBasket(basketItem);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("deleteItem")]
        public async Task<IActionResult> DeleteItemInBasket(int id)
        {
            if (ModelState.IsValid)
            {
                await _basketService.DeleteItemInBasket(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [Route("checkout")]
        public async Task<IActionResult> Checkout(int id)
        {
            if (ModelState.IsValid)
            {
                await _basketService.DeleteItemInBasket(id);
                return Ok();
            }
            return NotFound();
        }
    }
}