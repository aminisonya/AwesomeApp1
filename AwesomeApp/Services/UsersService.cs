using AwesomeApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;

namespace AwesomeApp.Services
{
    public class UsersService
    {
        private ApplicationUserManager GetUserManager()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        public bool Signin(string emailAddress)
        {
            bool result = false;

            ApplicationUserManager userManager = GetUserManager();
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            ApplicationUser user = userManager.FindByEmail(emailAddress);

            ClaimsIdentity signin = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, signin);

            if (user != null)
            {
                result = true;
            }

            return result;
        }
    }
}