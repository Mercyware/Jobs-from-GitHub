using System.Web.Mvc;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GitHubJobs.DI.Windsor.Plumbing;
using GitHubJobs.Interface.Domain.Services;
using GitHubJobs.Domain.Services;

namespace GitHubJobs.DI.Windsor.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IJobsService))
                    .ImplementedBy(typeof(JobsService))
                    .Named("JobsService")
                    .LifeStyle.Is(LifestyleType.Singleton));
        }
    }
}