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
    /// Shout
    /// Creates a message in an artist's shoutbox.
    /// </summary>
    public class Shout : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Shout Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Shout(TembooSession session) : base(session, "/Library/LastFm/Artist/Shout")
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
         /// (optional, string) An optional message to send with the recommendation. If not supplied a default message will be used.
         /// </summary>
         /// <param name="value">Value of the Message input for this Choreo.</param>
         public void setMessage(String value) {
             base.addInput ("Message", value);
         }
         /// <summary>
         /// (string) The session key retrieved in the last step of the authorization process.
         /// </summary>
         /// <param name="value">Value of the SessionKey input for this Choreo.</param>
         public void setSessionKey(String value) {
             base.addInput ("SessionKey", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ShoutResultSet containing execution metadata and results.</returns>
        new public ShoutResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ShoutResultSet results = new JavaScriptSerializer().Deserialize<ShoutResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Shout Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ShoutResultSet : Temboo.Core.ResultSet
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
