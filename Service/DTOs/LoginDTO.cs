using System.ComponentModel.DataAnnotations;

namespace Service.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="El correo es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage ="La contraseña es obligatoria")]
        public string Password { get; set; }
    }
}
