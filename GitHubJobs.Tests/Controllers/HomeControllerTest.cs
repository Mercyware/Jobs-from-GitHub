﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using GitHubJobs;
using GitHubJobs.Controllers;
using GitHubJobs.Domain.Services;
using GitHubJobs.Interface.Domain.Services;
using GitHubJobs.Interface.ViewModels;
using GitHubJobs.Repository.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace GitHubJobs.Tests.Controllers
{
    [TestFixture, Category("Controllers")]
    public class HomeControllerTest
    {
        private IJobsService jobsService;


        private HomeController homeController;

        private IJobsViewModel jobViewModel;
        private IEnumerable<Job> jobList;
        private Task<IJobsViewModel> jobTask;

        [SetUp]
        public void Setup()
        {
            this.jobsService = MockRepository.GenerateMock<IJobsService>();
            this.homeController = new HomeController(this.jobsService);

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
        public async Task Index_Calls_GetJobModelView_from_JobsService_Successfully()
        {
            //Setup
            this.jobsService.Expect(p => p.GetJobModelView("model", "model", "model", 1)).IgnoreArguments()
                .Return(jobTask);

            //Act
            await this.homeController.Index();


            //Assert
            this.jobsService.VerifyAllExpectations();
        }

        [Test]
        public async Task Test_That_Index_Returns_A_ViewResult_That_Is_Not_Null()
        {
            //Setup
            this.jobsService.Expect(p => p.GetJobModelView("model", "model", "model", 1)).IgnoreArguments()
                .Return(jobTask);

            // Act
            ViewResult result = await this.homeController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [Test]
        public void Test_About_Us_Return_A_View_That_is_Not_Null()
        {
            ViewResult result = this.homeController.About() as ViewResult;

        
            //Asset
            Assert.IsNotNull(result);
        }


    }
}