namespace GymAvailabilityApp.Models
{
    public class MachineAvaiabilityFactModel
    {
        public int Id { get; set; }
        public string Occupancy { get; set; }
        public string Timestamp { get; set; }
        public int MachineId { get; set; }
        public int GymRoomId { get; set; }
        public string Date { get; set; }

    }
}
