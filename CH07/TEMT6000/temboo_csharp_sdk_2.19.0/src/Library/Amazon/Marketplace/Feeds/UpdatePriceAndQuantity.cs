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

namespace Temboo.Library.Amazon.Marketplace.Feeds
{
    /// <summary>
    /// UpdatePriceAndQuantity
    /// Updates only the price and quantity of a particular product with a given product SKU.
    /// </summary>
    public class UpdatePriceAndQuantity : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdatePriceAndQuantity Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdatePriceAndQuantity(TembooSession session) : base(session, "/Library/Amazon/Marketplace/Feeds/UpdatePriceAndQuantity")
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
         /// (required, decimal) Enter the unit price for this product. The price must be greater than 0.00. Do NOT include the currency symbol (e.g. $).
         /// </summary>
         /// <param name="value">Value of the Price input for this Choreo.</param>
         public void setPrice(String value) {
             base.addInput ("Price", value);
         }
         /// <summary>
         /// (required, integer) Enter the quantity of the product you have for sale. The quantity must be a whole number, and should be greater than zero.
         /// </summary>
         /// <param name="value">Value of the Quantity input for this Choreo.</param>
         public void setQuantity(String value) {
             base.addInput ("Quantity", value);
         }
         /// <summary>
         /// (required, string) A SKU is a "Stock Keeping Unit" which you can assign to your products to track your inventory. Provide the SKU that you want to modify.
         /// </summary>
         /// <param name="value">Value of the SKU input for this Choreo.</param>
         public void setSKU(String value) {
             base.addInput ("SKU", value);
         }
         /// <summary>
         /// (optional, integer) By default, the Choreo will wait for 10 minutes to see if the report is ready for retrieval. Max is 120 minutes.
         /// </summary>
         /// <param name="value">Value of the TimeToWait input for this Choreo.</param>
         public void setTimeToWait(String value) {
             base.addInput ("TimeToWait", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdatePriceAndQuantityResultSet containing execution metadata and results.</returns>
        new public UpdatePriceAndQuantityResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdatePriceAndQuantityResultSet results = new JavaScriptSerializer().Deserialize<UpdatePriceAndQuantityResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdatePriceAndQuantity Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdatePriceAndQuantityResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ProcessingStatus" output from this Choreo execution
        /// <returns>String - (string) The processing status of the feed submission which is parsed from the Amazon response.</returns>
        /// </summary>
        public String ProcessingStatus
        {
            get
            {
                return (String) base.Output["ProcessingStatus"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "SubmissionId" output from this Choreo execution
        /// <returns>String - (integer) The submission id parsed from the Amazon response.</returns>
        /// </summary>
        public String SubmissionId
        {
            get
            {
                return (String) base.Output["SubmissionId"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "SubmissionResult" output from this Choreo execution
        /// <returns>String - (string) The submission result returned from Amazon.</returns>
        /// </summary>
        public String SubmissionResult
        {
            get
            {
                return (String) base.Output["SubmissionResult"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Amazon after submitting the feed.</returns>
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
