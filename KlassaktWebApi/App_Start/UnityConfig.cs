using KlassaktWebApi.Services;
using KlassaktWebApi.UnitOfWork;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using AutoMapper;
using KlassaktWebApi.DataAccess;
using KlassaktWebApi.Models;
using KlassaktWebApi.App_Start;

namespace KlassaktWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            /// e.g. container.RegisterType<ITestService, TestService>();



           
            var mapperConfig = MapperConfig.MapperConfiguration;
            IMapper mapper = mapperConfig.CreateMapper();
            container.RegisterInstance(mapper);
            container.RegisterType<IContentService, ContentService>();
            container.RegisterType<IUnitOfWorkProvider, UnitOfWorkProvider>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}