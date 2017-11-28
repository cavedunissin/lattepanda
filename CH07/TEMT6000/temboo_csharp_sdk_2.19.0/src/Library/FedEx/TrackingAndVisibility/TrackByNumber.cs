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

namespace Temboo.Library.FedEx.TrackingAndVisibility
{
    /// <summary>
    /// TrackByNumber
    /// Retrieves shipment information for a specified tracking number.
    /// </summary>
    public class TrackByNumber : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the TrackByNumber Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public TrackByNumber(TembooSession session) : base(session, "/Library/FedEx/TrackingAndVisibility/TrackByNumber")
        {
        }

         /// <summary>
         /// (required, string) Your FedEx Account Number or Test Account Number.
         /// </summary>
         /// <param name="value">Value of the AccountNumber input for this Choreo.</param>
         public void setAccountNumber(String value) {
             base.addInput ("AccountNumber", value);
         }
         /// <summary>
         /// (required, string) The Production Authentication Key or Development Test Key provided by FedEx Web Services.
         /// </summary>
         /// <param name="value">Value of the AuthenticationKey input for this Choreo.</param>
         public void setAuthenticationKey(String value) {
             base.addInput ("AuthenticationKey", value);
         }
         /// <summary>
         /// (conditional, string) Set to "test" to direct requests to the FedEx test environment. Defaults to "production" indicating that requests are sent to the production URL.
         /// </summary>
         /// <param name="value">Value of the Endpoint input for this Choreo.</param>
         public void setEndpoint(String value) {
             base.addInput ("Endpoint", value);
         }
         /// <summary>
         /// (required, string) The Production or Test Meter Number provided by FedEx Web Services.
         /// </summary>
         /// <param name="value">Value of the MeterNumber input for this Choreo.</param>
         public void setMeterNumber(String value) {
             base.addInput ("MeterNumber", value);
         }
         /// <summary>
         /// (required, password) The Production or Test Password provided by FedEx Web Services.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The tracking number for the shipment.
         /// </summary>
         /// <param name="value">Value of the TrackingNumber input for this Choreo.</param>
         public void setTrackingNumber(String value) {
             base.addInput ("TrackingNumber", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A TrackByNumberResultSet containing execution metadata and results.</returns>
        new public TrackByNumberResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            TrackByNumberResultSet results = new JavaScriptSerializer().Deserialize<TrackByNumberResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the TrackByNumber Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class TrackByNumberResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from FedEx.</returns>
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
