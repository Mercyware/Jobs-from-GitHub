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
        /// <param name="description">The description.</param>
        /// <param name="location">The location.</param>
        /// <param name="fulltime">The fulltime.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        IJobsViewModel JobView(IEnumerable<IJob> jobs, string description, string location, string fulltime,
            int page);
    }
}