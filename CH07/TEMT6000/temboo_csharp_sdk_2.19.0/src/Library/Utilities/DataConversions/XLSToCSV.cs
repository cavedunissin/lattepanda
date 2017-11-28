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
    /// XLSToCSV
    /// Converts Excel (.xls) formatted data to CSV.
    /// </summary>
    public class XLSToCSV : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the XLSToCSV Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public XLSToCSV(TembooSession session) : base(session, "/Library/Utilities/DataConversions/XLSToCSV")
        {
        }

         /// <summary>
         /// (conditional, string) The base64-encoded contents of the Excel file that you want to convert to CSV format. Compatible with Excel 97-2003.
         /// </summary>
         /// <param name="value">Value of the XLS input for this Choreo.</param>
         public void setXLS(String value) {
             base.addInput ("XLS", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A XLSToCSVResultSet containing execution metadata and results.</returns>
        new public XLSToCSVResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            XLSToCSVResultSet results = new JavaScriptSerializer().Deserialize<XLSToCSVResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the XLSToCSV Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class XLSToCSVResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "CSV" output from this Choreo execution
        /// <returns>String - (string) The CSV formatted data.</returns>
        /// </summary>
        public String CSV
        {
            get
            {
                return (String) base.Output["CSV"];
            }
        }
    }
}
