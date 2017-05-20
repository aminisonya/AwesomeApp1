using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AwesomeApp.Models.Requests
{
    public class WorkoutCreateRequest
    {
        [Required(ErrorMessage = "Workout name is required")]
        public string WorkoutName { get; set; }
        
        public string WorkoutNote { get; set; }
    }
}