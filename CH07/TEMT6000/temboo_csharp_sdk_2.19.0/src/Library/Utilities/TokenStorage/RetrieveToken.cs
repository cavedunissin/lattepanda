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
    /// RetrieveToken
    /// Retrieves a specified token.
    /// </summary>
    public class RetrieveToken : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RetrieveToken Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RetrieveToken(TembooSession session) : base(session, "/Library/Utilities/TokenStorage/RetrieveToken")
        {
        }

         /// <summary>
         /// (optional, boolean) If set to true, the Choreo will attempt to lock the token after retrieving it. If the token is already locked, the Choreo will attempt to get the lock for up-to 1 minute.
         /// </summary>
         /// <param name="value">Value of the LockToken input for this Choreo.</param>
         public void setLockToken(String value) {
             base.addInput ("LockToken", value);
         }
         /// <summary>
         /// (required, string) The name of the token to retrieve.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RetrieveTokenResultSet containing execution metadata and results.</returns>
        new public RetrieveTokenResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RetrieveTokenResultSet results = new JavaScriptSerializer().Deserialize<RetrieveTokenResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RetrieveToken Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RetrieveTokenResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Token" output from this Choreo execution
        /// <returns>String - (string) The token value. This will return an empty string if there is no token or if the token has expired.</returns>
        /// </summary>
        public String Token
        {
            get
            {
                return (String) base.Output["Token"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Locked" output from this Choreo execution
        /// <returns>String - (boolean) Returns true or false depending on whether the token is locked or not.</returns>
        /// </summary>
        public String Locked
        {
            get
            {
                return (String) base.Output["Locked"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Valid" output from this Choreo execution
        /// <returns>String - (boolean) Returns true or false depending on whether the token is valid or not.</returns>
        /// </summary>
        public String Valid
        {
            get
            {
                return (String) base.Output["Valid"];
            }
        }
    }
}
