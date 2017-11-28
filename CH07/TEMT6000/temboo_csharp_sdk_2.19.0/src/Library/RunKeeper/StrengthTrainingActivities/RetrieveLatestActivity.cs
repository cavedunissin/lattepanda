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

namespace Temboo.Library.RunKeeper.StrengthTrainingActivities
{
    /// <summary>
    /// RetrieveLatestActivity
    /// Returns the latest activity from a user's strength training activity history.
    /// </summary>
    public class RetrieveLatestActivity : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RetrieveLatestActivity Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RetrieveLatestActivity(TembooSession session) : base(session, "/Library/RunKeeper/StrengthTrainingActivities/RetrieveLatestActivity")
        {
        }

         /// <summary>
         /// (required, string) The Access Token retrieved after the final step in the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RetrieveLatestActivityResultSet containing execution metadata and results.</returns>
        new public RetrieveLatestActivityResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RetrieveLatestActivityResultSet results = new JavaScriptSerializer().Deserialize<RetrieveLatestActivityResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RetrieveLatestActivity Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RetrieveLatestActivityResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "BeginTime" output from this Choreo execution
        /// <returns>String - (date) The start time of the activity.</returns>
        /// </summary>
        public String BeginTime
        {
            get
            {
                return (String) base.Output["BeginTime"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Notes" output from this Choreo execution
        /// <returns>String - (string) Notes for the latest activity entry.</returns>
        /// </summary>
        public String Notes
        {
            get
            {
                return (String) base.Output["Notes"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "PrimaryMuscleGroup" output from this Choreo execution
        /// <returns>String - (string) The primary muscle group used in the activity.</returns>
        /// </summary>
        public String PrimaryMuscleGroup
        {
            get
            {
                return (String) base.Output["PrimaryMuscleGroup"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "PrimaryType" output from this Choreo execution
        /// <returns>String - (string) The primary exercise type for the activity.</returns>
        /// </summary>
        public String PrimaryType
        {
            get
            {
                return (String) base.Output["PrimaryType"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "URI" output from this Choreo execution
        /// <returns>String - (string) The activity URI.</returns>
        /// </summary>
        public String URI
        {
            get
            {
                return (String) base.Output["URI"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from RunKeeper.</returns>
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
