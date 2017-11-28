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

namespace Temboo.Library.Mixpanel.Events
{
    /// <summary>
    /// Track
    /// Records an event in Mixpanel.
    /// </summary>
    public class Track : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Track Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Track(TembooSession session) : base(session, "/Library/Mixpanel/Events/Track")
        {
        }

         /// <summary>
         /// (optional, string) Used to uniquely identify a user associated with your event. When provided, you can track a given user through funnels and distinguish unique users for retention analyses.
         /// </summary>
         /// <param name="value">Value of the DistinctID input for this Choreo.</param>
         public void setDistinctID(String value) {
             base.addInput ("DistinctID", value);
         }
         /// <summary>
         /// (required, string) A name for the event (e.g., Signed Up, Uploaded Photo, etc).
         /// </summary>
         /// <param name="value">Value of the EventName input for this Choreo.</param>
         public void setEventName(String value) {
             base.addInput ("EventName", value);
         }
         /// <summary>
         /// (optional, json) Additional properties associated with the event formatted as name/value pairs in a JSON object. These properties can be used for segmentation and funnels.
         /// </summary>
         /// <param name="value">Value of the EventProperties input for this Choreo.</param>
         public void setEventProperties(String value) {
             base.addInput ("EventProperties", value);
         }
         /// <summary>
         /// (optional, string) An IP address string associated with the event (e.g., 127.0.0.1). When set to 0 (the default) Mixpanel will ignore IP information.
         /// </summary>
         /// <param name="value">Value of the IP input for this Choreo.</param>
         public void setIP(String value) {
             base.addInput ("IP", value);
         }
         /// <summary>
         /// (optional, date) A unix timestamp representing the time the event occurred. If not provided, Mixpanel will use the time the event arrives at the server.
         /// </summary>
         /// <param name="value">Value of the Time input for this Choreo.</param>
         public void setTime(String value) {
             base.addInput ("Time", value);
         }
         /// <summary>
         /// (required, string) The token provided by Mixpanel. You can find your Mixpanel token in the project settings dialog in the Mixpanel app.
         /// </summary>
         /// <param name="value">Value of the Token input for this Choreo.</param>
         public void setToken(String value) {
             base.addInput ("Token", value);
         }
         /// <summary>
         /// (optional, boolean) When set to 1, the response will contain more information describing the success or failure of the tracking call.
         /// </summary>
         /// <param name="value">Value of the Verbose input for this Choreo.</param>
         public void setVerbose(String value) {
             base.addInput ("Verbose", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A TrackResultSet containing execution metadata and results.</returns>
        new public TrackResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            TrackResultSet results = new JavaScriptSerializer().Deserialize<TrackResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Track Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class TrackResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Mixpanel.</returns>
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
