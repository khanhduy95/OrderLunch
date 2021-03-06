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
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IOrderQueries _orderQueries;

        public OrdersController(IMediator mediator, IOrderQueries orderQueries)
        {
            _mediator = mediator;
            _orderQueries = orderQueries;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]CreateOrderCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool result = false;
            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateOrder = new IdentifiedCommand<CreateOrderCommand, bool>(command, guid);
                result = await _mediator.Send(requestCreateOrder);
            }
            else
            {
                result = await _mediator.Send(command);
            }

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> SetPaidStatus([FromBody]SetPaidOrderStatusCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool result = false;
            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateOrder = new IdentifiedCommand<SetPaidOrderStatusCommand, bool>(command, guid);
                result = await _mediator.Send(requestCreateOrder);
            }
            else
            {
                result = await _mediator.Send(command);
            }

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                
                var order = await _orderQueries.GetOrder(id);

                return Ok(order);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orders = await _orderQueries.GetOrders();

                return Ok(orders);
            }
            catch (Exception)
            {

                return NotFound();
            }
           
        }
    }
}