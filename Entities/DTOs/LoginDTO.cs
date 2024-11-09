using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="El correo es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage ="La contraseña es obligatoria")]
        public string Password { get; set; }
    }
}
