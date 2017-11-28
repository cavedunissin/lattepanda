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

namespace Temboo.Library.Nexmo.Account
{
    /// <summary>
    /// UpdateAccountSettings
    /// Update your account settings.
    /// </summary>
    public class UpdateAccountSettings : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateAccountSettings Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateAccountSettings(TembooSession session) : base(session, "/Library/Nexmo/Account/UpdateAccountSettings")
        {
        }

         /// <summary>
         /// (required, string) Your API Key provided to you by Nexmo.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) Your API Secret provided to you by Nexmo.
         /// </summary>
         /// <param name="value">Value of the APISecret input for this Choreo.</param>
         public void setAPISecret(String value) {
             base.addInput ("APISecret", value);
         }
         /// <summary>
         /// (conditional, string) Your new Delivery Receipt Callback URL.
         /// </summary>
         /// <param name="value">Value of the DeliveryReceiptCallbackURL input for this Choreo.</param>
         public void setDeliveryReceiptCallbackURL(String value) {
             base.addInput ("DeliveryReceiptCallbackURL", value);
         }
         /// <summary>
         /// (conditional, string) Your new Inbound Callback URL.
         /// </summary>
         /// <param name="value">Value of the InboundCallbackURL input for this Choreo.</param>
         public void setInboundCallbackURL(String value) {
             base.addInput ("InboundCallbackURL", value);
         }
         /// <summary>
         /// (optional, string) Your new API secret. (8 characters max)
         /// </summary>
         /// <param name="value">Value of the NewSecret input for this Choreo.</param>
         public void setNewSecret(String value) {
             base.addInput ("NewSecret", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "json" (the default) and "xml".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateAccountSettingsResultSet containing execution metadata and results.</returns>
        new public UpdateAccountSettingsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateAccountSettingsResultSet results = new JavaScriptSerializer().Deserialize<UpdateAccountSettingsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateAccountSettings Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateAccountSettingsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ResponseStatusCode" output from this Choreo execution
        /// <returns>String - (integer) The response status code returned from Nexmo.</returns>
        /// </summary>
        public String ResponseStatusCode
        {
            get
            {
                return (String) base.Output["ResponseStatusCode"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Nexmo. Corresponds to the ResponseFormat input. Defaults to json.</returns>
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
