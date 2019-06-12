using ArchaeoAnalysisHub.BLL;
using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.Controllers;
using ArchaeoAnalysisHub.Data;
using ArchaeoAnalysisHub.Data.Repository;
using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace ArchaeoAnalysisHub
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            container.RegisterType<IApplicationDbContext, ApplicationDbContext>();
            container.RegisterType<IAnalysisRepository, AnalysisRepository>();
            container.RegisterType<IArtifactRepository, ArtifactRepository>();
            container.RegisterType<ISampleRepository, SampleRepository>();

            container.RegisterType<IAnalysesService, AnalysesService>();
            container.RegisterType<IAnalysisDataPointService, AnalysisDataPointService>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}