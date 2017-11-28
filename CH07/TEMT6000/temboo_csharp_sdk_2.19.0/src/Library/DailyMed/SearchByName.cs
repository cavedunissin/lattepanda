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
    /// SearchByName
    /// Returns a list of drugs in the DailyMed database associated with a given drug name.
    /// </summary>
    public class SearchByName : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchByName Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchByName(TembooSession session) : base(session, "/Library/DailyMed/SearchByName")
        {
        }

         /// <summary>
         /// (required, string) The name of the drug you want to find.
         /// </summary>
         /// <param name="value">Value of the DrugName input for this Choreo.</param>
         public void setDrugName(String value) {
             base.addInput ("DrugName", value);
         }
         /// <summary>
         /// (optional, string) Filter results by a specified type. Acceptable values: rxonly, otc, human, human/rxonly, human/otc, animal. See documentation for more information.
         /// </summary>
         /// <param name="value">Value of the LabelType input for this Choreo.</param>
         public void setLabelType(String value) {
             base.addInput ("LabelType", value);
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
        /// <returns>A SearchByNameResultSet containing execution metadata and results.</returns>
        new public SearchByNameResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchByNameResultSet results = new JavaScriptSerializer().Deserialize<SearchByNameResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchByName Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchByNameResultSet : Temboo.Core.ResultSet
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
