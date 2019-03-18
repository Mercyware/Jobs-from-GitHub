using System;
using System.Collections;
using System.Web;
namespace GitHubJobs.Interface.Models
{
    public interface IJob
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        string Type { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        string Url { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        string Created_At { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        string Company { get; set; }

        /// <summary>
        /// Gets or sets the company URL.
        /// </summary>
        /// <value>
        /// The company URL.
        /// </value>
        string Company_Url { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        string Location { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the how to apply.
        /// </summary>
        /// <value>
        /// The how to apply.
        /// </value>
        string How_To_Apply { get; set; }

        /// <summary>
        /// Gets or sets the company logo.
        /// </summary>
        /// <value>
        /// The company logo.
        /// </value>
        string Company_Logo { get; set; }
    }
}