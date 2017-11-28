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

namespace Temboo.Library.Instagram
{
    /// <summary>
    /// SearchLocations
    /// Searches for locations by geographic coordinates. 
    /// </summary>
    public class SearchLocations : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchLocations Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchLocations(TembooSession session) : base(session, "/Library/Instagram/SearchLocations")
        {
        }

         /// <summary>
         /// (conditional, string) The access token retrieved during the OAuth 2.0 process. Required unless you provide the ClientID.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Instagram after registering your application. Required unless you provide the AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (optional, integer) The distance to search. Default is 1000m (distance=1000), max distance is 5000.
         /// </summary>
         /// <param name="value">Value of the Distance input for this Choreo.</param>
         public void setDistance(String value) {
             base.addInput ("Distance", value);
         }
         /// <summary>
         /// (conditional, string) Returns a location mapped off of a foursquare v2 api location id. If used, you are not required to provide values for Latitude or Longitude.
         /// </summary>
         /// <param name="value">Value of the FoursquareID input for this Choreo.</param>
         public void setFoursquareID(String value) {
             base.addInput ("FoursquareID", value);
         }
         /// <summary>
         /// (conditional, decimal) Latitude of the center search coordinate. If used, Longitude is required.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (conditional, decimal) Longitude of the center search coordinate. If used, Latitude is required.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchLocationsResultSet containing execution metadata and results.</returns>
        new public SearchLocationsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchLocationsResultSet results = new JavaScriptSerializer().Deserialize<SearchLocationsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchLocations Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchLocationsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Instagram.</returns>
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
