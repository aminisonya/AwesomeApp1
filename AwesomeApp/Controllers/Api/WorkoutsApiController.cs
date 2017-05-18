using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AwesomeApp.Controllers.Api
{
    [RoutePrefix("api/workouts")]
    public class WorkoutsApiController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage CreateWorkout(AddWorkoutRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            //int id = 
        }
    }
}
