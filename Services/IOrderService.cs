using FastStore.Api.Models;

namespace FastStore.Api.Services;

public interface IOrderService
{
    // para crear una orden de reposición
    Task<OrdenReposicion> CreateOrderAsync(int productoId, int cantidad);

    // para obtener las ordenes de reposición
    //Task<List<OrdenReposicion>> GetOrdersAsync();
}
