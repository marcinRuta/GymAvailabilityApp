namespace GymAvailabilityApp.Models
{
    public class AvaiabilityReportModel
    {
        public int? Id { get; set; }
        public string? CurrentState { get; set; }
        public string ? PreviousState { get; set; }
        public DateTime? Timestamp { get; set; }

    }
}
