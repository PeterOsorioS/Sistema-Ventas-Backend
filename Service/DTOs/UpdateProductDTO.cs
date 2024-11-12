using System.ComponentModel.DataAnnotations;

namespace Service.DTOs
{
    public class UpdateProductDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CodeQR { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio.")]
        public bool State { get; set; }
        [Required(ErrorMessage = "La categoria es obligatoria.")]
        public int IdCategory { get; set; }
    }
}
