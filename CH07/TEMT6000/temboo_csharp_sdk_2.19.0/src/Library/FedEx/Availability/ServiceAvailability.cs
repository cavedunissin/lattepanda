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

namespace Temboo.Library.FedEx.Availability
{
    /// <summary>
    /// ServiceAvailability
    /// Retrieves available shipping options and delivery dates for a specified origin and destination.
    /// </summary>
    public class ServiceAvailability : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ServiceAvailability Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ServiceAvailability(TembooSession session) : base(session, "/Library/FedEx/Availability/ServiceAvailability")
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
         /// (required, string) The destination country code to use for the service availability request (e.g., US).
         /// </summary>
         /// <param name="value">Value of the DestinationCountryCode input for this Choreo.</param>
         public void setDestinationCountryCode(String value) {
             base.addInput ("DestinationCountryCode", value);
         }
         /// <summary>
         /// (required, string) The destination postal code to use for  the service availability request.
         /// </summary>
         /// <param name="value">Value of the DestinationPostalCode input for this Choreo.</param>
         public void setDestinationPostalCode(String value) {
             base.addInput ("DestinationPostalCode", value);
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
         /// (required, string) The origin country code to use for the service availability request (e.g., US).
         /// </summary>
         /// <param name="value">Value of the OriginCountryCode input for this Choreo.</param>
         public void setOriginCountryCode(String value) {
             base.addInput ("OriginCountryCode", value);
         }
         /// <summary>
         /// (required, string) The origin postal code to use for the service availability request.
         /// </summary>
         /// <param name="value">Value of the OriginPostalCode input for this Choreo.</param>
         public void setOriginPostalCode(String value) {
             base.addInput ("OriginPostalCode", value);
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
         /// (optional, date) The date to use for the service availability request. Dates should be formatted as YYYY-MM-DD. Defautls to today's date.
         /// </summary>
         /// <param name="value">Value of the ShipDate input for this Choreo.</param>
         public void setShipDate(String value) {
             base.addInput ("ShipDate", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ServiceAvailabilityResultSet containing execution metadata and results.</returns>
        new public ServiceAvailabilityResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ServiceAvailabilityResultSet results = new JavaScriptSerializer().Deserialize<ServiceAvailabilityResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ServiceAvailability Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ServiceAvailabilityResultSet : Temboo.Core.ResultSet
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
