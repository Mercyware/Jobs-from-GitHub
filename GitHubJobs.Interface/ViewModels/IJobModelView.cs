using System.Collections.Generic;
using GitHubJobs.Interface.Models;

namespace GitHubJobs.Interface.ViewModels
{
    public interface IJobModelView
    {
        /// <summary>
        /// Gets or sets the jobs.
        /// </summary>
        /// <value>
        /// The jobs.
        /// </value>
        IEnumerable<IJob> Jobs { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        int Page { get; set; }
    }
}