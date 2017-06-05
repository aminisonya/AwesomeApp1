using AwesomeApp.Domain;
using AwesomeApp.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeApp.Services.Interfaces
{
    public interface IWeightsService
    {
        int Create(WeightCreateRequest model);

        void Update(WeightUpdateRequest model);

        List<WeightliftingExercise> GetAllWeightExercises();
    }
}