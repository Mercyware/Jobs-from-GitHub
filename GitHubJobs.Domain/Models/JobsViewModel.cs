using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubJobs.Interface.Models;
using GitHubJobs.Interface.ViewModels;

namespace GitHubJobs.Domain.Services
{
    public class JobsViewModel : IJobModelView
    {

        /// <summary>
        /// Gets or sets the jobs.
        /// </summary>
        /// <value>
        /// The jobs.
        /// </value>
        public IEnumerable<IJob> Jobs { get; set; }
    }
}