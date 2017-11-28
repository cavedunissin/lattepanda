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

namespace Temboo.Library.Dwolla.FundingSources
{
    /// <summary>
    /// FundingSourcesByID
    /// Retrieves the account information for the user associated with the given authorized access token.
    /// </summary>
    public class FundingSourcesByID : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FundingSourcesByID Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FundingSourcesByID(TembooSession session) : base(session, "/Library/Dwolla/FundingSources/FundingSourcesByID")
        {
        }

         /// <summary>
         /// (required, string) A valid OAuth token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) Funding source identifier of the funding source being requested.
         /// </summary>
         /// <param name="value">Value of the FundingID input for this Choreo.</param>
         public void setFundingID(String value) {
             base.addInput ("FundingID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A FundingSourcesByIDResultSet containing execution metadata and results.</returns>
        new public FundingSourcesByIDResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FundingSourcesByIDResultSet results = new JavaScriptSerializer().Deserialize<FundingSourcesByIDResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FundingSourcesByID Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FundingSourcesByIDResultSet : Temboo.Core.ResultSet
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
