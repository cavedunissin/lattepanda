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

namespace Temboo.Library.Twitter.FriendsAndFollowers
{
    /// <summary>
    /// FriendshipsShow
    /// Returns detailed information about the relationship between two users.
    /// </summary>
    public class FriendshipsShow : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FriendshipsShow Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FriendshipsShow(TembooSession session) : base(session, "/Library/Twitter/FriendsAndFollowers/FriendshipsShow")
        {
        }

         /// <summary>
         /// (required, string) The Access Token provided by Twitter or retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) The Access Token Secret provided by Twitter or retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessTokenSecret input for this Choreo.</param>
         public void setAccessTokenSecret(String value) {
             base.addInput ("AccessTokenSecret", value);
         }
         /// <summary>
         /// (required, string) The API Key (or Consumer Key) provided by Twitter.
         /// </summary>
         /// <param name="value">Value of the ConsumerKey input for this Choreo.</param>
         public void setConsumerKey(String value) {
             base.addInput ("ConsumerKey", value);
         }
         /// <summary>
         /// (required, string) The API Secret (or Consumer Secret) provided by Twitter.
         /// </summary>
         /// <param name="value">Value of the ConsumerSecret input for this Choreo.</param>
         public void setConsumerSecret(String value) {
             base.addInput ("ConsumerSecret", value);
         }
         /// <summary>
         /// (conditional, string) The screen_name of the subject user. Required unless specifying the SourceUserID instead.
         /// </summary>
         /// <param name="value">Value of the SourceScreenName input for this Choreo.</param>
         public void setSourceScreenName(String value) {
             base.addInput ("SourceScreenName", value);
         }
         /// <summary>
         /// (conditional, string) The ID of the subject user. Required unless specifying the SourceScreenName instead.
         /// </summary>
         /// <param name="value">Value of the SourceUserID input for this Choreo.</param>
         public void setSourceUserID(String value) {
             base.addInput ("SourceUserID", value);
         }
         /// <summary>
         /// (conditional, string) The screen_name of the target user. Required unless specifying the TargetUserID instead.
         /// </summary>
         /// <param name="value">Value of the TargetScreenName input for this Choreo.</param>
         public void setTargetScreenName(String value) {
             base.addInput ("TargetScreenName", value);
         }
         /// <summary>
         /// (conditional, string) The ID of the target user. Required unless specifying the TargetScreenName instead.
         /// </summary>
         /// <param name="value">Value of the TargetUserID input for this Choreo.</param>
         public void setTargetUserID(String value) {
             base.addInput ("TargetUserID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A FriendshipsShowResultSet containing execution metadata and results.</returns>
        new public FriendshipsShowResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FriendshipsShowResultSet results = new JavaScriptSerializer().Deserialize<FriendshipsShowResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FriendshipsShow Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FriendshipsShowResultSet : Temboo.Core.ResultSet
    {
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
