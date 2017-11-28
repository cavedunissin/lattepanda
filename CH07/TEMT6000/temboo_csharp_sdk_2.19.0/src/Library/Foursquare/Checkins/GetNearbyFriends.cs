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

namespace Temboo.Library.Foursquare.Checkins
{
    /// <summary>
    /// GetNearbyFriends
    /// Returns a list of recent friends' check-ins that are nearby the specified location.
    /// </summary>
    public class GetNearbyFriends : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetNearbyFriends Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetNearbyFriends(TembooSession session) : base(session, "/Library/Foursquare/Checkins/GetNearbyFriends")
        {
        }

         /// <summary>
         /// (optional, integer) The distance (in meters) between the supplied coordinates and the checkin location. This returns friends' checkins where the distance is less than or equal to this value. Default is 500.
         /// </summary>
         /// <param name="value">Value of the Distance input for this Choreo.</param>
         public void setDistance(String value) {
             base.addInput ("Distance", value);
         }
         /// <summary>
         /// (required, decimal) The latitude point of the user's location.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (optional, integer) Number of results to return, up to 100.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (required, decimal) The longitude point of the user's location.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (required, string) The Foursquare API OAuth token string.
         /// </summary>
         /// <param name="value">Value of the OauthToken input for this Choreo.</param>
         public void setOauthToken(String value) {
             base.addInput ("OauthToken", value);
         }
         /// <summary>
         /// (optional, string) Used to simplify the response. Valid values are: simple and verbose. When set to simple, an array of user objects are returned. Verbose mode returns an array of checkin objects. Defaults to "simple".
         /// </summary>
         /// <param name="value">Value of the ResponseMode input for this Choreo.</param>
         public void setResponseMode(String value) {
             base.addInput ("ResponseMode", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetNearbyFriendsResultSet containing execution metadata and results.</returns>
        new public GetNearbyFriendsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetNearbyFriendsResultSet results = new JavaScriptSerializer().Deserialize<GetNearbyFriendsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetNearbyFriends Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetNearbyFriendsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Foursquare. Corresponds to the ResponseFormat input. Defaults to JSON.</returns>
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
