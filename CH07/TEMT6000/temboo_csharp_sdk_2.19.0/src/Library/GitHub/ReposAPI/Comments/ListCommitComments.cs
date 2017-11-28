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

namespace Temboo.Library.GitHub.ReposAPI.Comments
{
    /// <summary>
    /// ListCommitComments
    /// Retrieves a list of comments for a single commit.
    /// </summary>
    public class ListCommitComments : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListCommitComments Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListCommitComments(TembooSession session) : base(session, "/Library/GitHub/ReposAPI/Comments/ListCommitComments")
        {
        }

         /// <summary>
         /// (conditional, string) The Access Token retrieved during the OAuth process. Required when accessing a protected resource.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
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
         /// (required, string) The name of the repository.
         /// </summary>
         /// <param name="value">Value of the Repo input for this Choreo.</param>
         public void setRepo(String value) {
             base.addInput ("Repo", value);
         }
         /// <summary>
         /// (required, string) The SHA of the commit.
         /// </summary>
         /// <param name="value">Value of the SHA input for this Choreo.</param>
         public void setSHA(String value) {
             base.addInput ("SHA", value);
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
        /// <returns>A ListCommitCommentsResultSet containing execution metadata and results.</returns>
        new public ListCommitCommentsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListCommitCommentsResultSet results = new JavaScriptSerializer().Deserialize<ListCommitCommentsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListCommitComments Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListCommitCommentsResultSet : Temboo.Core.ResultSet
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
