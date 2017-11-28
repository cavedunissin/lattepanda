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

namespace Temboo.Library.PagerDuty.Reports
{
    /// <summary>
    /// AlertsPerTime
    /// Returns high-level statistics about the number of alerts sent for a specified time period.
    /// </summary>
    public class AlertsPerTime : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AlertsPerTime Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AlertsPerTime(TembooSession session) : base(session, "/Library/PagerDuty/Reports/AlertsPerTime")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by PagerDuty.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) Used to rollup totals by time period. Valid values are: daily, weekly, or monthly.
         /// </summary>
         /// <param name="value">Value of the Rollup input for this Choreo.</param>
         public void setRollup(String value) {
             base.addInput ("Rollup", value);
         }
         /// <summary>
         /// (required, date) The start of the date range to search (e.g., 2013-03-06T15:28-05). Note that including the time is optional.
         /// </summary>
         /// <param name="value">Value of the Since input for this Choreo.</param>
         public void setSince(String value) {
             base.addInput ("Since", value);
         }
         /// <summary>
         /// (required, string) The subdomain of your PagerDuty site address.
         /// </summary>
         /// <param name="value">Value of the SubDomain input for this Choreo.</param>
         public void setSubDomain(String value) {
             base.addInput ("SubDomain", value);
         }
         /// <summary>
         /// (required, date) The end of the date range to search (e.g., 2013-03-06T15:28-05). Note that including the time is optional.
         /// </summary>
         /// <param name="value">Value of the Until input for this Choreo.</param>
         public void setUntil(String value) {
             base.addInput ("Until", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AlertsPerTimeResultSet containing execution metadata and results.</returns>
        new public AlertsPerTimeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AlertsPerTimeResultSet results = new JavaScriptSerializer().Deserialize<AlertsPerTimeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AlertsPerTime Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AlertsPerTimeResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from PagerDuty.</returns>
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
