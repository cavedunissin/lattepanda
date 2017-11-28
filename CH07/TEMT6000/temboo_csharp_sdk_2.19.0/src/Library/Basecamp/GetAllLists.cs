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
    /// GetAllLists
    /// Retrieves all To-do lists assigned to a specified user or company.
    /// </summary>
    public class GetAllLists : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetAllLists Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetAllLists(TembooSession session) : base(session, "/Library/Basecamp/GetAllLists")
        {
        }

         /// <summary>
         /// (required, string) A valid Basecamp account name. This is the first part of the account's URL.
         /// </summary>
         /// <param name="value">Value of the AccountName input for this Choreo.</param>
         public void setAccountName(String value) {
             base.addInput ("AccountName", value);
         }
         /// <summary>
         /// (required, password) The Basecamp account password. Use the value 'X' when specifying an API Key for the Username input.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (optional, integer) The user ID or company ID  (preceded by a “c”, as in "c1234") the To-Do lists are assigned to. Defaults to unassigned To-Dos If left blank.
         /// </summary>
         /// <param name="value">Value of the ResponsibleParty input for this Choreo.</param>
         public void setResponsibleParty(String value) {
             base.addInput ("ResponsibleParty", value);
         }
         /// <summary>
         /// (required, string) A Basecamp account username or API Key.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetAllListsResultSet containing execution metadata and results.</returns>
        new public GetAllListsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetAllListsResultSet results = new JavaScriptSerializer().Deserialize<GetAllListsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetAllLists Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetAllListsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response returned from Basecamp.</returns>
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
