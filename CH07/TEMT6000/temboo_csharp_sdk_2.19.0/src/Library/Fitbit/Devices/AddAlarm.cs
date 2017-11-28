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

namespace Temboo.Library.Fitbit.Devices
{
    /// <summary>
    /// AddAlarm
    /// Creates an alarm entry for a given device.
    /// </summary>
    public class AddAlarm : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AddAlarm Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AddAlarm(TembooSession session) : base(session, "/Library/Fitbit/Devices/AddAlarm")
        {
        }

         /// <summary>
         /// (required, string) The Access Token retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the AccessTokenSecret input for this Choreo.</param>
         public void setAccessTokenSecret(String value) {
             base.addInput ("AccessTokenSecret", value);
         }
         /// <summary>
         /// (required, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the ConsumerKey input for this Choreo.</param>
         public void setConsumerKey(String value) {
             base.addInput ("ConsumerKey", value);
         }
         /// <summary>
         /// (required, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the ConsumerSecret input for this Choreo.</param>
         public void setConsumerSecret(String value) {
             base.addInput ("ConsumerSecret", value);
         }
         /// <summary>
         /// (required, string) The id of the device you would like to manage the alarm on.
         /// </summary>
         /// <param name="value">Value of the DeviceID input for this Choreo.</param>
         public void setDeviceID(String value) {
             base.addInput ("DeviceID", value);
         }
         /// <summary>
         /// (required, boolean) Indicates whether or not the alarm is enabled. Valid values are: true and false.
         /// </summary>
         /// <param name="value">Value of the Enabled input for this Choreo.</param>
         public void setEnabled(String value) {
             base.addInput ("Enabled", value);
         }
         /// <summary>
         /// (optional, string) A label for the alarm.
         /// </summary>
         /// <param name="value">Value of the Label input for this Choreo.</param>
         public void setLabel(String value) {
             base.addInput ("Label", value);
         }
         /// <summary>
         /// (required, boolean) Specifies if this is a one-time or recurring alarm. Valid values are: true or false. When adding a recurring alarm, the WeekDays input is required.
         /// </summary>
         /// <param name="value">Value of the Recurring input for this Choreo.</param>
         public void setRecurring(String value) {
             base.addInput ("Recurring", value);
         }
         /// <summary>
         /// (optional, string) The format that you want the response to be in: xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, integer) The maximum snooze count.
         /// </summary>
         /// <param name="value">Value of the SnoozeCount input for this Choreo.</param>
         public void setSnoozeCount(String value) {
             base.addInput ("SnoozeCount", value);
         }
         /// <summary>
         /// (optional, integer) The number of minutes in between alarms when using the snooze option.
         /// </summary>
         /// <param name="value">Value of the SnoozeLength input for this Choreo.</param>
         public void setSnoozeLength(String value) {
             base.addInput ("SnoozeLength", value);
         }
         /// <summary>
         /// (required, string) The time of the alarm in the format XX:XX+XX:XX (the hour, minute, and time offset from UTC). This will be converted to the timezone of the user's profile.
         /// </summary>
         /// <param name="value">Value of the Time input for this Choreo.</param>
         public void setTime(String value) {
             base.addInput ("Time", value);
         }
         /// <summary>
         /// (optional, string) The user's encoded id. Defaults to "-" (dash) which will return data for the user associated with the token credentials provided.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }
         /// <summary>
         /// (optional, string) The vibe pattern. Currently this only has one accepted value: DEFAULT.
         /// </summary>
         /// <param name="value">Value of the Vibe input for this Choreo.</param>
         public void setVibe(String value) {
             base.addInput ("Vibe", value);
         }
         /// <summary>
         /// (required, string) Specifies the days of the week that the alarm is active. Required when specifying a "recurring" alarm. Multiple days can be specified in a comma-separated list (e.g., MONDAY,TUESDAY,WEDNESDAY).
         /// </summary>
         /// <param name="value">Value of the WeekDays input for this Choreo.</param>
         public void setWeekDays(String value) {
             base.addInput ("WeekDays", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AddAlarmResultSet containing execution metadata and results.</returns>
        new public AddAlarmResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AddAlarmResultSet results = new JavaScriptSerializer().Deserialize<AddAlarmResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AddAlarm Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AddAlarmResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Fitbit.</returns>
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
