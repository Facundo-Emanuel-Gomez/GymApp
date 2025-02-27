using System.ComponentModel.DataAnnotations;

namespace Gym_Proyect.Models
{
    public class Turno
    {
        [Key]
        public int TurnoID { get; set; }
        public required string Nombre { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
