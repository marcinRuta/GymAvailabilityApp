namespace GymAvailabilityApp.Models
{
    public class MachineModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ImageFileLink { get; set; }
        public string? Description { get; set; }
        public string? DeviceEUI { get; set; }
        public bool? IsOccupied { get; set; }
        
    }
}
