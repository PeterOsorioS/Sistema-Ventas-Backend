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
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CodeQR { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool State { get; set; }
        public int IdCategory { get; set; }
    }
}
