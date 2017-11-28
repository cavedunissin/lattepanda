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
    /// Base64Decode
    /// Returns the specified Base64 encoded string as decoded text.
    /// </summary>
    public class Base64Decode : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Base64Decode Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Base64Decode(TembooSession session) : base(session, "/Library/Utilities/Encoding/Base64Decode")
        {
        }

         /// <summary>
         /// (required, string) The Base64 encoded text to decode. Note that Base64 encoded binary data is not allowed.
         /// </summary>
         /// <param name="value">Value of the Base64EncodedText input for this Choreo.</param>
         public void setBase64EncodedText(String value) {
             base.addInput ("Base64EncodedText", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A Base64DecodeResultSet containing execution metadata and results.</returns>
        new public Base64DecodeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            Base64DecodeResultSet results = new JavaScriptSerializer().Deserialize<Base64DecodeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Base64Decode Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class Base64DecodeResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Text" output from this Choreo execution
        /// <returns>String - (string) The decoded text.</returns>
        /// </summary>
        public String Text
        {
            get
            {
                return (String) base.Output["Text"];
            }
        }
    }
}
