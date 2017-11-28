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

namespace Temboo.Library.Google.Geocoding
{
    /// <summary>
    /// GeocodeByCoordinates
    /// Converts latitude and longitude coordinates into a human-readable address.
    /// </summary>
    public class GeocodeByCoordinates : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GeocodeByCoordinates Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GeocodeByCoordinates(TembooSession session) : base(session, "/Library/Google/Geocoding/GeocodeByCoordinates")
        {
        }

         /// <summary>
         /// (optional, string) The bounding box of the viewport within which to bias geocode results more prominently.
         /// </summary>
         /// <param name="value">Value of the Bounds input for this Choreo.</param>
         public void setBounds(String value) {
             base.addInput ("Bounds", value);
         }
         /// <summary>
         /// (optional, string) The language in which to return results. Defaults to 'en' (English).
         /// </summary>
         /// <param name="value">Value of the Language input for this Choreo.</param>
         public void setLanguage(String value) {
             base.addInput ("Language", value);
         }
         /// <summary>
         /// (required, decimal) The latitude value for which you wish to obtain the closest, human-readable address.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (required, decimal) The longitude value for which you wish to obtain the closest, human-readable address.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, string) The region code, specified as a ccTLD ("top-level domain") two-character value. Defaults to 'us' (United States).
         /// </summary>
         /// <param name="value">Value of the Region input for this Choreo.</param>
         public void setRegion(String value) {
             base.addInput ("Region", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates whether or not the geocoding request is from a device with a location sensor. Value must be either 1 or 0. Defaults to 0 (false).
         /// </summary>
         /// <param name="value">Value of the Sensor input for this Choreo.</param>
         public void setSensor(String value) {
             base.addInput ("Sensor", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GeocodeByCoordinatesResultSet containing execution metadata and results.</returns>
        new public GeocodeByCoordinatesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GeocodeByCoordinatesResultSet results = new JavaScriptSerializer().Deserialize<GeocodeByCoordinatesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GeocodeByCoordinates Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GeocodeByCoordinatesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "FormattedAddress" output from this Choreo execution
        /// <returns>String - (string) The formatted address associated with the specified coordinates.</returns>
        /// </summary>
        public String FormattedAddress
        {
            get
            {
                return (String) base.Output["FormattedAddress"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Google.</returns>
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
