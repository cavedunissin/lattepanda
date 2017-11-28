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

namespace Temboo.Library.Xively.Triggers
{
    /// <summary>
    /// CreateTrigger
    /// Creates a new trigger.
    /// </summary>
    public class CreateTrigger : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateTrigger Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateTrigger(TembooSession session) : base(session, "/Library/Xively/Triggers/CreateTrigger")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Xively.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The ID of the datastream you would like to create a trigger for.
         /// </summary>
         /// <param name="value">Value of the DatastreamID input for this Choreo.</param>
         public void setDatastreamID(String value) {
             base.addInput ("DatastreamID", value);
         }
         /// <summary>
         /// (required, integer) The ID of the feed you would like to create a trigger for.
         /// </summary>
         /// <param name="value">Value of the FeedID input for this Choreo.</param>
         public void setFeedID(String value) {
             base.addInput ("FeedID", value);
         }
         /// <summary>
         /// (required, string) Threshold that will cause the trigger to activate. Not required if TriggerType = "change", "frozen" or "live". Required for all others.
         /// </summary>
         /// <param name="value">Value of the ThresholdValue input for this Choreo.</param>
         public void setThresholdValue(String value) {
             base.addInput ("ThresholdValue", value);
         }
         /// <summary>
         /// (required, string) Type of trigger. Possible values: "gt", "gte", "lt", "lte", "eq", "change" (any change), "frozen" (no updates for 15 minutes), or "live" (updated again after being frozen).
         /// </summary>
         /// <param name="value">Value of the TriggerType input for this Choreo.</param>
         public void setTriggerType(String value) {
             base.addInput ("TriggerType", value);
         }
         /// <summary>
         /// (required, string) The URL that the Xively trigger will post to when activated. Ex: http://requestb.in
         /// </summary>
         /// <param name="value">Value of the URL input for this Choreo.</param>
         public void setURL(String value) {
             base.addInput ("URL", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateTriggerResultSet containing execution metadata and results.</returns>
        new public CreateTriggerResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateTriggerResultSet results = new JavaScriptSerializer().Deserialize<CreateTriggerResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateTrigger Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateTriggerResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ResponseStatusCode" output from this Choreo execution
        /// <returns>String - (integer) The response status code returned from Xively. For a successful trigger creation, the code should be 201.</returns>
        /// </summary>
        public String ResponseStatusCode
        {
            get
            {
                return (String) base.Output["ResponseStatusCode"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "TriggerID" output from this Choreo execution
        /// <returns>String - (integer) TriggerID extracted from the TriggerLocation.</returns>
        /// </summary>
        public String TriggerID
        {
            get
            {
                return (String) base.Output["TriggerID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "TriggerLocation" output from this Choreo execution
        /// <returns>String - (string) The URL of the newly created trigger.</returns>
        /// </summary>
        public String TriggerLocation
        {
            get
            {
                return (String) base.Output["TriggerLocation"];
            }
        }
    }
}
