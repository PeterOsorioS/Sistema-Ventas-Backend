using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("birthday")]
        public string Birthday { get; set; }
        [Column("dni")]
        public long DNI { get; set; }
        [Column("role")]
        public int IdRole { get; set; }
        [ForeignKey("IdRole")]
        public Role Role { get; set; }
        [Column("permissions_blocked")]
        public ICollection<PermissionBlocked> PermissionsBlocked { get; set; }
    }
}
