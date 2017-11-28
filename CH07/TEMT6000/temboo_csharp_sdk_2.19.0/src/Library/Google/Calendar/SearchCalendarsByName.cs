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
    /// SearchCalendarsByName
    /// Retrieves information about a calendar including the id with a given calendar name.
    /// </summary>
    public class SearchCalendarsByName : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchCalendarsByName Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchCalendarsByName(TembooSession session) : base(session, "/Library/Google/Calendar/SearchCalendarsByName")
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
         /// (required, string) The name of the calendar that you want to retrieve information for. Note that if there are multiple calendars with the same name, only the first one will be returned.
         /// </summary>
         /// <param name="value">Value of the CalendarName input for this Choreo.</param>
         public void setCalendarName(String value) {
             base.addInput ("CalendarName", value);
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
         /// (optional, integer) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the Count input for this Choreo.</param>
         public void setCount(String value) {
             base.addInput ("Count", value);
         }
         /// <summary>
         /// (optional, integer) The maximum number of calendars to search by name. The default is 15.
         /// </summary>
         /// <param name="value">Value of the MaxResults input for this Choreo.</param>
         public void setMaxResults(String value) {
             base.addInput ("MaxResults", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth Refresh Token used to generate a new access token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchCalendarsByNameResultSet containing execution metadata and results.</returns>
        new public SearchCalendarsByNameResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchCalendarsByNameResultSet results = new JavaScriptSerializer().Deserialize<SearchCalendarsByNameResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchCalendarsByName Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchCalendarsByNameResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "CalendarDescription" output from this Choreo execution
        /// <returns>String - (string) The calendar description parsed from the Google response.</returns>
        /// </summary>
        public String CalendarDescription
        {
            get
            {
                return (String) base.Output["CalendarDescription"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "CalendarId" output from this Choreo execution
        /// <returns>String - (string) The calendar id parsed from the Google response.</returns>
        /// </summary>
        public String CalendarId
        {
            get
            {
                return (String) base.Output["CalendarId"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "CalendarSummary" output from this Choreo execution
        /// <returns>String - (string) The summary or calendar name parsed from the Google response.</returns>
        /// </summary>
        public String CalendarSummary
        {
            get
            {
                return (String) base.Output["CalendarSummary"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "CalendarTimezone" output from this Choreo execution
        /// <returns>String - (string) The calendar timezone parsed from the Google response.</returns>
        /// </summary>
        public String CalendarTimezone
        {
            get
            {
                return (String) base.Output["CalendarTimezone"];
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
    }
}
