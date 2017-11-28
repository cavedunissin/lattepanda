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

namespace Temboo.Library.Dwolla.Contacts
{
    /// <summary>
    /// UserContacts
    /// Retrieves the information for contacts for the user assoicated with the authorized access token.
    /// </summary>
    public class UserContacts : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UserContacts Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UserContacts(TembooSession session) : base(session, "/Library/Dwolla/Contacts/UserContacts")
        {
        }

         /// <summary>
         /// (required, string) A valid OAuth token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, integer) Number of contacts to retrieve. Defaults to 10. Can be between 1 and 200 contacts.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) Search term used to search the contacts.
         /// </summary>
         /// <param name="value">Value of the Search input for this Choreo.</param>
         public void setSearch(String value) {
             base.addInput ("Search", value);
         }
         /// <summary>
         /// (optional, string) Type of accounts to retrieve, in the form of a comma-separated list (e.g. "Facebook,Dwolla")
         /// </summary>
         /// <param name="value">Value of the Types input for this Choreo.</param>
         public void setTypes(String value) {
             base.addInput ("Types", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UserContactsResultSet containing execution metadata and results.</returns>
        new public UserContactsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UserContactsResultSet results = new JavaScriptSerializer().Deserialize<UserContactsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UserContacts Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UserContactsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Dwolla.</returns>
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
