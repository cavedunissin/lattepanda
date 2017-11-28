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
    /// UpdateInvoiceItem
    /// Updates the amount or description of an existing invoice item.
    /// </summary>
    public class UpdateInvoiceItem : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateInvoiceItem Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateInvoiceItem(TembooSession session) : base(session, "/Library/Stripe/InvoiceItems/UpdateInvoiceItem")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Stripe
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, integer) The amount in cents of the charge to be included in the customer's next invoice
         /// </summary>
         /// <param name="value">Value of the Amount input for this Choreo.</param>
         public void setAmount(String value) {
             base.addInput ("Amount", value);
         }
         /// <summary>
         /// (optional, string) 3-letter ISO code for currency. Defaults to 'usd' which is currently the only supported currency.
         /// </summary>
         /// <param name="value">Value of the Currency input for this Choreo.</param>
         public void setCurrency(String value) {
             base.addInput ("Currency", value);
         }
         /// <summary>
         /// (optional, string) An arbitrary string of text that will be included with the invoice item
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (required, string) The unique identifier of the invoice item you want to update
         /// </summary>
         /// <param name="value">Value of the InvoiceItemID input for this Choreo.</param>
         public void setInvoiceItemID(String value) {
             base.addInput ("InvoiceItemID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateInvoiceItemResultSet containing execution metadata and results.</returns>
        new public UpdateInvoiceItemResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateInvoiceItemResultSet results = new JavaScriptSerializer().Deserialize<UpdateInvoiceItemResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateInvoiceItem Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateInvoiceItemResultSet : Temboo.Core.ResultSet
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
