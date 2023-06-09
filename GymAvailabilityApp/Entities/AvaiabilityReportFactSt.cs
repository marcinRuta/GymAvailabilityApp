using System.ComponentModel.DataAnnotations;

namespace GymAvailabilityApp.Entities
{
    public class AvaiabilityReportFactSt
    {
        [Key]
        public int Id { get; set; }
        public string Occuppancy { get; set; }
        public int MachineId { get; set; }
        public int GymRoomId { get; set; }
        public string Timestamp { get; set; }
        public int FactId { get; set; }
        public string Date { get; set; }


    }
}
