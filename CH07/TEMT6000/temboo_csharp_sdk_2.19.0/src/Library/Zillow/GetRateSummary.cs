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

namespace Temboo.Library.Zillow
{
    /// <summary>
    /// GetRateSummary
    /// Retrieve current interest rates for a specified loan type.
    /// </summary>
    public class GetRateSummary : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetRateSummary Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetRateSummary(TembooSession session) : base(session, "/Library/Zillow/GetRateSummary")
        {
        }

         /// <summary>
         /// (optional, string) Enter the desired query output format.  Enter: xml, or json.  Default output is set to: xml.
         /// </summary>
         /// <param name="value">Value of the OutputFormat input for this Choreo.</param>
         public void setOutputFormat(String value) {
             base.addInput ("OutputFormat", value);
         }
         /// <summary>
         /// (optional, string) Enter a U.S. state abbreviation for which to retrieve mortgage rates.  If null, the national average rate is returned.
         /// </summary>
         /// <param name="value">Value of the State input for this Choreo.</param>
         public void setState(String value) {
             base.addInput ("State", value);
         }
         /// <summary>
         /// (required, string) Enter a Zillow Web Service Identifier (ZWS ID).
         /// </summary>
         /// <param name="value">Value of the ZWSID input for this Choreo.</param>
         public void setZWSID(String value) {
             base.addInput ("ZWSID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetRateSummaryResultSet containing execution metadata and results.</returns>
        new public GetRateSummaryResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetRateSummaryResultSet results = new JavaScriptSerializer().Deserialize<GetRateSummaryResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetRateSummary Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetRateSummaryResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Zillow.</returns>
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
