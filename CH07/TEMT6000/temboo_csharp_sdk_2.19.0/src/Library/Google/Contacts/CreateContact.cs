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

namespace Temboo.Library.Google.Contacts
{
    /// <summary>
    /// CreateContact
    /// Create a new contact.
    /// </summary>
    public class CreateContact : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateContact Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateContact(TembooSession session) : base(session, "/Library/Google/Contacts/CreateContact")
        {
        }

         /// <summary>
         /// (optional, string) The access token retrieved in the last step of the OAuth process. Access tokens that are expired will be refreshed and returned in the Choreo output.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The OAuth client ID provided by Google when you register your application.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The OAuth client secret provided by Google when you registered your application.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (conditional, string) The new contact's email address.
         /// </summary>
         /// <param name="value">Value of the Email input for this Choreo.</param>
         public void setEmail(String value) {
             base.addInput ("Email", value);
         }
         /// <summary>
         /// (conditional, string) The new contact's first name.
         /// </summary>
         /// <param name="value">Value of the FirstName input for this Choreo.</param>
         public void setFirstName(String value) {
             base.addInput ("FirstName", value);
         }
         /// <summary>
         /// (conditional, string) The new contact's last name.
         /// </summary>
         /// <param name="value">Value of the LastName input for this Choreo.</param>
         public void setLastName(String value) {
             base.addInput ("LastName", value);
         }
         /// <summary>
         /// (optional, string) The phone number for the new contact. It's best to use the "(555) 123-4567" format.
         /// </summary>
         /// <param name="value">Value of the Phone input for this Choreo.</param>
         public void setPhone(String value) {
             base.addInput ("Phone", value);
         }
         /// <summary>
         /// (conditional, string) The refresh token retrieved in the last step of the OAuth process. This is used when an access token is expired or not provided.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateContactResultSet containing execution metadata and results.</returns>
        new public CreateContactResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateContactResultSet results = new JavaScriptSerializer().Deserialize<CreateContactResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateContact Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateContactResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "AccessToken" output from this Choreo execution
        /// <returns>String - (optional, string) The access token retrieved in the last step of the OAuth process. Access tokens that are expired will be refreshed and returned in the Choreo output.</returns>
        /// </summary>
        public String AccessToken
        {
            get
            {
                return (String) base.Output["AccessToken"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ContactID" output from this Choreo execution
        /// <returns>String - (string) The unique ID supplied by Google for the new user.</returns>
        /// </summary>
        public String ContactID
        {
            get
            {
                return (String) base.Output["ContactID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from the API.</returns>
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
