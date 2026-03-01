using Microsoft.EntityFrameworkCore;
using FastStore.Api.Models;

namespace FastStore.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<OrdenReposicion> OrdenesReposicion => Set<OrdenReposicion>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "Calzado" },
            new Categoria { Id = 2, Nombre = "Ropa Superior" },
            new Categoria { Id = 3, Nombre = "Pantalones" }
        );

        modelBuilder.Entity<Producto>().HasData(
            new Producto { Id = 1, Nombre = "Tenis Nike Air Max 270 - Talla 40", Precio = 580000, StockActual = 15, StockMinimo = 5, CategoriaId = 1 },
            new Producto { Id = 2, Nombre = "Tenis Adidas Ultraboost - Talla 38", Precio = 620000, StockActual = 2, StockMinimo = 8, CategoriaId = 1 },
            new Producto { Id = 3, Nombre = "Camiseta Básica Oversize Blanca - M", Precio = 85000, StockActual = 50, StockMinimo = 20, CategoriaId = 2 },
            new Producto { Id = 4, Nombre = "Hoodie Negro Algodón - L", Precio = 145000, StockActual = 4, StockMinimo = 10, CategoriaId = 2 },
            new Producto { Id = 5, Nombre = "Jeans Slim Fit Azul - Talla 32", Precio = 180000, StockActual = 25, StockMinimo = 15, CategoriaId = 3 },
            new Producto { Id = 6, Nombre = "Joggers de Entrenamiento Gris - S", Precio = 120000, StockActual = 3, StockMinimo = 7, CategoriaId = 3 },
            new Producto { Id = 7, Nombre = "Tenis Puma Rider - Talla 41", Precio = 320000, StockActual = 12, StockMinimo = 5, CategoriaId = 1 },
            new Producto { Id = 8, Nombre = "Chaqueta Denim Clásica - M", Precio = 210000, StockActual = 1, StockMinimo = 5, CategoriaId = 2 },
            new Producto { Id = 9, Nombre = "Shorts Deportivos Pro - L", Precio = 95000, StockActual = 30, StockMinimo = 10, CategoriaId = 3 },
            new Producto { Id = 10, Nombre = "Tenis Jordan Retro 1 - Talla 42", Precio = 850000, StockActual = 2, StockMinimo = 3, CategoriaId = 1 }
        );
    }
}
