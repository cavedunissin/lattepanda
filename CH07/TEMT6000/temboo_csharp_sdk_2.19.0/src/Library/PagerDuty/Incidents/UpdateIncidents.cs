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
    /// UpdateIncidents
    /// Allows you to acknowledge, resolve, escalate or reassign one or more incidents.
    /// </summary>
    public class UpdateIncidents : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateIncidents Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateIncidents(TembooSession session) : base(session, "/Library/PagerDuty/Incidents/UpdateIncidents")
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
         /// (required, json) An array of incident objects that each include an incident ID. Other optional incident properties that can be present include: status, escalation_level, assigned_to_user, and escalation_policy.
         /// </summary>
         /// <param name="value">Value of the Incidents input for this Choreo.</param>
         public void setIncidents(String value) {
             base.addInput ("Incidents", value);
         }
         /// <summary>
         /// (required, string) The ID of the user making the request. This will be added to the incident log entry.
         /// </summary>
         /// <param name="value">Value of the RequesterID input for this Choreo.</param>
         public void setRequesterID(String value) {
             base.addInput ("RequesterID", value);
         }
         /// <summary>
         /// (required, string) The subdomain of your PagerDuty site address.
         /// </summary>
         /// <param name="value">Value of the SubDomain input for this Choreo.</param>
         public void setSubDomain(String value) {
             base.addInput ("SubDomain", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateIncidentsResultSet containing execution metadata and results.</returns>
        new public UpdateIncidentsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateIncidentsResultSet results = new JavaScriptSerializer().Deserialize<UpdateIncidentsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateIncidents Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateIncidentsResultSet : Temboo.Core.ResultSet
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
