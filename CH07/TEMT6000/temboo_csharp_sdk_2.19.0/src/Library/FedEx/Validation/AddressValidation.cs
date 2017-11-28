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

namespace Temboo.Library.FedEx.Validation
{
    /// <summary>
    /// AddressValidation
    /// Validates a given address.
    /// </summary>
    public class AddressValidation : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AddressValidation Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AddressValidation(TembooSession session) : base(session, "/Library/FedEx/Validation/AddressValidation")
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
         /// (conditional, string) The name of the city or town.
         /// </summary>
         /// <param name="value">Value of the City input for this Choreo.</param>
         public void setCity(String value) {
             base.addInput ("City", value);
         }
         /// <summary>
         /// (optional, string) A reference id provided by the client.
         /// </summary>
         /// <param name="value">Value of the ClientReferenceID input for this Choreo.</param>
         public void setClientReferenceID(String value) {
             base.addInput ("ClientReferenceID", value);
         }
         /// <summary>
         /// (optional, string) Identifies the company associated with the location.
         /// </summary>
         /// <param name="value">Value of the CompanyName input for this Choreo.</param>
         public void setCompanyName(String value) {
             base.addInput ("CompanyName", value);
         }
         /// <summary>
         /// (conditional, string) The country code associated with the address being validated (e.g., US).
         /// </summary>
         /// <param name="value">Value of the CountryCode input for this Choreo.</param>
         public void setCountryCode(String value) {
             base.addInput ("CountryCode", value);
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
         /// (optional, string) Identifies the phone number associated with the contact being validated.
         /// </summary>
         /// <param name="value">Value of the PhoneNumber input for this Choreo.</param>
         public void setPhoneNumber(String value) {
             base.addInput ("PhoneNumber", value);
         }
         /// <summary>
         /// (conditional, string) The postal code associated with the address being validated.
         /// </summary>
         /// <param name="value">Value of the PostalCode input for this Choreo.</param>
         public void setPostalCode(String value) {
             base.addInput ("PostalCode", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, string) Identifying abbreviation for US state, Canada province (e.g., NY).
         /// </summary>
         /// <param name="value">Value of the State input for this Choreo.</param>
         public void setState(String value) {
             base.addInput ("State", value);
         }
         /// <summary>
         /// (conditional, string) The street number and street name (e.g., 350 5th Ave).
         /// </summary>
         /// <param name="value">Value of the Street input for this Choreo.</param>
         public void setStreet(String value) {
             base.addInput ("Street", value);
         }
         /// <summary>
         /// (optional, string) Relevant only to addresses in Puerto Rico.
         /// </summary>
         /// <param name="value">Value of the UrbanizationCode input for this Choreo.</param>
         public void setUrbanizationCode(String value) {
             base.addInput ("UrbanizationCode", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AddressValidationResultSet containing execution metadata and results.</returns>
        new public AddressValidationResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AddressValidationResultSet results = new JavaScriptSerializer().Deserialize<AddressValidationResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AddressValidation Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AddressValidationResultSet : Temboo.Core.ResultSet
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
