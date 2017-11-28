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

namespace Temboo.Library.Twitter.Tweets
{
    /// <summary>
    /// UpdateWithMedia
    /// Allows you to update your Twitter status and attach an image.
    /// </summary>
    public class UpdateWithMedia : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateWithMedia Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateWithMedia(TembooSession session) : base(session, "/Library/Twitter/Tweets/UpdateWithMedia")
        {
        }

         /// <summary>
         /// (required, string) The Base64 encoded image content to post to Twitter.
         /// </summary>
         /// <param name="value">Value of the MediaContent input for this Choreo.</param>
         public void setMediaContent(String value) {
             base.addInput ("MediaContent", value);
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
         /// (optional, boolean) Whether or not to put a pin on the exact coordinates a tweet has been sent from.
         /// </summary>
         /// <param name="value">Value of the DisplayCoordinates input for this Choreo.</param>
         public void setDisplayCoordinates(String value) {
             base.addInput ("DisplayCoordinates", value);
         }
         /// <summary>
         /// (optional, string) The ID of an existing status that the update is in reply to.
         /// </summary>
         /// <param name="value">Value of the InReplyTo input for this Choreo.</param>
         public void setInReplyTo(String value) {
             base.addInput ("InReplyTo", value);
         }
         /// <summary>
         /// (optional, decimal) The latitude of the location this tweet refers to e.g., 40.71863.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (optional, decimal) The longitude of the location this tweet refers to e.g., -74.005584.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, string) The ID associated with a place in the world. These IDs can be retrieved from the PlacesAndGeo.ReverseGeocode Choreo.
         /// </summary>
         /// <param name="value">Value of the PlaceID input for this Choreo.</param>
         public void setPlaceID(String value) {
             base.addInput ("PlaceID", value);
         }
         /// <summary>
         /// (optional, boolean) Set to true for content which may not be suitable for every audience.
         /// </summary>
         /// <param name="value">Value of the PossiblySensitive input for this Choreo.</param>
         public void setPossiblySensitive(String value) {
             base.addInput ("PossiblySensitive", value);
         }
         /// <summary>
         /// (required, string) The text for your status update. 140-character limit.
         /// </summary>
         /// <param name="value">Value of the StatusUpdate input for this Choreo.</param>
         public void setStatusUpdate(String value) {
             base.addInput ("StatusUpdate", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateWithMediaResultSet containing execution metadata and results.</returns>
        new public UpdateWithMediaResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateWithMediaResultSet results = new JavaScriptSerializer().Deserialize<UpdateWithMediaResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateWithMedia Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateWithMediaResultSet : Temboo.Core.ResultSet
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
