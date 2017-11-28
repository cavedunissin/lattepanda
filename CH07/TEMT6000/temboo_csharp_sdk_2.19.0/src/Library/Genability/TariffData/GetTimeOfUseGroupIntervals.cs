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
    /// GetTimeOfUseGroupIntervals
    /// Returns all the Intervals for a Time of Use Group within a given date range.
    /// </summary>
    public class GetTimeOfUseGroupIntervals : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetTimeOfUseGroupIntervals Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetTimeOfUseGroupIntervals(TembooSession session) : base(session, "/Library/Genability/TariffData/GetTimeOfUseGroupIntervals")
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
         /// (optional, date) The starting date and time of the requested Intervals (in ISO 8601 format). Defaults to current date if not specified.
         /// </summary>
         /// <param name="value">Value of the FromDateTime input for this Choreo.</param>
         public void setFromDateTime(String value) {
             base.addInput ("FromDateTime", value);
         }
         /// <summary>
         /// (required, integer) Used to retrieve a TOU Group for a specific LSE.
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
         /// (required, integer) Used to retrieve a TOU Group by its ID.
         /// </summary>
         /// <param name="value">Value of the TOUGroupID input for this Choreo.</param>
         public void setTOUGroupID(String value) {
             base.addInput ("TOUGroupID", value);
         }
         /// <summary>
         /// (optional, date) The ending date and time of the requested Intervals (in ISO 8601 format). If not specified, defaults to one week ahead of the current date.
         /// </summary>
         /// <param name="value">Value of the ToDateTime input for this Choreo.</param>
         public void setToDateTime(String value) {
             base.addInput ("ToDateTime", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetTimeOfUseGroupIntervalsResultSet containing execution metadata and results.</returns>
        new public GetTimeOfUseGroupIntervalsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetTimeOfUseGroupIntervalsResultSet results = new JavaScriptSerializer().Deserialize<GetTimeOfUseGroupIntervalsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetTimeOfUseGroupIntervals Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetTimeOfUseGroupIntervalsResultSet : Temboo.Core.ResultSet
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
