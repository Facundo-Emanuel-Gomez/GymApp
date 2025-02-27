using System.ComponentModel.DataAnnotations;

namespace Gym_Proyect.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public required string Telefono { get; set; }
        public required DateTime FechaRegistro
        {
            get; set;
        }
        public bool Activo { get; set; } = true;

        // Relación con ClientePlan
        public required List<ClientePlan> ClientePlanes { get; set; }
    }
}
