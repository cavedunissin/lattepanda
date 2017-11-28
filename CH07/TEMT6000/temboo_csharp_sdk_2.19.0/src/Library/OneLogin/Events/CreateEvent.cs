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

namespace Temboo.Library.OneLogin.Events
{
    /// <summary>
    /// CreateEvent
    /// Creates a new event.
    /// </summary>
    public class CreateEvent : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateEvent Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateEvent(TembooSession session) : base(session, "/Library/OneLogin/Events/CreateEvent")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by OneLogin.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, integer) The id for the type of event you want to create. Note that depending on the event type id specified, you may need to provide the ObjectName and ObjectID that is being affected.
         /// </summary>
         /// <param name="value">Value of the EventTypeID input for this Choreo.</param>
         public void setEventTypeID(String value) {
             base.addInput ("EventTypeID", value);
         }
         /// <summary>
         /// (conditional, integer) The object id that is being affected. Required for certain event types. When specified, ObjectName must also be provided.
         /// </summary>
         /// <param name="value">Value of the ObjectID input for this Choreo.</param>
         public void setObjectID(String value) {
             base.addInput ("ObjectID", value);
         }
         /// <summary>
         /// (conditional, string) The object name that is being affected (i.e. user-id). Required for certain event types. When specified, ObjectID must also be provided.
         /// </summary>
         /// <param name="value">Value of the ObjectName input for this Choreo.</param>
         public void setObjectName(String value) {
             base.addInput ("ObjectName", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateEventResultSet containing execution metadata and results.</returns>
        new public CreateEventResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateEventResultSet results = new JavaScriptSerializer().Deserialize<CreateEventResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateEvent Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateEventResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from OneLogin.</returns>
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
