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
    /// Checksum
    /// Returns a checksum of the specified text calculated using the specified algorithm. 
    /// </summary>
    public class Checksum : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Checksum Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Checksum(TembooSession session) : base(session, "/Library/Utilities/Hashing/Checksum")
        {
        }

         /// <summary>
         /// (required, string) Algorithm used to calculate the checksum. Valid values are: FIX44,  MD5+BASE64, or MD5+HEX (the default). MD5+BASE64 and MD5+HEX return the result in Base64 and hexadecimal encoding, respectively.
         /// </summary>
         /// <param name="value">Value of the Algorithm input for this Choreo.</param>
         public void setAlgorithm(String value) {
             base.addInput ("Algorithm", value);
         }
         /// <summary>
         /// (optional, boolean) Setting this parameter to 1 indicates that the Text is Base64 encoded, and that the choreo should decode the value before calculating the checksum. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Base64DecodeValue input for this Choreo.</param>
         public void setBase64DecodeValue(String value) {
             base.addInput ("Base64DecodeValue", value);
         }
         /// <summary>
         /// (required, string) The text to return a checksum for.
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ChecksumResultSet containing execution metadata and results.</returns>
        new public ChecksumResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ChecksumResultSet results = new JavaScriptSerializer().Deserialize<ChecksumResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Checksum Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ChecksumResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Checksum" output from this Choreo execution
        /// <returns>String - (string) The checksum result.</returns>
        /// </summary>
        public String Checksum
        {
            get
            {
                return (String) base.Output["Checksum"];
            }
        }
    }
}
