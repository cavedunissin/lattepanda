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

namespace Temboo.Library.Twitter.Timelines
{
    /// <summary>
    /// UserTimeline
    /// Retrieves a collection of the most recent Tweets posted by the user whose screen_name or user_id is indicated.
    /// </summary>
    public class UserTimeline : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UserTimeline Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UserTimeline(TembooSession session) : base(session, "/Library/Twitter/Timelines/UserTimeline")
        {
        }

         /// <summary>
         /// (conditional, string) The Access Token provided by Twitter or retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The Access Token Secret provided by Twitter or retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessTokenSecret input for this Choreo.</param>
         public void setAccessTokenSecret(String value) {
             base.addInput ("AccessTokenSecret", value);
         }
         /// <summary>
         /// (conditional, string) The API Key (or Consumer Key) provided by Twitter.
         /// </summary>
         /// <param name="value">Value of the ConsumerKey input for this Choreo.</param>
         public void setConsumerKey(String value) {
             base.addInput ("ConsumerKey", value);
         }
         /// <summary>
         /// (conditional, string) The API Secret (or Consumer Secret) provided by Twitter.
         /// </summary>
         /// <param name="value">Value of the ConsumerSecret input for this Choreo.</param>
         public void setConsumerSecret(String value) {
             base.addInput ("ConsumerSecret", value);
         }
         /// <summary>
         /// (optional, boolean) Set to true to include the screen_name of the contributor. By default only the user_id of the contributor is included.
         /// </summary>
         /// <param name="value">Value of the ContributorDetails input for this Choreo.</param>
         public void setContributorDetails(String value) {
             base.addInput ("ContributorDetails", value);
         }
         /// <summary>
         /// (optional, integer) Specifies the number of records to retrieve. Must be less than or equal to 200. Defaults to 20.
         /// </summary>
         /// <param name="value">Value of the Count input for this Choreo.</param>
         public void setCount(String value) {
             base.addInput ("Count", value);
         }
         /// <summary>
         /// (optional, boolean) Set to true to prevent replies from appearing in the returned timeline.
         /// </summary>
         /// <param name="value">Value of the ExcludeReplies input for this Choreo.</param>
         public void setExcludeReplies(String value) {
             base.addInput ("ExcludeReplies", value);
         }
         /// <summary>
         /// (optional, boolean) When set to true, the response will include the "entities" node.
         /// </summary>
         /// <param name="value">Value of the IncludeRetweets input for this Choreo.</param>
         public void setIncludeRetweets(String value) {
             base.addInput ("IncludeRetweets", value);
         }
         /// <summary>
         /// (optional, string) Returns results with an ID less than (older than) or equal to the specified ID.
         /// </summary>
         /// <param name="value">Value of the MaxId input for this Choreo.</param>
         public void setMaxId(String value) {
             base.addInput ("MaxId", value);
         }
         /// <summary>
         /// (conditional, string) Screen name of the user to return results for. Required unless providing the UserId.
         /// </summary>
         /// <param name="value">Value of the ScreenName input for this Choreo.</param>
         public void setScreenName(String value) {
             base.addInput ("ScreenName", value);
         }
         /// <summary>
         /// (optional, string) Returns results with an ID greater than (more recent than) the specified ID.
         /// </summary>
         /// <param name="value">Value of the SinceId input for this Choreo.</param>
         public void setSinceId(String value) {
             base.addInput ("SinceId", value);
         }
         /// <summary>
         /// (optional, boolean) When set to true, each tweet returned in a timeline will include a user object including only the status authors numerical ID. Defaults to false.
         /// </summary>
         /// <param name="value">Value of the TrimUser input for this Choreo.</param>
         public void setTrimUser(String value) {
             base.addInput ("TrimUser", value);
         }
         /// <summary>
         /// (conditional, string) ID of the user to return results for. Required unless providing the ScreenName.
         /// </summary>
         /// <param name="value">Value of the UserId input for this Choreo.</param>
         public void setUserId(String value) {
             base.addInput ("UserId", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UserTimelineResultSet containing execution metadata and results.</returns>
        new public UserTimelineResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UserTimelineResultSet results = new JavaScriptSerializer().Deserialize<UserTimelineResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UserTimeline Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UserTimelineResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Limit" output from this Choreo execution
        /// <returns>String - (integer) The rate limit ceiling for this particular request.</returns>
        /// </summary>
        public String Limit
        {
            get
            {
                return (String) base.Output["Limit"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Remaining" output from this Choreo execution
        /// <returns>String - (integer) The number of requests left for the 15 minute window.</returns>
        /// </summary>
        public String Remaining
        {
            get
            {
                return (String) base.Output["Remaining"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Reset" output from this Choreo execution
        /// <returns>String - (date) The remaining window before the rate limit resets in UTC epoch seconds.</returns>
        /// </summary>
        public String Reset
        {
            get
            {
                return (String) base.Output["Reset"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Twitter.</returns>
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
