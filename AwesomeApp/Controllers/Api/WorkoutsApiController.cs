using AwesomeApp.Domain;
using AwesomeApp.Models.Requests;
using AwesomeApp.Models.Responses;
using AwesomeApp.Services.Interfaces;
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
        private IWorkoutsService _workoutsService;

        public WorkoutsApiController(IWorkoutsService workoutsService)
        {
            _workoutsService = workoutsService;
        }

        [AllowAnonymous]
        [Route, HttpPost]
        public HttpResponseMessage CreateWorkout(WorkoutCreateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            int id = _workoutsService.Create(model);

            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = id;

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{workoutId:int}"), HttpPut]
        public HttpResponseMessage UpdateWorkout(WorkoutUpdateRequest model, int workoutId)
        {
            if(workoutId != model.Id)
            {
                ModelState.AddModelError("Id", "The id does not match");
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _workoutsService.Update(model);

            return Request.CreateResponse(HttpStatusCode.OK, new SuccessResponse());
        }

        [Route, HttpGet]
        public HttpResponseMessage GetAllWorkouts()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemsResponse<Workout> response = new ItemsResponse<Workout>();
            response.Items = _workoutsService.GetAllWorkouts();

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
