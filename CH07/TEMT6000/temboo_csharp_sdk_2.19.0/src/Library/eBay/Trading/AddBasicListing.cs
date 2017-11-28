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

namespace Temboo.Library.eBay.Trading
{
    /// <summary>
    /// AddBasicListing
    /// Allows you create a basic listing on eBay using scalar inputs rather than an XML request.
    /// </summary>
    public class AddBasicListing : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AddBasicListing Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AddBasicListing(TembooSession session) : base(session, "/Library/eBay/Trading/AddBasicListing")
        {
        }

         /// <summary>
         /// (optional, decimal) Allows a user to purchase the item at a Buy It Now price and end the auction immediately.
         /// </summary>
         /// <param name="value">Value of the BuyItNowPrice input for this Choreo.</param>
         public void setBuyItNowPrice(String value) {
             base.addInput ("BuyItNowPrice", value);
         }
         /// <summary>
         /// (conditional, integer) The numeric ID for a category on eBay. Category IDs can be retrieved with the GetCategories Choreo.
         /// </summary>
         /// <param name="value">Value of the CategoryID input for this Choreo.</param>
         public void setCategoryID(String value) {
             base.addInput ("CategoryID", value);
         }
         /// <summary>
         /// (conditional, integer) The numeric ID (e.g., 1000) for the item condition.
         /// </summary>
         /// <param name="value">Value of the ConditionID input for this Choreo.</param>
         public void setConditionID(String value) {
             base.addInput ("ConditionID", value);
         }
         /// <summary>
         /// (conditional, string) The country where the item is located in.
         /// </summary>
         /// <param name="value">Value of the Country input for this Choreo.</param>
         public void setCountry(String value) {
             base.addInput ("Country", value);
         }
         /// <summary>
         /// (conditional, string) The currency associated with the item price.
         /// </summary>
         /// <param name="value">Value of the Currency input for this Choreo.</param>
         public void setCurrency(String value) {
             base.addInput ("Currency", value);
         }
         /// <summary>
         /// (conditional, integer) Specifies the maximum number of business days the seller commits to for preparing an item to be shipped after receiving a cleared payment.
         /// </summary>
         /// <param name="value">Value of the DispatchTimeMax input for this Choreo.</param>
         public void setDispatchTimeMax(String value) {
             base.addInput ("DispatchTimeMax", value);
         }
         /// <summary>
         /// (optional, boolean) Whether or not the seller is offering expedited shipping service options.
         /// </summary>
         /// <param name="value">Value of the ExpeditedService input for this Choreo.</param>
         public void setExpeditedService(String value) {
             base.addInput ("ExpeditedService", value);
         }
         /// <summary>
         /// (conditional, string) The seller's description of the item.
         /// </summary>
         /// <param name="value">Value of the ItemDescription input for this Choreo.</param>
         public void setItemDescription(String value) {
             base.addInput ("ItemDescription", value);
         }
         /// <summary>
         /// (conditional, string) The number of days the seller wants the listing to be active (e.g., Days_7). A complete list of accepted values is returned when calling GetCategoryFeatures with DetailLevel set to ReturnAll.
         /// </summary>
         /// <param name="value">Value of the ListingDuration input for this Choreo.</param>
         public void setListingDuration(String value) {
             base.addInput ("ListingDuration", value);
         }
         /// <summary>
         /// (optional, string) The format of the listing the seller wants to use. Valid values are: AdType, Chinese, FixedPriceItem, Half, LeadGeneration.
         /// </summary>
         /// <param name="value">Value of the ListingType input for this Choreo.</param>
         public void setListingType(String value) {
             base.addInput ("ListingType", value);
         }
         /// <summary>
         /// (conditional, string) The seller's PayPal email address. Required when a PaymentMethod is PayPal.
         /// </summary>
         /// <param name="value">Value of the PayPalEmailAddress input for this Choreo.</param>
         public void setPayPalEmailAddress(String value) {
             base.addInput ("PayPalEmailAddress", value);
         }
         /// <summary>
         /// (conditional, string) Identifies the payment method (such as PayPal) that the seller will accept when the buyer pays for the item. This can be a comma-separated list (e.g., VisaMC,PayPal).
         /// </summary>
         /// <param name="value">Value of the PaymentMethods input for this Choreo.</param>
         public void setPaymentMethods(String value) {
             base.addInput ("PaymentMethods", value);
         }
         /// <summary>
         /// (conditional, string) The URL for a picture associated with an item. Multiple URLs can be specified as a comma-separated list.
         /// </summary>
         /// <param name="value">Value of the PictureURL input for this Choreo.</param>
         public void setPictureURL(String value) {
             base.addInput ("PictureURL", value);
         }
         /// <summary>
         /// (conditional, string) The Postal code of the place where the item is located.
         /// </summary>
         /// <param name="value">Value of the PostalCode input for this Choreo.</param>
         public void setPostalCode(String value) {
             base.addInput ("PostalCode", value);
         }
         /// <summary>
         /// (conditional, integer) Indicates the quantity of items available for purchase in the listing. Required for all auction listings and for non-variation, fixed-price listings. For auction listings, this value is always '1'.
         /// </summary>
         /// <param name="value">Value of the Quantity input for this Choreo.</param>
         public void setQuantity(String value) {
             base.addInput ("Quantity", value);
         }
         /// <summary>
         /// (optional, string) Indicates how the seller will compensate the buyer for a returned item (e.g. MoneyBack).
         /// </summary>
         /// <param name="value">Value of the RefundOption input for this Choreo.</param>
         public void setRefundOption(String value) {
             base.addInput ("RefundOption", value);
         }
         /// <summary>
         /// (optional, decimal) The lowest price at which the seller is willing to sell the item.
         /// </summary>
         /// <param name="value">Value of the ReservePrice input for this Choreo.</param>
         public void setReservePrice(String value) {
             base.addInput ("ReservePrice", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The text description of return policy details.
         /// </summary>
         /// <param name="value">Value of the ReturnPolicyDescription input for this Choreo.</param>
         public void setReturnPolicyDescription(String value) {
             base.addInput ("ReturnPolicyDescription", value);
         }
         /// <summary>
         /// (conditional, string) Indicates whether the seller allows the buyer to return the item (e.g., ReturnsAccepted).
         /// </summary>
         /// <param name="value">Value of the ReturnsAcceptedOption input for this Choreo.</param>
         public void setReturnsAcceptedOption(String value) {
             base.addInput ("ReturnsAcceptedOption", value);
         }
         /// <summary>
         /// (optional, string) The period of time the buyer has to return the item (e.g., Days_14). To accepted values for this field, call GeteBayDetails with DetailName set to ReturnPolicyDetails.
         /// </summary>
         /// <param name="value">Value of the ReturnsWithinOption input for this Choreo.</param>
         public void setReturnsWithinOption(String value) {
             base.addInput ("ReturnsWithinOption", value);
         }
         /// <summary>
         /// (conditional, boolean) Indicates that the request should be made to the sandbox endpoint instead of the production endpoint. Set to 1 to enable sandbox mode.
         /// </summary>
         /// <param name="value">Value of the SandboxMode input for this Choreo.</param>
         public void setSandboxMode(String value) {
             base.addInput ("SandboxMode", value);
         }
         /// <summary>
         /// (conditional, string) The name of the shipping service offered (e.g. UPSGround, USPSMedia).
         /// </summary>
         /// <param name="value">Value of the ShippingService input for this Choreo.</param>
         public void setShippingService(String value) {
             base.addInput ("ShippingService", value);
         }
         /// <summary>
         /// (optional, decimal) Shipping costs in addition to the value specified for the ShippingServiceCost parameter.
         /// </summary>
         /// <param name="value">Value of the ShippingServiceAdditionalCost input for this Choreo.</param>
         public void setShippingServiceAdditionalCost(String value) {
             base.addInput ("ShippingServiceAdditionalCost", value);
         }
         /// <summary>
         /// (conditional, decimal) The cost for shipping the item.
         /// </summary>
         /// <param name="value">Value of the ShippingServiceCost input for this Choreo.</param>
         public void setShippingServiceCost(String value) {
             base.addInput ("ShippingServiceCost", value);
         }
         /// <summary>
         /// (conditional, string) The shipping cost model offered by the seller. Valid values are: Calculated, CalculatedDomesticFlatInternational, Flat, FlatDomesticCalculatedInternational, FreightFlat, NotSpecified.
         /// </summary>
         /// <param name="value">Value of the ShippingType input for this Choreo.</param>
         public void setShippingType(String value) {
             base.addInput ("ShippingType", value);
         }
         /// <summary>
         /// (optional, string) The name of the site on which the item is listed. This should corresponse to the SiteID. Default value is "US".
         /// </summary>
         /// <param name="value">Value of the Site input for this Choreo.</param>
         public void setSite(String value) {
             base.addInput ("Site", value);
         }
         /// <summary>
         /// (optional, string) The eBay site ID that you want to access. Defaults to 0 indicating the US site.
         /// </summary>
         /// <param name="value">Value of the SiteID input for this Choreo.</param>
         public void setSiteID(String value) {
             base.addInput ("SiteID", value);
         }
         /// <summary>
         /// (conditional, decimal) This value indicates the starting price of the item when it is listed for the first time.
         /// </summary>
         /// <param name="value">Value of the StartPrice input for this Choreo.</param>
         public void setStartPrice(String value) {
             base.addInput ("StartPrice", value);
         }
         /// <summary>
         /// (conditional, string) The title of the item as it appears in the listing or search results.
         /// </summary>
         /// <param name="value">Value of the Title input for this Choreo.</param>
         public void setTitle(String value) {
             base.addInput ("Title", value);
         }
         /// <summary>
         /// (required, string) A valid eBay Auth Token.
         /// </summary>
         /// <param name="value">Value of the UserToken input for this Choreo.</param>
         public void setUserToken(String value) {
             base.addInput ("UserToken", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AddBasicListingResultSet containing execution metadata and results.</returns>
        new public AddBasicListingResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AddBasicListingResultSet results = new JavaScriptSerializer().Deserialize<AddBasicListingResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AddBasicListing Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AddBasicListingResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from eBay.</returns>
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
