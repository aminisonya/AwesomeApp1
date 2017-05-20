using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeApp.Models.Requests
{
    public class WorkoutUpdateRequest : WorkoutCreateRequest
    {
        public int Id { get; set; }
    }
}