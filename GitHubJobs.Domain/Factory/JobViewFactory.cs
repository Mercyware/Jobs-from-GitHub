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
        /// <returns></returns>
        public IJobModelView JobView(IEnumerable<IJob> jobs)
        {
            if (jobs == null)
            {
                throw new ArgumentNullException(nameof(jobs));
            }

            //Generate the view data
            var viewModel = new JobsViewModel
            {
                Jobs = jobs
            };

            return viewModel;
        }
    }
}