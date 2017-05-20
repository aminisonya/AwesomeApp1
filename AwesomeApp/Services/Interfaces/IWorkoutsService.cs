using AwesomeApp.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeApp.Services.Interfaces
{
    public interface IWorkoutsService
    {
        int Create(WorkoutCreateRequest model);

        void Update(WorkoutUpdateRequest model);
    }
}