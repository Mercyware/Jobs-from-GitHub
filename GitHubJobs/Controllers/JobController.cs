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

        // GET: Job
        [Route("jobs/{page}")]
        public async Task<ActionResult> Index(int? page)
        {
            var jobViewModel = await _jobsService.GetJobModelView(page);

            return View(jobViewModel);
        }
    }
}