using AwesomeApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwesomeApp.Controllers
{
    [RoutePrefix("weightexercises")]
    public class WeightExercisesController : BaseController
    {
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [Route("create")]
        public ActionResult Create(int workoutId)
        {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = workoutId;

            return View(model);
        }

        [Route("{weightExerciseId:int}/edit")]
        public ActionResult Edit(int weightExerciseId)
        {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = weightExerciseId;

            return View("create", model);
        }
    }
}