using System.Threading.Tasks;
using GitHubJobs.Interface.Models;
using GitHubJobs.Interface.ViewModels;

namespace GitHubJobs.Interface.Domain.Services
{
    public interface IJobsService
    {
        /// <summary>
        /// Gets the job model view.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="location">The location.</param>
        /// <param name="fulltime">The fulltime.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        Task<IJobsViewModel> GetJobModelView(string description, string location, string fulltime,
            int? page = 1);
    }
}