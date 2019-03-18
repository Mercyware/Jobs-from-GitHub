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
        /// <param name="page">The page.</param>
        /// <returns></returns>
        Task<IJobModelView> GetJobModelView(int? page);
    }
}