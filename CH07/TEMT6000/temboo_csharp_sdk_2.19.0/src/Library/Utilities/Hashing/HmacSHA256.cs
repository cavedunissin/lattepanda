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

namespace Temboo.Library.Utilities.Hashing
{
    /// <summary>
    /// HmacSHA256
    /// Generates a SHA256-encrypted HMAC signature for the specified message text using the specified secret key.
    /// </summary>
    public class HmacSHA256 : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the HmacSHA256 Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public HmacSHA256(TembooSession session) : base(session, "/Library/Utilities/Hashing/HmacSHA256")
        {
        }

         /// <summary>
         /// (required, string) The secret key used to generate the SHA256-encrypted HMAC signature.
         /// </summary>
         /// <param name="value">Value of the Key input for this Choreo.</param>
         public void setKey(String value) {
             base.addInput ("Key", value);
         }
         /// <summary>
         /// (required, string) The text that should be SHA256-encrypted.
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A HmacSHA256ResultSet containing execution metadata and results.</returns>
        new public HmacSHA256ResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            HmacSHA256ResultSet results = new JavaScriptSerializer().Deserialize<HmacSHA256ResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the HmacSHA256 Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class HmacSHA256ResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "HmacSignature" output from this Choreo execution
        /// <returns>String - (string) The HMAC Signature for the specified string.</returns>
        /// </summary>
        public String HmacSignature
        {
            get
            {
                return (String) base.Output["HmacSignature"];
            }
        }
    }
}
