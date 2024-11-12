using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "El Id es obligatorio.")]
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio.")]
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
