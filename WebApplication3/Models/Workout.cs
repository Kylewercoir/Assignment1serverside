using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }  // Primary Key

        [Required]
        public DateTime WorkoutDate { get; set; }

        [Required]
        public string WorkoutType { get; set; }  // Push, Pull, Legs, etc.

        public string? Notes { get; set; }

        // One-to-Many Relationship
        public List<Exercise>? Exercises { get; set; }
    }
}