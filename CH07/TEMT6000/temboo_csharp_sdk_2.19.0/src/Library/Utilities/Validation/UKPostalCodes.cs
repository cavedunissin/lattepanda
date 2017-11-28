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

namespace Temboo.Library.Utilities.Validation
{
    /// <summary>
    /// UKPostalCodes
    /// Verifies that a given zip code matches the format expected for UK addresses.
    /// </summary>
    public class UKPostalCodes : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UKPostalCodes Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UKPostalCodes(TembooSession session) : base(session, "/Library/Utilities/Validation/UKPostalCodes")
        {
        }

         /// <summary>
         /// (required, string) The zip code to validate. Letters must be in uppercase to be valid.
         /// </summary>
         /// <param name="value">Value of the ZipCode input for this Choreo.</param>
         public void setZipCode(String value) {
             base.addInput ("ZipCode", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UKPostalCodesResultSet containing execution metadata and results.</returns>
        new public UKPostalCodesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UKPostalCodesResultSet results = new JavaScriptSerializer().Deserialize<UKPostalCodesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UKPostalCodes Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UKPostalCodesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Match" output from this Choreo execution
        /// <returns>String - (string) Contains a string indicating the result of the match -- "valid" or "invalid".</returns>
        /// </summary>
        public String Match
        {
            get
            {
                return (String) base.Output["Match"];
            }
        }
    }
}
