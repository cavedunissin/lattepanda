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

namespace Temboo.Library.Twilio.Calls
{
    /// <summary>
    /// MakeCall
    /// Initiates a call from the specified Twilio account.
    /// </summary>
    public class MakeCall : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the MakeCall Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public MakeCall(TembooSession session) : base(session, "/Library/Twilio/Calls/MakeCall")
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
         /// (conditional, string) The 34 character sid of the application Twilio should use to handle this phone call. Required unless providing the URL parameter.
         /// </summary>
         /// <param name="value">Value of the ApplicationSID input for this Choreo.</param>
         public void setApplicationSID(String value) {
             base.addInput ("ApplicationSID", value);
         }
         /// <summary>
         /// (required, string) The authorization token provided when you signed up for a Twilio account.
         /// </summary>
         /// <param name="value">Value of the AuthToken input for this Choreo.</param>
         public void setAuthToken(String value) {
             base.addInput ("AuthToken", value);
         }
         /// <summary>
         /// (optional, string) The HTTP method that Twilio should use to request the FallbackUrl. Valid values are: GET and POST.
         /// </summary>
         /// <param name="value">Value of the FallbackMethod input for this Choreo.</param>
         public void setFallbackMethod(String value) {
             base.addInput ("FallbackMethod", value);
         }
         /// <summary>
         /// (optional, string) A URL that Twilio will request if an error occurs making a request to the URL provided. This is ignored when ApplicationSID is provided.
         /// </summary>
         /// <param name="value">Value of the FallbackURL input for this Choreo.</param>
         public void setFallbackURL(String value) {
             base.addInput ("FallbackURL", value);
         }
         /// <summary>
         /// (required, string) The Twilio phone number or client identifier to use as the caller id.
         /// </summary>
         /// <param name="value">Value of the From input for this Choreo.</param>
         public void setFrom(String value) {
             base.addInput ("From", value);
         }
         /// <summary>
         /// (optional, string) Indicates if Twilio should to try and determine if a machine (like voicemail) or a human has answered the call. Possible values are "Continue" and "Hangup".
         /// </summary>
         /// <param name="value">Value of the IfMachine input for this Choreo.</param>
         public void setIfMachine(String value) {
             base.addInput ("IfMachine", value);
         }
         /// <summary>
         /// (optional, string) This the HTTP method Twilio will use when making its request to the URL (when the URL input is provided). Defaults to POST. This is ignored when ApplicationSID is provided.
         /// </summary>
         /// <param name="value">Value of the Method input for this Choreo.</param>
         public void setMethod(String value) {
             base.addInput ("Method", value);
         }
         /// <summary>
         /// (optional, boolean) Set this parameter to 'true' to record the entirety of a phone call.
         /// </summary>
         /// <param name="value">Value of the Record input for this Choreo.</param>
         public void setRecord(String value) {
             base.addInput ("Record", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) A string of keys to dial after connecting to the number. Valid digits in the string include: any digit (0-9), '#', '*' and 'w' (to insert a half second pause).
         /// </summary>
         /// <param name="value">Value of the SendDigits input for this Choreo.</param>
         public void setSendDigits(String value) {
             base.addInput ("SendDigits", value);
         }
         /// <summary>
         /// (optional, string) A URL that Twilio will request when the call ends to notify your app. This is ignored when ApplicationSID is provided.
         /// </summary>
         /// <param name="value">Value of the StatusCallback input for this Choreo.</param>
         public void setStatusCallback(String value) {
             base.addInput ("StatusCallback", value);
         }
         /// <summary>
         /// (optional, string) The HTTP method Twilio should use when requesting the StatusCallback URL. Defaults to POST. If an ApplicationSid parameter is present, this parameter is ignored.
         /// </summary>
         /// <param name="value">Value of the StatusCallbackMethod input for this Choreo.</param>
         public void setStatusCallbackMethod(String value) {
             base.addInput ("StatusCallbackMethod", value);
         }
         /// <summary>
         /// (optional, string) The SID of the subaccount associated with this call. If not specified, the main AccountSID used to authenticate is used in request.
         /// </summary>
         /// <param name="value">Value of the SubAccountSID input for this Choreo.</param>
         public void setSubAccountSID(String value) {
             base.addInput ("SubAccountSID", value);
         }
         /// <summary>
         /// (optional, integer) The integer number of seconds that Twilio should allow the phone to ring before assuming there is no answer. Default is 60 seconds, the maximum is 999 seconds.
         /// </summary>
         /// <param name="value">Value of the Timeout input for this Choreo.</param>
         public void setTimeout(String value) {
             base.addInput ("Timeout", value);
         }
         /// <summary>
         /// (required, string) The phone number or client identifier to call.
         /// </summary>
         /// <param name="value">Value of the To input for this Choreo.</param>
         public void setTo(String value) {
             base.addInput ("To", value);
         }
         /// <summary>
         /// (conditional, string) The fully qualified URL that should be consulted when the call connects. Required unless providing the ApplicationSID parameter.
         /// </summary>
         /// <param name="value">Value of the URL input for this Choreo.</param>
         public void setURL(String value) {
             base.addInput ("URL", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A MakeCallResultSet containing execution metadata and results.</returns>
        new public MakeCallResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            MakeCallResultSet results = new JavaScriptSerializer().Deserialize<MakeCallResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the MakeCall Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class MakeCallResultSet : Temboo.Core.ResultSet
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
