using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class UpdateCategoryDTO
    {
        [Required(ErrorMessage = "El nombre de la categoria es obligatorio.")]
        public string Name { get; set; }
        public bool State { get; set; }
    }
}
