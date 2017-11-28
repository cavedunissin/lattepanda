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

namespace Temboo.Library.Utilities.Numbers
{
    /// <summary>
    /// GenerateRandom
    /// This choreo generates a random number in a variety of ranges. 
    /// </summary>
    public class GenerateRandom : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GenerateRandom Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GenerateRandom(TembooSession session) : base(session, "/Library/Utilities/Numbers/GenerateRandom")
        {
        }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GenerateRandomResultSet containing execution metadata and results.</returns>
        new public GenerateRandomResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GenerateRandomResultSet results = new JavaScriptSerializer().Deserialize<GenerateRandomResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GenerateRandom Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GenerateRandomResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "SignedDecimal" output from this Choreo execution
        /// <returns>String - (decimal) Signed Decimal in the range of  -0.5 to +0.5.</returns>
        /// </summary>
        public String SignedDecimal
        {
            get
            {
                return (String) base.Output["SignedDecimal"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "SignedInteger" output from this Choreo execution
        /// <returns>String - (integer) SIgned Integer in the range of -2147483648 through 2147483647.</returns>
        /// </summary>
        public String SignedInteger
        {
            get
            {
                return (String) base.Output["SignedInteger"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "UnsignedDecimal" output from this Choreo execution
        /// <returns>String - (decimal) Unsigned Decimal in the range of 0.0 to 1.0.</returns>
        /// </summary>
        public String UnsignedDecimal
        {
            get
            {
                return (String) base.Output["UnsignedDecimal"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "UnsignedInteger" output from this Choreo execution
        /// <returns>String - (integer) Unsigned integer in the range of 0 through 4294967295.</returns>
        /// </summary>
        public String UnsignedInteger
        {
            get
            {
                return (String) base.Output["UnsignedInteger"];
            }
        }
    }
}
