using System.Web.Mvc;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GitHubJobs.DI.Windsor.Plumbing;
using GitHubJobs.Domain.Factory;
using GitHubJobs.Interface.Domain.Services;
using GitHubJobs.Domain.Services;
using GitHubJobs.Interface;

namespace GitHubJobs.DI.Windsor.Installers
{
    public class FactoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IJobViewFactory))
                    .ImplementedBy(typeof(JobViewFactory))
                    .Named("JobViewFactory")
                    .LifeStyle.Is(LifestyleType.Singleton));
        }
    }
}