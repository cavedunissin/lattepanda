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
    /// SearchByBoundingBox
    /// Retrieve businesses in a geographic bounding box.
    /// </summary>
    public class SearchByBoundingBox : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchByBoundingBox Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchByBoundingBox(TembooSession session) : base(session, "/Library/Yelp/SearchByBoundingBox")
        {
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
         /// (optional, boolean) Set to "true" to exclusively search for businesses with deals.
         /// </summary>
         /// <param name="value">Value of the Deals input for this Choreo.</param>
         public void setDeals(String value) {
             base.addInput ("Deals", value);
         }
         /// <summary>
         /// (optional, string) The ISO 639 language code. Default to "en". Reviews and snippets written in the specified language will be returned.
         /// </summary>
         /// <param name="value">Value of the LanguageCode input for this Choreo.</param>
         public void setLanguageCode(String value) {
             base.addInput ("LanguageCode", value);
         }
         /// <summary>
         /// (required, decimal) The northeastern latitude of the bounding box to search, such as "37.788022".
         /// </summary>
         /// <param name="value">Value of the NortheastLatitude input for this Choreo.</param>
         public void setNortheastLatitude(String value) {
             base.addInput ("NortheastLatitude", value);
         }
         /// <summary>
         /// (required, decimal) The northeastern longitude of the bounding box to search, such as "-122.399797".
         /// </summary>
         /// <param name="value">Value of the NortheastLongitude input for this Choreo.</param>
         public void setNortheastLongitude(String value) {
             base.addInput ("NortheastLongitude", value);
         }
         /// <summary>
         /// (optional, integer) Offsets the list of returned business results by this amount.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
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
         /// (required, decimal) The southwestern latitude of the bounding box to search, such as "37.900000".
         /// </summary>
         /// <param name="value">Value of the SouthwestLatitude input for this Choreo.</param>
         public void setSouthwestLatitude(String value) {
             base.addInput ("SouthwestLatitude", value);
         }
         /// <summary>
         /// (required, decimal) The southwestern longitude of the bounding box to search, such as "-122.500000".
         /// </summary>
         /// <param name="value">Value of the SouthwestLongitude input for this Choreo.</param>
         public void setSouthwestLongitude(String value) {
             base.addInput ("SouthwestLongitude", value);
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
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchByBoundingBoxResultSet containing execution metadata and results.</returns>
        new public SearchByBoundingBoxResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchByBoundingBoxResultSet results = new JavaScriptSerializer().Deserialize<SearchByBoundingBoxResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchByBoundingBox Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchByBoundingBoxResultSet : Temboo.Core.ResultSet
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
