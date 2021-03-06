﻿using System;
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
    //[Authorize(AuthenticationSchemes = MVSJwtTokens.AuthSchemes)]
    public class BasketsController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(BasketInPut model)
        {
            
            await _basketService.CreateBasket(model);
            return Ok();
           
        }

        [HttpGet]  
        [Route("")]
        public async Task<ActionResult> GetBasket()
        {
           
            return Ok(await _basketService.Getbasket());
          
        }

        [HttpPost]   
        [Route("{id}/Item")]
        public async Task<IActionResult> AddItemToBasket(BasketItemViewModel basketItem)
        {
          
            await _basketService.AddItemToBasket(basketItem);
            return Ok();
            
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBasket(int id,BasketItemViewModel basketItem)
        {
            try
            {
                await _basketService.UpdateBasket(basketItem, id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest($"parameter 'id' Incorrect or Object is null");

            }
        }

        [HttpDelete] 
        [Route("Item/{id}")]
        public async Task<IActionResult> DeleteItemInBasket(int id)
        {
            
            await _basketService.DeleteItemInBasket(id);
            return Ok();
            
        }

    }
}