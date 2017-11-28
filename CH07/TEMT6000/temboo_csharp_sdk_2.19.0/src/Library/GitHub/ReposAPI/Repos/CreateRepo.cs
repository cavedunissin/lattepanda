using System;
using Temboo.Core;
using System.Web.Script.Serialization;

/*
Copyright 2014 Temboo, Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

namespace Temboo.Library.GitHub.ReposAPI.Repos
{
    /// <summary>
    /// CreateRepo
    /// Creates a new repository for the authenticated user.
    /// </summary>
    public class CreateRepo : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateRepo Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateRepo(TembooSession session) : base(session, "/Library/GitHub/ReposAPI/Repos/CreateRepo")
        {
        }

         /// <summary>
         /// (required, string) The Access Token retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, string) A text description for the repo.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (optional, boolean) Se to "true" to enable downloads for this repository. Defaults to "true".
         /// </summary>
         /// <param name="value">Value of the HasDownloads input for this Choreo.</param>
         public void setHasDownloads(String value) {
             base.addInput ("HasDownloads", value);
         }
         /// <summary>
         /// (optional, boolean) Set to "true" to enable issues for this repository. Defaults to "true."
         /// </summary>
         /// <param name="value">Value of the HasIssues input for this Choreo.</param>
         public void setHasIssues(String value) {
             base.addInput ("HasIssues", value);
         }
         /// <summary>
         /// (optional, boolean) Set to "true" to enable the wiki for this repository. Defaults to "true".
         /// </summary>
         /// <param name="value">Value of the HasWiki input for this Choreo.</param>
         public void setHasWiki(String value) {
             base.addInput ("HasWiki", value);
         }
         /// <summary>
         /// (optional, string) A homepage link.
         /// </summary>
         /// <param name="value">Value of the Homepage input for this Choreo.</param>
         public void setHomepage(String value) {
             base.addInput ("Homepage", value);
         }
         /// <summary>
         /// (required, string) The name of the repo being created.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (optional, boolean) A flag indicating the the repo is private or public. Set to "true" to create a private repository. Defaults to "false".
         /// </summary>
         /// <param name="value">Value of the Private input for this Choreo.</param>
         public void setPrivate(String value) {
             base.addInput ("Private", value);
         }
         /// <summary>
         /// (optional, integer) The id of the team that will be granted access to this repository. Only valid when creating a repo in an organization.
         /// </summary>
         /// <param name="value">Value of the TeamID input for this Choreo.</param>
         public void setTeamID(String value) {
             base.addInput ("TeamID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateRepoResultSet containing execution metadata and results.</returns>
        new public CreateRepoResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateRepoResultSet results = new JavaScriptSerializer().Deserialize<CreateRepoResultSet>(json);

            // Note that we may actually have run into an exception while trying to execute
            // this request; if so, then throw an appropriate exception
            if (results.Execution.LastError != null)
            {
                throw new TembooException(results.Execution.LastError);
            }
            return results;
        }

    }

    /// <summary>
    /// A ResultSet with methods tailored to the values returned by the CreateRepo Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateRepoResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Limit" output from this Choreo execution
        /// <returns>String - (integer) The available rate limit for your account. This is returned in the GitHub response header.</returns>
        /// </summary>
        public String Limit
        {
            get
            {
                return (String) base.Output["Limit"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Remaining" output from this Choreo execution
        /// <returns>String - (integer) The remaining number of API requests available to you. This is returned in the GitHub response header.</returns>
        /// </summary>
        public String Remaining
        {
            get
            {
                return (String) base.Output["Remaining"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from GitHub.</returns>
        /// </summary>
        public String Response
        {
            get
            {
                return (String) base.Output["Response"];
            }
        }
    }
}
