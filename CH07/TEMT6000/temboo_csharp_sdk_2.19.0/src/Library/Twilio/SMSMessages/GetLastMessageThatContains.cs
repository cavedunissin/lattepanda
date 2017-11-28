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
    /// GetLastMessageThatContains
    /// Retrieves the latest received message that contains the specified search string.
    /// </summary>
    public class GetLastMessageThatContains : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetLastMessageThatContains Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetLastMessageThatContains(TembooSession session) : base(session, "/Library/Twilio/SMSMessages/GetLastMessageThatContains")
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
         /// (optional, string) Returns messages after the specified message sid. Required when using the pagination parameters. To return message sids in the response, set ResponseMode to "verbose".
         /// </summary>
         /// <param name="value">Value of the AfterSID input for this Choreo.</param>
         public void setAfterSID(String value) {
             base.addInput ("AfterSID", value);
         }
         /// <summary>
         /// (required, string) The authorization token provided when you signed up for a Twilio account.
         /// </summary>
         /// <param name="value">Value of the AuthToken input for this Choreo.</param>
         public void setAuthToken(String value) {
             base.addInput ("AuthToken", value);
         }
         /// <summary>
         /// (required, string) A search string to apply to the message body field.
         /// </summary>
         /// <param name="value">Value of the Filter input for this Choreo.</param>
         public void setFilter(String value) {
             base.addInput ("Filter", value);
         }
         /// <summary>
         /// (optional, integer) The page of results to retrieve. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, integer) The number of results per page to search through. Defaults to 50.
         /// </summary>
         /// <param name="value">Value of the PageSize input for this Choreo.</param>
         public void setPageSize(String value) {
             base.addInput ("PageSize", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml. This parameter is only valid when setting ResponseMode to "verbose".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Used to simplify the response. Valid values are: simple and verbose. When set to simple, only the message string is returned. Verbose mode returns the full object. Defaults to "simple".
         /// </summary>
         /// <param name="value">Value of the ResponseMode input for this Choreo.</param>
         public void setResponseMode(String value) {
             base.addInput ("ResponseMode", value);
         }
         /// <summary>
         /// (optional, boolean) If set to true, XML responses will be formatted using the deprecated /SMS/Messages resource schema. This should only be used if you have existing code that relies on the older schema.
         /// </summary>
         /// <param name="value">Value of the ReturnLegacyFormat input for this Choreo.</param>
         public void setReturnLegacyFormat(String value) {
             base.addInput ("ReturnLegacyFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetLastMessageThatContainsResultSet containing execution metadata and results.</returns>
        new public GetLastMessageThatContainsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetLastMessageThatContainsResultSet results = new JavaScriptSerializer().Deserialize<GetLastMessageThatContainsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetLastMessageThatContains Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetLastMessageThatContainsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "TotalPages" output from this Choreo execution
        /// <returns>String - (integer) Deprecated (retained for backward compatibility only).</returns>
        /// </summary>
        public String TotalPages
        {
            get
            {
                return (String) base.Output["TotalPages"];
            }
        }
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
