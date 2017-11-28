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
    /// TriggerEvent
    /// Triggers an event that will open a new incident or log an entry to an existing incident.
    /// </summary>
    public class TriggerEvent : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the TriggerEvent Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public TriggerEvent(TembooSession session) : base(session, "/Library/PagerDuty/Events/TriggerEvent")
        {
        }

         /// <summary>
         /// (required, string) A short description of the problem that led to this trigger. The maximum length is 1024 characters.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (required, json) A JSON object containing the data you'd like included in the incident log.
         /// </summary>
         /// <param name="value">Value of the Details input for this Choreo.</param>
         public void setDetails(String value) {
             base.addInput ("Details", value);
         }
         /// <summary>
         /// (optional, string) Identifies the incident to which this trigger event should be applied. If there's no open incident with this key, a new one will be created.
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
        /// <returns>A TriggerEventResultSet containing execution metadata and results.</returns>
        new public TriggerEventResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            TriggerEventResultSet results = new JavaScriptSerializer().Deserialize<TriggerEventResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the TriggerEvent Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class TriggerEventResultSet : Temboo.Core.ResultSet
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
