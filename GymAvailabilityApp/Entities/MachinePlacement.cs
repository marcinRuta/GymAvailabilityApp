using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymAvailabilityApp.Entities
{
    public class MachinePlacement
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        [ForeignKey("MachineId")]
        public int MachineId { get; set; }
        [ForeignKey("GymRoomId")]
        public int GymRoomId { get; set; } 
    }
}
