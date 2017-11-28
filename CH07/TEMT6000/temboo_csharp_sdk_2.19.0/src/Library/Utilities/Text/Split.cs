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

namespace Temboo.Library.Utilities.Text
{
    /// <summary>
    /// Split
    /// Splits a string into sub-strings delimited by the specified delmiter pattern.
    /// </summary>
    public class Split : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Split Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Split(TembooSession session) : base(session, "/Library/Utilities/Text/Split")
        {
        }

         /// <summary>
         /// (required, string) The delimiter to search for when splitting the string into sub-strings. See Choreo notes for restrictions with delimiters.
         /// </summary>
         /// <param name="value">Value of the Delimiter input for this Choreo.</param>
         public void setDelimiter(String value) {
             base.addInput ("Delimiter", value);
         }
         /// <summary>
         /// (required, multiline) The text that should be split into sub-strings.
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SplitResultSet containing execution metadata and results.</returns>
        new public SplitResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SplitResultSet results = new JavaScriptSerializer().Deserialize<SplitResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Split Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SplitResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (string) Contains the sub-strings formatted as a JSON array.</returns>
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
