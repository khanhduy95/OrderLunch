﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fetch.OrderLunch.WebApi.Application.Commands;
using Fetch.OrderLunch.WebApi.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fetch.OrderLunch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOrderQueries _orderQueries;

        public OrderController(IMediator mediator, IOrderQueries orderQueries)
        {
            _mediator = mediator;
            _orderQueries = orderQueries;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool result = false;
            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateOrder = new IdentifiedCommand<CreateOrderCommand, bool>(command, guid);
                result = await _mediator.Send(requestCreateOrder);
            }
            else
            {
                // If no x-requestid header is found we process the order anyway. This is just temporary to not break existing clients
                // that aren't still updated. When all clients were updated this could be removed.
                result = await _mediator.Send(command);
            }

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("{orderId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            try
            {
                var order = await _orderQueries.GetOrder(orderId);
                return Ok(order);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderQueries.GetOrders();

            return Ok(orders);
        }
    }
}