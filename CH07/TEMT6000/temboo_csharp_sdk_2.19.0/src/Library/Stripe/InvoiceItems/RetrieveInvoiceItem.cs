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

namespace Temboo.Library.Stripe.InvoiceItems
{
    /// <summary>
    /// RetrieveInvoiceItem
    /// Retrieves invoice items with a specified id.
    /// </summary>
    public class RetrieveInvoiceItem : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RetrieveInvoiceItem Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RetrieveInvoiceItem(TembooSession session) : base(session, "/Library/Stripe/InvoiceItems/RetrieveInvoiceItem")
        {
        }

         /// <summary>
         /// (required, string) The secret API Key provided by Stripe
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) A Stripe object that should be expanded to show additional fields in the response.
         /// </summary>
         /// <param name="value">Value of the Expand input for this Choreo.</param>
         public void setExpand(String value) {
             base.addInput ("Expand", value);
         }
         /// <summary>
         /// (required, string) The unique identifier of the invoice item you want to retrieve
         /// </summary>
         /// <param name="value">Value of the InvoiceItemID input for this Choreo.</param>
         public void setInvoiceItemID(String value) {
             base.addInput ("InvoiceItemID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RetrieveInvoiceItemResultSet containing execution metadata and results.</returns>
        new public RetrieveInvoiceItemResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RetrieveInvoiceItemResultSet results = new JavaScriptSerializer().Deserialize<RetrieveInvoiceItemResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RetrieveInvoiceItem Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RetrieveInvoiceItemResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Stripe</returns>
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
