using System.ComponentModel.DataAnnotations;

namespace GymAvailabilityApp.Entities
{
    public class Gym
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
