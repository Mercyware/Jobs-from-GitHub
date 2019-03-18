using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GitHubJobs.Interface;
using GitHubJobs.Interface.Domain.Services;
using GitHubJobs.Interface.ViewModels;
using GitHubJobs.Interface.Models;
using GitHubJobs.Repository.Model;
using Newtonsoft.Json;


namespace GitHubJobs.Domain.Services
{
    public class JobsService : IJobsService
    {
        private static HttpClient httpClient;
        private static string url = "https://jobs.github.com/positions.json";
        private readonly IJobViewFactory _jobViewFactory;


        /// <summary>
        /// Initializes a new instance of the <see cref="JobsService"/> class.
        /// </summary>
        /// <param name="jobViewFactory">The job view factory.</param>
        public JobsService(IJobViewFactory jobViewFactory)
        {
            httpClient = new HttpClient();
            this._jobViewFactory = jobViewFactory;
        }


        /// <summary>
        /// Gets the job model view.
        /// </summary>
        /// <returns></returns>
        public async Task<IJobModelView> GetJobModelView(int? page = 1)
        {
            //Connect to the API

            try
            {
              var  clientUrl = string.Format("{0}?page={1}", url, page);

                //this is the function that calls the api
                var response = await httpClient.GetAsync(clientUrl);

                //convert the json to string 
                var json = await response.Content.ReadAsStringAsync();

                //Get The Jobs List from the API
                var jobs = JsonConvert.DeserializeObject<IEnumerable<Job>>(json);


                //Generate the view from the factory
                var jobViewModel = this._jobViewFactory.JobView(jobs, page ?? 1);

                return jobViewModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        //Get The List of available jobs for without parameter
    }
}