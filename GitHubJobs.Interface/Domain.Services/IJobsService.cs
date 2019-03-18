using System.Threading.Tasks;
using GitHubJobs.Interface.Models;
using GitHubJobs.Interface.ViewModels;

namespace GitHubJobs.Interface.Domain.Services
{
    public interface IJobsService
    {
         Task<IJobModelView> GetJobModelView();
    }
}