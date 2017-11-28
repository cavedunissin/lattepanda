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

namespace Temboo.Library.Labs.GetPlaces
{
    /// <summary>
    /// ByCoordinates
    /// Retrieves information about places near a set of coordinates from multiple sources in one API call.
    /// </summary>
    public class ByCoordinates : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ByCoordinates Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ByCoordinates(TembooSession session) : base(session, "/Library/Labs/GetPlaces/ByCoordinates")
        {
        }

         /// <summary>
         /// (required, json) A JSON dictionary of credentials for the APIs you wish to access. See Choreo documentation for formatting examples.
         /// </summary>
         /// <param name="value">Value of the APICredentials input for this Choreo.</param>
         public void setAPICredentials(String value) {
             base.addInput ("APICredentials", value);
         }
         /// <summary>
         /// (required, decimal) The latitude of the user's location.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (optional, integer) Limits the number of Foursquare venue results.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (required, decimal) The longitude of the user's location.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, string) This keyword input can be used to narrow search results for Google Places and Foursquare.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Filters results by type of place, such as: bar, dentist, etc. This is used to filter results for Google Places and Yelp.
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ByCoordinatesResultSet containing execution metadata and results.</returns>
        new public ByCoordinatesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ByCoordinatesResultSet results = new JavaScriptSerializer().Deserialize<ByCoordinatesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ByCoordinates Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ByCoordinatesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - Contains the merged results from the API responses.</returns>
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
