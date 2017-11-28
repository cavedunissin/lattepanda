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

namespace Temboo.Library.Genability.TariffData
{
    /// <summary>
    /// GetTariffs
    /// Returns a list of Tariff objects based a specified search criteria.
    /// </summary>
    public class GetTariffs : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetTariffs Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetTariffs(TembooSession session) : base(session, "/Library/Genability/TariffData/GetTariffs")
        {
        }

         /// <summary>
         /// (optional, string) The unique ID of the Account to find tariffs for. Values passed in will override those from the Account.
         /// </summary>
         /// <param name="value">Value of the AccountID input for this Choreo.</param>
         public void setAccountID(String value) {
             base.addInput ("AccountID", value);
         }
         /// <summary>
         /// (conditional, string) The App ID provided by Genability.
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
         }
         /// <summary>
         /// (required, string) The App Key provided by Genability.
         /// </summary>
         /// <param name="value">Value of the AppKey input for this Choreo.</param>
         public void setAppKey(String value) {
             base.addInput ("AppKey", value);
         }
         /// <summary>
         /// (optional, string) Returns only these customer classes. Valid values are: RESIDENTIAL, GENERAL.
         /// </summary>
         /// <param name="value">Value of the CustomerClasses input for this Choreo.</param>
         public void setCustomerClasses(String value) {
             base.addInput ("CustomerClasses", value);
         }
         /// <summary>
         /// (optional, date) Returns only tariffs that are effective on this date.
         /// </summary>
         /// <param name="value">Value of the EffectiveOn input for this Choreo.</param>
         public void setEffectiveOn(String value) {
             base.addInput ("EffectiveOn", value);
         }
         /// <summary>
         /// (optional, string) When true, the search will only return results that end with the specified search string. Otherwise, any match of the search string will be returned as a result.
         /// </summary>
         /// <param name="value">Value of the EndsWith input for this Choreo.</param>
         public void setEndsWith(String value) {
             base.addInput ("EndsWith", value);
         }
         /// <summary>
         /// (optional, date) Returns only tariffs that are effective on or after this date.
         /// </summary>
         /// <param name="value">Value of the FromDateTime input for this Choreo.</param>
         public void setFromDateTime(String value) {
             base.addInput ("FromDateTime", value);
         }
         /// <summary>
         /// (optional, boolean) When true, the provided search string will be regarded as a regular expression and the search will return results matching the regular expression.
         /// </summary>
         /// <param name="value">Value of the IsRegex input for this Choreo.</param>
         public void setIsRegex(String value) {
             base.addInput ("IsRegex", value);
         }
         /// <summary>
         /// (optional, integer) Filter tariffs for a specific LSE.
         /// </summary>
         /// <param name="value">Value of the LSEID input for this Choreo.</param>
         public void setLSEID(String value) {
             base.addInput ("LSEID", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to return. Defaults to 25.
         /// </summary>
         /// <param name="value">Value of the PageCount input for this Choreo.</param>
         public void setPageCount(String value) {
             base.addInput ("PageCount", value);
         }
         /// <summary>
         /// (optional, integer) The page number to begin the result set from. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the PageStart input for this Choreo.</param>
         public void setPageStart(String value) {
             base.addInput ("PageStart", value);
         }
         /// <summary>
         /// (optional, boolean) Set to "true" to populate the properties for the returned Tariffs.
         /// </summary>
         /// <param name="value">Value of the PopulateProperties input for this Choreo.</param>
         public void setPopulateProperties(String value) {
             base.addInput ("PopulateProperties", value);
         }
         /// <summary>
         /// (optional, boolean) Set to "true" to populate the rate details for the returned Tariffs.
         /// </summary>
         /// <param name="value">Value of the PopulateRates input for this Choreo.</param>
         public void setPopulateRates(String value) {
             base.addInput ("PopulateRates", value);
         }
         /// <summary>
         /// (optional, string) The string of text to search on. This can also be a regular expression, in which case you should set the 'isRegex' flag to true.
         /// </summary>
         /// <param name="value">Value of the Search input for this Choreo.</param>
         public void setSearch(String value) {
             base.addInput ("Search", value);
         }
         /// <summary>
         /// (optional, string) Comma separated list of fields to query on. When searchOn is specified, the text provided in the search string field will be searched within these fields.
         /// </summary>
         /// <param name="value">Value of the SearchOn input for this Choreo.</param>
         public void setSearchOn(String value) {
             base.addInput ("SearchOn", value);
         }
         /// <summary>
         /// (optional, string) Comma separated list of fields to sort on.
         /// </summary>
         /// <param name="value">Value of the SortOn input for this Choreo.</param>
         public void setSortOn(String value) {
             base.addInput ("SortOn", value);
         }
         /// <summary>
         /// (optional, string) Comma separated list of ordering. Possible values are 'ASC' and 'DESC'. Default is 'ASC'. This list corresponds to the field list used in the SortOn input.
         /// </summary>
         /// <param name="value">Value of the SortOrder input for this Choreo.</param>
         public void setSortOrder(String value) {
             base.addInput ("SortOrder", value);
         }
         /// <summary>
         /// (optional, boolean) When true, the search will only return results that begin with the specified search string. Otherwise, any match of the search string will be returned as a result.
         /// </summary>
         /// <param name="value">Value of the StartsWith input for this Choreo.</param>
         public void setStartsWith(String value) {
             base.addInput ("StartsWith", value);
         }
         /// <summary>
         /// (optional, string) Returns only these tariff types. Valid values are: DEFAULT, ALTERNATIVE, OPTIONAL_EXTRA, RIDER.
         /// </summary>
         /// <param name="value">Value of the TariffTypes input for this Choreo.</param>
         public void setTariffTypes(String value) {
             base.addInput ("TariffTypes", value);
         }
         /// <summary>
         /// (optional, date) Returns only tariffs that are effective on or before this date.
         /// </summary>
         /// <param name="value">Value of the ToDateTime input for this Choreo.</param>
         public void setToDateTime(String value) {
             base.addInput ("ToDateTime", value);
         }
         /// <summary>
         /// (optional, string) Return tariffs for a given zip or post code.
         /// </summary>
         /// <param name="value">Value of the ZipCode input for this Choreo.</param>
         public void setZipCode(String value) {
             base.addInput ("ZipCode", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetTariffsResultSet containing execution metadata and results.</returns>
        new public GetTariffsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetTariffsResultSet results = new JavaScriptSerializer().Deserialize<GetTariffsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetTariffs Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetTariffsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Genability.</returns>
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
