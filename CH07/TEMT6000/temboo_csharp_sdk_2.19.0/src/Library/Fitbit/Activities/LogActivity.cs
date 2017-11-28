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

namespace Temboo.Library.Fitbit.Activities
{
    /// <summary>
    /// LogActivity
    /// Log a new activity for a particular date.
    /// </summary>
    public class LogActivity : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the LogActivity Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public LogActivity(TembooSession session) : base(session, "/Library/Fitbit/Activities/LogActivity")
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
         /// (conditional, integer) This can be the id of the activity, directory activity, or intensity level activity.
         /// </summary>
         /// <param name="value">Value of the ActivityID input for this Choreo.</param>
         public void setActivityID(String value) {
             base.addInput ("ActivityID", value);
         }
         /// <summary>
         /// (conditional, string) Custom activity name; either activityId or activityName should be provided.
         /// </summary>
         /// <param name="value">Value of the ActivityName input for this Choreo.</param>
         public void setActivityName(String value) {
             base.addInput ("ActivityName", value);
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
         /// (required, date) The date that corresponds with the new log entry (in the format yyyy-MM-dd).
         /// </summary>
         /// <param name="value">Value of the Date input for this Choreo.</param>
         public void setDate(String value) {
             base.addInput ("Date", value);
         }
         /// <summary>
         /// (conditional, decimal) The activity distance. Used when activityId corresponds to 'Running'  or 'Walking' for example.
         /// </summary>
         /// <param name="value">Value of the Distance input for this Choreo.</param>
         public void setDistance(String value) {
             base.addInput ("Distance", value);
         }
         /// <summary>
         /// (conditional, string) Corresponds with the Distance parameter (i.e. Mile). See Choreo documentation for links to unit charts.
         /// </summary>
         /// <param name="value">Value of the DistanceUnit input for this Choreo.</param>
         public void setDistanceUnit(String value) {
             base.addInput ("DistanceUnit", value);
         }
         /// <summary>
         /// (required, integer) The duration of the activity in milliseconds.
         /// </summary>
         /// <param name="value">Value of the Duration input for this Choreo.</param>
         public void setDuration(String value) {
             base.addInput ("Duration", value);
         }
         /// <summary>
         /// (conditional, integer) The amount of calories defined manually; required when using the ActivityName parameter, otherwise optional.
         /// </summary>
         /// <param name="value">Value of the ManualCalories input for this Choreo.</param>
         public void setManualCalories(String value) {
             base.addInput ("ManualCalories", value);
         }
         /// <summary>
         /// (optional, string) The format that you want the response to be in: xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The hour and minutes for the start of the activity formatted like HH:mm.
         /// </summary>
         /// <param name="value">Value of the StartTime input for this Choreo.</param>
         public void setStartTime(String value) {
             base.addInput ("StartTime", value);
         }
         /// <summary>
         /// (optional, string) The user's encoded id. Defaults to "-" (dash) which will return data for the user associated with the token credentials provided.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A LogActivityResultSet containing execution metadata and results.</returns>
        new public LogActivityResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            LogActivityResultSet results = new JavaScriptSerializer().Deserialize<LogActivityResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the LogActivity Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class LogActivityResultSet : Temboo.Core.ResultSet
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
