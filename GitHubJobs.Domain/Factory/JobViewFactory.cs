using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using GitHubJobs.Domain.Services;
using GitHubJobs.Interface;
using GitHubJobs.Interface.Models;
using GitHubJobs.Interface.ViewModels;


namespace GitHubJobs.Domain.Factory
{
    public class JobViewFactory : IJobViewFactory
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
        /// <exception cref="ArgumentNullException">jobs</exception>
        public IJobsViewModel JobView(IEnumerable<IJob> jobs, string description, string location, string fulltime,
            int page)
        {
            if (jobs == null)
            {
                throw new ArgumentNullException(nameof(jobs));
            }

            //Generate the view data
            var viewModel = new JobsViewModel
            {
                Jobs = jobs,
                Page = page + 1,
                Description = description,
                Location = location,
                FullTime = fulltime
            };

            return viewModel;
        }
    }
}