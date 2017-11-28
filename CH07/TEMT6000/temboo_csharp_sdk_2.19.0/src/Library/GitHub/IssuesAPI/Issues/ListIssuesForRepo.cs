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

namespace Temboo.Library.GitHub.IssuesAPI.Issues
{
    /// <summary>
    /// ListIssuesForRepo
    /// List all issues for a specified repository.
    /// </summary>
    public class ListIssuesForRepo : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListIssuesForRepo Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListIssuesForRepo(TembooSession session) : base(session, "/Library/GitHub/IssuesAPI/Issues/ListIssuesForRepo")
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
         /// (required, string) Can be set to a username, "none" for issues with no assinged user, or * for issues with any assigned user.
         /// </summary>
         /// <param name="value">Value of the Assignee input for this Choreo.</param>
         public void setAssignee(String value) {
             base.addInput ("Assignee", value);
         }
         /// <summary>
         /// (optional, string) The user that created the issue.
         /// </summary>
         /// <param name="value">Value of the Creator input for this Choreo.</param>
         public void setCreator(String value) {
             base.addInput ("Creator", value);
         }
         /// <summary>
         /// (optional, string) The direction of the sort order. Valid values are: asc or desc (the default).
         /// </summary>
         /// <param name="value">Value of the Direction input for this Choreo.</param>
         public void setDirection(String value) {
             base.addInput ("Direction", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of label names (i.e. bug, ui, etc).
         /// </summary>
         /// <param name="value">Value of the Labels input for this Choreo.</param>
         public void setLabels(String value) {
             base.addInput ("Labels", value);
         }
         /// <summary>
         /// (optional, string) A Github username that is mentioned.
         /// </summary>
         /// <param name="value">Value of the Mentioned input for this Choreo.</param>
         public void setMentioned(String value) {
             base.addInput ("Mentioned", value);
         }
         /// <summary>
         /// (required, string) Can be set to a milestone number, "none" for issues with no milestone, or * for issues with any milestone.
         /// </summary>
         /// <param name="value">Value of the Milestone input for this Choreo.</param>
         public void setMilestone(String value) {
             base.addInput ("Milestone", value);
         }
         /// <summary>
         /// (optional, integer) Indicates the page index that you want to retrieve. This is used to page through many results. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to return per page.
         /// </summary>
         /// <param name="value">Value of the PerPage input for this Choreo.</param>
         public void setPerPage(String value) {
             base.addInput ("PerPage", value);
         }
         /// <summary>
         /// (required, string) The name of the repo.
         /// </summary>
         /// <param name="value">Value of the Repo input for this Choreo.</param>
         public void setRepo(String value) {
             base.addInput ("Repo", value);
         }
         /// <summary>
         /// (optional, date) A timestamp in ISO 8601 format (YYYY-MM-DDTHH:MM:SSZ). Returns issues since this date.
         /// </summary>
         /// <param name="value">Value of the Since input for this Choreo.</param>
         public void setSince(String value) {
             base.addInput ("Since", value);
         }
         /// <summary>
         /// (optional, string) Indicates how the issues will be sorted in the response. Valid sort options are: created (the default), updated, comments.
         /// </summary>
         /// <param name="value">Value of the Sort input for this Choreo.</param>
         public void setSort(String value) {
             base.addInput ("Sort", value);
         }
         /// <summary>
         /// (optional, string) Returns issues with a particular state: open (the default) or closed.
         /// </summary>
         /// <param name="value">Value of the State input for this Choreo.</param>
         public void setState(String value) {
             base.addInput ("State", value);
         }
         /// <summary>
         /// (required, string) The GitHub account owner.
         /// </summary>
         /// <param name="value">Value of the User input for this Choreo.</param>
         public void setUser(String value) {
             base.addInput ("User", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListIssuesForRepoResultSet containing execution metadata and results.</returns>
        new public ListIssuesForRepoResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListIssuesForRepoResultSet results = new JavaScriptSerializer().Deserialize<ListIssuesForRepoResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListIssuesForRepo Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListIssuesForRepoResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "FirstPage" output from this Choreo execution
        /// <returns>String - (integer) The index for the first page of results.</returns>
        /// </summary>
        public String FirstPage
        {
            get
            {
                return (String) base.Output["FirstPage"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "LastPage" output from this Choreo execution
        /// <returns>String - (integer) The index for the last page of results.</returns>
        /// </summary>
        public String LastPage
        {
            get
            {
                return (String) base.Output["LastPage"];
            }
        }
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
        /// Retrieve the value for the "NextPage" output from this Choreo execution
        /// <returns>String - (integer) The index for the next page of results.</returns>
        /// </summary>
        public String NextPage
        {
            get
            {
                return (String) base.Output["NextPage"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "PreviousPage" output from this Choreo execution
        /// <returns>String - (integer) The index for the previous page of results.</returns>
        /// </summary>
        public String PreviousPage
        {
            get
            {
                return (String) base.Output["PreviousPage"];
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
