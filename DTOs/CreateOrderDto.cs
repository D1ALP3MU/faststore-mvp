using System.ComponentModel.DataAnnotations;

namespace FastStore.Api.DTOs;

public class CreateOrderDto
{
    [Required(ErrorMessage = "El ProductoId es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El ProductoId debe ser mayor a 0.")]
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "La cantidad es obligatoria.")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
    public int Cantidad { get; set; }
}
