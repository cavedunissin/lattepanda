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

namespace Temboo.Library.LastFm.Tasteometer
{
    /// <summary>
    /// CompareArtists
    /// Retrieves a Tasteometer score from two artist inputs.
    /// </summary>
    public class CompareArtists : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CompareArtists Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CompareArtists(TembooSession session) : base(session, "/Library/LastFm/Tasteometer/CompareArtists")
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
         /// (string) The first artist to compare.
         /// </summary>
         /// <param name="value">Value of the Artist1 input for this Choreo.</param>
         public void setArtist1(String value) {
             base.addInput ("Artist1", value);
         }
         /// <summary>
         /// (string) The second artist to compare.
         /// </summary>
         /// <param name="value">Value of the Artist2 input for this Choreo.</param>
         public void setArtist2(String value) {
             base.addInput ("Artist2", value);
         }
         /// <summary>
         /// (optional, integer) How many shared artists to display. Defaults to 5.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CompareArtistsResultSet containing execution metadata and results.</returns>
        new public CompareArtistsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CompareArtistsResultSet results = new JavaScriptSerializer().Deserialize<CompareArtistsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CompareArtists Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CompareArtistsResultSet : Temboo.Core.ResultSet
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
