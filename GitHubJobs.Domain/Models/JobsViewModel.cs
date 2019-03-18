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


        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int Page { get; set; }


        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Location { get; set; }


        /// <summary>
        /// Gets or sets the full time.
        /// </summary>
        /// <value>
        /// The full time.
        /// </value>
        public string FullTime { get; set; }
    }
}