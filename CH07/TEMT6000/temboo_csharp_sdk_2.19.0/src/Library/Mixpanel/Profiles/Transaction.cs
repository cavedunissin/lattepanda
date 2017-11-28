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

namespace Temboo.Library.Mixpanel.Profiles
{
    /// <summary>
    /// Transaction
    /// Appends transaction data to a profile.
    /// </summary>
    public class Transaction : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Transaction Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Transaction(TembooSession session) : base(session, "/Library/Mixpanel/Profiles/Transaction")
        {
        }

         /// <summary>
         /// (required, string) Used to uniquely identify the profile you want to update.
         /// </summary>
         /// <param name="value">Value of the DistinctID input for this Choreo.</param>
         public void setDistinctID(String value) {
             base.addInput ("DistinctID", value);
         }
         /// <summary>
         /// (optional, string) An IP address string associated with the profile (e.g., 127.0.0.1). When set to 0 (the default) Mixpanel will ignore IP information.
         /// </summary>
         /// <param name="value">Value of the IP input for this Choreo.</param>
         public void setIP(String value) {
             base.addInput ("IP", value);
         }
         /// <summary>
         /// (optional, boolean) When set to true, Mixpanel will not automatically update the "Last Seen" property of the profile. Otherwise, Mixpanel will add a "Last Seen" property associated with any set, append, or add requests.
         /// </summary>
         /// <param name="value">Value of the IgnoreTime input for this Choreo.</param>
         public void setIgnoreTime(String value) {
             base.addInput ("IgnoreTime", value);
         }
         /// <summary>
         /// (optional, date) A unix timestamp representing the time of the profile update. If not provided, Mixpanel will use the time the update arrives at the server.
         /// </summary>
         /// <param name="value">Value of the Time input for this Choreo.</param>
         public void setTime(String value) {
             base.addInput ("Time", value);
         }
         /// <summary>
         /// (required, string) The token provided by Mixpanel. You can find your Mixpanel token in the project settings dialog in the Mixpanel app.
         /// </summary>
         /// <param name="value">Value of the Token input for this Choreo.</param>
         public void setToken(String value) {
             base.addInput ("Token", value);
         }
         /// <summary>
         /// (required, decimal) The amount of the transaction.
         /// </summary>
         /// <param name="value">Value of the TransactionAmount input for this Choreo.</param>
         public void setTransactionAmount(String value) {
             base.addInput ("TransactionAmount", value);
         }
         /// <summary>
         /// (optional, json) A JSON object containing any transaction properties you wish to set (e.g. SKU, Product Name, etc).
         /// </summary>
         /// <param name="value">Value of the TransactionProperties input for this Choreo.</param>
         public void setTransactionProperties(String value) {
             base.addInput ("TransactionProperties", value);
         }
         /// <summary>
         /// (conditional, date) The time of the transaction (e.g., 2013-01-03T09:00:00). If this isn't provided, the current time in UTC is specified.
         /// </summary>
         /// <param name="value">Value of the TransactionTime input for this Choreo.</param>
         public void setTransactionTime(String value) {
             base.addInput ("TransactionTime", value);
         }
         /// <summary>
         /// (optional, boolean) When set to 1, the response will contain more information describing the success or failure of the tracking call.
         /// </summary>
         /// <param name="value">Value of the Verbose input for this Choreo.</param>
         public void setVerbose(String value) {
             base.addInput ("Verbose", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A TransactionResultSet containing execution metadata and results.</returns>
        new public TransactionResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            TransactionResultSet results = new JavaScriptSerializer().Deserialize<TransactionResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Transaction Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class TransactionResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Mixpanel.</returns>
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
