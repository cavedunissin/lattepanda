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
    /// Set
    /// Sets the properties of a profile.
    /// </summary>
    public class Set : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Set Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Set(TembooSession session) : base(session, "/Library/Mixpanel/Profiles/Set")
        {
        }

         /// <summary>
         /// (optional, string) The city associated with the user's location.
         /// </summary>
         /// <param name="value">Value of the City input for this Choreo.</param>
         public void setCity(String value) {
             base.addInput ("City", value);
         }
         /// <summary>
         /// (optional, date) The time when the user created their account. This should be expressed as YYYY-MM-DDThh:mm:ss.
         /// </summary>
         /// <param name="value">Value of the Created input for this Choreo.</param>
         public void setCreated(String value) {
             base.addInput ("Created", value);
         }
         /// <summary>
         /// (required, string) Used to uniquely identify the profile you want to update.
         /// </summary>
         /// <param name="value">Value of the DistinctID input for this Choreo.</param>
         public void setDistinctID(String value) {
             base.addInput ("DistinctID", value);
         }
         /// <summary>
         /// (optional, string) The user's email address. Mixpanel can use this property when sending email notifications to your users.
         /// </summary>
         /// <param name="value">Value of the Email input for this Choreo.</param>
         public void setEmail(String value) {
             base.addInput ("Email", value);
         }
         /// <summary>
         /// (optional, string) The first name of the user represented the profile.
         /// </summary>
         /// <param name="value">Value of the FirstName input for this Choreo.</param>
         public void setFirstName(String value) {
             base.addInput ("FirstName", value);
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
         /// (optional, string) The last name of the user representing the profile.
         /// </summary>
         /// <param name="value">Value of the LastName input for this Choreo.</param>
         public void setLastName(String value) {
             base.addInput ("LastName", value);
         }
         /// <summary>
         /// (optional, string) The full name of the user. This can be used as an alternative to FirstName and LastName.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (optional, string) The user's phone number (e.g., 4805551212). Mixpanel can use this property when sending SMS messages to your users.
         /// </summary>
         /// <param name="value">Value of the Phone input for this Choreo.</param>
         public void setPhone(String value) {
             base.addInput ("Phone", value);
         }
         /// <summary>
         /// (optional, json) A JSON object containing names and values of custom profile properties. Note that properties that exist already will be overwritten.
         /// </summary>
         /// <param name="value">Value of the ProfileProperties input for this Choreo.</param>
         public void setProfileProperties(String value) {
             base.addInput ("ProfileProperties", value);
         }
         /// <summary>
         /// (optional, string) The region associated with a user's location.
         /// </summary>
         /// <param name="value">Value of the Region input for this Choreo.</param>
         public void setRegion(String value) {
             base.addInput ("Region", value);
         }
         /// <summary>
         /// (optional, date) A unix timestamp representing the time of the profile update. If not provided, Mixpanel will use the time the update arrives at the server.
         /// </summary>
         /// <param name="value">Value of the Time input for this Choreo.</param>
         public void setTime(String value) {
             base.addInput ("Time", value);
         }
         /// <summary>
         /// (optional, string) The timezone associated with a user's location.
         /// </summary>
         /// <param name="value">Value of the Timezone input for this Choreo.</param>
         public void setTimezone(String value) {
             base.addInput ("Timezone", value);
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
        /// <returns>A SetResultSet containing execution metadata and results.</returns>
        new public SetResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SetResultSet results = new JavaScriptSerializer().Deserialize<SetResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Set Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SetResultSet : Temboo.Core.ResultSet
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
