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
    /// StoreToken
    /// Stores a token.
    /// </summary>
    public class StoreToken : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the StoreToken Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public StoreToken(TembooSession session) : base(session, "/Library/Utilities/TokenStorage/StoreToken")
        {
        }

         /// <summary>
         /// (optional, integer) The lifetime of the token (in seconds). Defaults to 0 indicating no expiration.
         /// </summary>
         /// <param name="value">Value of the Expires input for this Choreo.</param>
         public void setExpires(String value) {
             base.addInput ("Expires", value);
         }
         /// <summary>
         /// (required, string) The token name. When a token does not exist, it will be inserted. When a token does exist, an update is performed.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (required, string) The token value to store. The maximum number of characters for a token is 4096.
         /// </summary>
         /// <param name="value">Value of the Value input for this Choreo.</param>
         public void setValue(String value) {
             base.addInput ("Value", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A StoreTokenResultSet containing execution metadata and results.</returns>
        new public StoreTokenResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            StoreTokenResultSet results = new JavaScriptSerializer().Deserialize<StoreTokenResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the StoreToken Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class StoreTokenResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Updated" output from this Choreo execution
        /// <returns>String - (boolean) Returns true if token is stored successfully.</returns>
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
