using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CodeQR { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool State { get; set; }
        public string CreationDate { get; set; }
        public Category Category { get; set; }
    }
}
