using System.Collections.Generic;
using GitHubJobs.Interface.ViewModels;
using GitHubJobs.Interface.Models;

namespace GitHubJobs.Interface
{
    public interface IJobViewFactory
    {
        /// <summary>
        /// Jobs the view.
        /// </summary>
        /// <param name="jobs">The jobs.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        IJobModelView JobView(IEnumerable<IJob> jobs, int page);
    }
}