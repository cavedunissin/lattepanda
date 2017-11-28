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
    /// SearchForBusiness
    /// Retrieves information for a given business id or name.
    /// </summary>
    public class SearchForBusiness : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchForBusiness Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchForBusiness(TembooSession session) : base(session, "/Library/Yelp/SearchForBusiness")
        {
        }

         /// <summary>
         /// (conditional, string) The business id to return results for. This can be found in the URL when you're on the business page on yelp.com (i.e. "yelp-san-francisco"). This is required unless using the BusinessName input.
         /// </summary>
         /// <param name="value">Value of the BusinessId input for this Choreo.</param>
         public void setBusinessId(String value) {
             base.addInput ("BusinessId", value);
         }
         /// <summary>
         /// (conditional, string) A business name to search for. This is required unless using the BusinessId input.
         /// </summary>
         /// <param name="value">Value of the BusinessName input for this Choreo.</param>
         public void setBusinessName(String value) {
             base.addInput ("BusinessName", value);
         }
         /// <summary>
         /// (optional, string) The category to filter search results with when searching by BusinessName. This can be a list of comma delimited categories. For example, "bars,french". This can used when searching by BusinessName.
         /// </summary>
         /// <param name="value">Value of the Category input for this Choreo.</param>
         public void setCategory(String value) {
             base.addInput ("Category", value);
         }
         /// <summary>
         /// (conditional, string) The name of the city in which to search for businesses. This is required when searching by BusinessName.
         /// </summary>
         /// <param name="value">Value of the City input for this Choreo.</param>
         public void setCity(String value) {
             base.addInput ("City", value);
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
         /// (optional, integer) The number of business results to return when searching by BusinessName. The maxiumum is 20.
         /// </summary>
         /// <param name="value">Value of the Count input for this Choreo.</param>
         public void setCount(String value) {
             base.addInput ("Count", value);
         }
         /// <summary>
         /// (optional, string) The ISO 3166-1 2-digit country code to use when parsing the location field. United States = US, Canada = CA, United Kingdom = GB. This can be used when searching by BusinessName.
         /// </summary>
         /// <param name="value">Value of the CountryCode input for this Choreo.</param>
         public void setCountryCode(String value) {
             base.addInput ("CountryCode", value);
         }
         /// <summary>
         /// (optional, string) Set to "true" to exclusively search for businesses with deals. This can used when searching by BusinessName.
         /// </summary>
         /// <param name="value">Value of the Deals input for this Choreo.</param>
         public void setDeals(String value) {
             base.addInput ("Deals", value);
         }
         /// <summary>
         /// (optional, string) The ISO 639 language code. Default to "en". Reviews and snippets written in the specified language will be returned. This can be used when searching by BusinessName.
         /// </summary>
         /// <param name="value">Value of the LanguageCode input for this Choreo.</param>
         public void setLanguageCode(String value) {
             base.addInput ("LanguageCode", value);
         }
         /// <summary>
         /// (optional, integer) Offsets the list of returned business results by this amount when searching by BusinessName.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, multiline) The format of the response from Yelp, either XML or JSON (the default).
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, integer) The sort mode: 0 = Best matched, 1 = Distance (default), 2 = Highest Rated. This can be used when searching by BusinessName.
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
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchForBusinessResultSet containing execution metadata and results.</returns>
        new public SearchForBusinessResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchForBusinessResultSet results = new JavaScriptSerializer().Deserialize<SearchForBusinessResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchForBusiness Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchForBusinessResultSet : Temboo.Core.ResultSet
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
