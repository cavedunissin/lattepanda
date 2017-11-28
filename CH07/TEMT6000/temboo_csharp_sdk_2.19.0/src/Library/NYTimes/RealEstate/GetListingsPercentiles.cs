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

namespace Temboo.Library.NYTimes.RealEstate
{
    /// <summary>
    /// GetListingsPercentiles
    /// Retrieves percentiles of real estate listings from New York Times Web Service.
    /// </summary>
    public class GetListingsPercentiles : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetListingsPercentiles Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetListingsPercentiles(TembooSession session) : base(session, "/Library/NYTimes/RealEstate/GetListingsPercentiles")
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
         /// (optional, integer) Limits the results by number of bedrooms to search for. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Bedrooms input for this Choreo.</param>
         public void setBedrooms(String value) {
             base.addInput ("Bedrooms", value);
         }
         /// <summary>
         /// (required, string) Sets the quarter, month, week or day for the results (i.e. 2008-Q1, 2008-W52, 2007-07, 2010-10-01, etc).
         /// </summary>
         /// <param name="value">Value of the DateRange input for this Choreo.</param>
         public void setDateRange(String value) {
             base.addInput ("DateRange", value);
         }
         /// <summary>
         /// (required, string) The geographical unit for the results (i.e. borough, neighborhood, or zip).
         /// </summary>
         /// <param name="value">Value of the GeoExtentLevel input for this Choreo.</param>
         public void setGeoExtentLevel(String value) {
             base.addInput ("GeoExtentLevel", value);
         }
         /// <summary>
         /// (required, string) Limits the search to a specific area.  For example, if GeoExtentLevel is borough, the value for GeoExtentValue could be Brooklyn.
         /// </summary>
         /// <param name="value">Value of the GeoExtentValue input for this Choreo.</param>
         public void setGeoExtentValue(String value) {
             base.addInput ("GeoExtentValue", value);
         }
         /// <summary>
         /// (required, string) The geographic unit for grouping the results (borough, neighborhood, or zip).
         /// </summary>
         /// <param name="value">Value of the GeoSummaryLevel input for this Choreo.</param>
         public void setGeoSummaryLevel(String value) {
             base.addInput ("GeoSummaryLevel", value);
         }
         /// <summary>
         /// (required, integer) Specify a percentile for the listing prices you want to retrieve (i.e 50).
         /// </summary>
         /// <param name="value">Value of the Percentile input for this Choreo.</param>
         public void setPercentile(String value) {
             base.addInput ("Percentile", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetListingsPercentilesResultSet containing execution metadata and results.</returns>
        new public GetListingsPercentilesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetListingsPercentilesResultSet results = new JavaScriptSerializer().Deserialize<GetListingsPercentilesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetListingsPercentiles Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetListingsPercentilesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from the NY Times API.</returns>
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
