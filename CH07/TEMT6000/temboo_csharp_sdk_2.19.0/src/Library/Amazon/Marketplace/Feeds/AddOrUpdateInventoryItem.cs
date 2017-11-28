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
    /// AddOrUpdateInventoryItem
    /// Add or update an individual inventory listing.
    /// </summary>
    public class AddOrUpdateInventoryItem : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AddOrUpdateInventoryItem Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AddOrUpdateInventoryItem(TembooSession session) : base(session, "/Library/Amazon/Marketplace/Feeds/AddOrUpdateInventoryItem")
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
         /// (optional, string) The expedited shipping options that you offer for this item. Valid values: 3 = UK Only; N = None, no express delivery offered.
         /// </summary>
         /// <param name="value">Value of the ExpeditedShipping input for this Choreo.</param>
         public void setExpeditedShipping(String value) {
             base.addInput ("ExpeditedShipping", value);
         }
         /// <summary>
         /// (conditional, string) For those merchants using Amazon fulfillment services, this designates which fulfillment network will be used. Required when using Amazon fulfillment services. Valid values are: AMAZON_EU, DEFAULT.
         /// </summary>
         /// <param name="value">Value of the FulfillmentCenterId input for this Choreo.</param>
         public void setFulfillmentCenterId(String value) {
             base.addInput ("FulfillmentCenterId", value);
         }
         /// <summary>
         /// (conditional, integer) A numerical entry that indicates the condition of the item. Required for new listings. Valid values are: 1-11. See documentation for description of item condition numeric values.
         /// </summary>
         /// <param name="value">Value of the ItemCondition input for this Choreo.</param>
         public void setItemCondition(String value) {
             base.addInput ("ItemCondition", value);
         }
         /// <summary>
         /// (optional, string) A description or note for the item you're adding or updating.
         /// </summary>
         /// <param name="value">Value of the ItemNote input for this Choreo.</param>
         public void setItemNote(String value) {
             base.addInput ("ItemNote", value);
         }
         /// <summary>
         /// (optional, string) The Amazon MWS authorization token for the given seller and developer.
         /// </summary>
         /// <param name="value">Value of the MWSAuthToken input for this Choreo.</param>
         public void setMWSAuthToken(String value) {
             base.addInput ("MWSAuthToken", value);
         }
         /// <summary>
         /// (conditional, decimal) The price at which the merchant offers the product for sale. Required if ProductId is provided.
         /// </summary>
         /// <param name="value">Value of the Price input for this Choreo.</param>
         public void setPrice(String value) {
             base.addInput ("Price", value);
         }
         /// <summary>
         /// (conditional, string) A standard, alphanumeric string that uniquely identifies the product. This could be a UPC, EAN or ISBN.  This is a required field if product-id-type is provided.
         /// </summary>
         /// <param name="value">Value of the ProductId input for this Choreo.</param>
         public void setProductId(String value) {
             base.addInput ("ProductId", value);
         }
         /// <summary>
         /// (conditional, integer) The type of standard, unique identifier entered in the product-id field. This is a required field if product-id is provided. Valid values are: 1 (ASIN), 2 (ISBN), 3 (UPC), 4  (EAN).
         /// </summary>
         /// <param name="value">Value of the ProductIdType input for this Choreo.</param>
         public void setProductIdType(String value) {
             base.addInput ("ProductIdType", value);
         }
         /// <summary>
         /// (conditional, integer) Enter the quantity of the item you are making available for sale. Required for merchant-fulfilled items. Leave blank for amazon-fullfilled items.
         /// </summary>
         /// <param name="value">Value of the Quantity input for this Choreo.</param>
         public void setQuantity(String value) {
             base.addInput ("Quantity", value);
         }
         /// <summary>
         /// (required, string) A unique identifier for the product, assigned by the merchant. The SKU must be unique for each product listed.
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
         /// (optional, integer) Specify your international shipping options. Valid values are: 3 = UK Only; 4 = UK and Europe; 5 = UK, Europe, and North America; 6 = Worldwide
         /// </summary>
         /// <param name="value">Value of the WillShipInternationally input for this Choreo.</param>
         public void setWillShipInternationally(String value) {
             base.addInput ("WillShipInternationally", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AddOrUpdateInventoryItemResultSet containing execution metadata and results.</returns>
        new public AddOrUpdateInventoryItemResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AddOrUpdateInventoryItemResultSet results = new JavaScriptSerializer().Deserialize<AddOrUpdateInventoryItemResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AddOrUpdateInventoryItem Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AddOrUpdateInventoryItemResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ProcessingStatus" output from this Choreo execution
        /// <returns>String - (string) The processing status of the product submission which is parsed from the Amazon response.</returns>
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
