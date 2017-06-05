using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeApp.Models.ViewModels
{
    public class BaseViewModel
    {
        public bool IsLoggedIn { get; set; }

        public string UserId { get; set; }

        public List<string> Role { get; set; }

        public string Query { get; set; }

        public bool OnlyHasLayoutConfig { get; set; }
    }
}