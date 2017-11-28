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
    /// GetTimeOfUseGroup
    /// Returns a particular Time of Use Group with a given touGroupId and lseId.
    /// </summary>
    public class GetTimeOfUseGroup : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetTimeOfUseGroup Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetTimeOfUseGroup(TembooSession session) : base(session, "/Library/Genability/TariffData/GetTimeOfUseGroup")
        {
        }

         /// <summary>
         /// (required, string) The App ID provided by Genability.
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
         /// (optional, string) When true, the search will only return results that end with the specified search string. Otherwise, any match of the search string will be returned as a result.
         /// </summary>
         /// <param name="value">Value of the EndsWith input for this Choreo.</param>
         public void setEndsWith(String value) {
             base.addInput ("EndsWith", value);
         }
         /// <summary>
         /// (optional, boolean) When true, the provided search string will be regarded as a regular expression and the search will return results matching the regular expression.
         /// </summary>
         /// <param name="value">Value of the IsRegex input for this Choreo.</param>
         public void setIsRegex(String value) {
             base.addInput ("IsRegex", value);
         }
         /// <summary>
         /// (conditional, integer) Used to retrieve a TOU Group for a specific LSE.
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
         /// (conditional, integer) Used to retrieve a TOU Group by its ID (required when LSE ID is provided).
         /// </summary>
         /// <param name="value">Value of the TOUGroupID input for this Choreo.</param>
         public void setTOUGroupID(String value) {
             base.addInput ("TOUGroupID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetTimeOfUseGroupResultSet containing execution metadata and results.</returns>
        new public GetTimeOfUseGroupResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetTimeOfUseGroupResultSet results = new JavaScriptSerializer().Deserialize<GetTimeOfUseGroupResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetTimeOfUseGroup Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetTimeOfUseGroupResultSet : Temboo.Core.ResultSet
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
