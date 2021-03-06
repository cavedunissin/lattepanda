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

namespace Temboo.Library.NPR.StationFinder
{
    /// <summary>
    /// SearchByLocation
    /// Retrieves local NPR member stations near the specified latitude and longitude location coordinates.
    /// </summary>
    public class SearchByLocation : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchByLocation Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchByLocation(TembooSession session) : base(session, "/Library/NPR/StationFinder/SearchByLocation")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by NPR.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, decimal) The latitude point of a station's location.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (required, decimal) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the Lattitude input for this Choreo.</param>
         public void setLattitude(String value) {
             base.addInput ("Lattitude", value);
         }
         /// <summary>
         /// (required, decimal) The longitude point of a station's location.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are xml (the default), and json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchByLocationResultSet containing execution metadata and results.</returns>
        new public SearchByLocationResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchByLocationResultSet results = new JavaScriptSerializer().Deserialize<SearchByLocationResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchByLocation Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchByLocationResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from NPR.</returns>
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
