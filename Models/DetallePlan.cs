using System.ComponentModel.DataAnnotations;

namespace Gym_Proyect.Models
{
    public class DetallePlan
    {
        [Key]
        public required int DetalleID { get; set; }
        public required int PlanID { get; set; }
        public required string Ejercicio { get; set; }
        public required int Repeticiones { get; set; }
        public required int Series { get; set; }
        public required string Descanso { get; set; }

        // Relación con Plan
        public required Plan Plan { get; set; }
    }
}