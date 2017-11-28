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

namespace Temboo.Library.FedEx.Locations
{
    /// <summary>
    /// SearchLocationsByAddress
    /// Searches for FedEx locations near a given address.
    /// </summary>
    public class SearchLocationsByAddress : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchLocationsByAddress Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchLocationsByAddress(TembooSession session) : base(session, "/Library/FedEx/Locations/SearchLocationsByAddress")
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
         /// (required, string) The city associated with the location being searched.
         /// </summary>
         /// <param name="value">Value of the City input for this Choreo.</param>
         public void setCity(String value) {
             base.addInput ("City", value);
         }
         /// <summary>
         /// (required, string) The country code associated with the location being searched (e.g., US).
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
         /// (required, string) The postal code associated with the location being searched.
         /// </summary>
         /// <param name="value">Value of the PostalCode input for this Choreo.</param>
         public void setPostalCode(String value) {
             base.addInput ("PostalCode", value);
         }
         /// <summary>
         /// (optional, decimal) Specifies value of the radius around the address to search for FedEx locations. Note that RadiusUnits applies to this value. Defaults to 10 miles.
         /// </summary>
         /// <param name="value">Value of the RadiusDistance input for this Choreo.</param>
         public void setRadiusDistance(String value) {
             base.addInput ("RadiusDistance", value);
         }
         /// <summary>
         /// (optional, string) Specifies the unit of measure for the RadiusDistance value. Valid values are mi (the default) and km.
         /// </summary>
         /// <param name="value">Value of the RadiusUnits input for this Choreo.</param>
         public void setRadiusUnits(String value) {
             base.addInput ("RadiusUnits", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Specifies the criterion to be used to sort the location details. Valid values are: distance (the default), latest_express_dropoff_time, latest_ground_dropoff_time, location_type.
         /// </summary>
         /// <param name="value">Value of the SortBy input for this Choreo.</param>
         public void setSortBy(String value) {
             base.addInput ("SortBy", value);
         }
         /// <summary>
         /// (optional, string) Specifies sort order of the location details. Valid values are: lowest_to_highest (the default) and highest_to_lowest.
         /// </summary>
         /// <param name="value">Value of the SortOrder input for this Choreo.</param>
         public void setSortOrder(String value) {
             base.addInput ("SortOrder", value);
         }
         /// <summary>
         /// (required, string) Identifying abbreviation for US state, Canada province (e.g., NY).
         /// </summary>
         /// <param name="value">Value of the State input for this Choreo.</param>
         public void setState(String value) {
             base.addInput ("State", value);
         }
         /// <summary>
         /// (required, string) The street number and street name (e.g., 350 5th Ave).
         /// </summary>
         /// <param name="value">Value of the Street input for this Choreo.</param>
         public void setStreet(String value) {
             base.addInput ("Street", value);
         }
         /// <summary>
         /// (optional, string) Specifies the types of services supported by a FedEx location for redirect to hold. Valid values are: fedex_express, fedex_ground, fedex_ground_home_delivery.
         /// </summary>
         /// <param name="value">Value of the SupportedServices input for this Choreo.</param>
         public void setSupportedServices(String value) {
             base.addInput ("SupportedServices", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchLocationsByAddressResultSet containing execution metadata and results.</returns>
        new public SearchLocationsByAddressResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchLocationsByAddressResultSet results = new JavaScriptSerializer().Deserialize<SearchLocationsByAddressResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchLocationsByAddress Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchLocationsByAddressResultSet : Temboo.Core.ResultSet
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
