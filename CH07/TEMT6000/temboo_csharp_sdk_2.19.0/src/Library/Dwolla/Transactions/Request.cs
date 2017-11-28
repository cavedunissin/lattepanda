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

namespace Temboo.Library.Dwolla.Transactions
{
    /// <summary>
    /// Request
    /// Use this method to request funds from a source user, originating from the user associated with the authorized access token.
    /// </summary>
    public class Request : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Request Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Request(TembooSession session) : base(session, "/Library/Dwolla/Transactions/Request")
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
         /// (required, decimal) Amount of funds to request from the source user.
         /// </summary>
         /// <param name="value">Value of the Amount input for this Choreo.</param>
         public void setAmount(String value) {
             base.addInput ("Amount", value);
         }
         /// <summary>
         /// (optional, decimal) Amount of the facilitator fee to override. Only applicable if the facilitator fee feature is enabled. If set to 0, facilitator fee is disabled for transaction. Cannot exceed 25% of the 'amount'.
         /// </summary>
         /// <param name="value">Value of the FacillitatorAmount input for this Choreo.</param>
         public void setFacillitatorAmount(String value) {
             base.addInput ("FacillitatorAmount", value);
         }
         /// <summary>
         /// (optional, multiline) Note to attach to the transaction. Limited to 250 characters.
         /// </summary>
         /// <param name="value">Value of the Notes input for this Choreo.</param>
         public void setNotes(String value) {
             base.addInput ("Notes", value);
         }
         /// <summary>
         /// (required, integer) User's PIN associated with their account.
         /// </summary>
         /// <param name="value">Value of the Pin input for this Choreo.</param>
         public void setPin(String value) {
             base.addInput ("Pin", value);
         }
         /// <summary>
         /// (required, string) Identification of the user to request funds from. Must be the Dwolla identifier, Facebook identifier, Twitter screename, phone number, or email address.
         /// </summary>
         /// <param name="value">Value of the SourceID input for this Choreo.</param>
         public void setSourceID(String value) {
             base.addInput ("SourceID", value);
         }
         /// <summary>
         /// (optional, string) Type of destination user. Defaults to Dwolla. Can be Dwolla, Facebook, Twitter, Email, or Phone.
         /// </summary>
         /// <param name="value">Value of the SourceType input for this Choreo.</param>
         public void setSourceType(String value) {
             base.addInput ("SourceType", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RequestResultSet containing execution metadata and results.</returns>
        new public RequestResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RequestResultSet results = new JavaScriptSerializer().Deserialize<RequestResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Request Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RequestResultSet : Temboo.Core.ResultSet
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
