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

namespace Temboo.Library.RunKeeper.Users
{
    /// <summary>
    /// RetrieveUserInfo
    /// Returns the available resources for a specific user and the URIs for accessing them. 
    /// </summary>
    public class RetrieveUserInfo : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RetrieveUserInfo Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RetrieveUserInfo(TembooSession session) : base(session, "/Library/RunKeeper/Users/RetrieveUserInfo")
        {
        }

         /// <summary>
         /// (required, string) The Access Token retrieved after the final step in the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RetrieveUserInfoResultSet containing execution metadata and results.</returns>
        new public RetrieveUserInfoResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RetrieveUserInfoResultSet results = new JavaScriptSerializer().Deserialize<RetrieveUserInfoResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RetrieveUserInfo Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RetrieveUserInfoResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from RunKeeper.</returns>
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
