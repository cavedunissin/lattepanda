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

namespace Temboo.Library.OneLogin.Accounts
{
    /// <summary>
    /// UpdateAccount
    /// Updates an existing account.
    /// </summary>
    public class UpdateAccount : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateAccount Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateAccount(TembooSession session) : base(session, "/Library/OneLogin/Accounts/UpdateAccount")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by OneLogin.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The account name.
         /// </summary>
         /// <param name="value">Value of the AccountName input for this Choreo.</param>
         public void setAccountName(String value) {
             base.addInput ("AccountName", value);
         }
         /// <summary>
         /// (optional, string) The street address for the new account.
         /// </summary>
         /// <param name="value">Value of the Address input for this Choreo.</param>
         public void setAddress(String value) {
             base.addInput ("Address", value);
         }
         /// <summary>
         /// (optional, string) The city associated with the address.
         /// </summary>
         /// <param name="value">Value of the City input for this Choreo.</param>
         public void setCity(String value) {
             base.addInput ("City", value);
         }
         /// <summary>
         /// (optional, string) The country associated with the address of the new account.
         /// </summary>
         /// <param name="value">Value of the Country input for this Choreo.</param>
         public void setCountry(String value) {
             base.addInput ("Country", value);
         }
         /// <summary>
         /// (required, string) The email address for the new account.
         /// </summary>
         /// <param name="value">Value of the Email input for this Choreo.</param>
         public void setEmail(String value) {
             base.addInput ("Email", value);
         }
         /// <summary>
         /// (required, string) The first name on the new account.
         /// </summary>
         /// <param name="value">Value of the FirstName input for this Choreo.</param>
         public void setFirstName(String value) {
             base.addInput ("FirstName", value);
         }
         /// <summary>
         /// (required, integer) The id of the account to update.
         /// </summary>
         /// <param name="value">Value of the ID input for this Choreo.</param>
         public void setID(String value) {
             base.addInput ("ID", value);
         }
         /// <summary>
         /// (required, string) The last name on the new account.
         /// </summary>
         /// <param name="value">Value of the LastName input for this Choreo.</param>
         public void setLastName(String value) {
             base.addInput ("LastName", value);
         }
         /// <summary>
         /// (optional, string) The phone number for the new account.
         /// </summary>
         /// <param name="value">Value of the Phone input for this Choreo.</param>
         public void setPhone(String value) {
             base.addInput ("Phone", value);
         }
         /// <summary>
         /// (required, string) Indicates which plan the new account has (i.e. enterprise).
         /// </summary>
         /// <param name="value">Value of the Plan input for this Choreo.</param>
         public void setPlan(String value) {
             base.addInput ("Plan", value);
         }
         /// <summary>
         /// (optional, string) The state associated with the address of the new account.
         /// </summary>
         /// <param name="value">Value of the State input for this Choreo.</param>
         public void setState(String value) {
             base.addInput ("State", value);
         }
         /// <summary>
         /// (optional, string) The postal code associated with the address of the new account.
         /// </summary>
         /// <param name="value">Value of the Zip input for this Choreo.</param>
         public void setZip(String value) {
             base.addInput ("Zip", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateAccountResultSet containing execution metadata and results.</returns>
        new public UpdateAccountResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateAccountResultSet results = new JavaScriptSerializer().Deserialize<UpdateAccountResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateAccount Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateAccountResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from OneLogin.</returns>
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
