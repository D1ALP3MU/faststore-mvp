using FastStore.Api.Data;
using FastStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FastStore.Api.Services;

public class InventoryService : IInventoryService
{
    private readonly AppDbContext _context;

    public InventoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Producto>> GetAllAsync()
    {
        return await _context.Productos
            .Include(p => p.Categoria)
            .ToListAsync();
    }

    public async Task<List<Producto>> GetLowStockAsync()
    {
        return await _context.Productos
            .Include(p => p.Categoria)
            .Where(p => p.StockActual < p.StockMinimo)
            .ToListAsync();
    }
}
