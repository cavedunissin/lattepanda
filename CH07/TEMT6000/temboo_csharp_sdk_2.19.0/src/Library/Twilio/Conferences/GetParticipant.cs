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

namespace Temboo.Library.Twilio.Conferences
{
    /// <summary>
    /// GetParticipant
    /// Retrieves details for an individual participant of a conference.
    /// </summary>
    public class GetParticipant : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetParticipant Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetParticipant(TembooSession session) : base(session, "/Library/Twilio/Conferences/GetParticipant")
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
         /// (required, string) The call id associated with the participant to retrieve.
         /// </summary>
         /// <param name="value">Value of the CallSID input for this Choreo.</param>
         public void setCallSID(String value) {
             base.addInput ("CallSID", value);
         }
         /// <summary>
         /// (required, string) The id of the conference that the participant is in.
         /// </summary>
         /// <param name="value">Value of the ConferencesSID input for this Choreo.</param>
         public void setConferencesSID(String value) {
             base.addInput ("ConferencesSID", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The SID of the subaccount associated with the conference. If not specified, the main AccountSID used to authenticate is used in the request.
         /// </summary>
         /// <param name="value">Value of the SubAccountSID input for this Choreo.</param>
         public void setSubAccountSID(String value) {
             base.addInput ("SubAccountSID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetParticipantResultSet containing execution metadata and results.</returns>
        new public GetParticipantResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetParticipantResultSet results = new JavaScriptSerializer().Deserialize<GetParticipantResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetParticipant Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetParticipantResultSet : Temboo.Core.ResultSet
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
