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

namespace Temboo.Library.GitHub.GistsAPI.Gists
{
    /// <summary>
    /// CreateGist
    /// Creates a gist.
    /// </summary>
    public class CreateGist : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateGist Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateGist(TembooSession session) : base(session, "/Library/GitHub/GistsAPI/Gists/CreateGist")
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
         /// (optional, string) The description for this gist.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (required, string) The file contents of the gist.
         /// </summary>
         /// <param name="value">Value of the FileContents input for this Choreo.</param>
         public void setFileContents(String value) {
             base.addInput ("FileContents", value);
         }
         /// <summary>
         /// (required, string) The file name of the gist (i.e. myProject.py).
         /// </summary>
         /// <param name="value">Value of the FileName input for this Choreo.</param>
         public void setFileName(String value) {
             base.addInput ("FileName", value);
         }
         /// <summary>
         /// (required, boolean) Indicates whether or not the gist is public or private.
         /// </summary>
         /// <param name="value">Value of the Public input for this Choreo.</param>
         public void setPublic(String value) {
             base.addInput ("Public", value);
         }
         /// <summary>
         /// (required, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the User input for this Choreo.</param>
         public void setUser(String value) {
             base.addInput ("User", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateGistResultSet containing execution metadata and results.</returns>
        new public CreateGistResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateGistResultSet results = new JavaScriptSerializer().Deserialize<CreateGistResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateGist Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateGistResultSet : Temboo.Core.ResultSet
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
