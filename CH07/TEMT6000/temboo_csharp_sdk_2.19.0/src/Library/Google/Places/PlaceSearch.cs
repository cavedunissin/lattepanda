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

namespace Temboo.Library.Google.Places
{
    /// <summary>
    /// PlaceSearch
    /// Search for places based on latitude/longitude coordinates, keywords, and distance.
    /// </summary>
    public class PlaceSearch : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the PlaceSearch Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public PlaceSearch(TembooSession session) : base(session, "/Library/Google/Places/PlaceSearch")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Google.
         /// </summary>
         /// <param name="value">Value of the Key input for this Choreo.</param>
         public void setKey(String value) {
             base.addInput ("Key", value);
         }
         /// <summary>
         /// (optional, string) Enter a keyword (term, address, type, customer review, etc.) to be matched against all results retrieved for this Place.
         /// </summary>
         /// <param name="value">Value of the Keyword input for this Choreo.</param>
         public void setKeyword(String value) {
             base.addInput ("Keyword", value);
         }
         /// <summary>
         /// (optional, string) The language code, indicating in which language the results should be returned, if possible. See Choreo notes for a list of supported languages and their codes.
         /// </summary>
         /// <param name="value">Value of the Language input for this Choreo.</param>
         public void setLanguage(String value) {
             base.addInput ("Language", value);
         }
         /// <summary>
         /// (required, string) Specify a latitude point around which Places results will be retrieved (e.g., 38.898717).
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (required, string) Specify a longitude point around which Places results will be retrieved (e.g., -77.035974).
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, integer) Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount will vary from region to region.
         /// </summary>
         /// <param name="value">Value of the MaxPrice input for this Choreo.</param>
         public void setMaxPrice(String value) {
             base.addInput ("MaxPrice", value);
         }
         /// <summary>
         /// (optional, integer) Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount will vary from region to region.
         /// </summary>
         /// <param name="value">Value of the MinPrice input for this Choreo.</param>
         public void setMinPrice(String value) {
             base.addInput ("MinPrice", value);
         }
         /// <summary>
         /// (optional, string) Enter a name to be matched when results are retrieved for this specified Place.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (optional, boolean) Returns only those Places that are open for business at the time the query is sent. Places that do not specify opening hours in the Google Places database will not be returned.
         /// </summary>
         /// <param name="value">Value of the OpenNow input for this Choreo.</param>
         public void setOpenNow(String value) {
             base.addInput ("OpenNow", value);
         }
         /// <summary>
         /// (optional, string) The "NextPageToken" returned in the choreo output from a previous run. Used to page through large result sets. When the PageToken is specified, all other inputs are ignored.
         /// </summary>
         /// <param name="value">Value of the PageToken input for this Choreo.</param>
         public void setPageToken(String value) {
             base.addInput ("PageToken", value);
         }
         /// <summary>
         /// (required, integer) Specify the radius in meters for which Places results will be returned. Maximum radius is limited to 50,000 meters. If rankby=distance, then radius must not be specified.
         /// </summary>
         /// <param name="value">Value of the Radius input for this Choreo.</param>
         public void setRadius(String value) {
             base.addInput ("Radius", value);
         }
         /// <summary>
         /// (optional, string) Specify how results are listed. Values include: prominence (default); distance - sorts results by distance from specified location. Radius must not be used, and Keyword, Name, or Types are required).
         /// </summary>
         /// <param name="value">Value of the RankBy input for this Choreo.</param>
         public void setRankBy(String value) {
             base.addInput ("RankBy", value);
         }
         /// <summary>
         /// (optional, string) The format that response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates whether or not the directions request is from a device with a location sensor. Value must be either 1 or 0. Defaults to 0 (false).
         /// </summary>
         /// <param name="value">Value of the Sensor input for this Choreo.</param>
         public void setSensor(String value) {
             base.addInput ("Sensor", value);
         }
         /// <summary>
         /// (optional, string) Filter results by types, such as: bar, dentist.  Multiple types must be separated by the pipe ("|") symbol: bar|dentist|airport.
         /// </summary>
         /// <param name="value">Value of the Types input for this Choreo.</param>
         public void setTypes(String value) {
             base.addInput ("Types", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A PlaceSearchResultSet containing execution metadata and results.</returns>
        new public PlaceSearchResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PlaceSearchResultSet results = new JavaScriptSerializer().Deserialize<PlaceSearchResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the PlaceSearch Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PlaceSearchResultSet : Temboo.Core.ResultSet
    {
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
