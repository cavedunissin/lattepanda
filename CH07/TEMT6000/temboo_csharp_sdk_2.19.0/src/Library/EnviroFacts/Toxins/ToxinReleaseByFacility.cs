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
    /// ToxinReleaseByFacility
    /// Retrieves a list of the annual release quantities of toxic chemicals at EPA-regulated facilities into air, water, on-site land, and underground wells.
    /// </summary>
    public class ToxinReleaseByFacility : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ToxinReleaseByFacility Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ToxinReleaseByFacility(TembooSession session) : base(session, "/Library/EnviroFacts/Toxins/ToxinReleaseByFacility")
        {
        }

         /// <summary>
         /// (required, string) FacilityID for which a toxin release report is to be generated. Found by first running the FacilitiesSearch Choreo.
         /// </summary>
         /// <param name="value">Value of the FacilityID input for this Choreo.</param>
         public void setFacilityID(String value) {
             base.addInput ("FacilityID", value);
         }
         /// <summary>
         /// (optional, string) Specify the desired response format. Valid formats are: xml (the default) and csv.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, integer) Number 1 or greater indicates the ending row number of the results displayed. Default is 4999 when RowStart is 0. Up to 5000 entries are returned in the output.
         /// </summary>
         /// <param name="value">Value of the RowEnd input for this Choreo.</param>
         public void setRowEnd(String value) {
             base.addInput ("RowEnd", value);
         }
         /// <summary>
         /// (optional, integer) Indicates the starting row number of the results displayed. Default is 0.
         /// </summary>
         /// <param name="value">Value of the RowStart input for this Choreo.</param>
         public void setRowStart(String value) {
             base.addInput ("RowStart", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ToxinReleaseByFacilityResultSet containing execution metadata and results.</returns>
        new public ToxinReleaseByFacilityResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ToxinReleaseByFacilityResultSet results = new JavaScriptSerializer().Deserialize<ToxinReleaseByFacilityResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ToxinReleaseByFacility Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ToxinReleaseByFacilityResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from EnviroFacts.</returns>
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
