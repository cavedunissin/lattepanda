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
    /// ListMessages
    /// Retrieves a list of SMS messages from your Twilio account.
    /// </summary>
    public class ListMessages : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListMessages Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListMessages(TembooSession session) : base(session, "/Library/Twilio/SMSMessages/ListMessages")
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
         /// (optional, date) A date in YYYY-MM-DD format. If you use this input, the Choreo will retrieve only messages sent on this date.
         /// </summary>
         /// <param name="value">Value of the DateSent input for this Choreo.</param>
         public void setDateSent(String value) {
             base.addInput ("DateSent", value);
         }
         /// <summary>
         /// (optional, string) If used, the Choreo will only retrieve messages sent from this phone number.
         /// </summary>
         /// <param name="value">Value of the From input for this Choreo.</param>
         public void setFrom(String value) {
             base.addInput ("From", value);
         }
         /// <summary>
         /// (optional, integer) The page of results to retrieve. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, integer) The number of results per page.
         /// </summary>
         /// <param name="value">Value of the PageSize input for this Choreo.</param>
         public void setPageSize(String value) {
             base.addInput ("PageSize", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, boolean) If set to true, the response will be formatted using the deprecated /SMS/Messages resource schema. This should only be used if you have existing code that relies on the older schema.
         /// </summary>
         /// <param name="value">Value of the ReturnLegacyFormat input for this Choreo.</param>
         public void setReturnLegacyFormat(String value) {
             base.addInput ("ReturnLegacyFormat", value);
         }
         /// <summary>
         /// (optional, string) The SID of the subaccount to retrieve the message from. If not specified, the main AccountSID used to authenticate is used in request.
         /// </summary>
         /// <param name="value">Value of the SubAccountSID input for this Choreo.</param>
         public void setSubAccountSID(String value) {
             base.addInput ("SubAccountSID", value);
         }
         /// <summary>
         /// (optional, string) If used, the Choreo will only retrieve messages sent to this phone number.
         /// </summary>
         /// <param name="value">Value of the To input for this Choreo.</param>
         public void setTo(String value) {
             base.addInput ("To", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListMessagesResultSet containing execution metadata and results.</returns>
        new public ListMessagesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListMessagesResultSet results = new JavaScriptSerializer().Deserialize<ListMessagesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListMessages Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListMessagesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Twilio.</returns>
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
