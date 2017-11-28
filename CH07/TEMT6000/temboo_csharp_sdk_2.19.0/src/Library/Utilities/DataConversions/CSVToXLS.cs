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
    /// CSVToXLS
    /// Converts a CSV formatted file to Base64 encoded Excel data.
    /// </summary>
    public class CSVToXLS : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CSVToXLS Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CSVToXLS(TembooSession session) : base(session, "/Library/Utilities/DataConversions/CSVToXLS")
        {
        }

         /// <summary>
         /// (conditional, multiline) The CSV data you want to convert to XLS format. Required unless using the VaultFile input alias (an advanced option used when running Choreos in the Temboo Designer).
         /// </summary>
         /// <param name="value">Value of the CSV input for this Choreo.</param>
         public void setCSV(String value) {
             base.addInput ("CSV", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CSVToXLSResultSet containing execution metadata and results.</returns>
        new public CSVToXLSResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CSVToXLSResultSet results = new JavaScriptSerializer().Deserialize<CSVToXLSResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CSVToXLS Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CSVToXLSResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "XLS" output from this Choreo execution
        /// <returns>String - (string) The Base64 encoded Excel data.</returns>
        /// </summary>
        public String XLS
        {
            get
            {
                return (String) base.Output["XLS"];
            }
        }
    }
}
