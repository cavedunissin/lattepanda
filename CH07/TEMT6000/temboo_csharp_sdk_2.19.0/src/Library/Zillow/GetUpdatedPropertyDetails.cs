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
    /// GetUpdatedPropertyDetails
    /// Retrieve detailed property information that has been edited by the home's owner or agent.
    /// </summary>
    public class GetUpdatedPropertyDetails : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetUpdatedPropertyDetails Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetUpdatedPropertyDetails(TembooSession session) : base(session, "/Library/Zillow/GetUpdatedPropertyDetails")
        {
        }

         /// <summary>
         /// (required, integer) Enter a Zillow Property ID for the property being queried.
         /// </summary>
         /// <param name="value">Value of the ZPID input for this Choreo.</param>
         public void setZPID(String value) {
             base.addInput ("ZPID", value);
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
        /// <returns>A GetUpdatedPropertyDetailsResultSet containing execution metadata and results.</returns>
        new public GetUpdatedPropertyDetailsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetUpdatedPropertyDetailsResultSet results = new JavaScriptSerializer().Deserialize<GetUpdatedPropertyDetailsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetUpdatedPropertyDetails Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetUpdatedPropertyDetailsResultSet : Temboo.Core.ResultSet
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
