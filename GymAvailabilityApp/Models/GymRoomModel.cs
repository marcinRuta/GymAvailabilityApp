namespace GymAvailabilityApp.Models
{
    public class GymRoomModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Floor { get; set; }
        public string? RoomFileLink { get; set; }
        public List<MachineModel>? GymRoomMachines{ get; set; }
      
    }
}
