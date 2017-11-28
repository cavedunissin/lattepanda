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

namespace Temboo.Library.Dwolla.Transactions
{
    /// <summary>
    /// Listing
    /// Retrieves a list of transactions for the user associated with the authorized access token.
    /// </summary>
    public class Listing : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Listing Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Listing(TembooSession session) : base(session, "/Library/Dwolla/Transactions/Listing")
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
         /// (optional, string) Latest date and time for which to retrieve transactions.  (In ISO 8601 format.  e.g. 2012-07-22)  Defaults to current date and time in UTC.
         /// </summary>
         /// <param name="value">Value of the EndDate input for this Choreo.</param>
         public void setEndDate(String value) {
             base.addInput ("EndDate", value);
         }
         /// <summary>
         /// (optional, integer) Number of transactions to retrieve. Defaults to 10. Can be between 1 and 200 transactions.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) Earliest date and time (in ISO 8601 format) for which to retrieve transactions. (e.g. 2012-07-20) Defaults to 7 days prior to current date and time in UTC.
         /// </summary>
         /// <param name="value">Value of the SinceDate input for this Choreo.</param>
         public void setSinceDate(String value) {
             base.addInput ("SinceDate", value);
         }
         /// <summary>
         /// (optional, integer) Number of transactions to skip. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Skip input for this Choreo.</param>
         public void setSkip(String value) {
             base.addInput ("Skip", value);
         }
         /// <summary>
         /// (optional, string) Transaction types to retrieve. Must be delimited by a '|'. Options are money_sent, money_received, deposit, withdrawal, and fee. Defaults to include all transaction types.
         /// </summary>
         /// <param name="value">Value of the Types input for this Choreo.</param>
         public void setTypes(String value) {
             base.addInput ("Types", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListingResultSet containing execution metadata and results.</returns>
        new public ListingResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListingResultSet results = new JavaScriptSerializer().Deserialize<ListingResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Listing Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListingResultSet : Temboo.Core.ResultSet
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
