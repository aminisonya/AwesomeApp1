using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AwesomeApp.Models.Requests
{
    public class WeightCreateRequest
    {
        [Required]
        public int WorkoutId { get; set; }

        [Required, MinLength(2)]
        public string ExerciseName { get; set; }

        [Required]
        public int Sets { get; set; }

        [Required]
        public int Reps { get; set; }

        [Required]
        public int Weight { get; set; }
    }
}