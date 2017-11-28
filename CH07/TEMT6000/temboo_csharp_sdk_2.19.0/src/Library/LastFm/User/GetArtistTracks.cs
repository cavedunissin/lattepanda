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
    /// GetArtistTracks
    /// Retrieves a list of tracks by a given artist scrobbled by this user, including scrobble time.
    /// </summary>
    public class GetArtistTracks : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetArtistTracks Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetArtistTracks(TembooSession session) : base(session, "/Library/LastFm/User/GetArtistTracks")
        {
        }

         /// <summary>
         /// (required, string) Your Last.fm API Key.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The artist name you are interested in.
         /// </summary>
         /// <param name="value">Value of the Artist input for this Choreo.</param>
         public void setArtist(String value) {
             base.addInput ("Artist", value);
         }
         /// <summary>
         /// (optional, date) A unix timestamp to end at.
         /// </summary>
         /// <param name="value">Value of the EndTimestamp input for this Choreo.</param>
         public void setEndTimestamp(String value) {
             base.addInput ("EndTimestamp", value);
         }
         /// <summary>
         /// (optional, integer) The page number to fetch. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, date) A unix timestamp to start at.
         /// </summary>
         /// <param name="value">Value of the StartTimestamp input for this Choreo.</param>
         public void setStartTimestamp(String value) {
             base.addInput ("StartTimestamp", value);
         }
         /// <summary>
         /// (required, string) The last.fm username to fetch the recent tracks of.
         /// </summary>
         /// <param name="value">Value of the User input for this Choreo.</param>
         public void setUser(String value) {
             base.addInput ("User", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetArtistTracksResultSet containing execution metadata and results.</returns>
        new public GetArtistTracksResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetArtistTracksResultSet results = new JavaScriptSerializer().Deserialize<GetArtistTracksResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetArtistTracks Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetArtistTracksResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Last.fm.</returns>
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
