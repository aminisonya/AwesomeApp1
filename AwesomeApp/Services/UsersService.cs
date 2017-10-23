using AwesomeApp.Models;
using AwesomeApp.Models.Requests;
using AwesomeApp.Services.Interfaces;
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
    public class UsersService : IUsersService
    {
        private ApplicationUserManager GetUserManager()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        private ApplicationSignInManager GetSignInManager()
        {
            return HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
        }

        public ApplicationUser Create(UserCreateRequest model)
        {
            ApplicationUserManager userManager = GetUserManager();
            ApplicationUser newUser = new ApplicationUser { UserName = model.Email, Email = model.Email, LockoutEnabled = false };
            IdentityResult result = null;
            try
            {
                result = userManager.Create(newUser, model.Password);
            }
            catch
            {
                throw;
            }
            if (result.Succeeded)
            {
                return newUser;
            }
            else
            {
                string error = result.Errors.FirstOrDefault();
                throw new Exception(error);
            }
        }

        public ApplicationUser GetUserByEmail(string emailAddress)
        {
            ApplicationUserManager userManager = GetUserManager();
            IAuthenticationManager authManager = HttpContext.Current.GetOwinContext().Authentication;

            ApplicationUser user = userManager.FindByEmail(emailAddress);
            return user;
        }

        public bool SignIn(string emailAddress, string password)
        {
            var result = false;

            ApplicationUserManager userManager = GetUserManager();
            ApplicationUser user = userManager.Find(emailAddress, password);
            if (user != null)
            {
                ApplicationSignInManager signInMan = GetSignInManager();
                signInMan.PasswordSignIn(emailAddress, password, true, true);
                result = true;
            }
            return result;
        }
    }
}