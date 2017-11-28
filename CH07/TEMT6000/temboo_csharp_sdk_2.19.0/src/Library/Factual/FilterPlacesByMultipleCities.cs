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

namespace Temboo.Library.Factual
{
    /// <summary>
    /// FilterPlacesByMultipleCities
    /// Restrict a query to a specified city.
    /// </summary>
    public class FilterPlacesByMultipleCities : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FilterPlacesByMultipleCities Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FilterPlacesByMultipleCities(TembooSession session) : base(session, "/Library/Factual/FilterPlacesByMultipleCities")
        {
        }

         /// <summary>
         /// (optional, string) The API Key provided by Factual (AKA the OAuth Consumer Key).
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) The API Secret provided by Factual (AKA the OAuth Consumer Secret).
         /// </summary>
         /// <param name="value">Value of the APISecret input for this Choreo.</param>
         public void setAPISecret(String value) {
             base.addInput ("APISecret", value);
         }
         /// <summary>
         /// (required, json) A A JSON-encoded array of cities to filter results by.
         /// </summary>
         /// <param name="value">Value of the Cities input for this Choreo.</param>
         public void setCities(String value) {
             base.addInput ("Cities", value);
         }
         /// <summary>
         /// (optional, string) A search string (i.e. Starbucks).
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A FilterPlacesByMultipleCitiesResultSet containing execution metadata and results.</returns>
        new public FilterPlacesByMultipleCitiesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FilterPlacesByMultipleCitiesResultSet results = new JavaScriptSerializer().Deserialize<FilterPlacesByMultipleCitiesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FilterPlacesByMultipleCities Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FilterPlacesByMultipleCitiesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Factual.</returns>
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
