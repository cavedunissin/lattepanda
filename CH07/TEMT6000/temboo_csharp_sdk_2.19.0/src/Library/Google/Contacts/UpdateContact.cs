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
    /// UpdateContact
    /// Update an existing contact's information.
    /// </summary>
    public class UpdateContact : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateContact Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateContact(TembooSession session) : base(session, "/Library/Google/Contacts/UpdateContact")
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
         /// (conditional, string) The id of the contact to update. Required unless providing a value for the Query input.
         /// </summary>
         /// <param name="value">Value of the ID input for this Choreo.</param>
         public void setID(String value) {
             base.addInput ("ID", value);
         }
         /// <summary>
         /// (conditional, string) The contact's new email address.
         /// </summary>
         /// <param name="value">Value of the NewEmail input for this Choreo.</param>
         public void setNewEmail(String value) {
             base.addInput ("NewEmail", value);
         }
         /// <summary>
         /// (conditional, string) The contact's new first name.
         /// </summary>
         /// <param name="value">Value of the NewFirstName input for this Choreo.</param>
         public void setNewFirstName(String value) {
             base.addInput ("NewFirstName", value);
         }
         /// <summary>
         /// (conditional, string) The contact's new last name.
         /// </summary>
         /// <param name="value">Value of the NewLastName input for this Choreo.</param>
         public void setNewLastName(String value) {
             base.addInput ("NewLastName", value);
         }
         /// <summary>
         /// (optional, string) The contact's new telephone number.
         /// </summary>
         /// <param name="value">Value of the NewPhone input for this Choreo.</param>
         public void setNewPhone(String value) {
             base.addInput ("NewPhone", value);
         }
         /// <summary>
         /// (conditional, string) A search term to retrieve the contact to update, such as an email address, last name, or address. Required unless providing a value for the ID input.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
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
        /// <returns>A UpdateContactResultSet containing execution metadata and results.</returns>
        new public UpdateContactResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateContactResultSet results = new JavaScriptSerializer().Deserialize<UpdateContactResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateContact Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateContactResultSet : Temboo.Core.ResultSet
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
        /// <returns>String - (string) The unique ID for the contact returned by Google.</returns>
        /// </summary>
        public String ContactID
        {
            get
            {
                return (String) base.Output["ContactID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Email" output from this Choreo execution
        /// <returns>String - (string) The contact's current email address.</returns>
        /// </summary>
        public String Email
        {
            get
            {
                return (String) base.Output["Email"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "FirstName" output from this Choreo execution
        /// <returns>String - (string) The contact's current given name.</returns>
        /// </summary>
        public String FirstName
        {
            get
            {
                return (String) base.Output["FirstName"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "LastName" output from this Choreo execution
        /// <returns>String - (string) The contact's current family name.</returns>
        /// </summary>
        public String LastName
        {
            get
            {
                return (String) base.Output["LastName"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Phone" output from this Choreo execution
        /// <returns>String - (string) The contact's current telephone number.</returns>
        /// </summary>
        public String Phone
        {
            get
            {
                return (String) base.Output["Phone"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Google.</returns>
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
