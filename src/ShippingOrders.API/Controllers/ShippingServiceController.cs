﻿using Microsoft.AspNetCore.Mvc;
using ShippingOrders.Application.Services;

namespace ShippingOrders.API.Controllers
{
    [ApiController]
    [Route("api/shipping-services")]
    public class ShippingServiceController : ControllerBase
    {

        private readonly IShippingServiceService _service;

        public ShippingServiceController(IShippingServiceService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shippingServices = await _service.GetAll();
            return Ok(shippingServices);
        }
    }
}
