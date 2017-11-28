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

namespace Temboo.Library.Yahoo.PlaceFinder
{
    /// <summary>
    /// FindByCoordinates
    /// Retrieves complete location information from a specified pair of latitude and longitude coordinates.
    /// </summary>
    public class FindByCoordinates : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FindByCoordinates Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FindByCoordinates(TembooSession session) : base(session, "/Library/Yahoo/PlaceFinder/FindByCoordinates")
        {
        }

         /// <summary>
         /// (optional, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
         }
         /// <summary>
         /// (optional, string) Affects how geocoding is performed for the request. Valid value are: A, C, L, Q, or R. See documentation for more details on this parameter.
         /// </summary>
         /// <param name="value">Value of the GeocodeFlags input for this Choreo.</param>
         public void setGeocodeFlags(String value) {
             base.addInput ("GeocodeFlags", value);
         }
         /// <summary>
         /// (required, decimal) The latitude coordinate of the location you want to find (e.g., 38.898717).
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (required, decimal) The longitude coordinate of the location you want to find (e.g., -77.035974).
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, string) Determines which data elements are returned in the response. Valid values are: B, C, D, E, G, I, J, Q, R, T, U, W, X. See documentation for details on this parameter.
         /// </summary>
         /// <param name="value">Value of the ResponseFlags input for this Choreo.</param>
         public void setResponseFlags(String value) {
             base.addInput ("ResponseFlags", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: xml (the default) and json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A FindByCoordinatesResultSet containing execution metadata and results.</returns>
        new public FindByCoordinatesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FindByCoordinatesResultSet results = new JavaScriptSerializer().Deserialize<FindByCoordinatesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FindByCoordinates Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FindByCoordinatesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "WOEID" output from this Choreo execution
        /// <returns>String - (integer) The unique Where On Earth ID of the location.</returns>
        /// </summary>
        public String WOEID
        {
            get
            {
                return (String) base.Output["WOEID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Yahoo PlaceFinder.</returns>
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
