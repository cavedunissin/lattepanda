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

namespace Temboo.Library.Mixpanel.Profiles
{
    /// <summary>
    /// Append
    /// Appends a value to a list property on a profile.
    /// </summary>
    public class Append : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Append Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Append(TembooSession session) : base(session, "/Library/Mixpanel/Profiles/Append")
        {
        }

         /// <summary>
         /// (required, string) Used to uniquely identify the profile you want to update.
         /// </summary>
         /// <param name="value">Value of the DistinctID input for this Choreo.</param>
         public void setDistinctID(String value) {
             base.addInput ("DistinctID", value);
         }
         /// <summary>
         /// (optional, string) An IP address string associated with the profile (e.g., 127.0.0.1). When set to 0 (the default) Mixpanel will ignore IP information.
         /// </summary>
         /// <param name="value">Value of the IP input for this Choreo.</param>
         public void setIP(String value) {
             base.addInput ("IP", value);
         }
         /// <summary>
         /// (optional, boolean) When set to true, Mixpanel will not automatically update the "Last Seen" property of the profile. Otherwise, Mixpanel will add a "Last Seen" property associated with any set, append, or add requests.
         /// </summary>
         /// <param name="value">Value of the IgnoreTime input for this Choreo.</param>
         public void setIgnoreTime(String value) {
             base.addInput ("IgnoreTime", value);
         }
         /// <summary>
         /// (conditional, json) A JSON object containing a name/value pair representing a list name and value. The current value will be appended to any existing lists. If the list doesn't exist, it will be created.
         /// </summary>
         /// <param name="value">Value of the ProfileProperties input for this Choreo.</param>
         public void setProfileProperties(String value) {
             base.addInput ("ProfileProperties", value);
         }
         /// <summary>
         /// (optional, date) A unix timestamp representing the time of the profile update. If not provided, Mixpanel will use the time the update arrives at the server.
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
        /// <returns>A AppendResultSet containing execution metadata and results.</returns>
        new public AppendResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AppendResultSet results = new JavaScriptSerializer().Deserialize<AppendResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Append Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AppendResultSet : Temboo.Core.ResultSet
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
