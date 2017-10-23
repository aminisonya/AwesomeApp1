using AwesomeApp.Models;
using AwesomeApp.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeApp.Services.Interfaces
{
    public interface IUsersService
    {
        ApplicationUser Create(UserCreateRequest model);

        ApplicationUser GetUserByEmail(string emailAddress);

        bool SignIn(string emailAddress, string password);
    }
}