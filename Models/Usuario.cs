using Gym_Proyect.Context;
using System.ComponentModel.DataAnnotations;


namespace Gym_Proyect.Models
{
    public class Usuario
    {
        [Key]
        public required int id { get; set; }
        public required string Nombre { get; set; }
        public required int tipo_UsuarioID { get; set; }

        public required string Email { get; set; }

        public required string Contrasena { get; set; }

        public required Boolean Activo { get; set; }

        public required TipoUsuario TipoUsuario { get; set; }
    }
}
