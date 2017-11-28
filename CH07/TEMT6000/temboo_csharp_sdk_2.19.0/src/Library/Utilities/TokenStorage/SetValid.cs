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

namespace Temboo.Library.Utilities.TokenStorage
{
    /// <summary>
    /// SetValid
    /// Sets a specified token as valid or invalid.
    /// </summary>
    public class SetValid : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SetValid Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SetValid(TembooSession session) : base(session, "/Library/Utilities/TokenStorage/SetValid")
        {
        }

         /// <summary>
         /// (required, string) The name of the token to modify.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (conditional, boolean) Can be set to true or false depending on whether the token is valid or not.
         /// </summary>
         /// <param name="value">Value of the Valid input for this Choreo.</param>
         public void setValid(String value) {
             base.addInput ("Valid", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SetValidResultSet containing execution metadata and results.</returns>
        new public SetValidResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SetValidResultSet results = new JavaScriptSerializer().Deserialize<SetValidResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SetValid Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SetValidResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Updated" output from this Choreo execution
        /// <returns>String - (boolean) Returns true if the operation was successful.</returns>
        /// </summary>
        public String Updated
        {
            get
            {
                return (String) base.Output["Updated"];
            }
        }
    }
}
