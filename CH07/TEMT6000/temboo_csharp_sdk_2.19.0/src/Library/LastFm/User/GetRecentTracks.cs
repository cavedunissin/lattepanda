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

namespace Temboo.Library.LastFm.User
{
    /// <summary>
    /// GetRecentTracks
    /// Get a list of the recent tracks listened to by this user.
    /// </summary>
    public class GetRecentTracks : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetRecentTracks Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetRecentTracks(TembooSession session) : base(session, "/Library/LastFm/User/GetRecentTracks")
        {
        }

         /// <summary>
         /// (string) Your Last.fm API Key.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, date) End timestamp of a range - only display scrobbles before this time, in UNIX timestamp format. This must be in the UTC time zone.
         /// </summary>
         /// <param name="value">Value of the EndTimestamp input for this Choreo.</param>
         public void setEndTimestamp(String value) {
             base.addInput ("EndTimestamp", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to fetch per page. Defaults to 50. Maximum is 200.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, integer) The page number to fetch. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, date) Beginning timestamp of a range - only display scrobbles after this time, in UNIX timestamp format. This must be in the UTC time zone.
         /// </summary>
         /// <param name="value">Value of the StartTimestamp input for this Choreo.</param>
         public void setStartTimestamp(String value) {
             base.addInput ("StartTimestamp", value);
         }
         /// <summary>
         /// (string) The last.fm username to fetch the recent tracks of.
         /// </summary>
         /// <param name="value">Value of the User input for this Choreo.</param>
         public void setUser(String value) {
             base.addInput ("User", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetRecentTracksResultSet containing execution metadata and results.</returns>
        new public GetRecentTracksResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetRecentTracksResultSet results = new JavaScriptSerializer().Deserialize<GetRecentTracksResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetRecentTracks Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetRecentTracksResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (XML) The response from Last.fm.</returns>
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
