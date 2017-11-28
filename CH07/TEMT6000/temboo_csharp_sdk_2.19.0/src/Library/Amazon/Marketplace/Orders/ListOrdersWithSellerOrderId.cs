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
    /// ListOrdersWithSellerOrderId
    /// Returns orders associated with a seller order id that you specify.
    /// </summary>
    public class ListOrdersWithSellerOrderId : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListOrdersWithSellerOrderId Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListOrdersWithSellerOrderId(TembooSession session) : base(session, "/Library/Amazon/Marketplace/Orders/ListOrdersWithSellerOrderId")
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
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) An order identifier that is specified by the seller.
         /// </summary>
         /// <param name="value">Value of the SellerOrderId input for this Choreo.</param>
         public void setSellerOrderId(String value) {
             base.addInput ("SellerOrderId", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListOrdersWithSellerOrderIdResultSet containing execution metadata and results.</returns>
        new public ListOrdersWithSellerOrderIdResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListOrdersWithSellerOrderIdResultSet results = new JavaScriptSerializer().Deserialize<ListOrdersWithSellerOrderIdResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListOrdersWithSellerOrderId Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListOrdersWithSellerOrderIdResultSet : Temboo.Core.ResultSet
    {
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
