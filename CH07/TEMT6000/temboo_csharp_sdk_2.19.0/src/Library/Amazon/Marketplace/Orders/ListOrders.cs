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

namespace Temboo.Library.Amazon.Marketplace.Orders
{
    /// <summary>
    /// ListOrders
    /// Returns orders created during a time frame that you specify.
    /// </summary>
    public class ListOrders : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListOrders Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListOrders(TembooSession session) : base(session, "/Library/Amazon/Marketplace/Orders/ListOrders")
        {
        }

         /// <summary>
         /// (required, string) The Access Key ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSAccessKeyId input for this Choreo.</param>
         public void setAWSAccessKeyId(String value) {
             base.addInput ("AWSAccessKeyId", value);
         }
         /// <summary>
         /// (required, string) The Marketplace ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSMarketplaceId input for this Choreo.</param>
         public void setAWSMarketplaceId(String value) {
             base.addInput ("AWSMarketplaceId", value);
         }
         /// <summary>
         /// (required, string) The Merchant ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSMerchantId input for this Choreo.</param>
         public void setAWSMerchantId(String value) {
             base.addInput ("AWSMerchantId", value);
         }
         /// <summary>
         /// (required, string) The Secret Key ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSSecretKeyId input for this Choreo.</param>
         public void setAWSSecretKeyId(String value) {
             base.addInput ("AWSSecretKeyId", value);
         }
         /// <summary>
         /// (optional, date) A date used for selecting orders created after (or at) a specified time, in ISO 8601 date format (i.e. 2012-01-01). Defaults to today's date if not provided.
         /// </summary>
         /// <param name="value">Value of the CreatedAfter input for this Choreo.</param>
         public void setCreatedAfter(String value) {
             base.addInput ("CreatedAfter", value);
         }
         /// <summary>
         /// (optional, date) A date used for selecting orders created before (or at) a specified time, in ISO 8601 date format (i.e. 2012-01-01).
         /// </summary>
         /// <param name="value">Value of the CreatedBefore input for this Choreo.</param>
         public void setCreatedBefore(String value) {
             base.addInput ("CreatedBefore", value);
         }
         /// <summary>
         /// (conditional, string) The base URL for the MWS endpoint. Defaults to mws.amazonservices.co.uk.
         /// </summary>
         /// <param name="value">Value of the Endpoint input for this Choreo.</param>
         public void setEndpoint(String value) {
             base.addInput ("Endpoint", value);
         }
         /// <summary>
         /// (optional, string) A string indicating how an order was fulfilled. Use "AFN" for Amazon fulfilled orders, and "MFN" for seller fulfilled orders.
         /// </summary>
         /// <param name="value">Value of the FullfillmentChannel input for this Choreo.</param>
         public void setFullfillmentChannel(String value) {
             base.addInput ("FullfillmentChannel", value);
         }
         /// <summary>
         /// (optional, date) A date used for selecting orders that were last updated after (or at) a specified time, in ISO 8601 date format (i.e. 2012-01-01). Cannot be specified if CreatedAfter is specified.
         /// </summary>
         /// <param name="value">Value of the LastUpdatedAfter input for this Choreo.</param>
         public void setLastUpdatedAfter(String value) {
             base.addInput ("LastUpdatedAfter", value);
         }
         /// <summary>
         /// (optional, date) A date used for selecting orders that were last updated before (or at) a specified time, in ISO 8601 date format (i.e. 2012-01-01). Cannot be specified if CreatedAfter is specified.
         /// </summary>
         /// <param name="value">Value of the LastUpdatedBefore input for this Choreo.</param>
         public void setLastUpdatedBefore(String value) {
             base.addInput ("LastUpdatedBefore", value);
         }
         /// <summary>
         /// (optional, string) The Amazon MWS authorization token for the given seller and developer.
         /// </summary>
         /// <param name="value">Value of the MWSAuthToken input for this Choreo.</param>
         public void setMWSAuthToken(String value) {
             base.addInput ("MWSAuthToken", value);
         }
         /// <summary>
         /// (optional, integer) A number that indicates the maximum number of orders that can be returned per page. Valid values are: 1-100.
         /// </summary>
         /// <param name="value">Value of the MaxResultsPerPage input for this Choreo.</param>
         public void setMaxResultsPerPage(String value) {
             base.addInput ("MaxResultsPerPage", value);
         }
         /// <summary>
         /// (optional, string) One or more OrderStatus values separated by commas. This options selects only orders with a certain status (e.g. Pending, Unshipped, PartiallyShipped, Shipped, Canceled, Unfulfillable, etc).
         /// </summary>
         /// <param name="value">Value of the OrderStatus input for this Choreo.</param>
         public void setOrderStatus(String value) {
             base.addInput ("OrderStatus", value);
         }
         /// <summary>
         /// (optional, string) The value returned in the NextPageToken output of this Choreo when there are multiple pages of orders to retrieve.
         /// </summary>
         /// <param name="value">Value of the PageToken input for this Choreo.</param>
         public void setPageToken(String value) {
             base.addInput ("PageToken", value);
         }
         /// <summary>
         /// (optional, string) Used to select only orders of a certain payment type. Valid values are: COD (cash on delivery), CVS (convenience store payment), or Other (Any payment method other than COD or CVS).
         /// </summary>
         /// <param name="value">Value of the PaymentMethod input for this Choreo.</param>
         public void setPaymentMethod(String value) {
             base.addInput ("PaymentMethod", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListOrdersResultSet containing execution metadata and results.</returns>
        new public ListOrdersResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListOrdersResultSet results = new JavaScriptSerializer().Deserialize<ListOrdersResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListOrders Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListOrdersResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "NextPageToken" output from this Choreo execution
        /// <returns>String - (string) A token used to retrieve the next page of results. If a token is not returned, there are no more results to retrieve. This token can be passed to the PageToken input of this Choreo.</returns>
        /// </summary>
        public String NextPageToken
        {
            get
            {
                return (String) base.Output["NextPageToken"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - Stores the response from Amazon.</returns>
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
