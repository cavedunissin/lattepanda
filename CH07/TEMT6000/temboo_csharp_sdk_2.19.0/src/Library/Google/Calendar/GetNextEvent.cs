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

namespace Temboo.Library.Google.Calendar
{
    /// <summary>
    /// GetNextEvent
    /// Retrieves the next upcoming event in a Google calendar based on the current timestamp and the specified calendar's timezone setting.
    /// </summary>
    public class GetNextEvent : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetNextEvent Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetNextEvent(TembooSession session) : base(session, "/Library/Google/Calendar/GetNextEvent")
        {
        }

         /// <summary>
         /// (optional, string) A valid access token retrieved during the OAuth process. This is required unless you provide the ClientID, ClientSecret, and RefreshToken to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) The unique ID for the calendar with the next event to retrieve. Note that calendar IDs can be retrieved by running GetAllCalendars or SearchCalendarsByName.
         /// </summary>
         /// <param name="value">Value of the CalendarID input for this Choreo.</param>
         public void setCalendarID(String value) {
             base.addInput ("CalendarID", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Google. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by Google. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth Refresh Token used to generate a new access token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, string) The format that response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The time zone used in the response (i.e. America/Los_Angeles). The default is the time zone of the calendar.
         /// </summary>
         /// <param name="value">Value of the Timezone input for this Choreo.</param>
         public void setTimezone(String value) {
             base.addInput ("Timezone", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetNextEventResultSet containing execution metadata and results.</returns>
        new public GetNextEventResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetNextEventResultSet results = new JavaScriptSerializer().Deserialize<GetNextEventResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetNextEvent Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetNextEventResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "BeginTime" output from this Choreo execution
        /// <returns>String - (date) The start time of the event.</returns>
        /// </summary>
        public String BeginTime
        {
            get
            {
                return (String) base.Output["BeginTime"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "EndTime" output from this Choreo execution
        /// <returns>String - (date) The end time of the event.</returns>
        /// </summary>
        public String EndTime
        {
            get
            {
                return (String) base.Output["EndTime"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "NewAccessToken" output from this Choreo execution
        /// <returns>String - (string) Contains a new AccessToken when the RefreshToken is provided.</returns>
        /// </summary>
        public String NewAccessToken
        {
            get
            {
                return (String) base.Output["NewAccessToken"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Summary" output from this Choreo execution
        /// <returns>String - (string) The event summary.</returns>
        /// </summary>
        public String Summary
        {
            get
            {
                return (String) base.Output["Summary"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Google. Corresponds to the ResponseFormat input. Defaults to JSON.</returns>
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
