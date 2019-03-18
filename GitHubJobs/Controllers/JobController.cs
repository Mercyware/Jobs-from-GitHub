using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GitHubJobs.Interface.Domain.Services;

namespace GitHubJobs.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobsService _jobsService;

        public JobController(IJobsService jobsService)
        {
            this._jobsService = jobsService;
        }


        /// <summary>
        /// Indexes the specified description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="location">The location.</param>
        /// <param name="fulltime">The fulltime.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("jobs")]
        public async Task<ActionResult> Index(string description, string location, string fulltime, int? page)
        {
            var jobViewModel = await _jobsService.GetJobModelView(description, location, fulltime, page);

            return View(jobViewModel);
        }
    }
}