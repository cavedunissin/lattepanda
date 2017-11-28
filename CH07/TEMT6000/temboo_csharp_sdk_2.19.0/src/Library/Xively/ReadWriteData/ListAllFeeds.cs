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

namespace Temboo.Library.Xively.ReadWriteData
{
    /// <summary>
    /// ListAllFeeds
    /// Returns filterable data on all feeds viewable by the authenticated account.
    /// </summary>
    public class ListAllFeeds : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListAllFeeds Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListAllFeeds(TembooSession session) : base(session, "/Library/Xively/ReadWriteData/ListAllFeeds")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Xively.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) Describes whether to return full or summary results. Full - all datastream values are returned, summary - returns the environment metadata for each feed. Valid values: 'full' or 'summary'.
         /// </summary>
         /// <param name="value">Value of the Content input for this Choreo.</param>
         public void setContent(String value) {
             base.addInput ("Content", value);
         }
         /// <summary>
         /// (optional, decimal) Search radius (units like miles or kilometers defined by DistanceUnits). Ex: 5.0.
         /// </summary>
         /// <param name="value">Value of the Distance input for this Choreo.</param>
         public void setDistance(String value) {
             base.addInput ("Distance", value);
         }
         /// <summary>
         /// (optional, string) Units of distance. Valid values: "miles" or "kms" (default).
         /// </summary>
         /// <param name="value">Value of the DistanceUnits input for this Choreo.</param>
         public void setDistanceUnits(String value) {
             base.addInput ("DistanceUnits", value);
         }
         /// <summary>
         /// (optional, string) The type of feed that is being returned. Valid values are "json" (the default), "xml" and "csv". No metadata is returned for the csv feed.
         /// </summary>
         /// <param name="value">Value of the FeedType input for this Choreo.</param>
         public void setFeedType(String value) {
             base.addInput ("FeedType", value);
         }
         /// <summary>
         /// (optional, string) Returns any feeds matching this string.
         /// </summary>
         /// <param name="value">Value of the FullTextSearch input for this Choreo.</param>
         public void setFullTextSearch(String value) {
             base.addInput ("FullTextSearch", value);
         }
         /// <summary>
         /// (optional, decimal) Used to find feeds located around this latitude. Ex. 51.5235375648154.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (optional, decimal) Used to find feeds located around this longitude. Ex: -0.0807666778564453.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, integer) Indicates which page of results you are requesting. Starts from 1.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, integer) Defines how many results to return per page (1 to 1000).
         /// </summary>
         /// <param name="value">Value of the PerPage input for this Choreo.</param>
         public void setPerPage(String value) {
             base.addInput ("PerPage", value);
         }
         /// <summary>
         /// (optional, string) Include user login and user level for each feed. Valid values: true, false (default).
         /// </summary>
         /// <param name="value">Value of the ShowUser input for this Choreo.</param>
         public void setShowUser(String value) {
             base.addInput ("ShowUser", value);
         }
         /// <summary>
         /// (optional, string) Order of returned feeds. Valid values: "created_at", "retrieved_at" or "relevance".
         /// </summary>
         /// <param name="value">Value of the SortOrder input for this Choreo.</param>
         public void setSortOrder(String value) {
             base.addInput ("SortOrder", value);
         }
         /// <summary>
         /// (optional, string) Sets whether to search for only live feeds, only frozen feeds, or all feeds. Valid values: "live", "frozen", "all" (default).
         /// </summary>
         /// <param name="value">Value of the Status input for this Choreo.</param>
         public void setStatus(String value) {
             base.addInput ("Status", value);
         }
         /// <summary>
         /// (optional, string) Returns feeds containing datastreams tagged with the search query.
         /// </summary>
         /// <param name="value">Value of the Tag input for this Choreo.</param>
         public void setTag(String value) {
             base.addInput ("Tag", value);
         }
         /// <summary>
         /// (optional, string) Returns feeds containing datastreams with units specified by the search query. Ex: Celsius.
         /// </summary>
         /// <param name="value">Value of the Units input for this Choreo.</param>
         public void setUnits(String value) {
             base.addInput ("Units", value);
         }
         /// <summary>
         /// (optional, string) Returns feeds created by the user specified.
         /// </summary>
         /// <param name="value">Value of the User input for this Choreo.</param>
         public void setUser(String value) {
             base.addInput ("User", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListAllFeedsResultSet containing execution metadata and results.</returns>
        new public ListAllFeedsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListAllFeedsResultSet results = new JavaScriptSerializer().Deserialize<ListAllFeedsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListAllFeeds Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListAllFeedsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Xively.</returns>
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
