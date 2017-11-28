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

namespace Temboo.Library.NYTimes.EventListings
{
    /// <summary>
    /// SearchWithinBoundedBox
    /// Allows you to do a spatial search for events within a box bounded by specified northeast and southwest points.
    /// </summary>
    public class SearchWithinBoundedBox : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchWithinBoundedBox Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchWithinBoundedBox(TembooSession session) : base(session, "/Library/NYTimes/EventListings/SearchWithinBoundedBox")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by NY Times.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, date) Start date to end date in the following format: YYYY-MM-DD:YYYY-MM-DD.
         /// </summary>
         /// <param name="value">Value of the DateRange input for this Choreo.</param>
         public void setDateRange(String value) {
             base.addInput ("DateRange", value);
         }
         /// <summary>
         /// (optional, string) Filters search results using facet names and values. See Choreo documentation for examples.
         /// </summary>
         /// <param name="value">Value of the Filters input for this Choreo.</param>
         public void setFilters(String value) {
             base.addInput ("Filters", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to return.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (conditional, decimal) The northeastern latitude of the bounding box to search. When searching within a bounded box, all four coordinates are required.
         /// </summary>
         /// <param name="value">Value of the NortheastLatitude input for this Choreo.</param>
         public void setNortheastLatitude(String value) {
             base.addInput ("NortheastLatitude", value);
         }
         /// <summary>
         /// (conditional, decimal) The northeastern longitude of the bounding box to search. When searching within a bounded box, all four coordinates are required.
         /// </summary>
         /// <param name="value">Value of the NortheastLongitude input for this Choreo.</param>
         public void setNortheastLongitude(String value) {
             base.addInput ("NortheastLongitude", value);
         }
         /// <summary>
         /// (optional, integer) A numeric value indicating the starting point of the result set. This can be used in combination with the Limit input to page through results.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, string) Search keywords to perform a text search on the following fields: web_description, event_name and venue_name.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (optional, integer) The radius of the spacial search (in meters). Defaults to 1000.
         /// </summary>
         /// <param name="value">Value of the Radius input for this Choreo.</param>
         public void setRadius(String value) {
             base.addInput ("Radius", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Can be set to json, xml, or sphp. Defaults to xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Allows you to sort results. Appending "+asc" or "+desc" to a facet will sort results on that value in ascending or descending order (i.e. dist+asc).
         /// </summary>
         /// <param name="value">Value of the Sort input for this Choreo.</param>
         public void setSort(String value) {
             base.addInput ("Sort", value);
         }
         /// <summary>
         /// (conditional, decimal) The southwest latitude of the bounding box to search. When searching within a bounded box, all four coordinates are required.
         /// </summary>
         /// <param name="value">Value of the SouthwestLatitude input for this Choreo.</param>
         public void setSouthwestLatitude(String value) {
             base.addInput ("SouthwestLatitude", value);
         }
         /// <summary>
         /// (conditional, decimal) The southwest longitude of the bounding box to search. When searching within a bounded box, all four coordinates are required.
         /// </summary>
         /// <param name="value">Value of the SouthwestLongitude input for this Choreo.</param>
         public void setSouthwestLongitude(String value) {
             base.addInput ("SouthwestLongitude", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchWithinBoundedBoxResultSet containing execution metadata and results.</returns>
        new public SearchWithinBoundedBoxResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchWithinBoundedBoxResultSet results = new JavaScriptSerializer().Deserialize<SearchWithinBoundedBoxResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchWithinBoundedBox Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchWithinBoundedBoxResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from the NY Times API. Valid values are: json (the default) and xml.</returns>
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
