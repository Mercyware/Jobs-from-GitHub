using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GitHubJobs.Domain.Services;
using GitHubJobs.Interface;
using GitHubJobs.Interface.Domain.Services;
using GitHubJobs.Interface.Models;
using GitHubJobs.Interface.ViewModels;
using GitHubJobs.Repository.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using Rhino.Mocks;


namespace GitHubJobs.Tests.Domain.Services
{
    [TestFixture]
    public class JobsServicesTest
    {
        private IJobViewFactory jobViewFactory;
        private IJobsService jobsService;
        private IEnumerable<Job> jobList;
        private IJobsViewModel jobViewModel;

        [SetUp]
        public void SetUp()
        {
            this.jobViewFactory = MockRepository.GenerateMock<IJobViewFactory>();
            this.jobsService = new JobsService(this.jobViewFactory);

            jobList = new List<Job>();

            jobViewModel = new JobsViewModel
            {
                Jobs = jobList,
                Description = "testDescription",
                Location = "testLocation",
                FullTime = "true",
                Page = 1
            };
        }


        [Test]
        public async Task Test_That_GetJobModelView_Calls_JobView_of_JobFactory_Successfully()
        {
            //Setup
            this.jobViewFactory.Expect(p => p.JobView(jobList, "description", "location", "true", 1)).IgnoreArguments()
                .Return(jobViewModel);

            //Act
            await this.jobsService.GetJobModelView("description", "location", "true", 1);

            //Assert
            this.jobViewFactory.VerifyAllExpectations();
        }


        [Test]
        public async Task Test_That_GetJobModelView_Returns_A_View_Successfully()
        {
            //Setup
            this.jobViewFactory.Stub(p => p.JobView(jobList, "description", "location", "true", 1)).IgnoreArguments()
                .Return(jobViewModel);

            //Act
            var model = await this.jobsService.GetJobModelView("description", "location", "true", 1);

            //Assert
            Assert.AreEqual(typeof(JobsViewModel), model.GetType());
        }
    }
}