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

namespace Temboo.Library.Foursquare.Venues
{
    /// <summary>
    /// SearchVenues
    /// Obtain a list of venues near the current location. 
    /// </summary>
    public class SearchVenues : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchVenues Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchVenues(TembooSession session) : base(session, "/Library/Foursquare/Venues/SearchVenues")
        {
        }

         /// <summary>
         /// (optional, integer) Accuracy of latitude and longitude, in meters. Currently, this parameter   does not affect search results.
         /// </summary>
         /// <param name="value">Value of the AccuracyOfCoordinates input for this Choreo.</param>
         public void setAccuracyOfCoordinates(String value) {
             base.addInput ("AccuracyOfCoordinates", value);
         }
         /// <summary>
         /// (optional, integer) Altitude of the user's location, in meters. Currently, this parameter does not affect search results.
         /// </summary>
         /// <param name="value">Value of the Altitude input for this Choreo.</param>
         public void setAltitude(String value) {
             base.addInput ("Altitude", value);
         }
         /// <summary>
         /// (optional, integer) Accuracy of the user's altitude, in meters. Currently, this parameter does not affect search results.
         /// </summary>
         /// <param name="value">Value of the AltitudeAccuracy input for this Choreo.</param>
         public void setAltitudeAccuracy(String value) {
             base.addInput ("AltitudeAccuracy", value);
         }
         /// <summary>
         /// (conditional, string) Your Foursquare client ID, obtained after registering at Foursquare. Required unless using the OauthToken input.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) Your Foursquare client secret, obtained after registering at Foursquare. Required unless using the OauthToken input.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (optional, string) Indicates your intent when performing the search.  Enter: checkin (default), match (requires Query and Latitude/Longitude to be provided).
         /// </summary>
         /// <param name="value">Value of the Intent input for this Choreo.</param>
         public void setIntent(String value) {
             base.addInput ("Intent", value);
         }
         /// <summary>
         /// (required, decimal) The latitude point of the user's location.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (optional, integer) Number of results to retun, up to 50.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (required, decimal) The longitude point of the user's location.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (conditional, string) The Foursquare API Oauth token string. Required unless specifying the ClientID and ClientSecret.
         /// </summary>
         /// <param name="value">Value of the OauthToken input for this Choreo.</param>
         public void setOauthToken(String value) {
             base.addInput ("OauthToken", value);
         }
         /// <summary>
         /// (optional, string) Your search string.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (optional, string) The format that response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchVenuesResultSet containing execution metadata and results.</returns>
        new public SearchVenuesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchVenuesResultSet results = new JavaScriptSerializer().Deserialize<SearchVenuesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchVenues Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchVenuesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Foursquare. Corresponds to the ResponseFormat input. Defaults to JSON.</returns>
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
