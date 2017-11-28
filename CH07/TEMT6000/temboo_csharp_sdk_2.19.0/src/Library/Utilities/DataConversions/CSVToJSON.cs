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

namespace Temboo.Library.Utilities.DataConversions
{
    /// <summary>
    /// CSVToJSON
    /// Converts a CSV formatted file to JSON.
    /// </summary>
    public class CSVToJSON : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CSVToJSON Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CSVToJSON(TembooSession session) : base(session, "/Library/Utilities/DataConversions/CSVToJSON")
        {
        }

         /// <summary>
         /// (required, multiline) The CSV file to convert to JSON. Your CSV data must contain column names.
         /// </summary>
         /// <param name="value">Value of the CSV input for this Choreo.</param>
         public void setCSV(String value) {
             base.addInput ("CSV", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CSVToJSONResultSet containing execution metadata and results.</returns>
        new public CSVToJSONResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CSVToJSONResultSet results = new JavaScriptSerializer().Deserialize<CSVToJSONResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CSVToJSON Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CSVToJSONResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "JSON" output from this Choreo execution
        /// <returns>String - (json) The JSON formatted data.</returns>
        /// </summary>
        public String JSON
        {
            get
            {
                return (String) base.Output["JSON"];
            }
        }
    }
}
