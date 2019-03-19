using System.Threading.Tasks;
using GitHubJobs.Interface.Domain.Services;
using System.Web.Mvc;

namespace GitHubJobs.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobsService _jobsService;


        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="jobsService">The jobs service.</param>
        public HomeController(IJobsService jobsService)
        {
            this._jobsService = jobsService;
        }


        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            var page = 1;
            var jobViewModel = await _jobsService.GetJobModelView(null, null, null, page);

            return View(jobViewModel);
        }

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}