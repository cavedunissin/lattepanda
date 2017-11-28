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

namespace Temboo.Library.Twilio.SMSMessages
{
    /// <summary>
    /// SendSMS
    /// Sends an SMS to a specified phone number using the Twilio API.
    /// </summary>
    public class SendSMS : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SendSMS Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SendSMS(TembooSession session) : base(session, "/Library/Twilio/SMSMessages/SendSMS")
        {
        }

         /// <summary>
         /// (required, string) The AccountSID provided when you signed up for a Twilio account.
         /// </summary>
         /// <param name="value">Value of the AccountSID input for this Choreo.</param>
         public void setAccountSID(String value) {
             base.addInput ("AccountSID", value);
         }
         /// <summary>
         /// (required, string) The authorization token provided when you signed up for a Twilio account.
         /// </summary>
         /// <param name="value">Value of the AuthToken input for this Choreo.</param>
         public void setAuthToken(String value) {
             base.addInput ("AuthToken", value);
         }
         /// <summary>
         /// (conditional, string) The text of the message.
         /// </summary>
         /// <param name="value">Value of the Body input for this Choreo.</param>
         public void setBody(String value) {
             base.addInput ("Body", value);
         }
         /// <summary>
         /// (required, string) The purchased Twilio phone number, Twilio Sandbox number, or short code enabled for the type of message you wish to send (SMS or MMS). Format with a '+' and country code e.g., +16175551212.
         /// </summary>
         /// <param name="value">Value of the From input for this Choreo.</param>
         public void setFrom(String value) {
             base.addInput ("From", value);
         }
         /// <summary>
         /// (optional, string) One or more URLs for media you wish to send with the message. Supported formats include: png, gif, and jpeg. Multiple URLs (up-to 10) should be separated by commas.
         /// </summary>
         /// <param name="value">Value of the MediaURL input for this Choreo.</param>
         public void setMediaURL(String value) {
             base.addInput ("MediaURL", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The SID of the subaccount to send the message from. If not specified, the main AccountSID used to authenticate is used in request.
         /// </summary>
         /// <param name="value">Value of the SubAccountSID input for this Choreo.</param>
         public void setSubAccountSID(String value) {
             base.addInput ("SubAccountSID", value);
         }
         /// <summary>
         /// (required, string) The destination phone number. Format with a '+' and country code e.g., +16175551212.
         /// </summary>
         /// <param name="value">Value of the To input for this Choreo.</param>
         public void setTo(String value) {
             base.addInput ("To", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SendSMSResultSet containing execution metadata and results.</returns>
        new public SendSMSResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SendSMSResultSet results = new JavaScriptSerializer().Deserialize<SendSMSResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SendSMS Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SendSMSResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The Twilio response.</returns>
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
