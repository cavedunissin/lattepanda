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

namespace Temboo.Library.Yelp
{
    /// <summary>
    /// SearchForBusinessesWithDeals
    /// Only returns information for businesses with deals.
    /// </summary>
    public class SearchForBusinessesWithDeals : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchForBusinessesWithDeals Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchForBusinessesWithDeals(TembooSession session) : base(session, "/Library/Yelp/SearchForBusinessesWithDeals")
        {
        }

         /// <summary>
         /// (optional, integer) Narrow or widen the search range in relation to the coordinates, such as "2" for state or "8" for street address.
         /// </summary>
         /// <param name="value">Value of the Accuracy input for this Choreo.</param>
         public void setAccuracy(String value) {
             base.addInput ("Accuracy", value);
         }
         /// <summary>
         /// (optional, string) A term to narrow the search, such as "wine" or "restaurants". Leave blank to search for all business types.
         /// </summary>
         /// <param name="value">Value of the BusinessType input for this Choreo.</param>
         public void setBusinessType(String value) {
             base.addInput ("BusinessType", value);
         }
         /// <summary>
         /// (optional, string) The category to filter search results with. This can be a list of comma delimited categories. For example, "bars,french". See Choreo description for a list of categories.
         /// </summary>
         /// <param name="value">Value of the Category input for this Choreo.</param>
         public void setCategory(String value) {
             base.addInput ("Category", value);
         }
         /// <summary>
         /// (required, string) The Consumer Key provided by Yelp.
         /// </summary>
         /// <param name="value">Value of the ConsumerKey input for this Choreo.</param>
         public void setConsumerKey(String value) {
             base.addInput ("ConsumerKey", value);
         }
         /// <summary>
         /// (required, string) The Consumer Secret provided by Yelp.
         /// </summary>
         /// <param name="value">Value of the ConsumerSecret input for this Choreo.</param>
         public void setConsumerSecret(String value) {
             base.addInput ("ConsumerSecret", value);
         }
         /// <summary>
         /// (optional, integer) The number of business results to return. The maxiumum is 20.
         /// </summary>
         /// <param name="value">Value of the Count input for this Choreo.</param>
         public void setCount(String value) {
             base.addInput ("Count", value);
         }
         /// <summary>
         /// (optional, string) The ISO 3166-1 2-digit country code to use when parsing the location field. United States = US, Canada = CA, United Kingdom = GB.
         /// </summary>
         /// <param name="value">Value of the CountryCode input for this Choreo.</param>
         public void setCountryCode(String value) {
             base.addInput ("CountryCode", value);
         }
         /// <summary>
         /// (optional, string) The ISO 639 language code. Default to "en". Reviews and snippets written in the specified language will be returned.
         /// </summary>
         /// <param name="value">Value of the LanguageCode input for this Choreo.</param>
         public void setLanguageCode(String value) {
             base.addInput ("LanguageCode", value);
         }
         /// <summary>
         /// (conditional, decimal) The latitude to search near, such as "37.788022". Searching with either Location or Coordinates is required.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (conditional, string) An address, neighborhood, city, state, or ZIP code in which to search for the category. Searching with either Location or Coordinates is required.
         /// </summary>
         /// <param name="value">Value of the Location input for this Choreo.</param>
         public void setLocation(String value) {
             base.addInput ("Location", value);
         }
         /// <summary>
         /// (conditional, decimal) The longitude to search near, such as "-122.399797". Searching with either Location or Coordinates is required.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, integer) Offsets the list of returned business results by this amount.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, integer) Narrow or expand a search by specifying a range in either feet, meters, miles, or kilometers, depending on the value of the Units input. Defaults to 200 feet. Maximum is 25 miles (40000 meters).
         /// </summary>
         /// <param name="value">Value of the Range input for this Choreo.</param>
         public void setRange(String value) {
             base.addInput ("Range", value);
         }
         /// <summary>
         /// (optional, string) The format of the response from Yelp, either XML or JSON (the default).
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, integer) The sort mode: 0 = Best matched, 1 = Distance (default), 2 = Highest Rated.
         /// </summary>
         /// <param name="value">Value of the Sort input for this Choreo.</param>
         public void setSort(String value) {
             base.addInput ("Sort", value);
         }
         /// <summary>
         /// (required, string) The Token provided by Yelp.
         /// </summary>
         /// <param name="value">Value of the Token input for this Choreo.</param>
         public void setToken(String value) {
             base.addInput ("Token", value);
         }
         /// <summary>
         /// (required, string) The Token Secret provided by Yelp.
         /// </summary>
         /// <param name="value">Value of the TokenSecret input for this Choreo.</param>
         public void setTokenSecret(String value) {
             base.addInput ("TokenSecret", value);
         }
         /// <summary>
         /// (optional, string) Specify "feet" (the default), "meters", "miles", or "kilometers". Units apply to the Range input value.
         /// </summary>
         /// <param name="value">Value of the Units input for this Choreo.</param>
         public void setUnits(String value) {
             base.addInput ("Units", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchForBusinessesWithDealsResultSet containing execution metadata and results.</returns>
        new public SearchForBusinessesWithDealsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchForBusinessesWithDealsResultSet results = new JavaScriptSerializer().Deserialize<SearchForBusinessesWithDealsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchForBusinessesWithDeals Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchForBusinessesWithDealsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Yelp. Corresponds to the input value for ResponseFormat (defaults to JSON).</returns>
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
