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
    /// ListAllInvoiceItems
    /// Returns a list of all invoice items or a list of invoice items for a specified customer.
    /// </summary>
    public class ListAllInvoiceItems : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListAllInvoiceItems Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListAllInvoiceItems(TembooSession session) : base(session, "/Library/Stripe/InvoiceItems/ListAllInvoiceItems")
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
         /// (optional, integer) The limit of invoice items to be returned. Can range from 1 to 100. Defaults to 10.
         /// </summary>
         /// <param name="value">Value of the Count input for this Choreo.</param>
         public void setCount(String value) {
             base.addInput ("Count", value);
         }
         /// <summary>
         /// (optional, string) The unique identifier of the customer whose invoice items to return. If not specified, all invoice items will be returned.
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
         /// (optional, integer) Stripe will return a list of invoice items starting at the specified offset. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListAllInvoiceItemsResultSet containing execution metadata and results.</returns>
        new public ListAllInvoiceItemsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListAllInvoiceItemsResultSet results = new JavaScriptSerializer().Deserialize<ListAllInvoiceItemsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListAllInvoiceItems Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListAllInvoiceItemsResultSet : Temboo.Core.ResultSet
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
