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

namespace Temboo.Library.Utilities.Finding
{
    /// <summary>
    /// FindSubstring
    /// Finds all occurrences of a specified substring and returns the substring positions as a JSON array.
    /// </summary>
    public class FindSubstring : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FindSubstring Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FindSubstring(TembooSession session) : base(session, "/Library/Utilities/Finding/FindSubstring")
        {
        }

         /// <summary>
         /// (optional, boolean) When set to true, the search will be case-sensitive. Defaults to false indicating a case-insensitive search.
         /// </summary>
         /// <param name="value">Value of the CaseSensitive input for this Choreo.</param>
         public void setCaseSensitive(String value) {
             base.addInput ("CaseSensitive", value);
         }
         /// <summary>
         /// (optional, string) The character position at which to begin the search. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the StartNumber input for this Choreo.</param>
         public void setStartNumber(String value) {
             base.addInput ("StartNumber", value);
         }
         /// <summary>
         /// (required, string) The sub-string to search within the specified text (searching from left to right).
         /// </summary>
         /// <param name="value">Value of the Substring input for this Choreo.</param>
         public void setSubstring(String value) {
             base.addInput ("Substring", value);
         }
         /// <summary>
         /// (required, string) The text to search for a sub-string.
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A FindSubstringResultSet containing execution metadata and results.</returns>
        new public FindSubstringResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FindSubstringResultSet results = new JavaScriptSerializer().Deserialize<FindSubstringResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FindSubstring Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FindSubstringResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Count" output from this Choreo execution
        /// <returns>String - (integer) The count of sub-strings found.</returns>
        /// </summary>
        public String Count
        {
            get
            {
                return (String) base.Output["Count"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Positions" output from this Choreo execution
        /// <returns>String - (json) The positions of the sub-strings that were found in the search.</returns>
        /// </summary>
        public String Positions
        {
            get
            {
                return (String) base.Output["Positions"];
            }
        }
    }
}
