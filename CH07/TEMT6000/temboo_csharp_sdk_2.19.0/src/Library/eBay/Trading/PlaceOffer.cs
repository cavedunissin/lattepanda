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
    /// PlaceOffer
    /// Allows an authenticated user to to make a bid, a best offer, or a purchase on the item specified by the ItemID input field.
    /// </summary>
    public class PlaceOffer : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the PlaceOffer Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public PlaceOffer(TembooSession session) : base(session, "/Library/eBay/Trading/PlaceOffer")
        {
        }

         /// <summary>
         /// (optional, xml) The complete XML request body containing properties you wish to set. This can be used as an alternative to individual inputs that represent request properties.
         /// </summary>
         /// <param name="value">Value of the PlaceOfferRequest input for this Choreo.</param>
         public void setPlaceOfferRequest(String value) {
             base.addInput ("PlaceOfferRequest", value);
         }
         /// <summary>
         /// (conditional, string) Indicates the type of offer being made on the specified listing. Valid values are: Bid, Purchase, Accept, Counter, Decline, or Offer.
         /// </summary>
         /// <param name="value">Value of the Action input for this Choreo.</param>
         public void setAction(String value) {
             base.addInput ("Action", value);
         }
         /// <summary>
         /// (conditional, string) The ID of a Best Offer on an item. Required if Action is set to Accept or Decline.
         /// </summary>
         /// <param name="value">Value of the BestOfferID input for this Choreo.</param>
         public void setBestOfferID(String value) {
             base.addInput ("BestOfferID", value);
         }
         /// <summary>
         /// (optional, string) The response detail level. Valid values are: ItemReturnAttributes, ItemReturnDescription, and ReturnAll.
         /// </summary>
         /// <param name="value">Value of the DetailLevel input for this Choreo.</param>
         public void setDetailLevel(String value) {
             base.addInput ("DetailLevel", value);
         }
         /// <summary>
         /// (conditional, string) The public IP address of the machine from which the request is sent.
         /// </summary>
         /// <param name="value">Value of the EndUserIP input for this Choreo.</param>
         public void setEndUserIP(String value) {
             base.addInput ("EndUserIP", value);
         }
         /// <summary>
         /// (conditional, string) The ItemID that uniquely identifies the item listing to bid on.
         /// </summary>
         /// <param name="value">Value of the ItemID input for this Choreo.</param>
         public void setItemID(String value) {
             base.addInput ("ItemID", value);
         }
         /// <summary>
         /// (conditional, decimal) The amount of the offer placed on the listing.
         /// </summary>
         /// <param name="value">Value of the MaxBid input for this Choreo.</param>
         public void setMaxBid(String value) {
             base.addInput ("MaxBid", value);
         }
         /// <summary>
         /// (conditional, string) A message from the buyer to the seller.
         /// </summary>
         /// <param name="value">Value of the Message input for this Choreo.</param>
         public void setMessage(String value) {
             base.addInput ("Message", value);
         }
         /// <summary>
         /// (conditional, integer) Specifies the number of items from the specified listing that the user intends to purchase. For auctions, this must be set to 1.
         /// </summary>
         /// <param name="value">Value of the Quantity input for this Choreo.</param>
         public void setQuantity(String value) {
             base.addInput ("Quantity", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, boolean) Indicates that the request should be made to the sandbox endpoint instead of the production endpoint. Set to 1 to enable sandbox mode.
         /// </summary>
         /// <param name="value">Value of the SandboxMode input for this Choreo.</param>
         public void setSandboxMode(String value) {
             base.addInput ("SandboxMode", value);
         }
         /// <summary>
         /// (optional, string) The eBay site ID that you want to access. Defaults to 0 indicating the US site.
         /// </summary>
         /// <param name="value">Value of the SiteID input for this Choreo.</param>
         public void setSiteID(String value) {
             base.addInput ("SiteID", value);
         }
         /// <summary>
         /// (conditional, boolean) When set to true, confirms that the bidder read and agrees to eBay's privacy policy.
         /// </summary>
         /// <param name="value">Value of the UserConsent input for this Choreo.</param>
         public void setUserConsent(String value) {
             base.addInput ("UserConsent", value);
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
        /// <returns>A PlaceOfferResultSet containing execution metadata and results.</returns>
        new public PlaceOfferResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PlaceOfferResultSet results = new JavaScriptSerializer().Deserialize<PlaceOfferResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the PlaceOffer Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PlaceOfferResultSet : Temboo.Core.ResultSet
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
