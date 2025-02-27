using System.ComponentModel.DataAnnotations;

namespace Gym_Proyect.Models
{
    public class Plan
    {
        [Key]
        public int PlanID { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relación con DetallePlan
        public required List<DetallePlan> Detalles { get; set; }
        public required List<ClientePlan> ClientePlanes { get; set; }
    }
}