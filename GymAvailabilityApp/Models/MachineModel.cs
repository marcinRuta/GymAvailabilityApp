using Microsoft.Build.Framework;

namespace GymAvailabilityApp.Models
{
    public class MachineModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? ImageFileLink { get; set; }
        public string? Description { get; set; }
        public string? DeviceEUI { get; set; }
        public bool? IsOccupied { get; set; }
        [Required]
        public int? GymRoomId { get; set; }
        [Required]
        public string? GymRoomName { get; set; }
        [Required]
        public string? MachinePlacementDescription { get; set; }
        
    }
}
