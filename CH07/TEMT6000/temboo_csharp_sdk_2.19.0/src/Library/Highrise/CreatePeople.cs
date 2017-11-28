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
    /// CreatePeople
    /// Creates a new contact record in your Highrise CRM.
    /// </summary>
    public class CreatePeople : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreatePeople Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreatePeople(TembooSession session) : base(session, "/Library/Highrise/CreatePeople")
        {
        }

         /// <summary>
         /// (required, string) A valid Highrise account name. This is the first part of the account's URL.
         /// </summary>
         /// <param name="value">Value of the AccountName input for this Choreo.</param>
         public void setAccountName(String value) {
             base.addInput ("AccountName", value);
         }
         /// <summary>
         /// (optional, string) Corresponds to the background field in Highrise
         /// </summary>
         /// <param name="value">Value of the Background input for this Choreo.</param>
         public void setBackground(String value) {
             base.addInput ("Background", value);
         }
         /// <summary>
         /// (optional, string) Corresponds to the company name field in Highrise.
         /// </summary>
         /// <param name="value">Value of the CompanyName input for this Choreo.</param>
         public void setCompanyName(String value) {
             base.addInput ("CompanyName", value);
         }
         /// <summary>
         /// (optional, string) Corresponds to the email address field in Highrise.
         /// </summary>
         /// <param name="value">Value of the EmailAddress input for this Choreo.</param>
         public void setEmailAddress(String value) {
             base.addInput ("EmailAddress", value);
         }
         /// <summary>
         /// (required, string) Corresponds to the first name field in Highrise.
         /// </summary>
         /// <param name="value">Value of the FirstName input for this Choreo.</param>
         public void setFirstName(String value) {
             base.addInput ("FirstName", value);
         }
         /// <summary>
         /// (optional, string) Corresponds to the home phone field in Highrise.
         /// </summary>
         /// <param name="value">Value of the HomePhone input for this Choreo.</param>
         public void setHomePhone(String value) {
             base.addInput ("HomePhone", value);
         }
         /// <summary>
         /// (optional, string) Corresponds to the last name field in Highrise.
         /// </summary>
         /// <param name="value">Value of the LastName input for this Choreo.</param>
         public void setLastName(String value) {
             base.addInput ("LastName", value);
         }
         /// <summary>
         /// (required, password) The Highrise account password. Use the value 'X' when specifying an API Key for the Username input.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (optional, string) Corresponds to the title field in Highrise.
         /// </summary>
         /// <param name="value">Value of the Title input for this Choreo.</param>
         public void setTitle(String value) {
             base.addInput ("Title", value);
         }
         /// <summary>
         /// (required, string) A Highrise account username or API Key.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }
         /// <summary>
         /// (optional, string) Corresponds to the work phone field in Highrise.
         /// </summary>
         /// <param name="value">Value of the WorkPhone input for this Choreo.</param>
         public void setWorkPhone(String value) {
             base.addInput ("WorkPhone", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreatePeopleResultSet containing execution metadata and results.</returns>
        new public CreatePeopleResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreatePeopleResultSet results = new JavaScriptSerializer().Deserialize<CreatePeopleResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreatePeople Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreatePeopleResultSet : Temboo.Core.ResultSet
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
