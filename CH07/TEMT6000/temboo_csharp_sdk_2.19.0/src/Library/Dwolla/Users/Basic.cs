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

namespace Temboo.Library.Dwolla.Users
{
    /// <summary>
    /// Basic
    /// Retrieves the Dwolla account information for the user associated with the specified consumer credentials and Dwolla account identifier.
    /// </summary>
    public class Basic : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Basic Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Basic(TembooSession session) : base(session, "/Library/Dwolla/Users/Basic")
        {
        }

         /// <summary>
         /// (required, string) Dwolla account identifier or email address of the Dwolla account.
         /// </summary>
         /// <param name="value">Value of the AccountIdentifier input for this Choreo.</param>
         public void setAccountIdentifier(String value) {
             base.addInput ("AccountIdentifier", value);
         }
         /// <summary>
         /// (required, string) The Client ID provided by Dwolla (AKA the Consumer Key).
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (required, string) The Client Secret provided by Dwolla (AKA the Consumer Secret).
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A BasicResultSet containing execution metadata and results.</returns>
        new public BasicResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            BasicResultSet results = new JavaScriptSerializer().Deserialize<BasicResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Basic Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class BasicResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Dwolla.</returns>
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
