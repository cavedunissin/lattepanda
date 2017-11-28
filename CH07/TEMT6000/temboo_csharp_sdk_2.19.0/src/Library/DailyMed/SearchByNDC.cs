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

namespace Temboo.Library.DailyMed
{
    /// <summary>
    /// SearchByNDC
    /// Returns a list of drugs in the DailyMed database associated with a given National Drug Code (NDC).
    /// </summary>
    public class SearchByNDC : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchByNDC Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchByNDC(TembooSession session) : base(session, "/Library/DailyMed/SearchByNDC")
        {
        }

         /// <summary>
         /// (required, string) National Drug Code. This is a unique 10-digit numeric identifier assigned to each medication by the Food and Drug Administration (FDA).
         /// </summary>
         /// <param name="value">Value of the NDC input for this Choreo.</param>
         public void setNDC(String value) {
             base.addInput ("NDC", value);
         }
         /// <summary>
         /// (optional, string) Defaults to XML format when nothing is specified. Acceptable values: xml or json.
         /// </summary>
         /// <param name="value">Value of the OutputFormat input for this Choreo.</param>
         public void setOutputFormat(String value) {
             base.addInput ("OutputFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchByNDCResultSet containing execution metadata and results.</returns>
        new public SearchByNDCResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchByNDCResultSet results = new JavaScriptSerializer().Deserialize<SearchByNDCResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchByNDC Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchByNDCResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from DailyMed.</returns>
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
