using System.Threading.Tasks;
using GitHubJobs.Interface.Domain.Services;
using System.Web.Mvc;

namespace GitHubJobs.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobsService _jobsService;

        public HomeController(IJobsService jobsService)
        {
            this._jobsService = jobsService;
        }

        public async  Task<ActionResult> Index()
        {
            await _jobsService.GetJobModelView();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}