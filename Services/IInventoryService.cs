using FastStore.Api.Models;
using FastStore.Api.DTOs;

namespace FastStore.Api.Services;

public interface IInventoryService
{
    //Task<List<Producto>> GetAllAsync();
    Task<List<ProductoDTO>> GetAllAsync();
    Task<List<ProductoDTO>> GetLowStockAsync();
}
