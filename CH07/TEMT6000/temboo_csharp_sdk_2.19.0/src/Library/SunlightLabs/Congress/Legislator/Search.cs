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

namespace Temboo.Library.SunlightLabs.Congress.Legislator
{
    /// <summary>
    /// Search
    /// Returns current committees, subcommittees, and their membership.
    /// </summary>
    public class Search : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Search Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Search(TembooSession session) : base(session, "/Library/SunlightLabs/Congress/Legislator/Search")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Sunlight Labs.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, boolean) A boolean flag indicating to search for all legislators even when they are no longer in office.
         /// </summary>
         /// <param name="value">Value of the AllLegislators input for this Choreo.</param>
         public void setAllLegislators(String value) {
             base.addInput ("AllLegislators", value);
         }
         /// <summary>
         /// (optional, string) A comma-separated list of fields to include in the response.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, string) A JSON object containing key/value pairs to be used as filters.
         /// </summary>
         /// <param name="value">Value of the Filters input for this Choreo.</param>
         public void setFilters(String value) {
             base.addInput ("Filters", value);
         }
         /// <summary>
         /// (optional, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (optional, string) Used to order the results by field name (e.g. field__asc).
         /// </summary>
         /// <param name="value">Value of the Order input for this Choreo.</param>
         public void setOrder(String value) {
             base.addInput ("Order", value);
         }
         /// <summary>
         /// (optional, integer) The page offset.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to return per page.
         /// </summary>
         /// <param name="value">Value of the PerPage input for this Choreo.</param>
         public void setPerPage(String value) {
             base.addInput ("PerPage", value);
         }
         /// <summary>
         /// (conditional, string) A search term.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
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
        /// <returns>A SearchResultSet containing execution metadata and results.</returns>
        new public SearchResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchResultSet results = new JavaScriptSerializer().Deserialize<SearchResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Search Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from the Sunlight Congress API.</returns>
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
