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

namespace Temboo.Library.GitHub.GitDataAPI.Tags
{
    /// <summary>
    /// CreateTag
    /// Creates a tag object.
    /// </summary>
    public class CreateTag : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateTag Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateTag(TembooSession session) : base(session, "/Library/GitHub/GitDataAPI/Tags/CreateTag")
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
         /// (required, string) The tag message.
         /// </summary>
         /// <param name="value">Value of the Message input for this Choreo.</param>
         public void setMessage(String value) {
             base.addInput ("Message", value);
         }
         /// <summary>
         /// (required, string) The SHA of the git object that is being tagged.
         /// </summary>
         /// <param name="value">Value of the Object input for this Choreo.</param>
         public void setObject(String value) {
             base.addInput ("Object", value);
         }
         /// <summary>
         /// (required, string) The name of the repo associated with the tag being created.
         /// </summary>
         /// <param name="value">Value of the Repo input for this Choreo.</param>
         public void setRepo(String value) {
             base.addInput ("Repo", value);
         }
         /// <summary>
         /// (required, string) A string to use for the tag (i.e. v0.0.1).
         /// </summary>
         /// <param name="value">Value of the Tag input for this Choreo.</param>
         public void setTag(String value) {
             base.addInput ("Tag", value);
         }
         /// <summary>
         /// (required, date) A timestamp of when the object is tagged. Should be formatted like: 2011-06-17T14:53:35-07:00.
         /// </summary>
         /// <param name="value">Value of the TaggerDate input for this Choreo.</param>
         public void setTaggerDate(String value) {
             base.addInput ("TaggerDate", value);
         }
         /// <summary>
         /// (required, string) The email of the author of the tag.
         /// </summary>
         /// <param name="value">Value of the TaggerEmail input for this Choreo.</param>
         public void setTaggerEmail(String value) {
             base.addInput ("TaggerEmail", value);
         }
         /// <summary>
         /// (required, string) The name of the author of the tag.
         /// </summary>
         /// <param name="value">Value of the TaggerName input for this Choreo.</param>
         public void setTaggerName(String value) {
             base.addInput ("TaggerName", value);
         }
         /// <summary>
         /// (required, string) The type of object that is being tagged. Valid values are: commit, tree, or blob.
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
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
        /// <returns>A CreateTagResultSet containing execution metadata and results.</returns>
        new public CreateTagResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateTagResultSet results = new JavaScriptSerializer().Deserialize<CreateTagResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateTag Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateTagResultSet : Temboo.Core.ResultSet
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
