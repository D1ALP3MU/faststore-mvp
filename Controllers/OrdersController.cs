using FastStore.Api.DTOs;
using FastStore.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastStore.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    // POST: /api/orders
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
    {
        try
        {
            var order = await _service.CreateOrderAsync(dto.ProductoId, dto.Cantidad);
            return Ok(order);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // GET: /api/orders
    // [HttpGet]
    // public async Task<IActionResult> GetOrders()
    // {
    //     var orders = await _service.GetOrdersAsync();
    //     return Ok(orders);
    // }
}

