using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using GitHubJobs.Controllers;
using GitHubJobs.Domain.Services;
using GitHubJobs.Interface.Domain.Services;
using GitHubJobs.Interface.ViewModels;
using GitHubJobs.Repository.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace GitHubJobs.Tests.Controllers
{
    [TestFixture]
    public class JobControllerTest
    {
        private IJobsService jobsService;
        private JobController jobController;
        private IJobsViewModel jobViewModel;
        private IEnumerable<Job> jobList;
        private Task<IJobsViewModel> jobTask;

        [SetUp]
        public void Setup()
        {
            this.jobsService = MockRepository.GenerateMock<IJobsService>();

            this.jobController = new JobController(this.jobsService);

            this.jobViewModel = new JobsViewModel
                {Page = 1, Jobs = null, Location = "testLocation", Description = "testDescription", FullTime = "true"};

            jobList = new List<Job>();

            jobViewModel = new JobsViewModel
            {
                Jobs = jobList,
                Description = "testDescription",
                Location = "testLocation",
                FullTime = "true",
                Page = 1
            };

            jobTask = Task<IJobsViewModel>.Factory.StartNew(() => new JobsViewModel
                {Page = 1, Jobs = null, Location = "model", Description = "testDescription", FullTime = "true"});
        }


        [Test]
        public async Task Test_That_JobController_Calls_GetJobModelView_of_JobService_Succesfully()
        {
            //Setup
            this.jobsService.Expect(p => p.GetJobModelView("model", "model", "model", 1)).IgnoreArguments()
                .Return(jobTask);

            //Act
            await this.jobController.Index("testDescription", "testLocation", "true", 1);
        }


        [Test]
        public async Task Test_That_Job_Controller_Return_A_View_That_is_Not_Null()
        {
            //Setup
            this.jobsService.Expect(p => p.GetJobModelView("model", "model", "model", 1)).IgnoreArguments()
                .Return(jobTask);


            //Act
            var result = (ViewResult) await this.jobController.Index("testDescription", "testLocation", "true", 1);


            //Assert
            Assert.IsNotNull(result);
        }


       
    }
}