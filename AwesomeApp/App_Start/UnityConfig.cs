using AwesomeApp.Services;
using AwesomeApp.Services.Interfaces;
using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using Unity.WebApi;

namespace AwesomeApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			UnityContainer container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IWorkoutsService, WorkoutsService>();

            //sets up Unity for Web API controllers
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            //sets up Unity for MVC controllers
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            //this line is needed so that the resolver can be used by api controllers
            //config.DependencyResolver = new AwesomeApp.Injection.UnityResolver(container);
        }
    }
}