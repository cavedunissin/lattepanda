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

namespace Temboo.Library.Facebook.Actions.Video.Watches
{
    /// <summary>
    /// UpdateWatch
    /// Updates an existing watch action.
    /// </summary>
    public class UpdateWatch : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateWatch Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateWatch(TembooSession session) : base(session, "/Library/Facebook/Actions/Video/Watches/UpdateWatch")
        {
        }

         /// <summary>
         /// (required, string) The access token retrieved from the final step of the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) The id of the action to update.
         /// </summary>
         /// <param name="value">Value of the ActionID input for this Choreo.</param>
         public void setActionID(String value) {
             base.addInput ("ActionID", value);
         }
         /// <summary>
         /// (optional, date) The time that the user ended the action (e.g. 2013-06-24T18:53:35+0000).
         /// </summary>
         /// <param name="value">Value of the EndTime input for this Choreo.</param>
         public void setEndTime(String value) {
             base.addInput ("EndTime", value);
         }
         /// <summary>
         /// (optional, string) The URL or ID for an Open Graph object representing an episode of a show.
         /// </summary>
         /// <param name="value">Value of the Episode input for this Choreo.</param>
         public void setEpisode(String value) {
             base.addInput ("Episode", value);
         }
         /// <summary>
         /// (optional, integer) The amount of time (in milliseconds) from the publish_time that the action will expire.
         /// </summary>
         /// <param name="value">Value of the ExpiresIn input for this Choreo.</param>
         public void setExpiresIn(String value) {
             base.addInput ("ExpiresIn", value);
         }
         /// <summary>
         /// (optional, string) A message attached to this action. Setting this parameter requires enabling of message capabilities.
         /// </summary>
         /// <param name="value">Value of the Message input for this Choreo.</param>
         public void setMessage(String value) {
             base.addInput ("Message", value);
         }
         /// <summary>
         /// (optional, string) The URL or ID for an Open Graph object representing a movie.
         /// </summary>
         /// <param name="value">Value of the Movie input for this Choreo.</param>
         public void setMovie(String value) {
             base.addInput ("Movie", value);
         }
         /// <summary>
         /// (optional, string) The URL or ID for an Open Graph object representing the location associated with this action.
         /// </summary>
         /// <param name="value">Value of the Place input for this Choreo.</param>
         public void setPlace(String value) {
             base.addInput ("Place", value);
         }
         /// <summary>
         /// (optional, string) The URL or ID for an Open Graph object representing a TV show.
         /// </summary>
         /// <param name="value">Value of the TVShow input for this Choreo.</param>
         public void setTVShow(String value) {
             base.addInput ("TVShow", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of other profile IDs that also performed this action.
         /// </summary>
         /// <param name="value">Value of the Tags input for this Choreo.</param>
         public void setTags(String value) {
             base.addInput ("Tags", value);
         }
         /// <summary>
         /// (optional, string) The URL or ID for an Open Graph object representing any general video content.
         /// </summary>
         /// <param name="value">Value of the Video input for this Choreo.</param>
         public void setVideo(String value) {
             base.addInput ("Video", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateWatchResultSet containing execution metadata and results.</returns>
        new public UpdateWatchResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateWatchResultSet results = new JavaScriptSerializer().Deserialize<UpdateWatchResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateWatch Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateWatchResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Facebook.</returns>
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
