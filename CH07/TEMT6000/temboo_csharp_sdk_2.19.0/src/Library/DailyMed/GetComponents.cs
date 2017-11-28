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
    /// GetComponents
    /// Returns imprint data associated with a given National Drug Code (NDC) in the DailyMed database.
    /// </summary>
    public class GetComponents : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetComponents Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetComponents(TembooSession session) : base(session, "/Library/DailyMed/GetComponents")
        {
        }

         /// <summary>
         /// (required, string) The unique ID assigned by DailyMed to each drug. You can find the SetID of a drug by first running the SearchByName or SearchByNDC Choreos.
         /// </summary>
         /// <param name="value">Value of the SetID input for this Choreo.</param>
         public void setSetID(String value) {
             base.addInput ("SetID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetComponentsResultSet containing execution metadata and results.</returns>
        new public GetComponentsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetComponentsResultSet results = new JavaScriptSerializer().Deserialize<GetComponentsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetComponents Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetComponentsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from DailyMed.</returns>
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
