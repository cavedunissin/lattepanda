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
    /// GetMemberMessages
    /// Retrieves a list of the messages that buyers have posted about your active item listings.
    /// </summary>
    public class GetMemberMessages : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetMemberMessages Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetMemberMessages(TembooSession session) : base(session, "/Library/eBay/Trading/GetMemberMessages")
        {
        }

         /// <summary>
         /// (optional, boolean) When set to true, only public messages (viewable in the Item listing) are returned.
         /// </summary>
         /// <param name="value">Value of the DisplayToPublic input for this Choreo.</param>
         public void setDisplayToPublic(String value) {
             base.addInput ("DisplayToPublic", value);
         }
         /// <summary>
         /// (optional, date) Used to filter by date range (e.g., 2013-02-08T00:00:00.000Z).
         /// </summary>
         /// <param name="value">Value of the EndCreationTime input for this Choreo.</param>
         public void setEndCreationTime(String value) {
             base.addInput ("EndCreationTime", value);
         }
         /// <summary>
         /// (optional, integer) The maximum number of records to return in the result.
         /// </summary>
         /// <param name="value">Value of the EntriesPerPage input for this Choreo.</param>
         public void setEntriesPerPage(String value) {
             base.addInput ("EntriesPerPage", value);
         }
         /// <summary>
         /// (optional, string) The ID of the item the message is about.
         /// </summary>
         /// <param name="value">Value of the ItemID input for this Choreo.</param>
         public void setItemID(String value) {
             base.addInput ("ItemID", value);
         }
         /// <summary>
         /// (required, string) The type of message to retrieve. Valid values are: All and AskSellerQuestion. When set to AskSellerQuestion, ItemID or a date range filter must be specified.
         /// </summary>
         /// <param name="value">Value of the MailMessageType input for this Choreo.</param>
         public void setMailMessageType(String value) {
             base.addInput ("MailMessageType", value);
         }
         /// <summary>
         /// (optional, string) An ID that uniquely identifies the message for a given user to be retrieved.
         /// </summary>
         /// <param name="value">Value of the MemberMessageID input for this Choreo.</param>
         public void setMemberMessageID(String value) {
             base.addInput ("MemberMessageID", value);
         }
         /// <summary>
         /// (optional, string) The status of the message. Valid values are: Answered and Unanswered.
         /// </summary>
         /// <param name="value">Value of the MessageStatus input for this Choreo.</param>
         public void setMessageStatus(String value) {
             base.addInput ("MessageStatus", value);
         }
         /// <summary>
         /// (optional, integer) Specifies the page number of the results to return.
         /// </summary>
         /// <param name="value">Value of the PageNumber input for this Choreo.</param>
         public void setPageNumber(String value) {
             base.addInput ("PageNumber", value);
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
         /// (optional, string) The seller's UserID.
         /// </summary>
         /// <param name="value">Value of the SenderID input for this Choreo.</param>
         public void setSenderID(String value) {
             base.addInput ("SenderID", value);
         }
         /// <summary>
         /// (optional, string) The eBay site ID that you want to access. Defaults to 0 indicating the US site.
         /// </summary>
         /// <param name="value">Value of the SiteID input for this Choreo.</param>
         public void setSiteID(String value) {
             base.addInput ("SiteID", value);
         }
         /// <summary>
         /// (optional, date) Used to filter by date range (e.g., 2013-02-08T00:00:00.000Z).
         /// </summary>
         /// <param name="value">Value of the StartCreationTime input for this Choreo.</param>
         public void setStartCreationTime(String value) {
             base.addInput ("StartCreationTime", value);
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
        /// <returns>A GetMemberMessagesResultSet containing execution metadata and results.</returns>
        new public GetMemberMessagesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetMemberMessagesResultSet results = new JavaScriptSerializer().Deserialize<GetMemberMessagesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetMemberMessages Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetMemberMessagesResultSet : Temboo.Core.ResultSet
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
