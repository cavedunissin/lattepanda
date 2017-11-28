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
    /// GetLogEntry
    /// Returns details for a specific incident log entry.
    /// </summary>
    public class GetLogEntry : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetLogEntry Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetLogEntry(TembooSession session) : base(session, "/Library/PagerDuty/LogEntries/GetLogEntry")
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
         /// (required, string) The ID of the log entry to return.
         /// </summary>
         /// <param name="value">Value of the LogEntryID input for this Choreo.</param>
         public void setLogEntryID(String value) {
             base.addInput ("LogEntryID", value);
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
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetLogEntryResultSet containing execution metadata and results.</returns>
        new public GetLogEntryResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetLogEntryResultSet results = new JavaScriptSerializer().Deserialize<GetLogEntryResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetLogEntry Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetLogEntryResultSet : Temboo.Core.ResultSet
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
