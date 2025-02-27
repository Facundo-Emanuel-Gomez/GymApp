using Gym_Proyect.Context;
using System.ComponentModel.DataAnnotations;

namespace Gym_Proyect.Models
{
    public class Movimiento
    {
        [Key]
        public required int MovimientoID { get; set; }
        public required int TipoUsuarioID { get; set; }
        public required int UsuarioID { get; set; }
        public required int ClienteID { get; set; }
        public required int? TurnoID { get; set; }
        public required DateTime FechaMovimiento
        {
            get; set;
        }
        public required string Observaciones { get; set; }

        public required TipoUsuario TipoUsuario { get; set; }
        public required Usuario Usuario { get; set; }
        public required Cliente Cliente { get; set; }
        public required Turno Turno { get; set; }
    }
}
