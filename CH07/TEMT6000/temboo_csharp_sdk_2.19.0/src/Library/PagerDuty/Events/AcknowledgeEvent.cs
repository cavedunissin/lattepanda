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

namespace Temboo.Library.PagerDuty.Events
{
    /// <summary>
    /// AcknowledgeEvent
    /// Updates the state of an incident to "acknowleged", and allows you to log data to an incident log.
    /// </summary>
    public class AcknowledgeEvent : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AcknowledgeEvent Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AcknowledgeEvent(TembooSession session) : base(session, "/Library/PagerDuty/Events/AcknowledgeEvent")
        {
        }

         /// <summary>
         /// (optional, string) A short description that will appear in the incident's log associated with this event.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (optional, json) A JSON object containing any data you'd like included in the incident log.
         /// </summary>
         /// <param name="value">Value of the Details input for this Choreo.</param>
         public void setDetails(String value) {
             base.addInput ("Details", value);
         }
         /// <summary>
         /// (required, string) Identifies the incident to acknowledge.
         /// </summary>
         /// <param name="value">Value of the IncidentKey input for this Choreo.</param>
         public void setIncidentKey(String value) {
             base.addInput ("IncidentKey", value);
         }
         /// <summary>
         /// (required, string) The service key of one of your "Generic API" services. This is listed on a Generic API's service detail page.
         /// </summary>
         /// <param name="value">Value of the ServiceKey input for this Choreo.</param>
         public void setServiceKey(String value) {
             base.addInput ("ServiceKey", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AcknowledgeEventResultSet containing execution metadata and results.</returns>
        new public AcknowledgeEventResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AcknowledgeEventResultSet results = new JavaScriptSerializer().Deserialize<AcknowledgeEventResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AcknowledgeEvent Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AcknowledgeEventResultSet : Temboo.Core.ResultSet
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
