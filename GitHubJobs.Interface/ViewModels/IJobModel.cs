using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubJobs.Interface.Models
{
    public interface IJobModel
    {
        string Id { get; set; }
        string Type { get; set; }
        string Url { get; set; }
        string Created_At { get; set; }
        string Company { get; set; }
        string Company_Url { get; set; }
        string Location { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string How_To_Apply { get; set; }
        string Company_Logo { get; set; }
    }
}