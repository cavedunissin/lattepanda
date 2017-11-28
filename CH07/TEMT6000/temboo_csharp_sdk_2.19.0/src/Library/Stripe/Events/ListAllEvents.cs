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

namespace Temboo.Library.Stripe.Events
{
    /// <summary>
    /// ListAllEvents
    /// Returns a list of events that have happened in your account.
    /// </summary>
    public class ListAllEvents : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListAllEvents Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListAllEvents(TembooSession session) : base(session, "/Library/Stripe/Events/ListAllEvents")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Stripe
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, integer) A limit on the number of events to be returned. Count can range between 1 and 100 items.
         /// </summary>
         /// <param name="value">Value of the Count input for this Choreo.</param>
         public void setCount(String value) {
             base.addInput ("Count", value);
         }
         /// <summary>
         /// (optional, date) Filters the result based on the event created date (a UTC timestamp).
         /// </summary>
         /// <param name="value">Value of the Created input for this Choreo.</param>
         public void setCreated(String value) {
             base.addInput ("Created", value);
         }
         /// <summary>
         /// (optional, string) A Stripe object that should be expanded to show additional fields in the response.
         /// </summary>
         /// <param name="value">Value of the Expand input for this Choreo.</param>
         public void setExpand(String value) {
             base.addInput ("Expand", value);
         }
         /// <summary>
         /// (optional, date) Returns events that have been created after this UTC timestamp.
         /// </summary>
         /// <param name="value">Value of the GreaterThan input for this Choreo.</param>
         public void setGreaterThan(String value) {
             base.addInput ("GreaterThan", value);
         }
         /// <summary>
         /// (optional, date) Returns events that have been created after or equal to this UTC timestamp.
         /// </summary>
         /// <param name="value">Value of the GreaterThanEqualTo input for this Choreo.</param>
         public void setGreaterThanEqualTo(String value) {
             base.addInput ("GreaterThanEqualTo", value);
         }
         /// <summary>
         /// (optional, date) Return events that were created before this UTC timestamp.
         /// </summary>
         /// <param name="value">Value of the LessThan input for this Choreo.</param>
         public void setLessThan(String value) {
             base.addInput ("LessThan", value);
         }
         /// <summary>
         /// (optional, date) Return events that were created before or equal to this UTC timestamp.
         /// </summary>
         /// <param name="value">Value of the LessThanEqualTo input for this Choreo.</param>
         public void setLessThanEqualTo(String value) {
             base.addInput ("LessThanEqualTo", value);
         }
         /// <summary>
         /// (optional, integer) An offset into your events array. The API will return the requested number of events starting at that offset.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, string) A string containing a specific event name, or group of events using * as a wildcard. This will return a filtered result including only events with a matching event property.
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListAllEventsResultSet containing execution metadata and results.</returns>
        new public ListAllEventsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListAllEventsResultSet results = new JavaScriptSerializer().Deserialize<ListAllEventsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListAllEvents Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListAllEventsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Stripe</returns>
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
