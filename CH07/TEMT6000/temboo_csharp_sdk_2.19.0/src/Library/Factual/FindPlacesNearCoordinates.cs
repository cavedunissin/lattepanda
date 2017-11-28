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

namespace Temboo.Library.Factual
{
    /// <summary>
    /// FindPlacesNearCoordinates
    /// Find places near specified latitude, longitude coordinates.
    /// </summary>
    public class FindPlacesNearCoordinates : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FindPlacesNearCoordinates Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FindPlacesNearCoordinates(TembooSession session) : base(session, "/Library/Factual/FindPlacesNearCoordinates")
        {
        }

         /// <summary>
         /// (optional, string) The API Key provided by Factual (AKA the OAuth Consumer Key).
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) The API Secret provided by Factual (AKA the OAuth Consumer Secret).
         /// </summary>
         /// <param name="value">Value of the APISecret input for this Choreo.</param>
         public void setAPISecret(String value) {
             base.addInput ("APISecret", value);
         }
         /// <summary>
         /// (required, decimal) Enter latitude coordinates of the location defining the center of the search radius.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (required, decimal) Enter longitude coordinates of the location defining the center of the search radius.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, string) A search string (i.e. Starbucks)
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (required, integer) Provide the radius (in meters, and centered on the latitude-longitude coordinates specified) for which search results will be returned.
         /// </summary>
         /// <param name="value">Value of the Radius input for this Choreo.</param>
         public void setRadius(String value) {
             base.addInput ("Radius", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A FindPlacesNearCoordinatesResultSet containing execution metadata and results.</returns>
        new public FindPlacesNearCoordinatesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FindPlacesNearCoordinatesResultSet results = new JavaScriptSerializer().Deserialize<FindPlacesNearCoordinatesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FindPlacesNearCoordinates Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FindPlacesNearCoordinatesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Factual.</returns>
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
