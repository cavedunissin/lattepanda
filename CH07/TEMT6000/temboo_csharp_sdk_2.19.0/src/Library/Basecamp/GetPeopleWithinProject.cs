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

namespace Temboo.Library.Basecamp
{
    /// <summary>
    /// GetPeopleWithinProject
    /// Retrieves all people that have access to a specified project.
    /// </summary>
    public class GetPeopleWithinProject : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetPeopleWithinProject Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetPeopleWithinProject(TembooSession session) : base(session, "/Library/Basecamp/GetPeopleWithinProject")
        {
        }

         /// <summary>
         /// (required, string) The Basecamp account name for you or your company. This is the first part of your account URL.
         /// </summary>
         /// <param name="value">Value of the AccountName input for this Choreo.</param>
         public void setAccountName(String value) {
             base.addInput ("AccountName", value);
         }
         /// <summary>
         /// (required, password) Your Basecamp password.  You can use the value 'X' when specifying an API Key for the Username input.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, integer) The ID for the project associated with the people you want to retrieve.
         /// </summary>
         /// <param name="value">Value of the ProjectId input for this Choreo.</param>
         public void setProjectId(String value) {
             base.addInput ("ProjectId", value);
         }
         /// <summary>
         /// (required, string) Your Basecamp username or API Key.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetPeopleWithinProjectResultSet containing execution metadata and results.</returns>
        new public GetPeopleWithinProjectResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetPeopleWithinProjectResultSet results = new JavaScriptSerializer().Deserialize<GetPeopleWithinProjectResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetPeopleWithinProject Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetPeopleWithinProjectResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Basecamp.</returns>
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
