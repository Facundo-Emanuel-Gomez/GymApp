using System.ComponentModel.DataAnnotations;

namespace Gym_Proyect.Models
{
    public class AsistenciaGeneral
    {
        [Key] // Esto define la clave primaria
        public int AsistenciaID { get; set; }
        public int? UsuarioID { get; set; }
        public int? ClienteID { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public TimeSpan HoraIngreso { get; set; }
        public TimeSpan? HoraSalida { get; set; }

        public required Usuario Usuario { get; set; }
        public required Cliente Cliente { get; set; }
    }
}
