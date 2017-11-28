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

namespace Temboo.Library.Highrise
{
    /// <summary>
    /// ShowPeople
    /// Retrieves contacts from your Highrise CRM.
    /// </summary>
    public class ShowPeople : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ShowPeople Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ShowPeople(TembooSession session) : base(session, "/Library/Highrise/ShowPeople")
        {
        }

         /// <summary>
         /// (required, string) A Highrise account username or API Key.
         /// </summary>
         /// <param name="value">Value of the AccountName input for this Choreo.</param>
         public void setAccountName(String value) {
             base.addInput ("AccountName", value);
         }
         /// <summary>
         /// (required, integer) The ID of the contact you want to retrieve. This is used to construct the URL for the request.
         /// </summary>
         /// <param name="value">Value of the ConactID input for this Choreo.</param>
         public void setConactID(String value) {
             base.addInput ("ConactID", value);
         }
         /// <summary>
         /// (required, password) The Highrise account password. Use the value 'X' when specifying an API Key for the Username input.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, string) A Highrise account username or API Key.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ShowPeopleResultSet containing execution metadata and results.</returns>
        new public ShowPeopleResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ShowPeopleResultSet results = new JavaScriptSerializer().Deserialize<ShowPeopleResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ShowPeople Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ShowPeopleResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Highrise.</returns>
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
