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

namespace Temboo.Library.Facebook.Searching
{
    /// <summary>
    /// Search
    /// Search public objects across the social graph.
    /// </summary>
    public class Search : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Search Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Search(TembooSession session) : base(session, "/Library/Facebook/Searching/Search")
        {
        }

         /// <summary>
         /// (conditional, string) The access token retrieved from the final OAuth step.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The coordinates for a place (such as 37.76,122.427). Used only when specifying an object type of "place".
         /// </summary>
         /// <param name="value">Value of the Center input for this Choreo.</param>
         public void setCenter(String value) {
             base.addInput ("Center", value);
         }
         /// <summary>
         /// (optional, integer) The distance search parameter used only when specifying an object type of "place". Defaults to 1000.
         /// </summary>
         /// <param name="value">Value of the Distance input for this Choreo.</param>
         public void setDistance(String value) {
             base.addInput ("Distance", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of fields to return (i.e. id,name).
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, integer) Used to page through results. Limits the number of records returned in the response.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (required, string) The type of object to search for such as: user, page, event, group, or place.
         /// </summary>
         /// <param name="value">Value of the ObjectType input for this Choreo.</param>
         public void setObjectType(String value) {
             base.addInput ("ObjectType", value);
         }
         /// <summary>
         /// (optional, integer) Used to page through results. Returns results starting from the specified number.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (conditional, string) The Facebook query term to send in the request.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, date) Used for time-based pagination. Values can be a unix timestamp or any date accepted by strtotime.
         /// </summary>
         /// <param name="value">Value of the Since input for this Choreo.</param>
         public void setSince(String value) {
             base.addInput ("Since", value);
         }
         /// <summary>
         /// (optional, date) Used for time-based pagination. Values can be a unix timestamp or any date accepted by strtotime.
         /// </summary>
         /// <param name="value">Value of the Until input for this Choreo.</param>
         public void setUntil(String value) {
             base.addInput ("Until", value);
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
        /// Retrieve the value for the "HasNext" output from this Choreo execution
        /// <returns>String - (boolean) A boolean flag indicating that a next page exists.</returns>
        /// </summary>
        public String HasNext
        {
            get
            {
                return (String) base.Output["HasNext"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "HasPrevious" output from this Choreo execution
        /// <returns>String - (boolean) A boolean flag indicating that a previous page exists.</returns>
        /// </summary>
        public String HasPrevious
        {
            get
            {
                return (String) base.Output["HasPrevious"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Facebook. Corresponds to the ResponseFormat input. Defaults to JSON.</returns>
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
