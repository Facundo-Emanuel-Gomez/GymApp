using System.ComponentModel.DataAnnotations;

namespace GymApp.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int TipoUsuarioID { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Contrasena { get; set; }

        public bool Activo { get; set; } = true;

        // Relación con TipoUsuario

    }
}
