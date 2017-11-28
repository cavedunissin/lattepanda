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
    /// Explore
    /// Returns a list of recommended venues near the current location.
    /// </summary>
    public class Explore : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Explore Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Explore(TembooSession session) : base(session, "/Library/Foursquare/Venues/Explore")
        {
        }

         /// <summary>
         /// (optional, integer) Accuracy of latitude and longitude, in meters.
         /// </summary>
         /// <param name="value">Value of the AccuracyOfCoordinates input for this Choreo.</param>
         public void setAccuracyOfCoordinates(String value) {
             base.addInput ("AccuracyOfCoordinates", value);
         }
         /// <summary>
         /// (optional, integer) Altitude of the user's location, in meters.
         /// </summary>
         /// <param name="value">Value of the Altitude input for this Choreo.</param>
         public void setAltitude(String value) {
             base.addInput ("Altitude", value);
         }
         /// <summary>
         /// (optional, integer) Accuracy of the user's altitude, in meters.
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
         /// (optional, string) When set to "any", results for any day of the week are returned. Results that are targeted to the current day of the week are returned by default.
         /// </summary>
         /// <param name="value">Value of the Day input for this Choreo.</param>
         public void setDay(String value) {
             base.addInput ("Day", value);
         }
         /// <summary>
         /// (optional, string) Limits results to places the acting user's friends have or haven't been. Valid values are: "visited" or "notvisited". 
         /// </summary>
         /// <param name="value">Value of the FriendsVisits input for this Choreo.</param>
         public void setFriendsVisits(String value) {
             base.addInput ("FriendsVisits", value);
         }
         /// <summary>
         /// (optional, string) Used in combination with the LastVenue input.  Return venues users often visit after a given venue when setting to "nextVenues" and providing a venue ID for the LastVenue input.
         /// </summary>
         /// <param name="value">Value of the Intent input for this Choreo.</param>
         public void setIntent(String value) {
             base.addInput ("Intent", value);
         }
         /// <summary>
         /// (optional, string) A venue ID to use when Intent = "nextVenues", which returns venues users often visit after a given venue. See Choreo notes for more details about the use of this input.
         /// </summary>
         /// <param name="value">Value of the LastVenue input for this Choreo.</param>
         public void setLastVenue(String value) {
             base.addInput ("LastVenue", value);
         }
         /// <summary>
         /// (conditional, decimal) The latitude point of the user's location. Required unless the Near parameter is provided.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (optional, integer) Number of results to return, up to 50.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (conditional, decimal) The longitude point of the user's location. Required unless the Near parameter is provided.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (conditional, string) A string naming a place in the world. If the near string is not geocodable, returns a failed_geocode error. Required unless provided Latitude and Longitude.
         /// </summary>
         /// <param name="value">Value of the Near input for this Choreo.</param>
         public void setNear(String value) {
             base.addInput ("Near", value);
         }
         /// <summary>
         /// (optional, string) Pass "new" or "old" to limit results to places the acting user hasn't been or has been, respectively. Omitting this parameter returns a mixture of both new and old.
         /// </summary>
         /// <param name="value">Value of the Novelty input for this Choreo.</param>
         public void setNovelty(String value) {
             base.addInput ("Novelty", value);
         }
         /// <summary>
         /// (conditional, string) The Foursquare API OAuth token string. Required unless specifying the ClientID and ClientSecret.
         /// </summary>
         /// <param name="value">Value of the OauthToken input for this Choreo.</param>
         public void setOauthToken(String value) {
             base.addInput ("OauthToken", value);
         }
         /// <summary>
         /// (optional, integer) Used with the Limit input to page through results.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 1 to only include venues that are open now. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the OpenNow input for this Choreo.</param>
         public void setOpenNow(String value) {
             base.addInput ("OpenNow", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of price points. Currently the valid range of price points are: [1,2,3,4]. See Choreo notes for more details about the use of this parameter.
         /// </summary>
         /// <param name="value">Value of the Price input for this Choreo.</param>
         public void setPrice(String value) {
             base.addInput ("Price", value);
         }
         /// <summary>
         /// (optional, string) A search term to be applied against tips, category, etc. at a venue.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (optional, integer) Radius to search within, in meters. If radius is not specified, a suggested radius will be used depending on the density of venues in the area.
         /// </summary>
         /// <param name="value">Value of the Radius input for this Choreo.</param>
         public void setRadius(String value) {
             base.addInput ("Radius", value);
         }
         /// <summary>
         /// (optional, string) The format that response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 1 to only include venues that the user has saved on their To-Do list or to another list. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Saved input for this Choreo.</param>
         public void setSaved(String value) {
             base.addInput ("Saved", value);
         }
         /// <summary>
         /// (optional, string) One of food, drinks, coffee, shops, arts, outdoors, sights, trending, specials, nextVenues , or topPicks. Choosing one of these limits results to venues with categories matching these terms.
         /// </summary>
         /// <param name="value">Value of the Section input for this Choreo.</param>
         public void setSection(String value) {
             base.addInput ("Section", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 1 to sort the results by distance instead of relevance. Default to 0.
         /// </summary>
         /// <param name="value">Value of the SortByDistance input for this Choreo.</param>
         public void setSortByDistance(String value) {
             base.addInput ("SortByDistance", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 1 to only include venues that have a special. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Specials input for this Choreo.</param>
         public void setSpecials(String value) {
             base.addInput ("Specials", value);
         }
         /// <summary>
         /// (optional, string) When set to "any", results for any time of day are returned. Results that are targeted to the current time of day are returned by default.
         /// </summary>
         /// <param name="value">Value of the Time input for this Choreo.</param>
         public void setTime(String value) {
             base.addInput ("Time", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 1 to include a photo for each venue in response, if one is available. Default is 0 (no photos).
         /// </summary>
         /// <param name="value">Value of the VenuePhotos input for this Choreo.</param>
         public void setVenuePhotos(String value) {
             base.addInput ("VenuePhotos", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ExploreResultSet containing execution metadata and results.</returns>
        new public ExploreResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ExploreResultSet results = new JavaScriptSerializer().Deserialize<ExploreResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Explore Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ExploreResultSet : Temboo.Core.ResultSet
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
