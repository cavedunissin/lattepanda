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

namespace Temboo.Library.Twilio.AvailablePhoneNumbers
{
    /// <summary>
    /// LocalList
    /// Returns a list of local available phone numbers that match the specified filters.
    /// </summary>
    public class LocalList : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the LocalList Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public LocalList(TembooSession session) : base(session, "/Library/Twilio/AvailablePhoneNumbers/LocalList")
        {
        }

         /// <summary>
         /// (required, string) The AccountSID provided when you signed up for a Twilio account.
         /// </summary>
         /// <param name="value">Value of the AccountSID input for this Choreo.</param>
         public void setAccountSID(String value) {
             base.addInput ("AccountSID", value);
         }
         /// <summary>
         /// (optional, integer) Find phone numbers in the specified area code. (US and Canada only).
         /// </summary>
         /// <param name="value">Value of the AreaCode input for this Choreo.</param>
         public void setAreaCode(String value) {
             base.addInput ("AreaCode", value);
         }
         /// <summary>
         /// (required, string) The authorization token provided when you signed up for a Twilio account.
         /// </summary>
         /// <param name="value">Value of the AuthToken input for this Choreo.</param>
         public void setAuthToken(String value) {
             base.addInput ("AuthToken", value);
         }
         /// <summary>
         /// (optional, string) A pattern to match phone numbers on. Valid characters are '*' and [0-9a-zA-Z]. The '*' character will match any single digit.
         /// </summary>
         /// <param name="value">Value of the Contains input for this Choreo.</param>
         public void setContains(String value) {
             base.addInput ("Contains", value);
         }
         /// <summary>
         /// (optional, integer) Specifies the search radius for Latitude, Longitude, and NearNumber quires in miles. If not specified this defaults to 25 miles.
         /// </summary>
         /// <param name="value">Value of the Distance input for this Choreo.</param>
         public void setDistance(String value) {
             base.addInput ("Distance", value);
         }
         /// <summary>
         /// (optional, string) Limit results to a specific Local access and transport area (LATA). Given a phone number, search within the same LATA as that number.
         /// </summary>
         /// <param name="value">Value of the InLata input for this Choreo.</param>
         public void setInLata(String value) {
             base.addInput ("InLata", value);
         }
         /// <summary>
         /// (optional, integer) Limit results to a particular postal code. Given a phone number, search within the same postal code as that number. (US and Canada only).
         /// </summary>
         /// <param name="value">Value of the InPostalCode input for this Choreo.</param>
         public void setInPostalCode(String value) {
             base.addInput ("InPostalCode", value);
         }
         /// <summary>
         /// (optional, string) Limit results to a specific rate center, or given a phone number search within the same rate center as that number. Requires InLata to be set as well.
         /// </summary>
         /// <param name="value">Value of the InRateCenter input for this Choreo.</param>
         public void setInRateCenter(String value) {
             base.addInput ("InRateCenter", value);
         }
         /// <summary>
         /// (optional, string) Limit results to a particular region (i.e. State/Province). Given a phone number, search within the same Region as that number. (US and Canada only).
         /// </summary>
         /// <param name="value">Value of the InRegion input for this Choreo.</param>
         public void setInRegion(String value) {
             base.addInput ("InRegion", value);
         }
         /// <summary>
         /// (optional, string) The country code to search within. Defaults to US.
         /// </summary>
         /// <param name="value">Value of the IsoCountryCode input for this Choreo.</param>
         public void setIsoCountryCode(String value) {
             base.addInput ("IsoCountryCode", value);
         }
         /// <summary>
         /// (optional, decimal) Finds numbers close to this Latitude coordinate. Longitude is also required when searching by coordinates.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (optional, string) Finds numbers close this Longitude. Latitude is also required when searching by coordinates.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, string) Searches numbers near  this phone number.
         /// </summary>
         /// <param name="value">Value of the NearNumber input for this Choreo.</param>
         public void setNearNumber(String value) {
             base.addInput ("NearNumber", value);
         }
         /// <summary>
         /// (optional, integer) The page of results to retrieve. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, integer) The number of results per page.
         /// </summary>
         /// <param name="value">Value of the PageSize input for this Choreo.</param>
         public void setPageSize(String value) {
             base.addInput ("PageSize", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A LocalListResultSet containing execution metadata and results.</returns>
        new public LocalListResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            LocalListResultSet results = new JavaScriptSerializer().Deserialize<LocalListResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the LocalList Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class LocalListResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Twilio.</returns>
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
