using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Models;

namespace WebApplication3.Models 
{
    public class Exercise
    {
        public int ExerciseId { get; set; }  // Primary Key

        [Required]
        public string ExerciseName { get; set; }

        [Range(1, 50)]
        public int Sets { get; set; }

        [Range(1, 100)]
        public int Reps { get; set; }

        [Range(0, 2000)]
        public double Weight { get; set; }

        // Foreign Key
        public int WorkoutId { get; set; }

        [ForeignKey("WorkoutId")]
        public Workout? Workout { get; set; }
    }
}