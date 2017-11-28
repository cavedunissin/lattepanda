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
    /// GetInfo
    /// Retrieves the metadata for an artist including biographical data.
    /// </summary>
    public class GetInfo : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetInfo Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetInfo(TembooSession session) : base(session, "/Library/LastFm/Artist/GetInfo")
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
         /// (conditional, string) The artist name. Required unless providing MbID.
         /// </summary>
         /// <param name="value">Value of the Artist input for this Choreo.</param>
         public void setArtist(String value) {
             base.addInput ("Artist", value);
         }
         /// <summary>
         /// (optional, boolean) Transform misspelled artist names into correct artist names. The corrected artist name will be returned in the response. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the AutoCorrect input for this Choreo.</param>
         public void setAutoCorrect(String value) {
             base.addInput ("AutoCorrect", value);
         }
         /// <summary>
         /// (optional, string) The language to return the biography in, expressed as an ISO 639 alpha-2 code.
         /// </summary>
         /// <param name="value">Value of the Language input for this Choreo.</param>
         public void setLanguage(String value) {
             base.addInput ("Language", value);
         }
         /// <summary>
         /// (conditional, string) The musicbrainz id for the artist. Required unless providing Artist.
         /// </summary>
         /// <param name="value">Value of the MbID input for this Choreo.</param>
         public void setMbID(String value) {
             base.addInput ("MbID", value);
         }
         /// <summary>
         /// (optional, string) The username for the context of the request. If supplied, the user's playcount for this artist is included in the response.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetInfoResultSet containing execution metadata and results.</returns>
        new public GetInfoResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetInfoResultSet results = new JavaScriptSerializer().Deserialize<GetInfoResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetInfo Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetInfoResultSet : Temboo.Core.ResultSet
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
