﻿using System;
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
        /// <param name="description">The description.</param>
        /// <param name="location">The location.</param>
        /// <param name="fulltime">The fulltime.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public async Task<IJobsViewModel> GetJobModelView(string description, string location, string fulltime,
            int? page = 1)
        {
            //Connect to the API

            try
            {
                var clientUrl = string.Format("{0}?page={1}&description={2}&location={3}&fulltime={4}", url, page,
                    description, location, fulltime);

                //this is the function that calls the api
                var response = await httpClient.GetAsync(clientUrl);

                //convert the json to string 
                var json = await response.Content.ReadAsStringAsync();

                //Get The Jobs List from the API
                var jobs = JsonConvert.DeserializeObject<IEnumerable<Job>>(json);


                //Generate the view from the factory
                var jobViewModel = this._jobViewFactory.JobView(jobs, description, location, fulltime, page ?? 1);

                return jobViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }


       
    }
}