using AwesomeApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwesomeApp.Controllers
{
    [RoutePrefix("workouts")]
    public class WorkoutsController : BaseController
    {
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("{workoutId:int}/edit")]
        public ActionResult Edit(int workoutId)
        {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = workoutId;

            return View("create", model);
        }
    }
}