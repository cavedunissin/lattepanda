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

namespace Temboo.Library.PagerDuty.Incidents
{
    /// <summary>
    /// CountIncidents
    /// Returns a count of incidents that match a specified criteria.
    /// </summary>
    public class CountIncidents : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CountIncidents Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CountIncidents(TembooSession session) : base(session, "/Library/PagerDuty/Incidents/CountIncidents")
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
         /// (optional, string) Returns the count of incidents assigned to the specified user.
         /// </summary>
         /// <param name="value">Value of the AssignedToUser input for this Choreo.</param>
         public void setAssignedToUser(String value) {
             base.addInput ("AssignedToUser", value);
         }
         /// <summary>
         /// (optional, string) When set to "all", this allows you to retrieve the count of all incidents since the account was created.
         /// </summary>
         /// <param name="value">Value of the DateRange input for this Choreo.</param>
         public void setDateRange(String value) {
             base.addInput ("DateRange", value);
         }
         /// <summary>
         /// (optional, string) Returns the count of incidents with the specified key.
         /// </summary>
         /// <param name="value">Value of the IncidentKey input for this Choreo.</param>
         public void setIncidentKey(String value) {
             base.addInput ("IncidentKey", value);
         }
         /// <summary>
         /// (optional, string) Returns the count of incidents associated with the specified service.
         /// </summary>
         /// <param name="value">Value of the Service input for this Choreo.</param>
         public void setService(String value) {
             base.addInput ("Service", value);
         }
         /// <summary>
         /// (optional, date) The start of the date range to search (e.g., 2013-03-06T15:28-05). Note that including the time is optional.
         /// </summary>
         /// <param name="value">Value of the Since input for this Choreo.</param>
         public void setSince(String value) {
             base.addInput ("Since", value);
         }
         /// <summary>
         /// (optional, string) Returns the count of incidents with this specified status. Valid values are: triggered, acknowledged, and resolved.
         /// </summary>
         /// <param name="value">Value of the Status input for this Choreo.</param>
         public void setStatus(String value) {
             base.addInput ("Status", value);
         }
         /// <summary>
         /// (required, string) The subdomain of your PagerDuty site address.
         /// </summary>
         /// <param name="value">Value of the SubDomain input for this Choreo.</param>
         public void setSubDomain(String value) {
             base.addInput ("SubDomain", value);
         }
         /// <summary>
         /// (optional, date) The end of the date range to search (e.g., 2013-03-06T15:28-05). Note that including the time is optional.
         /// </summary>
         /// <param name="value">Value of the Until input for this Choreo.</param>
         public void setUntil(String value) {
             base.addInput ("Until", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CountIncidentsResultSet containing execution metadata and results.</returns>
        new public CountIncidentsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CountIncidentsResultSet results = new JavaScriptSerializer().Deserialize<CountIncidentsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CountIncidents Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CountIncidentsResultSet : Temboo.Core.ResultSet
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
