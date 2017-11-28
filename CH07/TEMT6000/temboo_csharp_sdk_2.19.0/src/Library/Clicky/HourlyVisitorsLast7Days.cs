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

namespace Temboo.Library.Clicky
{
    /// <summary>
    /// HourlyVisitorsLast7Days
    /// Retrieves hourly visitor and action tallies for the last 7 days.
    /// </summary>
    public class HourlyVisitorsLast7Days : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the HourlyVisitorsLast7Days Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public HourlyVisitorsLast7Days(TembooSession session) : base(session, "/Library/Clicky/HourlyVisitorsLast7Days")
        {
        }

         /// <summary>
         /// (optional, string) What format you want the returned data to be in. Accepted values: xml, php, json, csv. Defaults to 'xml'.
         /// </summary>
         /// <param name="value">Value of the Output input for this Choreo.</param>
         public void setOutput(String value) {
             base.addInput ("Output", value);
         }
         /// <summary>
         /// (required, integer) Your request must include the site's ID that you want to access data from. Available from your site preferences page.
         /// </summary>
         /// <param name="value">Value of the SiteID input for this Choreo.</param>
         public void setSiteID(String value) {
             base.addInput ("SiteID", value);
         }
         /// <summary>
         /// (required, string) The unique key assigned to you when you first register with Clicky. Available from your site preferences page.
         /// </summary>
         /// <param name="value">Value of the SiteKey input for this Choreo.</param>
         public void setSiteKey(String value) {
             base.addInput ("SiteKey", value);
         }
         /// <summary>
         /// (optional, string) The type of data you want to retrieve. Defaults to "visitors,actions".
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A HourlyVisitorsLast7DaysResultSet containing execution metadata and results.</returns>
        new public HourlyVisitorsLast7DaysResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            HourlyVisitorsLast7DaysResultSet results = new JavaScriptSerializer().Deserialize<HourlyVisitorsLast7DaysResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the HourlyVisitorsLast7Days Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class HourlyVisitorsLast7DaysResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Clicky formatted as specified in the Output parameter. Default is XML.</returns>
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
