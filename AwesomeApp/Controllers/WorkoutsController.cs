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
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }
    }
}