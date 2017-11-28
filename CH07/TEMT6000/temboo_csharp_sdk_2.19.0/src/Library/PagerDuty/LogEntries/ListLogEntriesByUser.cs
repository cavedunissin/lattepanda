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

namespace Temboo.Library.PagerDuty.LogEntries
{
    /// <summary>
    /// ListLogEntriesByUser
    /// Lists all incident log entries associated with a specific user.
    /// </summary>
    public class ListLogEntriesByUser : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListLogEntriesByUser Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListLogEntriesByUser(TembooSession session) : base(session, "/Library/PagerDuty/LogEntries/ListLogEntriesByUser")
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
         /// (optional, string) A list of additional details to include in the response. Valid values are: channel, incident, and service.
         /// </summary>
         /// <param name="value">Value of the Include input for this Choreo.</param>
         public void setInclude(String value) {
             base.addInput ("Include", value);
         }
         /// <summary>
         /// (optional, boolean) If set to true, only log entries of type trigger, acknowledge, or resolve are returned. Defaults to false.
         /// </summary>
         /// <param name="value">Value of the IsOverview input for this Choreo.</param>
         public void setIsOverview(String value) {
             base.addInput ("IsOverview", value);
         }
         /// <summary>
         /// (optional, integer) The number of log events returned. Default (and max limit) is 100.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, integer) The offset of the first log event record returned. Default is 0.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, date) The start of the date range to search (e.g., 2013-03-06T15:28-05). Note that including the time is optional.
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
         /// (optional, string) The time zone in which dates in the result will be rendered. Defaults to account time zone.
         /// </summary>
         /// <param name="value">Value of the TimeZone input for this Choreo.</param>
         public void setTimeZone(String value) {
             base.addInput ("TimeZone", value);
         }
         /// <summary>
         /// (optional, date) The end of the date range to search (e.g., 2013-03-06T15:28-05). Note that including the time is optional.
         /// </summary>
         /// <param name="value">Value of the Until input for this Choreo.</param>
         public void setUntil(String value) {
             base.addInput ("Until", value);
         }
         /// <summary>
         /// (required, string) The ID of the user associated with the log entries to retrieve.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListLogEntriesByUserResultSet containing execution metadata and results.</returns>
        new public ListLogEntriesByUserResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListLogEntriesByUserResultSet results = new JavaScriptSerializer().Deserialize<ListLogEntriesByUserResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListLogEntriesByUser Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListLogEntriesByUserResultSet : Temboo.Core.ResultSet
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
