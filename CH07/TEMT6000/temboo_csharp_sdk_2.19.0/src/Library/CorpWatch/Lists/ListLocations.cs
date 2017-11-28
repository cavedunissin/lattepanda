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

namespace Temboo.Library.CorpWatch.Lists
{
    /// <summary>
    /// ListLocations
    /// Returns a list of locations of companies matching the given query.
    /// </summary>
    public class ListLocations : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListLocations Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListLocations(TembooSession session) : base(session, "/Library/CorpWatch/Lists/ListLocations")
        {
        }

         /// <summary>
         /// (optional, string) The APIKey from CorpWatch if you have one.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) Enter an address fragment to search for. This can be either a street address, city, or state/subregion.
         /// </summary>
         /// <param name="value">Value of the Address input for this Choreo.</param>
         public void setAddress(String value) {
             base.addInput ("Address", value);
         }
         /// <summary>
         /// (optional, string) Enter an ISO-3166 formatted country code. 
         /// </summary>
         /// <param name="value">Value of the CountryCode input for this Choreo.</param>
         public void setCountryCode(String value) {
             base.addInput ("CountryCode", value);
         }
         /// <summary>
         /// (optional, integer) Set the index number of the first result to be returned. The index of the first result is 0.
         /// </summary>
         /// <param name="value">Value of the Index input for this Choreo.</param>
         public void setIndex(String value) {
             base.addInput ("Index", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to be returned. Defaults to 100. Maximum is 5000.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, integer) Indicate desired year of the most recent appearance in SEC filing data (e.g. indicating 2007 will search for companies that ceased filing in 2007).
         /// </summary>
         /// <param name="value">Value of the MaxYear input for this Choreo.</param>
         public void setMaxYear(String value) {
             base.addInput ("MaxYear", value);
         }
         /// <summary>
         /// (optional, integer) Indicate desired year of the earliest appearance in SEC filing data (e.g. indicating 2004 will search for companies that started filing in 2004).
         /// </summary>
         /// <param name="value">Value of the MinYear input for this Choreo.</param>
         public void setMinYear(String value) {
             base.addInput ("MinYear", value);
         }
         /// <summary>
         /// (optional, integer) Enter a postal code to be searched.
         /// </summary>
         /// <param name="value">Value of the PostalCode input for this Choreo.</param>
         public void setPostalCode(String value) {
             base.addInput ("PostalCode", value);
         }
         /// <summary>
         /// (optional, string) Specify json or xml for the type of response to be returned. Defaults to xml.
         /// </summary>
         /// <param name="value">Value of the ResponseType input for this Choreo.</param>
         public void setResponseType(String value) {
             base.addInput ("ResponseType", value);
         }
         /// <summary>
         /// (optional, string) Indicates the origin of the location information found. Acceptable values: relation_loc, business, mailing, state_of_incorp. See documentation for more info.
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }
         /// <summary>
         /// (optional, integer) If a year is specified, only records for that year will be returned and the data in the company objects returned will be set appropriately for the request year. Defaults to most recent.
         /// </summary>
         /// <param name="value">Value of the Year input for this Choreo.</param>
         public void setYear(String value) {
             base.addInput ("Year", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListLocationsResultSet containing execution metadata and results.</returns>
        new public ListLocationsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListLocationsResultSet results = new JavaScriptSerializer().Deserialize<ListLocationsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListLocations Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListLocationsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from CorpWatch.</returns>
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
