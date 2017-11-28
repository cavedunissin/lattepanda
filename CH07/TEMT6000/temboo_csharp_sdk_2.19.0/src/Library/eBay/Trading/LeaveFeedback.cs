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
    /// LeaveFeedback
    /// Enables a buyer and seller to leave feedback for their order partner at the conclusion of a successful order.
    /// </summary>
    public class LeaveFeedback : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the LeaveFeedback Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public LeaveFeedback(TembooSession session) : base(session, "/Library/eBay/Trading/LeaveFeedback")
        {
        }

         /// <summary>
         /// (optional, xml) The complete XML request body containing properties you wish to set. This can be used as an alternative to individual inputs that represent request properties.
         /// </summary>
         /// <param name="value">Value of the LeaveFeedbackRequest input for this Choreo.</param>
         public void setLeaveFeedbackRequest(String value) {
             base.addInput ("LeaveFeedbackRequest", value);
         }
         /// <summary>
         /// (conditional, string) The comment text to leave Feedback about the buyer.
         /// </summary>
         /// <param name="value">Value of the CommentText input for this Choreo.</param>
         public void setCommentText(String value) {
             base.addInput ("CommentText", value);
         }
         /// <summary>
         /// (conditional, string) The type of comment. Valid values are: Positive, Negative, and Neutral.
         /// </summary>
         /// <param name="value">Value of the CommentType input for this Choreo.</param>
         public void setCommentType(String value) {
             base.addInput ("CommentType", value);
         }
         /// <summary>
         /// (conditional, string) The unique identifier for an eBay item listing that was sold. Required unless OrderLineItemID is specified.
         /// </summary>
         /// <param name="value">Value of the ItemID input for this Choreo.</param>
         public void setItemID(String value) {
             base.addInput ("ItemID", value);
         }
         /// <summary>
         /// (optional, string) This is a unique identifier for an eBay order line item and is based upon the concatenation of ItemID and TransactionID, with a hyphen in between these two IDs.
         /// </summary>
         /// <param name="value">Value of the OrderLineItemID input for this Choreo.</param>
         public void setOrderLineItemID(String value) {
             base.addInput ("OrderLineItemID", value);
         }
         /// <summary>
         /// (conditional, integer) A detailed numeric rating (1 through 5) for an order line item. This rating is applied to the subject provided for RatingDetail.
         /// </summary>
         /// <param name="value">Value of the Rating input for this Choreo.</param>
         public void setRating(String value) {
             base.addInput ("Rating", value);
         }
         /// <summary>
         /// (conditional, string) The subject that is being rated. Valid values are: Communication, ItemAsDescribed, ShippingAndHandlingCharges, and ShippingTime.
         /// </summary>
         /// <param name="value">Value of the RatingDetail input for this Choreo.</param>
         public void setRatingDetail(String value) {
             base.addInput ("RatingDetail", value);
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
         /// (conditional, string) The user ID of the buyer who you want to leave feedback for.
         /// </summary>
         /// <param name="value">Value of the TargetUser input for this Choreo.</param>
         public void setTargetUser(String value) {
             base.addInput ("TargetUser", value);
         }
         /// <summary>
         /// (optional, string) The unique identifier for an eBay order line item (transaction). Required when there are multiple order ine items between the two order partners that require feedback.
         /// </summary>
         /// <param name="value">Value of the TransactionID input for this Choreo.</param>
         public void setTransactionID(String value) {
             base.addInput ("TransactionID", value);
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
        /// <returns>A LeaveFeedbackResultSet containing execution metadata and results.</returns>
        new public LeaveFeedbackResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            LeaveFeedbackResultSet results = new JavaScriptSerializer().Deserialize<LeaveFeedbackResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the LeaveFeedback Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class LeaveFeedbackResultSet : Temboo.Core.ResultSet
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
