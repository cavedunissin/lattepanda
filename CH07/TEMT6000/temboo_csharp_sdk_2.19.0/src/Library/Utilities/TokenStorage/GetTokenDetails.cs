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
    /// GetTokenDetails
    /// Returns one or more tokens represented by a specified list of names.
    /// </summary>
    public class GetTokenDetails : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetTokenDetails Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetTokenDetails(TembooSession session) : base(session, "/Library/Utilities/TokenStorage/GetTokenDetails")
        {
        }

         /// <summary>
         /// (required, json) A list of tokens to return. This should be formated as a JSON array.
         /// </summary>
         /// <param name="value">Value of the Names input for this Choreo.</param>
         public void setNames(String value) {
             base.addInput ("Names", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetTokenDetailsResultSet containing execution metadata and results.</returns>
        new public GetTokenDetailsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetTokenDetailsResultSet results = new JavaScriptSerializer().Deserialize<GetTokenDetailsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetTokenDetails Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetTokenDetailsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Tokens" output from this Choreo execution
        /// <returns>String - (json) The token values.</returns>
        /// </summary>
        public String Tokens
        {
            get
            {
                return (String) base.Output["Tokens"];
            }
        }
    }
}
