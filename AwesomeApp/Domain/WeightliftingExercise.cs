using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeApp.Domain
{
    public class WeightliftingExercise
    {
        public int Id { get; set; }

        public int WorkoutId { get; set; }

        public string ExerciseName { get; set; }

        public int Sets { get; set; }

        public int Reps { get; set; }

        public int Weight { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}