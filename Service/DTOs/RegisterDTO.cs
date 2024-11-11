using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no es valido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El numero de documento es obligatorio.")]
        public long DNI { get; set; }
        [Required(ErrorMessage = "El Rol es obligatorio")]
        public int IdRole { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener minimo 8 caracteres.")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime Birthdate { get; set; }
    }
}
