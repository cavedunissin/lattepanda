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

namespace Temboo.Library.Stripe.Invoices
{
    /// <summary>
    /// UpdateInvoice
    /// Updates an existing invoice.
    /// </summary>
    public class UpdateInvoice : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateInvoice Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateInvoice(TembooSession session) : base(session, "/Library/Stripe/Invoices/UpdateInvoice")
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
         /// (conditional, boolean) Whether or not the invoice should be closed or not. To close an invoice, set this to "true".
         /// </summary>
         /// <param name="value">Value of the Closed input for this Choreo.</param>
         public void setClosed(String value) {
             base.addInput ("Closed", value);
         }
         /// <summary>
         /// (required, string) The id of the invoice to update.
         /// </summary>
         /// <param name="value">Value of the InvoiceID input for this Choreo.</param>
         public void setInvoiceID(String value) {
             base.addInput ("InvoiceID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateInvoiceResultSet containing execution metadata and results.</returns>
        new public UpdateInvoiceResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateInvoiceResultSet results = new JavaScriptSerializer().Deserialize<UpdateInvoiceResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateInvoice Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateInvoiceResultSet : Temboo.Core.ResultSet
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
