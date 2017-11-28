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
    /// CreateCommitComment
    /// Creates a comment on a specified commit.
    /// </summary>
    public class CreateCommitComment : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateCommitComment Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateCommitComment(TembooSession session) : base(session, "/Library/GitHub/ReposAPI/Comments/CreateCommitComment")
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
         /// (required, string) The comment text.
         /// </summary>
         /// <param name="value">Value of the Body input for this Choreo.</param>
         public void setBody(String value) {
             base.addInput ("Body", value);
         }
         /// <summary>
         /// (required, integer) The line number in the file to comment on.
         /// </summary>
         /// <param name="value">Value of the Line input for this Choreo.</param>
         public void setLine(String value) {
             base.addInput ("Line", value);
         }
         /// <summary>
         /// (required, string) The relative path of the file to comment on.
         /// </summary>
         /// <param name="value">Value of the Path input for this Choreo.</param>
         public void setPath(String value) {
             base.addInput ("Path", value);
         }
         /// <summary>
         /// (required, integer) The line index in the diff to comment on.
         /// </summary>
         /// <param name="value">Value of the Position input for this Choreo.</param>
         public void setPosition(String value) {
             base.addInput ("Position", value);
         }
         /// <summary>
         /// (required, string) The name of the repo that the comment is associated with.
         /// </summary>
         /// <param name="value">Value of the Repo input for this Choreo.</param>
         public void setRepo(String value) {
             base.addInput ("Repo", value);
         }
         /// <summary>
         /// (required, string) The SHA or id of the commit.
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
        /// <returns>A CreateCommitCommentResultSet containing execution metadata and results.</returns>
        new public CreateCommitCommentResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateCommitCommentResultSet results = new JavaScriptSerializer().Deserialize<CreateCommitCommentResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateCommitComment Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateCommitCommentResultSet : Temboo.Core.ResultSet
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
