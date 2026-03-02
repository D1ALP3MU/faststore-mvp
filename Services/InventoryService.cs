using FastStore.Api.Data;
using FastStore.Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FastStore.Api.Services;

public class InventoryService : IInventoryService
{
    private readonly AppDbContext _context;

    public InventoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductoDTO>> GetAllAsync()
    {
        return await _context.Productos
            .AsNoTracking()
            .Include(p => p.Categoria)
            .Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                StockActual = p.StockActual,
                StockMinimo = p.StockMinimo,
                CategoriaId = p.CategoriaId,
                CategoriaNombre = p.Categoria.Nombre
            })
            .ToListAsync();
    }

    public async Task<List<ProductoDTO>> GetLowStockAsync()
    {
        return await _context.Productos
            .AsNoTracking()
            .Include(p => p.Categoria)
            .Where(p => p.StockActual < p.StockMinimo)
            .Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                StockActual = p.StockActual,
                StockMinimo = p.StockMinimo,
                CategoriaId = p.CategoriaId,
                CategoriaNombre = p.Categoria.Nombre
            })
            .ToListAsync();
    }
}