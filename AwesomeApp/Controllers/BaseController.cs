using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using AwesomeApp.Models;
using AwesomeApp.Models.ViewModels;
using AwesomeApp.Services.Interfaces;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AwesomeApp.Controllers
{
    //add this after reg/login code is added
    //[Authorize(Roles = "User")]
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.navBarUser = "Yes";
                ViewBag.userId = User.Identity.Name;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}