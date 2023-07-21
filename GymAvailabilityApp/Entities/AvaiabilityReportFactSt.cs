using System.ComponentModel.DataAnnotations;

namespace GymAvailabilityApp.Entities
{
    public class AvaiabilityReportFactSt
    {
        [Key]
        public int Id { get; set; }
        public string Occupancy { get; set; }
        public int MachineId { get; set; }
        public int GymRoomId { get; set; }
        public TimeSpan Timestamp { get; set; }
        public int FactId { get; set; }
        public DateTime Date { get; set; }


    }
}
