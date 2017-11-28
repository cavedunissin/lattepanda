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

namespace Temboo.Library.DataGov
{
    /// <summary>
    /// GetCensusIDByTypeAndName
    /// Retrieve the U.S. census ID for a specified geography type and name.
    /// </summary>
    public class GetCensusIDByTypeAndName : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetCensusIDByTypeAndName Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetCensusIDByTypeAndName(TembooSession session) : base(session, "/Library/DataGov/GetCensusIDByTypeAndName")
        {
        }

         /// <summary>
         /// (required, string) Specify the geography name for the correspnding type, with at least three leading characters. For example, for the geography type "state" you could enter "ore" for Oregon.
         /// </summary>
         /// <param name="value">Value of the GeographyName input for this Choreo.</param>
         public void setGeographyName(String value) {
             base.addInput ("GeographyName", value);
         }
         /// <summary>
         /// (required, string) Specify one of the following geography type values: "state", "county", "tract", "block", "congdistrict", "statehouse", "statesenate", "censusplace", or "msa" (metropolitan statistical area).
         /// </summary>
         /// <param name="value">Value of the GeographyType input for this Choreo.</param>
         public void setGeographyType(String value) {
             base.addInput ("GeographyType", value);
         }
         /// <summary>
         /// (required, integer) Specify the maximum number of results to return. Defaults to 50.
         /// </summary>
         /// <param name="value">Value of the MaxResults input for this Choreo.</param>
         public void setMaxResults(String value) {
             base.addInput ("MaxResults", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: xml (the default) and json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetCensusIDByTypeAndNameResultSet containing execution metadata and results.</returns>
        new public GetCensusIDByTypeAndNameResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetCensusIDByTypeAndNameResultSet results = new JavaScriptSerializer().Deserialize<GetCensusIDByTypeAndNameResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetCensusIDByTypeAndName Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetCensusIDByTypeAndNameResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "CensusID" output from this Choreo execution
        /// <returns>String - (integer) The ID retrieved from the API call.</returns>
        /// </summary>
        public String CensusID
        {
            get
            {
                return (String) base.Output["CensusID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response returned from the API.</returns>
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
