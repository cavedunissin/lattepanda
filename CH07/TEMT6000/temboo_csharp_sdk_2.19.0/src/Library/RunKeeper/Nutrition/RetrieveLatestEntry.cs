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

namespace Temboo.Library.RunKeeper.Nutrition
{
    /// <summary>
    /// RetrieveLatestEntry
    /// Returns the lastest entry from a user's nutrition history.
    /// </summary>
    public class RetrieveLatestEntry : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RetrieveLatestEntry Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RetrieveLatestEntry(TembooSession session) : base(session, "/Library/RunKeeper/Nutrition/RetrieveLatestEntry")
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
        /// <returns>A RetrieveLatestEntryResultSet containing execution metadata and results.</returns>
        new public RetrieveLatestEntryResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RetrieveLatestEntryResultSet results = new JavaScriptSerializer().Deserialize<RetrieveLatestEntryResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RetrieveLatestEntry Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RetrieveLatestEntryResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Calories" output from this Choreo execution
        /// <returns>String - (integer) The number of calories associated with the latest nutrition entry.</returns>
        /// </summary>
        public String Calories
        {
            get
            {
                return (String) base.Output["Calories"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Meal" output from this Choreo execution
        /// <returns>String - (string) The meal name of the latest nutrition entry.</returns>
        /// </summary>
        public String Meal
        {
            get
            {
                return (String) base.Output["Meal"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Timestamp" output from this Choreo execution
        /// <returns>String - (date) The timestamp of the entry.</returns>
        /// </summary>
        public String Timestamp
        {
            get
            {
                return (String) base.Output["Timestamp"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "URI" output from this Choreo execution
        /// <returns>String - (string) TThe URI of the nutrition entry.</returns>
        /// </summary>
        public String URI
        {
            get
            {
                return (String) base.Output["URI"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Water" output from this Choreo execution
        /// <returns>String - (decimal) The water measurement from the latest nutrition entry.</returns>
        /// </summary>
        public String Water
        {
            get
            {
                return (String) base.Output["Water"];
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
