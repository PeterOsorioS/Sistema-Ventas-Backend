using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("code_qr")]
        public string? CodeQR { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("stock")]
        public int Stock { get; set; }
        [Column("state")]
        public bool State { get; set; }
        [Column("creation_date")]
        public string CreationDate { get; set; }
        [Column("category")]
        public int IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public Category Category { get; set; }
    }
}
