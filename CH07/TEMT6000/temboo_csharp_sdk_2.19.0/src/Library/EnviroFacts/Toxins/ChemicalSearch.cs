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

namespace Temboo.Library.EnviroFacts.Toxins
{
    /// <summary>
    /// ChemicalSearch
    /// Retrieves information about specific chemicals released by EPA-regulated facilities.
    /// </summary>
    public class ChemicalSearch : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ChemicalSearch Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ChemicalSearch(TembooSession session) : base(session, "/Library/EnviroFacts/Toxins/ChemicalSearch")
        {
        }

         /// <summary>
         /// (required, string) EPA ID number of a chemical. Chemical IDs from a given facility can be found by first running the ChemActivityByFacility or ToxinReleaseByFacility Choreos.
         /// </summary>
         /// <param name="value">Value of the ChemicalID input for this Choreo.</param>
         public void setChemicalID(String value) {
             base.addInput ("ChemicalID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ChemicalSearchResultSet containing execution metadata and results.</returns>
        new public ChemicalSearchResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ChemicalSearchResultSet results = new JavaScriptSerializer().Deserialize<ChemicalSearchResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ChemicalSearch Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ChemicalSearchResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from EnviroFacts.</returns>
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
