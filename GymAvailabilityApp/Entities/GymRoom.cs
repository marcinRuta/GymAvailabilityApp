using System.ComponentModel.DataAnnotations.Schema;

namespace GymAvailabilityApp.Entities
{
    public class GymRoom
    {
        public int Id { get; set; }
        public string Floor { get; set; }
        public string Name { get; set; }
        public string? RoomFileLink { get; set; }

        [ForeignKey("GymId")]
        public int GymId { get; set; }
        
    }
}
