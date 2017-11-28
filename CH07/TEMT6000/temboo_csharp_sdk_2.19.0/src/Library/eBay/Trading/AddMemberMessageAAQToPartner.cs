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
    /// AddMemberMessageAAQToPartner
    /// Allows a buyer and seller in an order relationship to send messages to each other's My Messages Inboxes.
    /// </summary>
    public class AddMemberMessageAAQToPartner : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AddMemberMessageAAQToPartner Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AddMemberMessageAAQToPartner(TembooSession session) : base(session, "/Library/eBay/Trading/AddMemberMessageAAQToPartner")
        {
        }

         /// <summary>
         /// (required, string) The message body.
         /// </summary>
         /// <param name="value">Value of the Body input for this Choreo.</param>
         public void setBody(String value) {
             base.addInput ("Body", value);
         }
         /// <summary>
         /// (optional, boolean) A flag used to indicate that a copy should be sent to the sender.
         /// </summary>
         /// <param name="value">Value of the EmailCopyToSender input for this Choreo.</param>
         public void setEmailCopyToSender(String value) {
             base.addInput ("EmailCopyToSender", value);
         }
         /// <summary>
         /// (required, string) The unique ID of the item about which the question was asked.
         /// </summary>
         /// <param name="value">Value of the ItemID input for this Choreo.</param>
         public void setItemID(String value) {
             base.addInput ("ItemID", value);
         }
         /// <summary>
         /// (required, string) The type of question. Valid values are: General, Shipping, Payment, MultipleItemShipping, CustomizedSubject, or None.
         /// </summary>
         /// <param name="value">Value of the QuestionType input for this Choreo.</param>
         public void setQuestionType(String value) {
             base.addInput ("QuestionType", value);
         }
         /// <summary>
         /// (required, string) The user ID of the message recipient.
         /// </summary>
         /// <param name="value">Value of the RecipientID input for this Choreo.</param>
         public void setRecipientID(String value) {
             base.addInput ("RecipientID", value);
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
         /// (required, string) The message subject.
         /// </summary>
         /// <param name="value">Value of the Subject input for this Choreo.</param>
         public void setSubject(String value) {
             base.addInput ("Subject", value);
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
        /// <returns>A AddMemberMessageAAQToPartnerResultSet containing execution metadata and results.</returns>
        new public AddMemberMessageAAQToPartnerResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AddMemberMessageAAQToPartnerResultSet results = new JavaScriptSerializer().Deserialize<AddMemberMessageAAQToPartnerResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AddMemberMessageAAQToPartner Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AddMemberMessageAAQToPartnerResultSet : Temboo.Core.ResultSet
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
