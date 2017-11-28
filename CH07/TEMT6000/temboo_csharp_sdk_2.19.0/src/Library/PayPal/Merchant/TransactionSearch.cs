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

namespace Temboo.Library.PayPal.Merchant
{
    /// <summary>
    /// TransactionSearch
    /// Retrieves transaction history for transactions that meet a specified criteria.
    /// </summary>
    public class TransactionSearch : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the TransactionSearch Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public TransactionSearch(TembooSession session) : base(session, "/Library/PayPal/Merchant/TransactionSearch")
        {
        }

         /// <summary>
         /// (optional, string) Search by credit card number.
         /// </summary>
         /// <param name="value">Value of the Account input for this Choreo.</param>
         public void setAccount(String value) {
             base.addInput ("Account", value);
         }
         /// <summary>
         /// (optional, string) Search by auction item number of the purchased item.
         /// </summary>
         /// <param name="value">Value of the AuctionItemNumber input for this Choreo.</param>
         public void setAuctionItemNumber(String value) {
             base.addInput ("AuctionItemNumber", value);
         }
         /// <summary>
         /// (optional, string) Search by currency code (i.e. USD).
         /// </summary>
         /// <param name="value">Value of the CurrencyCode input for this Choreo.</param>
         public void setCurrencyCode(String value) {
             base.addInput ("CurrencyCode", value);
         }
         /// <summary>
         /// (optional, string) Search by email.
         /// </summary>
         /// <param name="value">Value of the Email input for this Choreo.</param>
         public void setEmail(String value) {
             base.addInput ("Email", value);
         }
         /// <summary>
         /// (optional, date) The latest transaction date to return. Must be an epoch timestamp in milliseconds or formatted in UTC like: 2011-05-19T00:00:00Z.
         /// </summary>
         /// <param name="value">Value of the EndDate input for this Choreo.</param>
         public void setEndDate(String value) {
             base.addInput ("EndDate", value);
         }
         /// <summary>
         /// (optional, string) Search by invoice number.
         /// </summary>
         /// <param name="value">Value of the InvoiceNumber input for this Choreo.</param>
         public void setInvoiceNumber(String value) {
             base.addInput ("InvoiceNumber", value);
         }
         /// <summary>
         /// (required, password) The API Password provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (optional, string) Search by the PayPal receipt ID.
         /// </summary>
         /// <param name="value">Value of the ReceiptId input for this Choreo.</param>
         public void setReceiptId(String value) {
             base.addInput ("ReceiptId", value);
         }
         /// <summary>
         /// (optional, string) Search by the email address of the receiver.
         /// </summary>
         /// <param name="value">Value of the Receiver input for this Choreo.</param>
         public void setReceiver(String value) {
             base.addInput ("Receiver", value);
         }
         /// <summary>
         /// (required, string) The API Signature provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Signature input for this Choreo.</param>
         public void setSignature(String value) {
             base.addInput ("Signature", value);
         }
         /// <summary>
         /// (required, date) The earliest transaction date to return. Must be an epoch timestamp in milliseconds or formatted in UTC like: 2011-05-19T00:00:00Z.
         /// </summary>
         /// <param name="value">Value of the StartDate input for this Choreo.</param>
         public void setStartDate(String value) {
             base.addInput ("StartDate", value);
         }
         /// <summary>
         /// (optional, decimal) Search by transaction amount.
         /// </summary>
         /// <param name="value">Value of the TransactionAmount input for this Choreo.</param>
         public void setTransactionAmount(String value) {
             base.addInput ("TransactionAmount", value);
         }
         /// <summary>
         /// (optional, string) Search by classification of transaction (i.e. All, Sent, Recieved, etc).
         /// </summary>
         /// <param name="value">Value of the TransactionClass input for this Choreo.</param>
         public void setTransactionClass(String value) {
             base.addInput ("TransactionClass", value);
         }
         /// <summary>
         /// (optional, string) Search by the transaction ID
         /// </summary>
         /// <param name="value">Value of the TransactionId input for this Choreo.</param>
         public void setTransactionId(String value) {
             base.addInput ("TransactionId", value);
         }
         /// <summary>
         /// (optional, string) Search by transaction status (i.e. Pending, Processing, Success, Denied, Reversed).
         /// </summary>
         /// <param name="value">Value of the TransactionStatus input for this Choreo.</param>
         public void setTransactionStatus(String value) {
             base.addInput ("TransactionStatus", value);
         }
         /// <summary>
         /// (conditional, boolean) Set to 1 to indicate that you're testing against the PayPal sandbox instead of production. Set to 0 (the default) when moving to production.
         /// </summary>
         /// <param name="value">Value of the UseSandbox input for this Choreo.</param>
         public void setUseSandbox(String value) {
             base.addInput ("UseSandbox", value);
         }
         /// <summary>
         /// (required, string) The API Username provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A TransactionSearchResultSet containing execution metadata and results.</returns>
        new public TransactionSearchResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            TransactionSearchResultSet results = new JavaScriptSerializer().Deserialize<TransactionSearchResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the TransactionSearch Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class TransactionSearchResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (string) Response from PayPal formatted in name/value pairs.</returns>
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
