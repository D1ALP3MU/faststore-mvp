using FastStore.Api.Models;

namespace FastStore.Api.Services;

public interface IOrderService
{
    Task<OrdenReposicion> CreateOrderAsync(int productoId, int cantidad);
}
