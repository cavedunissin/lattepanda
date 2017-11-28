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

namespace Temboo.Library.Twitter.SuggestedUsers
{
    /// <summary>
    /// GetSuggestedUsers
    /// Retrieves users in a given category of the Twitter suggested user list.
    /// </summary>
    public class GetSuggestedUsers : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetSuggestedUsers Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetSuggestedUsers(TembooSession session) : base(session, "/Library/Twitter/SuggestedUsers/GetSuggestedUsers")
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
         /// (optional, string) Restricts the suggested categories to the requested language. The language must be specified by the appropriate two letter ISO 639-1 code (e.g., en).
         /// </summary>
         /// <param name="value">Value of the Language input for this Choreo.</param>
         public void setLanguage(String value) {
             base.addInput ("Language", value);
         }
         /// <summary>
         /// (optional, boolean) When set to true, makes a request to users/suggestions/:slug/members and retrieves the most recent statuses for users that are not protected.
         /// </summary>
         /// <param name="value">Value of the Members input for this Choreo.</param>
         public void setMembers(String value) {
             base.addInput ("Members", value);
         }
         /// <summary>
         /// (required, string) The short name of  the category (e.g., news, technology, government). These are returned in the response of the GetSuggestedCategories Choreo.
         /// </summary>
         /// <param name="value">Value of the Slug input for this Choreo.</param>
         public void setSlug(String value) {
             base.addInput ("Slug", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetSuggestedUsersResultSet containing execution metadata and results.</returns>
        new public GetSuggestedUsersResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetSuggestedUsersResultSet results = new JavaScriptSerializer().Deserialize<GetSuggestedUsersResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetSuggestedUsers Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetSuggestedUsersResultSet : Temboo.Core.ResultSet
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
