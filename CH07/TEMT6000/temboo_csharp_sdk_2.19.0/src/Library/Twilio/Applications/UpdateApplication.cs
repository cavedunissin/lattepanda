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

namespace Temboo.Library.Twilio.Applications
{
    /// <summary>
    /// UpdateApplication
    /// Updates an existing application within your account.
    /// </summary>
    public class UpdateApplication : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateApplication Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateApplication(TembooSession session) : base(session, "/Library/Twilio/Applications/UpdateApplication")
        {
        }

         /// <summary>
         /// (optional, string) Requests to this application's URLs will start a new TwiML session with this API version. Either 2010-04-01 or 2008-08-01. Defaults to your account's default API version.
         /// </summary>
         /// <param name="value">Value of the APIVersion input for this Choreo.</param>
         public void setAPIVersion(String value) {
             base.addInput ("APIVersion", value);
         }
         /// <summary>
         /// (required, string) The AccountSID provided when you signed up for a Twilio account.
         /// </summary>
         /// <param name="value">Value of the AccountSID input for this Choreo.</param>
         public void setAccountSID(String value) {
             base.addInput ("AccountSID", value);
         }
         /// <summary>
         /// (required, string) The id of the application to update.
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
         /// (optional, string) A human readable description of the new application. Maximum 64 characters.
         /// </summary>
         /// <param name="value">Value of the FriendlyName input for this Choreo.</param>
         public void setFriendlyName(String value) {
             base.addInput ("FriendlyName", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The HTTP method that should be used to request the SmsFallbackUrl. Must be either GET or POST. Defaults to POST.
         /// </summary>
         /// <param name="value">Value of the SmsFallbackMethod input for this Choreo.</param>
         public void setSmsFallbackMethod(String value) {
             base.addInput ("SmsFallbackMethod", value);
         }
         /// <summary>
         /// (optional, string) A URL that Twilio will request if an error occurs requesting or executing the TwiML defined by SmsUrl.
         /// </summary>
         /// <param name="value">Value of the SmsFallbackURL input for this Choreo.</param>
         public void setSmsFallbackURL(String value) {
             base.addInput ("SmsFallbackURL", value);
         }
         /// <summary>
         /// (optional, string) The HTTP method that should be used to request the SmsUrl. Must be either GET or POST. Defaults to POST.
         /// </summary>
         /// <param name="value">Value of the SmsMethod input for this Choreo.</param>
         public void setSmsMethod(String value) {
             base.addInput ("SmsMethod", value);
         }
         /// <summary>
         /// (optional, string) Twilio will make a POST request to this URL to pass status parameters (such as sent or failed) to your application.
         /// </summary>
         /// <param name="value">Value of the SmsStatusCallback input for this Choreo.</param>
         public void setSmsStatusCallback(String value) {
             base.addInput ("SmsStatusCallback", value);
         }
         /// <summary>
         /// (optional, string) The URL that Twilio should request when somebody sends an SMS to a phone number assigned to this application.
         /// </summary>
         /// <param name="value">Value of the SmsURL input for this Choreo.</param>
         public void setSmsURL(String value) {
             base.addInput ("SmsURL", value);
         }
         /// <summary>
         /// (optional, string) The URL that Twilio will request to pass status parameters (such as call ended) to your application.
         /// </summary>
         /// <param name="value">Value of the StatusCallback input for this Choreo.</param>
         public void setStatusCallback(String value) {
             base.addInput ("StatusCallback", value);
         }
         /// <summary>
         /// (optional, string) The HTTP method Twilio will use to make requests to the StatusCallback URL. Either GET or POST. Defaults to POST.
         /// </summary>
         /// <param name="value">Value of the StatusCallbackMethod input for this Choreo.</param>
         public void setStatusCallbackMethod(String value) {
             base.addInput ("StatusCallbackMethod", value);
         }
         /// <summary>
         /// (optional, string) The 34 character sid of the application Twilio should use to handle phone calls to this number.
         /// </summary>
         /// <param name="value">Value of the VoiceApplicationSID input for this Choreo.</param>
         public void setVoiceApplicationSID(String value) {
             base.addInput ("VoiceApplicationSID", value);
         }
         /// <summary>
         /// (optional, string) Do a lookup of a caller's name from the CNAM database and post it to your app. Either true or false. Defaults to false.
         /// </summary>
         /// <param name="value">Value of the VoiceCallerIDLookup input for this Choreo.</param>
         public void setVoiceCallerIDLookup(String value) {
             base.addInput ("VoiceCallerIDLookup", value);
         }
         /// <summary>
         /// (optional, string) The HTTP method that should be used to request the VoiceFallbackUrl. Either GET or POST. Defaults to POST.
         /// </summary>
         /// <param name="value">Value of the VoiceFallbackMethod input for this Choreo.</param>
         public void setVoiceFallbackMethod(String value) {
             base.addInput ("VoiceFallbackMethod", value);
         }
         /// <summary>
         /// (optional, string) A URL that Twilio will request if an error occurs requesting or executing the TwiML at Url.
         /// </summary>
         /// <param name="value">Value of the VoiceFallbackURL input for this Choreo.</param>
         public void setVoiceFallbackURL(String value) {
             base.addInput ("VoiceFallbackURL", value);
         }
         /// <summary>
         /// (optional, string) The HTTP method that should be used to request the VoiceUrl. Must be either GET or POST. Defaults to POST.
         /// </summary>
         /// <param name="value">Value of the VoiceMethod input for this Choreo.</param>
         public void setVoiceMethod(String value) {
             base.addInput ("VoiceMethod", value);
         }
         /// <summary>
         /// (optional, string) The URL that Twilio should request when somebody dials a phone number assigned to this application.
         /// </summary>
         /// <param name="value">Value of the VoiceURL input for this Choreo.</param>
         public void setVoiceURL(String value) {
             base.addInput ("VoiceURL", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateApplicationResultSet containing execution metadata and results.</returns>
        new public UpdateApplicationResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateApplicationResultSet results = new JavaScriptSerializer().Deserialize<UpdateApplicationResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateApplication Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateApplicationResultSet : Temboo.Core.ResultSet
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
