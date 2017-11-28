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

namespace Temboo.Library.Utilities.Encoding
{
    /// <summary>
    /// Base64Encode
    /// Returns the specified text or file as a Base64 encoded string.
    /// </summary>
    public class Base64Encode : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Base64Encode Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Base64Encode(TembooSession session) : base(session, "/Library/Utilities/Encoding/Base64Encode")
        {
        }

         /// <summary>
         /// (conditional, string) The text that should be Base64 encoded. Required unless providing a value for the URL input.
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }
         /// <summary>
         /// (conditional, string) A URL to a hosted file that should be Base64 encoded. Required unless providing a value for the Text input.
         /// </summary>
         /// <param name="value">Value of the URL input for this Choreo.</param>
         public void setURL(String value) {
             base.addInput ("URL", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A Base64EncodeResultSet containing execution metadata and results.</returns>
        new public Base64EncodeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            Base64EncodeResultSet results = new JavaScriptSerializer().Deserialize<Base64EncodeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Base64Encode Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class Base64EncodeResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Base64EncodedText" output from this Choreo execution
        /// <returns>String - (string) The Base64 encoded text.</returns>
        /// </summary>
        public String Base64EncodedText
        {
            get
            {
                return (String) base.Output["Base64EncodedText"];
            }
        }
    }
}
