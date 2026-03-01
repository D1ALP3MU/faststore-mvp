using FastStore.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _service;

    public InventoryController(IInventoryService service)
    {
        _service = service;
    }

    // GET: /api/inventory
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _service.GetAllAsync();
        return Ok(products);
    }

    // GET: /api/inventory/low-stock
    [HttpGet("low-stock")]
    public async Task<IActionResult> GetLowStock()
    {
        var products = await _service.GetLowStockAsync();
        return Ok(products);
    }
}
