using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeApp.Domain
{
    public class Workout
    {
        public int Id { get; set; }

        public string WorkoutName { get; set; }

        public string WorkoutNote { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}