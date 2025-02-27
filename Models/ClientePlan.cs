using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Gym_Proyect.Models
{
    public class ClientePlan
    {
        [Key]
        public required int ClienteID { get; set; }
        public required int PlanID { get; set; }
        public required DateTime FechaAsignacion
        {
            get; set;
        }

        public required Cliente Cliente { get; set; }
        public required Plan Plan { get; set; }
    }
}