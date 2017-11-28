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
    /// GetDeepSearchResults
    /// Retrieve comprehensive property information for a specified address. 
    /// </summary>
    public class GetDeepSearchResults : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetDeepSearchResults Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetDeepSearchResults(TembooSession session) : base(session, "/Library/Zillow/GetDeepSearchResults")
        {
        }

         /// <summary>
         /// (required, string) Enter the address of the property to search.
         /// </summary>
         /// <param name="value">Value of the Address input for this Choreo.</param>
         public void setAddress(String value) {
             base.addInput ("Address", value);
         }
         /// <summary>
         /// (required, string) Enter a city name.
         /// </summary>
         /// <param name="value">Value of the City input for this Choreo.</param>
         public void setCity(String value) {
             base.addInput ("City", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 1 (true) to enable. Defaults to 0 (false).
         /// </summary>
         /// <param name="value">Value of the RentEstimate input for this Choreo.</param>
         public void setRentEstimate(String value) {
             base.addInput ("RentEstimate", value);
         }
         /// <summary>
         /// (required, string) Enter a State abbreviation. If State is set, an entry for City must also be entered.
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
         /// (required, integer) Enter a zipcode. Can be combined with or without the  City and State input variables.
         /// </summary>
         /// <param name="value">Value of the Zipcode input for this Choreo.</param>
         public void setZipcode(String value) {
             base.addInput ("Zipcode", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetDeepSearchResultsResultSet containing execution metadata and results.</returns>
        new public GetDeepSearchResultsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetDeepSearchResultsResultSet results = new JavaScriptSerializer().Deserialize<GetDeepSearchResultsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetDeepSearchResults Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetDeepSearchResultsResultSet : Temboo.Core.ResultSet
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
