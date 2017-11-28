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
    /// Send
    /// Use this method to send funds to a destination user, from the user associated with the authorized access token.
    /// </summary>
    public class Send : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Send Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Send(TembooSession session) : base(session, "/Library/Dwolla/Transactions/Send")
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
         /// (required, decimal) Amount of funds to transfer to the destination user.
         /// </summary>
         /// <param name="value">Value of the Amount input for this Choreo.</param>
         public void setAmount(String value) {
             base.addInput ("Amount", value);
         }
         /// <summary>
         /// (required, boolean) Set to true if the user will assume the Dwolla fee. Set to false if the destination user will assume the Dwolla fee. Does not affect facilitator fees. Defaults to false.
         /// </summary>
         /// <param name="value">Value of the AssumeCosts input for this Choreo.</param>
         public void setAssumeCosts(String value) {
             base.addInput ("AssumeCosts", value);
         }
         /// <summary>
         /// (required, string) Identification of the user to send funds to. Must be the Dwolla identifier, Facebook identifier, Twitter identifier, phone number, or email address.
         /// </summary>
         /// <param name="value">Value of the DestinationId input for this Choreo.</param>
         public void setDestinationId(String value) {
             base.addInput ("DestinationId", value);
         }
         /// <summary>
         /// (optional, string) Type of destination user. Defaults to Dwolla. Can be Dwolla, Facebook, Twitter, Email, or Phone.
         /// </summary>
         /// <param name="value">Value of the DestinationType input for this Choreo.</param>
         public void setDestinationType(String value) {
             base.addInput ("DestinationType", value);
         }
         /// <summary>
         /// (required, string) Amount of the facilitator fee to override. Only applicable if the facilitator fee feature is enabled. If set to 0, facilitator fee is disabled for transaction. Cannot exceed 25% of the 'amount'.
         /// </summary>
         /// <param name="value">Value of the FacillitatorAmount input for this Choreo.</param>
         public void setFacillitatorAmount(String value) {
             base.addInput ("FacillitatorAmount", value);
         }
         /// <summary>
         /// (required, string) Id of funding source to send funds from. Defaults to Balance.  Balance sourced transfers process immediately. Non-balanced sourced transfers may process immediately or take up to five business days.
         /// </summary>
         /// <param name="value">Value of the FundsSource input for this Choreo.</param>
         public void setFundsSource(String value) {
             base.addInput ("FundsSource", value);
         }
         /// <summary>
         /// (required, multiline) Note to attach to the transaction. Limited to 250 characters.
         /// </summary>
         /// <param name="value">Value of the Notes input for this Choreo.</param>
         public void setNotes(String value) {
             base.addInput ("Notes", value);
         }
         /// <summary>
         /// (required, integer) User's PIN associated with their account
         /// </summary>
         /// <param name="value">Value of the Pin input for this Choreo.</param>
         public void setPin(String value) {
             base.addInput ("Pin", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SendResultSet containing execution metadata and results.</returns>
        new public SendResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SendResultSet results = new JavaScriptSerializer().Deserialize<SendResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Send Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SendResultSet : Temboo.Core.ResultSet
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
