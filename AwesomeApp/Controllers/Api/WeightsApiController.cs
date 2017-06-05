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
    [RoutePrefix("api/weightexercises")]
    public class WeightsApiController : ApiController
    {
        private IWeightsService _weightsService;

        public WeightsApiController(IWeightsService weightsService)
        {
            _weightsService = weightsService;
        }

        [AllowAnonymous]
        [Route, HttpPost]
        public HttpResponseMessage CreateWeightExercise(WeightCreateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            int id = _weightsService.Create(model);

            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = id;

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{weightexerciseId:int}"), HttpPut]
        public HttpResponseMessage UpdateWeightExercise(WeightUpdateRequest model, int weightExerciseId)
        {
            if (weightExerciseId != model.Id)
            {
                ModelState.AddModelError("Id", "The id does not match");
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _weightsService.Update(model);

            return Request.CreateResponse(HttpStatusCode.OK, new SuccessResponse());
        }

        [Route, HttpGet]
        public HttpResponseMessage GetAllWeightExercises()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemsResponse<WeightliftingExercise> response = new ItemsResponse<WeightliftingExercise>();
            response.Items = _weightsService.GetAllWeightExercises();

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
