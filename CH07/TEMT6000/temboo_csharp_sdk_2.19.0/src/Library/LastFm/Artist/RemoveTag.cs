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

namespace Temboo.Library.LastFm.Artist
{
    /// <summary>
    /// RemoveTag
    /// Removes a user's tag from an artist.
    /// </summary>
    public class RemoveTag : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RemoveTag Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RemoveTag(TembooSession session) : base(session, "/Library/LastFm/Artist/RemoveTag")
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
         /// (string) Your Last.fm API Secret.
         /// </summary>
         /// <param name="value">Value of the APISecret input for this Choreo.</param>
         public void setAPISecret(String value) {
             base.addInput ("APISecret", value);
         }
         /// <summary>
         /// (string) The artist name.
         /// </summary>
         /// <param name="value">Value of the Artist input for this Choreo.</param>
         public void setArtist(String value) {
             base.addInput ("Artist", value);
         }
         /// <summary>
         /// (string) The session key retrieved in the last step of the authorization process.
         /// </summary>
         /// <param name="value">Value of the SessionKey input for this Choreo.</param>
         public void setSessionKey(String value) {
             base.addInput ("SessionKey", value);
         }
         /// <summary>
         /// (string) A single user tag to remove from this artist.
         /// </summary>
         /// <param name="value">Value of the Tag input for this Choreo.</param>
         public void setTag(String value) {
             base.addInput ("Tag", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RemoveTagResultSet containing execution metadata and results.</returns>
        new public RemoveTagResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RemoveTagResultSet results = new JavaScriptSerializer().Deserialize<RemoveTagResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RemoveTag Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RemoveTagResultSet : Temboo.Core.ResultSet
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
