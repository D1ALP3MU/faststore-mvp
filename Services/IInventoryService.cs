using FastStore.Api.Models;

namespace FastStore.Api.Services;

public interface IInventoryService
{
    Task<List<Producto>> GetAllAsync();
    Task<List<Producto>> GetLowStockAsync();
}
