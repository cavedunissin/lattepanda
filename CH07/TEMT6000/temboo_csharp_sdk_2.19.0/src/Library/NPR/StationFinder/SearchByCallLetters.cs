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

namespace Temboo.Library.NPR.StationFinder
{
    /// <summary>
    /// SearchByCallLetters
    /// Retrieves local NPR member stations based on uniquely identifying call letters.
    /// </summary>
    public class SearchByCallLetters : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchByCallLetters Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchByCallLetters(TembooSession session) : base(session, "/Library/NPR/StationFinder/SearchByCallLetters")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by NPR.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) Enter AM or FM.
         /// </summary>
         /// <param name="value">Value of the Band input for this Choreo.</param>
         public void setBand(String value) {
             base.addInput ("Band", value);
         }
         /// <summary>
         /// (required, string) Enter the unique identifier associated with a station.
         /// </summary>
         /// <param name="value">Value of the CallLetters input for this Choreo.</param>
         public void setCallLetters(String value) {
             base.addInput ("CallLetters", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are xml (the default), and json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchByCallLettersResultSet containing execution metadata and results.</returns>
        new public SearchByCallLettersResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchByCallLettersResultSet results = new JavaScriptSerializer().Deserialize<SearchByCallLettersResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchByCallLetters Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchByCallLettersResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from NPR.</returns>
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
