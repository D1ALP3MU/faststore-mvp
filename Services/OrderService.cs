using FastStore.Api.Data;
using FastStore.Api.Models;

namespace FastStore.Api.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<OrdenReposicion> CreateOrderAsync(int productoId, int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException("La cantidad debe ser mayor a cero.");

        var producto = await _context.Productos.FindAsync(productoId);

        if (producto == null)
            throw new ArgumentException("Producto no encontrado.");

        if (producto.StockActual > producto.StockMinimo)
            throw new ArgumentException("El producto no se encuentra en stock crítico.");

        var orden = new OrdenReposicion
        {
            ProductoId = productoId,
            Cantidad = cantidad,
            FechaSolicitud = DateTime.Now,
            Estado = EstadoOrden.Pendiente
        };

        _context.OrdenesReposicion.Add(orden);
        await _context.SaveChangesAsync();

        return orden;
    }

}
