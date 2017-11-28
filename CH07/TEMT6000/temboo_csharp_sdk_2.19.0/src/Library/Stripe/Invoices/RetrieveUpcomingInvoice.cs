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
    /// RetrieveUpcomingInvoice
    /// Retrieves a customer's upcoming invoice.
    /// </summary>
    public class RetrieveUpcomingInvoice : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RetrieveUpcomingInvoice Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RetrieveUpcomingInvoice(TembooSession session) : base(session, "/Library/Stripe/Invoices/RetrieveUpcomingInvoice")
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
         /// (required, string) The unique identifier of the customer whose upcoming invoice to return
         /// </summary>
         /// <param name="value">Value of the CustomerID input for this Choreo.</param>
         public void setCustomerID(String value) {
             base.addInput ("CustomerID", value);
         }
         /// <summary>
         /// (optional, string) A Stripe object that should be expanded to show additional fields in the response.
         /// </summary>
         /// <param name="value">Value of the Expand input for this Choreo.</param>
         public void setExpand(String value) {
             base.addInput ("Expand", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RetrieveUpcomingInvoiceResultSet containing execution metadata and results.</returns>
        new public RetrieveUpcomingInvoiceResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RetrieveUpcomingInvoiceResultSet results = new JavaScriptSerializer().Deserialize<RetrieveUpcomingInvoiceResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RetrieveUpcomingInvoice Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RetrieveUpcomingInvoiceResultSet : Temboo.Core.ResultSet
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
