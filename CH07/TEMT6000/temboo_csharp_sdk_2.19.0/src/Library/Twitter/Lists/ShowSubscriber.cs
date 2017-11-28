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

namespace Temboo.Library.Twitter.Lists
{
    /// <summary>
    /// ShowSubscriber
    /// Verifies that the specified user is a subscriber of the specified list.
    /// </summary>
    public class ShowSubscriber : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ShowSubscriber Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ShowSubscriber(TembooSession session) : base(session, "/Library/Twitter/Lists/ShowSubscriber")
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
         /// (optional, boolean) The "entities" node containing extra metadata will not be included when set to false.
         /// </summary>
         /// <param name="value">Value of the IncludeEntities input for this Choreo.</param>
         public void setIncludeEntities(String value) {
             base.addInput ("IncludeEntities", value);
         }
         /// <summary>
         /// (conditional, string) The numerical ID of the list. Required unless Slug is provided.
         /// </summary>
         /// <param name="value">Value of the ListId input for this Choreo.</param>
         public void setListId(String value) {
             base.addInput ("ListId", value);
         }
         /// <summary>
         /// (optional, string) The user ID of the user who owns the list being requested by a slug.
         /// </summary>
         /// <param name="value">Value of the OwnerId input for this Choreo.</param>
         public void setOwnerId(String value) {
             base.addInput ("OwnerId", value);
         }
         /// <summary>
         /// (optional, string) The screen name of the user who owns the list being requested by a slug.
         /// </summary>
         /// <param name="value">Value of the OwnerScreenName input for this Choreo.</param>
         public void setOwnerScreenName(String value) {
             base.addInput ("OwnerScreenName", value);
         }
         /// <summary>
         /// (conditional, string) The screen name of the user to retrieve from the list. Required unless providing the UserId.
         /// </summary>
         /// <param name="value">Value of the ScreenName input for this Choreo.</param>
         public void setScreenName(String value) {
             base.addInput ("ScreenName", value);
         }
         /// <summary>
         /// (optional, boolean) When set to either true, statuses will not be included in the returned user objects.
         /// </summary>
         /// <param name="value">Value of the SkipStatus input for this Choreo.</param>
         public void setSkipStatus(String value) {
             base.addInput ("SkipStatus", value);
         }
         /// <summary>
         /// (optional, string) When identifying a list by a slug, either OwnerScreenName or OwnerId must be provided.
         /// </summary>
         /// <param name="value">Value of the Slug input for this Choreo.</param>
         public void setSlug(String value) {
             base.addInput ("Slug", value);
         }
         /// <summary>
         /// (conditional, string) The ID of the user to retrieve from the list. Required unless providing the ScreenName.
         /// </summary>
         /// <param name="value">Value of the UserId input for this Choreo.</param>
         public void setUserId(String value) {
             base.addInput ("UserId", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ShowSubscriberResultSet containing execution metadata and results.</returns>
        new public ShowSubscriberResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ShowSubscriberResultSet results = new JavaScriptSerializer().Deserialize<ShowSubscriberResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ShowSubscriber Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ShowSubscriberResultSet : Temboo.Core.ResultSet
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
